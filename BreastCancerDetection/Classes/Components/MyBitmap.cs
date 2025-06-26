using System.Drawing;

namespace BreastCancerDetection.Classes
{
    /// <summary>
    /// Clasă personalizată pentru manipularea imaginilor în format grayscale, 
    /// stocând valorile pixelilor într-un tablou bidimensional de octeți.
    /// </summary>
    public class MyBitmap
    {

        /// Lățimea imaginii.
        public int Width { get; set; } 
        
        /// Înălțimea imaginii.
        public int Height { get; set; }

        /// Datele pixelilor imaginii, stocate într-un tablou bidimensional.
        private byte[,] PixelData { get; set; }

        /// <summary>
        /// Constructor care inițializează o imagine goală cu dimensiuni date.
        /// </summary>
        public MyBitmap(int h, int w)
        {
            this.Width = w;
            this.Height = h;
            this.PixelData = new byte[this.Height, this.Width];
        }

        /// <summary>
        /// Returnează valoarea pixelului de la o anumită coordonată.
        /// </summary>
        public byte GetPixel(int y, int x) { return this.PixelData[y, x]; }

        /// <summary>
        /// Setează valoarea unui pixel la coordonatele date.
        /// </summary>
        public void SetPixel(int y, int x, byte value) { this.PixelData[y, x] = value; }

        /// <summary>
        /// Convertește obiectul `MyBitmap` într-o imagine `Bitmap` standard.
        /// </summary>
        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    int pixel = this.PixelData[y, x];
                    Color c = Color.FromArgb(pixel, pixel, pixel); // Conversie grayscale
                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
        }
    }
}
