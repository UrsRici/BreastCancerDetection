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
    public class PGM
    {
        public string magicNumber = "P5";
        public int width = 1024;
        public int height = 1024;
        public int maxVal = 255;
        public MyBitmap bitmap { get; set; }
        public Bitmap mask { get; set; }
        public float[,] matrix { get; set; }

        public PGM()
        {
            magicNumber = string.Empty;
            width = 0;
            height = 0;
            maxVal = 0;
            bitmap = null;
            mask = null;
            matrix = null;
        }
        public PGM(Bitmap bmp)
        {
            this.magicNumber = "P5"; // Format standard pentru PGM binar
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.maxVal = 255;

            this.bitmap = new MyBitmap(bmp.Height, bmp.Width);
            this.mask = new Bitmap(bmp);
            this.matrix = new float[bmp.Height, bmp.Width];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    byte gray = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);

                    this.bitmap.SetPixel(y, x, gray);
                    this.matrix[y, x] = gray;
                }
            }
        }
        public PGM(PGM img)
        {
            this.magicNumber = img.magicNumber;
            this.width = img.width;
            this.height = img.height;
            this.maxVal = img.maxVal;

            this.bitmap = new MyBitmap(img.bitmap);
            this.mask = new Bitmap(img.mask);

            this.matrix = new float[img.matrix.GetLength(0), img.matrix.GetLength(1)];
            for (int y = 0; y < img.matrix.GetLength(0); y++)
            {
                for (int x = 0; x < img.matrix.GetLength(1); x++)
                {
                    this.matrix[y, x] = img.matrix[y, x];
                }
            }
        }
        public PGM(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            // Read the magic number (should be "P5" for binary PGM)
            this.magicNumber = sr.ReadLine();

            // Read width and height
            string[] line = sr.ReadLine().Split(' ');
            this.width = int.Parse(line[0]);
            this.height = int.Parse(line[1]);

            // Read max pixel value
            this.maxVal = int.Parse(sr.ReadLine());
            // Read pixel data
            byte[] pixelData = new byte[height * width];
            sr.BaseStream.Read(pixelData, 0, pixelData.Length);

            // Create bitmap and fill it with pixel data
            this.bitmap = new MyBitmap(this.height, this.width);
            this.mask = new Bitmap(this.height, this.width);
            this.matrix = new float[this.height, this.width];

            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    byte pixel = pixelData[y * this.height + x];
                    // Use the pixel value to set the color (grayscale)
                    this.bitmap.SetPixel(y, this.width - x - 1, pixel);
                    this.matrix[y, this.width - x - 1] = pixel;
                }
            }
        }

        public void Update(MyBitmap bmp)
        {
            this.bitmap = bmp;
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.matrix = new float[this.height, this.width];
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    matrix[y, x] = bmp.GetPixel(y, x);
                }
            }
        }
        public void Update(float[,] matrix)
        {
            this.width = matrix.GetLength(0);
            this.height = matrix.GetLength(1);
            this.bitmap = new MyBitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = (byte)matrix[y, x];
                    this.bitmap.SetPixel(y, x, pixel);
                }
            }
        }
        public void Update(Bitmap bmp)
        {
            this.magicNumber = "P5"; // Format standard pentru PGM binar
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.maxVal = 255;

            this.bitmap = new MyBitmap(bmp.Height, bmp.Width);
            this.mask = new Bitmap(bmp);
            this.matrix = new float[bmp.Height, bmp.Width];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    byte gray = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);

                    this.bitmap.SetPixel(y, x, gray);
                    this.matrix[y, x] = gray;
                }
            }
        }
        public Bitmap ToBitmap()
        {
            return this.bitmap.ToBitmap();
        }

        public void ShowImage(PictureBox p) { p.Image = this.bitmap.ToBitmap(); }
        public void ShowMask(PictureBox p) { p.Image = this.mask; }
        public void Show(PictureBox p) 
        { 
            Bitmap image = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (this.mask.GetPixel(x, y).R == 0)
                    {
                        byte pixel = (byte)this.bitmap.GetPixel(x, y);
                        Color color = Color.FromArgb(pixel, pixel, pixel);
                        image.SetPixel(x, y, color);
                    }
                    else
                    {
                        image.SetPixel(x, y, this.mask.GetPixel(x, y));
                    }
                }
            }
            p.Image = image; 
        }

        public void RemoveArea(Point p0, Point p1)
        {
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++)
                {
                    this.matrix[x, y] = 0;
                }
            }
            this.Update(this.matrix);
        }
        public void ApplyMask(Point p0, Point p1, float[,] roi)
        {
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++) 
                {
                    Color color = Color.FromArgb((byte)roi[x - p0.X, y - p0.Y], 0, 0);
                    this.mask.SetPixel(x, y, color);
                }
            }
        }
        public void ApplyMask(float[,] roi)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {                   
                    Color color = Color.FromArgb((byte)roi[x, y], 0, 0);
                    this.mask.SetPixel(x, y, color);
                }
            }
            //this.Update(this.matrix);
        }

        public float[] Histogram()
        {
            float[] histogram = new float[256];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    histogram[bitmap.GetPixel(x, y)]++;

            return histogram;
        }
        public float[] CumulativeHistogram()
        {
            float[] histogram = this.Histogram();
            float[] cumulativeHistogram = new float[histogram.Length];
            cumulativeHistogram[0] = histogram[0]; // Setăm primul element

            // Calculăm suma cumulativă
            for (int i = 1; i < histogram.Length; i++)
            {
                cumulativeHistogram[i] = cumulativeHistogram[i - 1] + histogram[i];
            }

            return cumulativeHistogram; // Returnăm histogramă cumulativă
        }

    }
}
