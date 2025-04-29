using System;
using System.Collections.Generic;
using System.Linq;

namespace BrestCancerDetection.Classes
{
    /// <summary>
    /// Clasa care implementează procesarea imaginii pentru îmbunătățirea calității acesteia, incluzând eliminarea zgomotului, aplicarea transformatei Haar și eliminarea artefactelor.
    /// </summary>
    public static class Preprocessing
    {
        private static float[,] matrix;
        private static float[,] coefficients;
        private static float threshold;
        private static float[,] denoisedMatrix;
        private static MyBitmap cleanImage;

        /// <summary>
        /// Aplica procesarea imaginii pe imaginea dată (PGM).
        /// </summary>
        /// <param name="pgm">Imaginea PGM de procesat.</param>
        /// <returns>Imaginea procesată.</returns>
        public static MyBitmap Apply(PGM pgm)
        {
            // Elimină zgomotul de înălțime din imagine...
            RemoveHeightNoise(pgm);

            matrix = pgm.matrix;

            // Aplică algoritmul Haar Wavelet...
            HaarWavelet();

            // Elimină artefactele din imagine...
            ArtifactRemover();

            return cleanImage;
        }

        /// <summary>
        /// Elimină zgomotul de înălțime (valorile extreme) din imaginea PGM.
        /// </summary>
        /// <param name="pgm">Imaginea PGM din care se elimină zgomotul.</param>
        private static void RemoveHeightNoise(PGM pgm)
        {
            MyBitmap image = pgm.bitmap;
            int width = image.Width;
            int height = image.Height;
            cleanImage = new MyBitmap(height, width);

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
                            if (dx == 0 && dy == 0) continue;
                            byte neighborPixel = image.GetPixel(y + dy, x + dx);
                            avgIntensity += neighborPixel;
                            count++;
                        }
                    }

                    avgIntensity /= count;

                    // Dacă intensitatea pixelului curent diferă mult de media vecinilor, îl înlocuim cu media
                    if (Math.Abs(currentPixel - avgIntensity) > 10)
                        cleanImage.SetPixel(y, x, (byte)avgIntensity);
                    else
                        cleanImage.SetPixel(y, x, currentPixel);
                }
            }
            pgm.Update(cleanImage);
        }

        #region HaarWavelet
        /// <summary>
        /// Realizează transformata Haar pe matricea de imagine.
        /// </summary>
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

        /// <summary>
        /// Realizează transformata inversă Haar pe matricea de coeficienți.
        /// </summary>
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

        /// <summary>
        /// Calculează pragul adaptiv pe baza coeficientilor Haar.
        /// </summary>
        private static void CalculateThreshold()
        {
            // Implementare simplă pentru calcularea pragului
            float mean = coefficients.Cast<float>().Average();
            float stdDev = (float)Math.Sqrt(coefficients.Cast<float>().Select(val => (float)Math.Pow(val - mean, 2)).Average());
            threshold = mean + .5f * stdDev; // Prag adaptiv simplificat
        }

        /// <summary>
        /// Aplică pragul la coeficientii Haar pentru a elimina valorile mici.
        /// </summary>
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

        /// <summary>
        /// Convertește matricea denoizată într-o imagine Bitmap.
        /// </summary>
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
                    int grayValue = 0;

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

        /// <summary>
        /// Aplică procesul complet Haar Wavelet.
        /// </summary>
        private static void HaarWavelet()
        {
            // Transformă matricea în coeficienți Haar...
            Transform();

            // Calculează pragul...
            CalculateThreshold();

            // Aplică pragul pe coeficientii Haar...
            ApplyThreshold();

            // Transformă matricea Haar cu prag în matricea denoizată...
            InverseTransform();

            // Convertește matricea denoizată într-o imagine denoizată...
            ConvertMatrixToBitmap();
        }
        #endregion

        #region ArtifactRemover
        /// <summary>
        /// Înlătură artefactele din imagine folosind un algoritm de identificare a regiunilor conectate.
        /// </summary
        private static void ArtifactRemover()
        {
            int width = cleanImage.Width; // Lățimea imaginii
            int height = cleanImage.Height; // Înălțimea imaginii
            MyBitmap image = new MyBitmap(height, width); // Crearea unei noi imagini pentru a stoca rezultatul
            bool[,] visited = new bool[height, width]; // Matrice pentru a urmări pixelii deja analizați
            List<List<(int, int)>> regions = new List<List<(int, int)>>(); // Listă pentru regiunile detectate

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte currentPixel = image.GetPixel(y, x); // Pixelul curent

                    // Dacă pixelul nu a fost vizitat și valoarea sa este mai mare decât 0
                    if (!visited[y, x] && cleanImage.GetPixel(y, x) > 0)
                    {
                        List<(int, int)> region = new List<(int, int)>();
                        Queue<(int, int)> queue = new Queue<(int, int)>();

                        queue.Enqueue((y, x));
                        visited[y, x] = true;

                        // Procesăm coada pentru a detecta întreaga regiune
                        while (queue.Count > 0)
                        {
                            var (cy, cx) = queue.Dequeue();

                            region.Add((cy, cx));

                            // Verificăm vecinii pixelului curent
                            foreach (var (dy, dx) in GetNeighbors(cy, cx))
                            {
                                if (!visited[dy, dx])
                                {
                                    visited[dy, dx] = true;
                                    queue.Enqueue((dy, dx));
                                }
                            }
                        }
                        regions.Add(region); // Adăugăm regiunea la lista de regiuni detectate
                    }
                }
            }

            // Îndepărtăm regiunile mai mici, păstrând doar cea mai mare
            RemoveRegions(regions);
        }

        /// <summary>
        /// Obține toți vecinii unui pixel (8 direcții de vecinătate).
        /// </summary>
        /// <param name="y">Coordonata pe axa Y a pixelului.</param>
        /// <param name="x">Coordonata pe axa X a pixelului.</param>
        /// <returns>Lista vecinilor.</returns>
        private static List<(int, int)> GetNeighbors(int y, int x)
        {
            List<(int, int)> neighbors = new List<(int, int)>(); // Listă pentru vecini

            // Parcurgem pixelii vecini (în jurul pixelului curent)
            for (int dy = -1; dy < 2; dy++)
            {
                for (int dx = -1; dx < 2; dx++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int newX = x + dy;
                    int newY = y + dx;

                    // Verificăm dacă vecinul este în interiorul imaginii și dacă nu este un pixel negru (0)
                    if (newX >= 0 && newX < cleanImage.Width && newY >= 0 && newY < cleanImage.Height && cleanImage.GetPixel(newY, newX) != 0)
                    {
                        neighbors.Add((newY, newX));
                    }
                }
            }
            return neighbors;
        }

        /// <summary>
        /// Înlătură regiunile mici și păstrează doar regiunea cea mai mare.
        /// </summary>
        /// <param name="regions">Lista regiunilor detectate.</param>
        private static void RemoveRegions(List<List<(int, int)>> regions)
        {
            int width = cleanImage.Width;
            int height = cleanImage.Height;
            MyBitmap image = new MyBitmap(height, width);

            // Selectăm regiunea cea mai mare din listă
            var region = regions.OrderByDescending(list => list.Count).FirstOrDefault();

            // Copiem pixelii din regiunea cea mai mare în noua imagine
            foreach (var (y, x) in region)
            {
                image.SetPixel(y, x, cleanImage.GetPixel(y, x));
            }

            // Actualizăm imaginea curentă cu imaginea finală
            cleanImage = image;
        }
        #endregion

    }
}
