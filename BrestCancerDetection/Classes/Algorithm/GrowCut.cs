using System.Collections.Generic;

namespace BrestCancerDetection.Classes
{
    /// <summary>
    /// Clasa care implementează algoritmul GrowCut pentru segmentarea imaginii.
    /// </summary>
    public static class GrowCut
    {
        // Matricea pentru punctele de decizie (conturul fiecărei regiuni)
        private static float[,] points;
        // Matricea pentru forțele de influență a vecinilor
        private static float[,] strength;
        private static int height, width;
        // Pragul pentru a decide dacă un punct aparține unei regiuni
        private static float threshold = 0.75f;

        /// <summary>
        /// Aplică algoritmul GrowCut pe o matrice de date (imagine).
        /// </summary>
        /// <param name="matrix">Matricea de date care reprezintă imaginea.</param>
        /// <returns>O mască binară cu valorile segmentate.</returns>
        public static float[,] ApplyData(float[,] matrix)
        {
            // Creăm o mască de dimensiuni corespunzătoare
            float[,] mask = new float[matrix.GetLength(0), matrix.GetLength(1)];

            // Obținem datele necesare pentru procesare (ROI-uri)
            var datas = ImageData.GetDatas();

            if (datas != null)
            {
                // Procesăm fiecare regiune de interes (ROI)
                foreach (var data in datas)
                {
                    // Creăm o matrice temporară pentru ROI
                    float[,] ROI = new float[2 * data.Radius + 1, 2 * data.Radius + 1];

                    // Extragem regiunea de interes (ROI) din matricea inițială
                    for (int y = 0; y < ROI.GetLength(0); y++)
                    {
                        for (int x = 0; x < ROI.GetLength(1); x++)
                        {
                            ROI[y, x] = matrix[y + data.Y - data.Radius, x + data.X - data.Radius];
                        }
                    }
                    // Aplicăm algoritmul GrowCut pe ROI
                    ROI = Apply(ROI);

                    // Actualizăm masca cu rezultatele procesării ROI
                    for (int y = 0; y < ROI.GetLength(0); y++)
                    {
                        for (int x = 0; x < ROI.GetLength(1); x++)
                        {
                            mask[y + data.Y - data.Radius, x + data.X - data.Radius] = ROI[y, x];
                        }
                    }
                }
            }
            return mask;
        }

        /// <summary>
        /// Aplică algoritmul GrowCut pe un ROI dat.
        /// </summary>
        /// <param name="ROI">Regiunea de interes pe care se aplică algoritmul.</param>
        /// <returns>O matrice de valori segmentate (0 sau 255).</returns>
        public static float[,] Apply(float[,] ROI)
        {
            // Inițializăm datele necesare (dimensiuni, puncte, forțe)
            Initialization(ROI);

            bool found = true;
            // Algoritmul continuă până când nu mai există modificări
            while (found)
            {
                found = false;
                // Parcurgem fiecare pixel al imaginii pentru a actualiza punctele și forțele
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Obținem vecinii pixelului curent
                        List<pixel> neighbors = getNeighbors(y, x);
                        foreach (pixel n in neighbors)
                        {
                            // Calculăm forța de influență dintre pixelii curenți și vecinii lor
                            float s = f(points[y, x], points[n.y, n.x]) * strength[n.y, n.x];
                            if (s > strength[y, x])
                            {
                                // Dacă forța este mai mare decât valoarea curentă, actualizăm forța
                                strength[y, x] = s;
                                found = true; // Continuăm căutarea
                            }
                        }
                    }
                }
            }

            // După terminarea algoritmului, actualizăm punctele pe baza forței
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (strength[y, x] > threshold)
                    {
                        points[y, x] = 255; // Atribuim valoarea maximă dacă forța depășește pragul
                    }
                    else
                    {
                        points[y, x] = 0; // Altfel, atribuim valoarea minimă
                    }
                }
            }
            return points;
        }

        /// <summary>
        /// Inițializează variabilele necesare pentru procesarea imaginii (dimensiuni, puncte, forțe).
        /// </summary>
        /// <param name="ROI">Regiunea de interes pentru care se face procesarea.</param>
        private static void Initialization(float[,] ROI)
        {
            height = ROI.GetLength(0);
            width = ROI.GetLength(1);
            points = new float[height, width];
            strength = new float[height, width];

            int X = 0, Y = 0;
            // Căutăm pixelul cu valoarea maximă pentru a începe procesul de segmentare
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    strength[y, x] = 0;
                    points[y, x] = ROI[y, x];
                    if (ROI[y, x] > ROI[Y, X])
                    {
                        X = x;
                        Y = y;
                    }
                }
            }
            // Setăm forța maximă pentru pixelul cu valoarea cea mai mare
            strength[Y, X] = 1;
        }

        /// <summary>
        /// Obține vecinii unui pixel dat într-o fereastră de 3x3.
        /// </summary>
        /// <param name="Y">Coordonata Y a pixelului curent.</param>
        /// <param name="X">Coordonata X a pixelului curent.</param>
        /// <returns>Lista vecinilor pixelului curent.</returns>
        private static List<pixel> getNeighbors(int Y, int X)
        {
            List<pixel> N = new List<pixel>();
            // Parcurgem vecinii din jurul pixelului (fereastră 3x3)
            for (int y = Y - 1; y < Y + 2; y++)
            {
                for (int x = X - 1; x < X + 2; x++)
                {
                    if ((x != X || y != Y) && (-1 < x && x < width && -1 < y && y < height))
                    {
                        N.Add(new pixel(y, x, points[y, x])); // Adăugăm vecinul în listă
                    }
                }
            }
            return N;
        }

        /// <summary>
        /// Funcția care calculează forța de influență între două valori.
        /// </summary>
        /// <param name="i1">Prima valoare (intensitatea pixelului curent).</param>
        /// <param name="i2">A doua valoare (intensitatea vecinului).</param>
        /// <returns>Forța de influență calculată între cele două valori.</returns>
        private static float f(float i1, float i2)
        {
            // Calculăm forța de influență în funcție de diferența dintre intensități
            if (i1 > i2)
                return i1 == 0 ? 0 : (1 - (i1 - i2) / i1);
            else
                return i2 == 0 ? 0 : (1 - (i2 - i1) / i2);
        }
    }
}
