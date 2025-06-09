using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

namespace BreastCancerDetection.Classes
{
    /// <summary>
    /// Clasa care implementează funcționalitatea de îmbunătățire a contrastului folosind metoda CLAHE (Contrast Limited Adaptive Histogram Equalization).
    /// </summary>
    public static class MyClahe
    {
        /// <summary>
        /// Aplică algoritmul CLAHE pe o imagine bitmap pentru îmbunătățirea contrastului.
        /// </summary>
        /// <param name="bitmap">Imaginea pe care se va aplica CLAHE.</param>
        /// <param name="clipLimit">Limita de tăiere pentru histogramă.</param>
        /// <param name="size">Dimensiunea ferestrei pentru aplicarea CLAHE.</param>
        /// <returns>Imaginea procesată cu CLAHE și cu zgomotul eliminat.</returns>
        public static Bitmap Apply(Bitmap bitmap, double clipLimit, int size)
        {
            // Convertește Bitmap-ul într-o imagine în tonuri de gri
            Image<Gray, byte> image = new Image<Gray, byte>(bitmap);

            // Creăm obiecte Mat pentru a lucra cu datele imaginii
            Mat input = image.Mat;
            Mat output = new Mat();

            // Aplicăm CLAHE pe imaginea de intrare
            CvInvoke.CLAHE(input, clipLimit, new Size(size, size), output);

            // Înlăturăm zgomotul din imaginea rezultată
            return RemoveNoise(output.Bitmap);
        }

        /// <summary>
        /// Înlătură zgomotul din imaginea procesată prin setarea pixelilor cu valori foarte mici la negru.
        /// </summary>
        /// <param name="mat">Imaginea procesată pe care dorim să o curățăm de zgomot.</param>
        /// <returns>Imaginea curățată de zgomot.</returns>
        private static Bitmap RemoveNoise(Bitmap mat)
        {
            // Creăm un nou obiect Bitmap pentru imaginea curățată
            Bitmap bitmap = new Bitmap(mat.Width, mat.Height);

            // Parcurgem fiecare pixel al imaginii
            for (int y = 0; y < mat.Height; y++)
            {
                for (int x = 0; x < mat.Width; x++)
                {
                    // Dacă valoarea pixelului este foarte mică (sub pragul 10), o considerăm zgomot
                    if (mat.GetPixel(y, x).R < 10)
                        bitmap.SetPixel(y, x, Color.FromArgb(0, 0, 0));
                    else
                        bitmap.SetPixel(y, x, mat.GetPixel(y, x));
                }
            }
            return bitmap;
        }
    }
}
