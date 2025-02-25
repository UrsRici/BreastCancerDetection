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
        private static float[,] points;
        private static float[,] strength;
        private static int height, width;
        private static float threshold = 0.75f;

        public static float[,] ApplyData(float[,] matrix)
        {
            float[,] mask = new float[matrix.GetLength(0), matrix.GetLength(1)];

            var datas = ImageData.GetDatas();

            if (datas != null)
            {
                foreach (var data in datas)
                {
                    float[,] ROI = new float[2 * data.Radius + 1, 2 * data.Radius + 1];

                    for (int y = 0; y < ROI.GetLength(0); y++)
                    {
                        for (int x = 0; x < ROI.GetLength(1); x++)
                        {
                            ROI[y, x] = matrix[y + data.Y - data.Radius, x + data.X - data.Radius];
                        }
                    }
                    ROI = Apply(ROI);

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
                        List<pixel> neighbors = getNeighbors(y, x);
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

        private static List<pixel> getNeighbors(int Y, int X)
        {
            List<pixel> N = new List<pixel>();
            for (int y = Y - 1; y < Y + 2; y++)
            {
                for (int x = X - 1; x < X + 2; x++)
                {
                    if ((x != X || y != Y) && (-1 < x && x < width && -1 < y && y < height))
                    {
                        N.Add(new pixel(y, x, points[y, x]));
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
