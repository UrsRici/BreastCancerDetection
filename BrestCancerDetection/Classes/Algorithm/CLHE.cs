using System;

namespace BrestCancerDetection.Classes
{
    /// <summary>
    /// Clasa care implementează metoda de echilibrare a contrastului limitat (CLAHE) pe o imagine.
    /// </summary>
    public static class CLHE
    {
        /// <summary>
        /// Calculează histograma unei imagini (bitplane).
        /// </summary>
        /// <param name="bitplane":Imaginea de procesat (tipul MyBitmap).</param>
        /// <returns>Un tablou cu frecvențele de intensitate ale pixelilor.</returns>
        private static double[] calculateHistogram(MyBitmap bitplane)
        {
            double[] histogram = new double[256]; // Histogramă pentru intensitățile de la 0 la 255
            int x, y;
            for (y = 0; y < bitplane.Height; y++)
                for (x = 0; x < bitplane.Width; x++)
                    histogram[bitplane.GetPixel(x, y)]++; // Incrementăm valoarea corespunzătoare fiecărei intensități

            return histogram;
        }

        /// <summary>
        /// Calculează frecvența cumulativă pentru un array dat.
        /// </summary>
        /// <param name="array">Tabloul de frecvențe.</param>
        /// <returns>Tabloul de frecvență cumulativă.</returns>
        private static double[] calculateComulativeFrequency(double[] array)
        {
            int size = array.Length;
            double[] comulativeFreq = new double[size];
            comulativeFreq[0] = array[0]; // Primul element rămâne același
            for (int i = 1; i < size; i++)
                comulativeFreq[i] = comulativeFreq[i - 1] + array[i]; // Calculăm suma cumulativă

            return comulativeFreq;
        }

        /// <summary>
        /// Găsește valoarea minimă dintr-un array.
        /// </summary>
        /// <param name="array">Tabloul de valori pentru care se calculează minimul.</param>
        /// <returns>Valoarea minimă din array.</returns>
        private static double findMin(double[] array)
        {
            double min = double.MaxValue; // Inițializăm cu valoarea maximă posibilă
            foreach (double value in array)
                if (value < min)
                    min = value; // Găsim minimul
            return min;
        }

        /// <summary>
        /// Aplică metoda CLAHE (Contrast Limited Adaptive Histogram Equalization) pe o imagine.
        /// </summary>
        /// <param name="bitplane">Imaginea de procesat (tipul MyBitmap).</param>
        /// <param name="contrastLimit">Limită pentru contrast, care reglează echilibrarea acestuia.</param>
        public static void Apply(ref MyBitmap bitplane, double contrastLimit)
        {
            // Calculăm limita de contrast și parametrii necesari
            double cl = (contrastLimit * (bitplane.Width * bitplane.Height)) / 256;
            double top = cl;
            double bottom = 0;
            double SUM = 0;
            int i;

            // Calculează histograma imaginii
            double[] histogram = calculateHistogram(bitplane);

            // Ajustăm intervalul de frecvență pe baza unei metode de căutare binară
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

            // Calculăm nivelul de tăiere (clipLevel)
            double clipLevel = Math.Round(bottom + (SUM / 256));

            // Ajustăm histograma pentru a limita contrastul
            double L = cl - clipLevel;
            for (i = 0; i < 256; i++)
                if (histogram[i] >= clipLevel)
                    histogram[i] = clipLevel;
                else
                    histogram[i] += L;

            // Adăugăm un pas pentru a distribui uniform frecvențele
            double perBin = SUM / 256;
            for (i = 0; i < 256; i++)
                histogram[i] += perBin;

            // Calculăm histograma cumulativă
            histogram = calculateComulativeFrequency(histogram);
            int[] finalFreq = new int[256];

            // Găsim valoarea minimă din histograma cumulativă
            double min = findMin(histogram);

            // Normalizăm histograma și transformăm valorile pentru a le adapta la intervalul [0, 255]
            for (i = 0; i < 256; i++)
                finalFreq[i] = (int)((histogram[i] - min) / ((bitplane.Width * bitplane.Height) - 2) * 255);

            // Aplicăm valorile finalizate pe fiecare pixel din imagine
            int x;
            for (int y = 0; y < bitplane.Height; y++)
                for (x = 0; x < bitplane.Width; x++)
                    bitplane.SetPixel(x, y, (byte)finalFreq[bitplane.GetPixel(x, y)]);
        }
    }
}
