using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Licenta_Mamograf;

namespace Vaja1_CLAHE
{
    public class MyBitmap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public byte[,] PixelData { get; set; }

        public MyBitmap(Bitmap bitplane)
        {
            this.Width = bitplane.Width;
            this.Height = bitplane.Height;

            this.PixelData = new byte[this.Height, this.Width];

            for (int y = 0; y < this.Height; ++y)
                for (int x = 0; x < this.Width; ++x)
                    this.PixelData[y, x] = (byte)bitplane.GetPixel(x, y).R;
        }
        public MyBitmap(MyBitmap bitplane)
        {
            this.Width = bitplane.Width;
            this.Height = bitplane.Height;

            for (int y = 0; y < this.Height; ++y)
                for (int x = 0; x < this.Width; ++x)
                    SetPixel(x, y, bitplane.GetPixel(x, y));
        }

        public MyBitmap(int w, int h)
        {
            Width = w;
            Height = h;

            PixelData = new byte[Height, Width];
        }

        public byte GetPixel(int x, int y)
        {
            return PixelData[y, x];
        }

        public void SetPixel(int x, int y, byte value)
        {
            PixelData[y, x] = value;
        }
        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < this.Height; ++y)
                for (int x = 0; x < this.Width; ++x)
                {
                    int pixel = PixelData[y, x];
                    Color c = Color.FromArgb(pixel, pixel, pixel);
                    bitmap.SetPixel(x, y, c);
                }

            return bitmap;
        }
    }
}
