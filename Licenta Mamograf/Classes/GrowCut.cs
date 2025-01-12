using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf.Classes
{
    public static class GrowCut
    {   
        private class pixel
        {
            public int x { get; set; }
            public int y { get; set; }
            public float i { get; set; }
            public pixel(int x, int y, float i)
            {
                this.i = i;
                this.x = x;
                this.y = y;
            }
            public override string ToString()
            {
                return $"Pixel: ({x}, {y}), Intensity: {i}";
            }

        }

        private class imageData
        {
            // 1st column: MIAS database reference number
            public string ID { get; set; }

            // 2nd column: Character of background tissue (F, G, D)
            public string TissueType { get; set; }

            // 3rd column: Class of abnormality present (CALC, CIRC, SPIC, etc.)
            public string AbnormalityClass { get; set; }

            // 4th column: Severity of abnormality (B, M)
            public string Severity { get; set; }

            // 5th and 6th columns: x, y image-coordinates
            public int X { get; set; } 
            public int Y { get; set; }

            // 7th column: Approximate radius in pixels
            public int Radius { get; set; }

            public imageData(string iD, string tissueType, string abnormalityClass, string severity, int x, int y, int radius)
            { 
                this.ID = iD;
                this.TissueType = tissueType;
                this.AbnormalityClass = abnormalityClass;
                this.Severity = severity;
                this.X = x;
                this.Y = y;
                this.Radius = radius;
            }
            public imageData(string iD, string tissueType, string abnormalityClass)
            {
                this.ID = iD;
                this.TissueType = tissueType;
                this.AbnormalityClass = abnormalityClass;
                this.Severity = string.Empty;
                this.X = 0;
                this.Y = 0;
                this.Radius = 0;
            }
            public override string ToString()
            {
                return $"{ID} {TissueType} {AbnormalityClass} {Severity} {X} {Y} {Radius}";
            }
        }

        private static float[,] points;
        private static float[,] strength;
        private static int height, width;
        private static float threshold = 0.75f;
        private static List<imageData> Data = new List<imageData>();

        public static void Load()
        {
            string filePath = @"D:\Aplicatii\Facultate\Informatica\Licenta\Licenta Mamograf\Licenta Mamograf\Images\data.txt";
            StreamReader sr = new StreamReader(filePath);
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] row = buffer.Split(' ');
                if (row.Length > 4)
                {
                    Data.Add(new imageData(row[0], row[1], row[2], row[3], int.Parse(row[4]), 1024 - int.Parse(row[5]), int.Parse(row[6])));
                }
                else
                {
                    Data.Add(new imageData(row[0], row[1], row[2]));
                }
            }
        }

        public static float[,] ApplyData(float[,] matrix, string fileName)
        {
            float[,] mask = new float[matrix.GetLength(0), matrix.GetLength(1)];

            var datas = Data.Where(item => item.ID == fileName);

            if (datas != null)
            {
                foreach (var data in datas)
                {
                    float[,] ROI = new float[2 * data.Radius + 1, 2 * data.Radius + 1];

                    for (int y = 0; y < ROI.GetLength(0); y++)
                    {
                        for (int x = 0; x < ROI.GetLength(1); x++)
                        {
                            ROI[x, y] = matrix[x + data.X - data.Radius, y + data.Y - data.Radius];
                        }
                    }
                    ROI = Apply(ROI);

                    for (int y = 0; y < ROI.GetLength(0); y++)
                    {
                        for (int x = 0; x < ROI.GetLength(1); x++)
                        {
                            mask[x + data.X - data.Radius, y + data.Y - data.Radius] = ROI[x, y];
                        }
                    }
                }
            }
            return mask;
        }

        public static float[,] Apply(float[,] ROI)
        {
            Initialization(ROI);

            bool found = true;
            while (found)
            {
                found = false;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        List<pixel> neighbors = getNeighbors(x, y);
                        foreach (pixel n in neighbors) 
                        {
                            float s = f(points[y, x], points[n.y, n.x]) * strength[n.y, n.x];
                            if (s > strength[y, x])
                            {
                                strength[y, x] = s;
                                found = true;
                            }
                        }
                    }
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (strength[y, x] > threshold)
                    {
                        points[y, x] = 255;
                    }
                    else
                    {
                        points[y, x] = 0;
                    }
                }
            }
          return points;
        }

        private static void Initialization(float[,] ROI)
        {
            height = ROI.GetLength(0);
            width = ROI.GetLength(1);
            points = new float[height, width];
            strength = new float[height, width];

            int X = 0, Y = 0;
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
            strength[Y, X] = 1;
        }

        private static List<pixel> getNeighbors(int X, int Y)
        {
            List<pixel> N = new List<pixel>();
            for (int y = Y - 1; y < Y + 2; y++)
            {
                for (int x = X - 1; x < X + 2; x++)
                {
                    if ((x != X || y != Y) && (-1 < x && x < width && -1 < y && y < height))
                    {
                        N.Add(new pixel(x, y, points[y, x]));
                    }
                }
            }
            return N;
        }

        private static float f(float i1, float i2)
        {
            if(i1 > i2)
                return i1 == 0 ? 0 : (1 - (i1 - i2) / i1);
            else
                return i2 == 0 ? 0 : (1 - (i2 - i1) / i2);
        }
    }
}
