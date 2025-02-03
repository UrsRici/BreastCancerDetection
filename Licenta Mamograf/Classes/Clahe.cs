using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf
{
    public static class CLHE
    {
        private static double[] calculateHistogram(MyBitmap bitplane)
        {
            double[] histogram = new double[256];
            int x, y;
            for (y = 0; y < bitplane.Height; y++)
                for (x = 0; x < bitplane.Width; x++)
                    histogram[bitplane.GetPixel(x, y)]++;

            return histogram;
        }

        private static double[] calculateComulativeFrequency(double[] array)
        {
            int size = array.Length;
            double[] comulativeFreq = new double[size];
            comulativeFreq[0] = array[0];
            for (int i = 1; i < size; i++)
                comulativeFreq[i] = comulativeFreq[i - 1] + array[i];
            return comulativeFreq;
        }

        private static double findMin(double[] array)
        {
            double min = double.MaxValue;
            foreach (double value in array)
                if (value < min)
                    min = value;
            return min;
        }

        public static void Apply(ref MyBitmap bitplane, double contrastLimit)
        {
            double cl = (contrastLimit * (bitplane.Width * bitplane.Height)) / 256;
            double top = cl;
            double bottom = 0;
            double SUM = 0;
            int i;

            double[] histogram = calculateHistogram(bitplane);


            while (top - bottom > 1)
            {
                double middle = (top + bottom) / 2;
                SUM = 0;
                foreach (double value in histogram)
                    if (value > middle)
                        SUM += value - middle;
                if (SUM > (cl - middle) * 256)
                    top = middle;
                else
                    bottom = middle;
            }

            double clipLevel = Math.Round(bottom + (SUM / 256));

            double L = cl - clipLevel;
            for (i = 0; i < 256; i++)
                if (histogram[i] >= clipLevel)
                    histogram[i] = clipLevel;
                else
                    histogram[i] += L;

            double perBin = SUM / 256;

            for (i = 0; i < 256; i++)
                histogram[i] += perBin;

            histogram = calculateComulativeFrequency(histogram);
            int[] finalFreq = new int[256];
            double min = findMin(histogram);
            for (i = 0; i < 256; i++)
                finalFreq[i] = (int)((histogram[i] - min) / ((bitplane.Width * bitplane.Height) - 2) * 255);

            int x;
            for (int y = 0; y < bitplane.Height; y++)
                for (x = 0; x < bitplane.Width; x++)
                    bitplane.SetPixel(x, y, (byte)finalFreq[bitplane.GetPixel(x, y)]);
        }
    }
}
