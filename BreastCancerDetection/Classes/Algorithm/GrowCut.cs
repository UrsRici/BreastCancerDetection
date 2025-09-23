using System.Collections.Generic;
using System.Security;

namespace BreastCancerDetection.Classes
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
        public static float[,] ApplyData(float[,] matrix, float th)
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
                    ROI = Apply(ROI, th);

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
        public static float[,] Apply(float[,] ROI, float th)
        {
            // Inițializăm datele necesare (dimensiuni, puncte, forțe)
            Initialization(ROI, th);

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
            FillContur();

            return points;
        }

        /// <summary>
        /// Umple si sterge pixeli în interiorul conturului, bazându-se pe vecinii lor.
        /// </summary>
        private static void FillContur()
        {
            bool found = true;
            while (found)
            {
                found = false;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (points[y, x] == 255) continue; // Sărim peste pixelii deja marcați
                        List<pixel> neighbors = getNeighbors(y, x);
                            int aux = 0;
                        foreach (pixel n in neighbors)
                        {
                            if (points[n.y, n.x] == 255)
                            {
                                aux++;
                            }
                        }

                        if (aux > 4)
                        {
                            points[y, x] = 255;
                            found = true;
                        }
                    }
                }
            }
            found = true;
            while (found)
            {
                found = false;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (points[y, x] == 0) continue; // Sărim peste pixelii deja marcați
                        List<pixel> neighbors = getNeighbors(y, x);
                        int aux = 0;
                        foreach (pixel n in neighbors)
                        {
                            if (points[n.y, n.x] == 0)
                            {
                                aux++;
                            }
                        }
                        if (aux > 5)
                        {
                            points[y, x] = 0;
                            found = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inițializează variabilele necesare pentru procesarea imaginii (dimensiuni, puncte, forțe).
        /// </summary>
        private static void Initialization(float[,] ROI, float th)
        {
            height = ROI.GetLength(0);
            width = ROI.GetLength(1);
            points = new float[height, width];
            strength = new float[height, width];

            threshold = th;

            int X = width / 2, Y = height / 2;
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
            strength[height / 2, width / 2] = 1; // strength[Y, X] = 1
        }

        /// <summary>
        /// Obține vecinii unui pixel dat într-o fereastră de 3x3.
        /// </summary>
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