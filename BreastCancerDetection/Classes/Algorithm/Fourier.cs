using System;
using System.Drawing;

namespace BreastCancerDetection.Classes
{
    public static class FourierProcessor
    {
        public static Bitmap GetFourierSpectrum(Bitmap input)
        {
            int width = input.Width;
            int height = input.Height;

            // Convertim la grayscale
            double[,] gray = ToGrayscaleArray(input);

            // Convertim în matrice de numere complexe
            ComplexNumber[,] data = new ComplexNumber[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    data[i, j] = new ComplexNumber(gray[i, j], 0);

            // FFT pe linii
            for (int i = 0; i < height; i++)
            {
                ComplexNumber[] row = new ComplexNumber[width];
                for (int j = 0; j < width; j++)
                    row[j] = data[i, j];

                FFT(row);

                for (int j = 0; j < width; j++)
                    data[i, j] = row[j];
            }

            // FFT pe coloane
            for (int j = 0; j < width; j++)
            {
                ComplexNumber[] col = new ComplexNumber[height];
                for (int i = 0; i < height; i++)
                    col[i] = data[i, j];

                FFT(col);

                for (int i = 0; i < height; i++)
                    data[i, j] = col[i];
            }

            // Magnitudine logaritmică
            double[,] magnitude = new double[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    magnitude[i, j] = Math.Log(1 + data[i, j].Magnitude());

            // Shift quadrants
            magnitude = ShiftQuadrants(magnitude);

            // Normalizare și bitmap
            return NormalizeToBitmap(magnitude);
        }

        // ---------------- FFT 1D ----------------

        private static void FFT(ComplexNumber[] buffer)
        {
            int n = buffer.Length;
            int bits = (int)Math.Log(n, 2);

            // Bit-reversal
            for (int i = 0; i < n; i++)
            {
                int j = ReverseBits(i, bits);
                if (j > i)
                {
                    var temp = buffer[i];
                    buffer[i] = buffer[j];
                    buffer[j] = temp;
                }
            }

            // Cooley–Tukey
            for (int len = 2; len <= n; len <<= 1)
            {
                double angle = -2 * Math.PI / len;
                ComplexNumber wlen = new ComplexNumber(Math.Cos(angle), Math.Sin(angle));

                for (int i = 0; i < n; i += len)
                {
                    ComplexNumber w = new ComplexNumber(1, 0);

                    for (int j = 0; j < len / 2; j++)
                    {
                        ComplexNumber u = buffer[i + j];
                        ComplexNumber v = buffer[i + j + len / 2] * w;

                        buffer[i + j] = u + v;
                        buffer[i + j + len / 2] = u - v;

                        w *= wlen;
                    }
                }
            }
        }

        private static int ReverseBits(int x, int bits)
        {
            int y = 0;
            for (int i = 0; i < bits; i++)
            {
                y = (y << 1) | (x & 1);
                x >>= 1;
            }
            return y;
        }

        // ---------------- Helpers ----------------

        private static double[,] ToGrayscaleArray(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;
            double[,] data = new double[h, w];

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    data[y, x] = (c.R + c.G + c.B) / 3.0;
                }

            return data;
        }

        private static double[,] ShiftQuadrants(double[,] data)
        {
            int h = data.GetLength(0);
            int w = data.GetLength(1);

            double[,] shifted = new double[h, w];

            int halfH = h / 2;
            int halfW = w / 2;

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    int newI = (i + halfH) % h;
                    int newJ = (j + halfW) % w;
                    shifted[newI, newJ] = data[i, j];
                }

            return shifted;
        }

        private static Bitmap NormalizeToBitmap(double[,] data)
        {
            int h = data.GetLength(0);
            int w = data.GetLength(1);

            double min = double.MaxValue;
            double max = double.MinValue;

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    if (data[i, j] < min) min = data[i, j];
                    if (data[i, j] > max) max = data[i, j];
                }

            Bitmap bmp = new Bitmap(w, h);

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    int val = (int)(255 * (data[i, j] - min) / (max - min));
                    bmp.SetPixel(j, i, Color.FromArgb(val, val, val));
                }

            return bmp;
        }

        // ---------------- Complex number struct ----------------

        private struct ComplexNumber
        {
            public double Real;
            public double Imag;

            public ComplexNumber(double r, double i)
            {
                Real = r;
                Imag = i;
            }

            public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
                => new ComplexNumber(a.Real + b.Real, a.Imag + b.Imag);

            public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
                => new ComplexNumber(a.Real - b.Real, a.Imag - b.Imag);

            public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
                => new ComplexNumber(
                    a.Real * b.Real - a.Imag * b.Imag,
                    a.Real * b.Imag + a.Imag * b.Real
                );

            public double Magnitude()
                => Math.Sqrt(Real * Real + Imag * Imag);
        }
    }
}
