using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tensorflow.TensorShapeProto.Types;

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
        public static float[,] ApplyData(float[,] matrix, float th, bool check)
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
                    // Definim punctele care delimitează ROI-ul
                    Point p0 = new Point(Math.Max(0, data.X - data.Radius), Math.Max(0, data.Y - data.Radius));
                    Point p1 = new Point(Math.Min(matrix.GetLength(1) - 1, data.X + data.Radius), Math.Min(matrix.GetLength(0) - 1, data.Y + data.Radius));
                    mask = MargeMask(Apply(matrix, th, p0, p1, check), mask);
                }
            }
            return mask;
        }
        private static float[,] MargeMask(float[,] newMask, float[,]oldMask)
        {
            if (oldMask == null) return newMask;
            int height = Math.Min(oldMask.GetLength(0), newMask.GetLength(0));
            int width = Math.Min(oldMask.GetLength(1), newMask.GetLength(1));
            float[,] mask = new float[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (oldMask[y, x] == 255 || newMask[y, x] == 255)
                        mask[y, x] = 255;
                    else
                        mask[y, x] = 0;
                }
            }
            return mask;
        }
        /// <summary>
        /// Aplică algoritmul GrowCut pe un ROI dat.
        /// </summary>
        public static float[,] Apply(float[,] matrix, float th, Point p0, Point p1, bool check)
        {
            // Extragem regiunea de interes (ROI) din imagine
            float[,] ROI = new float[p1.Y - p0.Y, p1.X - p0.X];
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++)
                {
                    ROI[y - p0.Y, x - p0.X] = matrix[y, x]; // Aplicăm culoarea din ROI pe mască
                }
            }

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
            if (check)
            {
                bool[] verif = GetVerify(points);
                while (verif[0] || verif[1] || verif[2] || verif[3])
                {
                    (p0, p1) = ChangeRoiPoints(matrix, p0, p1, 10, verif);
                    //ImagePopup.Show(points, "points");
                    points = Apply(matrix, th, p0, p1, check);
                    verif = GetVerify(points);
                }
            }
            if (points.Length != matrix.Length) GetFullMask(matrix, p0, p1);
            return points;
        }
        private static bool[] GetVerify(float[,] points)
        {
            int height = points.GetLength(0);
            int width = points.GetLength(1);
            bool N = false, S = false, E = false, W = false;

            for (int i = 0; i < height; i++)
            {
                if (points[i, 0] != 0) W = true;          // corect — stânga → Vest
                if (points[i, width - 1] != 0) E = true;  // corect — dreapta → Est
            }
            for (int i = 0; i < width; i++)
            {
                if (points[0, i] != 0) N = true;          // corect — sus → Nord
                if (points[height - 1, i] != 0) S = true; // corect — jos → Sud
            }
            return new bool[] { N, S, E, W };
        }
        public static (Point, Point) ChangeRoiPoints(float[,] matrix, Point p0, Point p1, int margin, bool[] verif)
        {
            int minX = Math.Min(p0.X, p1.X);
            int minY = Math.Min(p0.Y, p1.Y);
            int maxX = Math.Max(p0.X, p1.X);
            int maxY = Math.Max(p0.Y, p1.Y);

            // Adăugăm marginea (dar limităm în interiorul imaginii)
            if (verif[3]) minX = Math.Max(0, minX - margin);   // W
            if (verif[0]) minY = Math.Max(0, minY - margin);   // N
            if (verif[2]) maxX = Math.Min(matrix.GetLength(1) - 1, maxX + margin); // E
            if (verif[1]) maxY = Math.Min(matrix.GetLength(0) - 1, maxY + margin); // S

            Point topLeft = new Point(minX, minY);
            Point bottomRight = new Point(maxX, maxY);

            return (topLeft, bottomRight);
        }
        private static void GetFullMask(float[,] matrix, Point p0, Point p1)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            matrix = new float[height, width];
            //ImagePopup.Show(matrix, "m");
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++)
                {
                   matrix[y, x] = points[y - p0.Y, x - p0.X];
                }
            }
            points = matrix;
        }
        /// <summary>
        /// Umple sau sterge pixeli în interiorul conturului, bazându-se pe vecinii lor.
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
                    /*if (ROI[y, x] > ROI[Y, X])
                    {
                        X = x;
                        Y = y;
                    }*/
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