using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf
{
    public class HaarWavelet
    {
        private double[,] matrix;
        private double[,] coefficients;
        private double threshold;
        private double[,] denoisedMatrix;
        private Bitmap denoisedBitmap;
        private Bitmap image;

        public HaarWavelet(Bitmap bitmap) { image = bitmap; }   

        private void Transform()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            coefficients = new double[rows, cols];

            // Transformata Haar pe rânduri
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    coefficients[i, j] = (matrix[i, 2 * j] + matrix[i, 2 * j + 1]) / Math.Sqrt(2);
                    coefficients[i, j + cols / 2] = (matrix[i, 2 * j] - matrix[i, 2 * j + 1]) / Math.Sqrt(2);
                }
            }
        }

        private void InverseTransform()
        {
            int rows = coefficients.GetLength(0);
            int cols = coefficients.GetLength(1);
            denoisedMatrix = new double[rows, cols];

            // Transformata Haar inversă pe rânduri
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    denoisedMatrix[i, 2 * j] = (coefficients[i, j] + coefficients[i, j + cols / 2]) / Math.Sqrt(2);
                    denoisedMatrix[i, 2 * j + 1] = (coefficients[i, j] - coefficients[i, j + cols / 2]) / Math.Sqrt(2);
                }
            }
        }

        private void CalculateThreshold()
        {
            // Implementare simplă pentru calcularea pragului
            double mean = coefficients.Cast<double>().Average();
            double stdDev = Math.Sqrt(coefficients.Cast<double>().Select(val => Math.Pow(val - mean, 2)).Average());
            threshold = mean + 0.5f * stdDev; // Prag adaptiv simplificat
        }

        private void ApplyThreshold()
        {
            int rows = coefficients.GetLength(0);
            int cols = coefficients.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Elimină coeficientii cu intensitate prea mare
                    if (Math.Abs(coefficients[i, j]) < threshold /*|| Math.Abs(coefficients[i, j]) > 255*/) // Prag maxim
                    {
                        coefficients[i, j] = 0; // Setează coeficientul la 0
                    }
                }
            }
        }

        private void ConvertMatrixToBitmap()
        {
            int height = denoisedMatrix.GetLength(0);
            int width = denoisedMatrix.GetLength(1);
            denoisedBitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Normalizează valoarea pentru a fi între 0 și 255
                    int grayValue; // Asigură-te că valoarea este în limite
                    if (denoisedMatrix[y, x] >= 0 && denoisedMatrix[y, x] <= 255)
                        grayValue = (int)denoisedMatrix[y, x];
                    else
                        if (denoisedMatrix[y, x] < 0)
                        grayValue = 0;
                    else
                        grayValue = 255;
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    denoisedBitmap.SetPixel(x, y, grayColor);
                }
            }
        }

        private void ConvertBitmapToMatrix()
        {
            int width = image.Width;
            int height = image.Height;
            matrix = new double[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Obține valoarea de gri a pixelului
                    Color pixelColor = image.GetPixel(x, y);
                    double grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0; // Poți folosi o formulă mai complexă pentru luminanță
                    matrix[y, x] = grayValue;
                }
            };
        }

        public (Bitmap, double[,]) Denoising()
        {
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

            return (denoisedBitmap, denoisedMatrix);
        }
    }
}
