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
        public byte[,] PixelData { get; set; }
        public Color[,] R { get; set; }
        public Color[,] G { get; set; }
        public Color[,] B { get; set; }

        public MyBitmap(MyBitmap bitmap)
        {        
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;

            this.PixelData = new byte[this.Height, this.Width];
            this.R = new Color[this.Width, this.Height];
            this.G = new Color[this.Width, this.Height];
            this.B = new Color[this.Width, this.Height];

            this.PixelData = bitmap.PixelData;
            this.R = bitmap.R;
            this.G = bitmap.G;
            this.B = bitmap.B;

            /*for (int y = 0; y < this.Height; ++y)
                for (int x = 0; x < this.Width; ++x)
                    this.PixelData[y, x] = bitmap.GetPixel(x, y).R;*/
        }
        
        public MyBitmap(int w, int h)
        {
            this.Width = w;
            this.Height = h;

            this.PixelData = new byte[this.Height, this.Width];
            this.R = new Color[this.Width, this.Height];
            this.G = new Color[this.Width, this.Height];
            this.B = new Color[this.Width, this.Height];
        }

        public byte GetPixel(int y, int x)
        {
            return PixelData[y, x];
        }

        public void SetPixel(int y, int x, byte value)
        {
            PixelData[y, x] = value;
            R[y, x] = Color.FromArgb(value, 0, 0);
            G[y, x] = Color.FromArgb(0, value, 0);
            B[y, x] = Color.FromArgb(0, 0, value);
        }

        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    int pixel = PixelData[y, x];
                    Color c = Color.FromArgb(pixel, pixel, pixel);
                    bitmap.SetPixel(y, x, c);
                }
            }

            return bitmap;
        }

        public Bitmap ToBitmap_R()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    bitmap.SetPixel(y, x, R[y, x]);
                }
            }

            return bitmap;
        }

        public Bitmap ToBitmap_G()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    bitmap.SetPixel(y, x, G[y, x]);
                }
            }

            return bitmap;
        }

        public Bitmap ToBitmap_B()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    bitmap.SetPixel(y, x, B[y, x]);
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
