using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.CvEnum;

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
        public static Bitmap Apply(Bitmap bitmap, double clipLimit, int size)
        {
            // Convertim bitmap-ul la grayscale
            Mat input = bitmap.ToMat();

            Mat output = new Mat();
            CvInvoke.CLAHE(input, clipLimit, new Size(size, size), output);

            return RemoveNoise(output.Bitmap);
        }
        
        /// <summary>
        /// Înlătură zgomotul din imaginea procesată prin setarea pixelilor cu valori foarte mici la negru.
        /// </summary>
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
