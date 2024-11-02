using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta_Mamograf
{
    public class Pixel
    {
        public int x, y, s;
        public Pixel(int x, int y, int s)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
        public Pixel()
        {
            this.x = 0;
            this.y = 0;
            this.s = 0;
        }
    }

    public class PGM
    {

        public string magicNumber = "P5";
        public int width = 1024;
        public int height = 1024;
        public int maxVal = 255;
        public MyBitmap bitmap { get; set; }
        public double[,] matrix { get; set; }


        public PGM()
        {
            magicNumber = string.Empty;
            width = 0;
            height = 0;
            maxVal = 0;
            bitmap = null;
            matrix = null;
        }

        public PGM(PGM img)
        {
            this.magicNumber = img.magicNumber;
            this.width = img.width;
            this.height = img.height;
            this.maxVal = img.maxVal;

            this.bitmap = new MyBitmap(img.bitmap);

            this.matrix = new double[img.matrix.GetLength(0), img.matrix.GetLength(1)];
            for (int i = 0; i < img.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < img.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = img.matrix[i, j];
                }
            }
        }

        public PGM(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            // Read the magic number (should be "P5" for binary PGM)
            magicNumber = sr.ReadLine();

            // Read width and height
            string[] line = sr.ReadLine().Split(' ');
            width = int.Parse(line[0]);
            height = int.Parse(line[1]);

            // Read max pixel value
            maxVal = int.Parse(sr.ReadLine());
            // Read pixel data
            byte[] pixelData = new byte[height * width];
            sr.BaseStream.Read(pixelData, 0, pixelData.Length);

            // Create bitmap and fill it with pixel data
            bitmap = new MyBitmap(height, width);
            matrix = new double[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = pixelData[x * width + y];
                    // Use the pixel value to set the color (grayscale)
                    // height - y - 1 because we are fliping the image
                    bitmap.SetPixel(height - y - 1, x, pixel);
                    matrix[height - y - 1, x] = pixel;
                }
            }
        }

        public PGM Update(MyBitmap bmp)
        {
            bitmap = bmp;
            width = bmp.Width;
            height = bmp.Height;
            matrix = new double[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[y, x] = bmp.GetPixel(y, x);
                }
            }
            return this;
        }

        public void Show(PictureBox p, PictureBox pR, PictureBox pG, PictureBox pB)
        {
            Bitmap bmp = new Bitmap(this.height, this.width);
            int height = bmp.Height;
            int width = bmp.Width;
            Bitmap r = new Bitmap(height, width);
            Bitmap g = new Bitmap(height, width);
            Bitmap b = new Bitmap(height, width);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = bitmap.GetPixel(y, x);
                    bmp.SetPixel(y, x, Color.FromArgb(pixel, pixel, pixel));
                    r.SetPixel(y, x, Color.FromArgb(pixel, 0, 0));
                    g.SetPixel(y, x, Color.FromArgb(0, pixel, 0));
                    b.SetPixel(y, x, Color.FromArgb(0, 0, pixel));
                }
            }
            p.Image = bmp;
            pR.Image = r;
            pG.Image = g;
            pB.Image = b;
            /*p.Image = bitmap.ToBitmap();
            pR.Image = bitmap.ToBitmap_R();
            pG.Image = bitmap.ToBitmap_G();
            pB.Image = bitmap.ToBitmap_B();*/
        }

        public PGM Coppy() { return new PGM(this); }

    }
}
