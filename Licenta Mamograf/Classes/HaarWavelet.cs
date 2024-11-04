using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf
{
    public static class HaarWavelet
    {
        private static double[,] matrix;
        private static double[,] coefficients;
        private static double threshold;
        private static double[,] denoisedMatrix;
        private static MyBitmap denoisedBitmap;
        private static MyBitmap image;


        private static double[,] Transform(double[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            // Presupunem că dimensiunile sunt multipli de 2
            double[,] coefficients = new double[height, width];

            // Parcurgem matricea pe blocuri de 2x2
            for (int i = 0; i < height; i += 2)
            {
                for (int j = 0; j < width; j += 2)
                {
                    // Extragem valorile din blocul 2x2
                    double a = matrix[i, j];
                    double b = matrix[i, j + 1];
                    double c = matrix[i + 1, j];
                    double d = matrix[i + 1, j + 1];

                    // Calculăm coeficienții Haar pentru cele patru sub-bande
                    double LL = (a + b + c + d) / 2.0;
                    double LH = (a - b + c - d) / 2.0;
                    double HL = (a + b - c - d) / 2.0;
                    double HH = (a - b - c + d) / 2.0;

                    // Salvăm rezultatele în matricea de coeficienți
                    coefficients[i / 2, j / 2] = LL;                 // LL în colțul stânga-sus
                    coefficients[i / 2, j / 2 + width / 2] = LH;     // LH în colțul dreapta-sus
                    coefficients[i / 2 + height / 2, j / 2] = HL;    // HL în colțul stânga-jos
                    coefficients[i / 2 + height / 2, j / 2 + width / 2] = HH; // HH în colțul dreapta-jos
                }
            }

            return coefficients;
        }


        private static void Transform()
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            coefficients = new double[height, width];

            // Transformata Haar pe rânduri
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width / 2; j++)
                {
                    coefficients[i, j] = (matrix[i, 2 * j] + matrix[i, 2 * j + 1]) / Math.Sqrt(2);
                    coefficients[i, j + width / 2] = (matrix[i, 2 * j] - matrix[i, 2 * j + 1]) / Math.Sqrt(2);
                }
            }
        }

        private static void InverseTransform()
        {
            int height = coefficients.GetLength(0);
            int width = coefficients.GetLength(1);
            denoisedMatrix = new double[height, width];

            // Transformata Haar inversă pe rânduri
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width / 2; j++)
                {
                    denoisedMatrix[i, 2 * j] = (coefficients[i, j] + coefficients[i, j + width / 2]) / Math.Sqrt(2);
                    denoisedMatrix[i, 2 * j + 1] = (coefficients[i, j] - coefficients[i, j + width / 2]) / Math.Sqrt(2);
                }
            }
        }

        private static void CalculateThreshold()
        {
            // Implementare simplă pentru calcularea pragului
            double mean = coefficients.Cast<double>().Average();
            double stdDev = Math.Sqrt(coefficients.Cast<double>().Select(val => Math.Pow(val - mean, 2)).Average());
            threshold = mean + 0.5f * stdDev; // Prag adaptiv simplificat
        }

        private static void ApplyThreshold()
        {
            int height = coefficients.GetLength(0);
            int width = coefficients.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    // Elimină coeficientii cu intensitate prea mare
                    if (coefficients[i, j] < threshold || coefficients[i, j] > 255) // Prag maxim
                    {
                        coefficients[i, j] = 0; // Setează coeficientul la 0
                    }
                }
            }
        }

        private static void ConvertMatrixToBitmap()
        {
            int height = denoisedMatrix.GetLength(0);
            int width = denoisedMatrix.GetLength(1);
            denoisedBitmap = new MyBitmap(height, width);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Normalizează valoarea pentru a fi între 0 și 255
                    int grayValue = 0; // Asigură-te că valoarea este în limite

                    if (denoisedMatrix[y, x] > 0 && denoisedMatrix[y, x] < 255)
                        grayValue = (int)matrix[y, x];
                    else if (denoisedMatrix[y, x] <= 0)
                        grayValue = 0;
                    else
                        grayValue = 255;

                    denoisedBitmap.SetPixel(y, x, (byte)grayValue);
                }
            }
        }

        private static void ConvertBitmapToMatrix()
        {
            int width = image.Width;
            int height = image.Height;
            matrix = new double[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obține valoarea de gri a pixelului
                    matrix[y, x] = image.GetPixel(y, x);
                }
            }
            /*
             * Eliminarea primei si ultimei lini
             * 
            int right = 0, left = 0;
            for (int i = 0; i < width; i++)
            {
                if (matrix[i, 0] > 0)
                {
                    left = i;
                    break;
                }
            }
            for (int i = width - 1; i >= 0; i--)
            {
                if (matrix[i, 0] > 0)
                {
                    right = i;
                    break;
                }
            }
            for (int i = 0; i < height; i++)
            {
                matrix[left, i] = 0;
                matrix[right, i] = 0;
            }*/
        }

        public static MyBitmap Denoising(PGM pGM)
        {
            image = pGM.bitmap;
            // Convert the image into a matrix...
            ConvertBitmapToMatrix();

            // Transform the matrix into Haar coefficients...
            Transform();

            // Calculate the threshold...
            CalculateThreshold();

            // Apply the threshold to the Haar coefficients...
            ApplyThreshold();

            // Transform the thresholded Haar matrix into a denoised matrix...
            InverseTransform();

            // Convert the denoised matrix into a denoised image...
            ConvertMatrixToBitmap();

            return denoisedBitmap;
        }

    }
}
