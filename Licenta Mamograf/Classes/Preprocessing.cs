using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf
{
    public static class Preprocessing
    {
        private static float[,] matrix;
        private static float[,] coefficients;
        private static float threshold;
        private static float[,] denoisedMatrix;
        private static MyBitmap cleanImage;

        private static void Transform()
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            coefficients = new float[height, width];

            // Transformata Haar pe rânduri
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width / 2; j++)
                {
                    coefficients[i, j] = (matrix[i, 2 * j] + matrix[i, 2 * j + 1]) / (float)Math.Sqrt(2);
                    coefficients[i, j + width / 2] = (matrix[i, 2 * j] - matrix[i, 2 * j + 1]) / (float)Math.Sqrt(2);
                }
            }
        }
        private static void InverseTransform()
        {
            int height = coefficients.GetLength(0);
            int width = coefficients.GetLength(1);
            denoisedMatrix = new float[height, width];

            // Transformata Haar inversă pe rânduri
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width / 2; j++)
                {
                    denoisedMatrix[i, 2 * j] = (coefficients[i, j] + coefficients[i, j + width / 2]) / (float)Math.Sqrt(2);
                    denoisedMatrix[i, 2 * j + 1] = (coefficients[i, j] - coefficients[i, j + width / 2]) / (float)Math.Sqrt(2);
                }
            }
        }
        private static void CalculateThreshold()
        {
            // Implementare simplă pentru calcularea pragului
            float mean = coefficients.Cast<float>().Average();
            float stdDev = (float)Math.Sqrt(coefficients.Cast<float>().Select(val => (float)Math.Pow(val - mean, 2)).Average());
            threshold = mean + .5f * stdDev; // Prag adaptiv simplificat
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
                    if (coefficients[i, j] < threshold /*|| coefficients[i, j] > 255*/) // Prag maxim
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
            cleanImage = new MyBitmap(height, width);

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

                    cleanImage.SetPixel(y, x, (byte)grayValue);
                }
            }
        }
        private static void HaarWavelet()
        {
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
        }

        private static void RemoveHeightNoise(PGM pgm)
        {
            MyBitmap image = pgm.bitmap;
            int width = image.Width;
            int height = image.Height;
            cleanImage = new MyBitmap(width, height);

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    byte currentPixel = image.GetPixel(y, x);
                    int avgIntensity = 0;
                    int count = 0;

                    // Calculăm media pixelilor vecini
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            if (dx == 0 && dy == 0) continue; // Evităm pixelul central
                            byte neighborPixel = image.GetPixel(y + dy, x + dx);
                            avgIntensity += neighborPixel;
                            count++;
                        }
                    }

                    avgIntensity /= count;

                    // Dacă intensitatea pixelului curent diferă mult de media vecinilor, îl înlocuim cu media
                    if (Math.Abs(currentPixel - avgIntensity) > 10) // Pragul poate fi ajustat
                        cleanImage.SetPixel(y, x, (byte)avgIntensity);
                    else
                        cleanImage.SetPixel(y, x, currentPixel); // Lasă pixelul neschimbat
                }
            }
            pgm.Update(cleanImage);
        }

        private static void ArtifactRemover()
        {
            int width = cleanImage.Width;
            int height = cleanImage.Height;
            MyBitmap image = new MyBitmap(width, height);
            bool[,] visited = new bool[width, height];
            List<List<(int, int)>> regions = new List<List<(int, int)>>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte currentPixel = image.GetPixel(x, y);

                    if (!visited[y, x] && cleanImage.GetPixel(y, x) > 0)
                    {
                        List<(int, int)> region = new List<(int, int)>();
                        Queue<(int, int)> queue = new Queue<(int, int)>();

                        queue.Enqueue((y, x));
                        visited[y, x] = true;
                        while (queue.Count > 0)
                        {
                            var (cy, cx) = queue.Dequeue();

                            region.Add((cy, cx));

                            foreach (var (dy, dx) in GetNeighbors(cy, cx))
                            {
                                if (!visited[dy, dx])
                                {
                                    visited[dy, dx] = true;
                                    queue.Enqueue((dy, dx));
                                }
                            }
                        }
                        regions.Add(region);
                    }
                }
            }
            RemoveRegions(regions);
        }
        private static List<(int, int)> GetNeighbors(int y, int x)
        {
            List<(int, int)> neighbors = new List<(int, int)>();

            for (int dy = -1; dy < 2; dy++)
            {
                for (int dx = -1; dx < 2; dx++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int newX = x + dy;
                    int newY = y + dx;
                    if (newX >= 0 && newX < cleanImage.Width && newY >= 0 && newY < cleanImage.Height && cleanImage.GetPixel(newY, newX) != 0)
                    {
                        neighbors.Add((newY, newX));
                    }
                }
            }
            return neighbors;

        }
        private static void RemoveRegions(List<List<(int, int)>> regions)
        {
            // Remove all regions except the largest one...
            int width = cleanImage.Width;
            int height = cleanImage.Height;
            MyBitmap image = new MyBitmap(width, height);

            var region = regions.OrderByDescending(list => list.Count).FirstOrDefault();

            foreach (var (y, x) in region)
            {
                image.SetPixel(y, x, cleanImage.GetPixel(y, x));
            }
            cleanImage = image;
        }

        public static MyBitmap Apply(PGM pgm)
        {
            // Remove intens pixels...
            RemoveHeightNoise(pgm);

            matrix = pgm.matrix;

            // Apply Haar Wavelet algortm...
            HaarWavelet();

            //Remove Artifacts from the image...
            ArtifactRemover();

            return cleanImage;
        }

    }
}
