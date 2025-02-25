using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Licenta_Mamograf
{
    public class MyBitmap
    {

        public int Width { get; set; }
        public int Height { get; set; }
        private byte[,] PixelData { get; set; }

        public MyBitmap(MyBitmap bitmap)
        {        
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;

            this.PixelData = new byte[this.Height, this.Width];

            this.PixelData = bitmap.PixelData;

            for (int y = 0; y < this.Height; ++y)
                for (int x = 0; x < this.Width; ++x)
                    this.PixelData[y, x] = bitmap.GetPixel(y, x);
        }
        
        public MyBitmap(int h, int w)
        {
            this.Width = w;
            this.Height = h;

            this.PixelData = new byte[this.Height, this.Width];
        }

        public byte GetPixel(int y, int x)
        {
            return this.PixelData[y, x];
        }

        public void SetPixel(int y, int x, byte value)
        {
            this.PixelData[y, x] = value;
        }

        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    int pixel = this.PixelData[y, x];
                    Color c = Color.FromArgb(pixel, pixel, pixel);
                    bitmap.SetPixel(x, y, c);
                }
            }

            return bitmap;
        }

        public void ToMyBitmap(Bitmap bmp)
        {

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.SetPixel(y, x, bmp.GetPixel(y, x).R);
                }
            }
        }
    }
}
