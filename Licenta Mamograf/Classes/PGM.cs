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
            this.matrix = new double[this.height, this.width];

            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    byte pixel = pixelData[x * this.width + y];
                    // Use the pixel value to set the color (grayscale)
                    // height - y - 1 because we are fliping the image
                    this.bitmap.SetPixel(height - y - 1, x, pixel);
                    this.matrix[this.height - y - 1, x] = pixel;
                }
            }
        }

        public void Update(MyBitmap bmp)
        {
            this.bitmap = bmp;
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.matrix = new double[this.width, this.height];
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    this.matrix[y, x] = bmp.GetPixel(y, x);
                }
            }
        }

        public void Update(double[,] matrix)
        {
            this.width = matrix.GetLength(0);
            this.height = matrix.GetLength(1);
            this.bitmap = new MyBitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this.bitmap.SetPixel(y, x, (byte)matrix[y, x]);
                }
            }
        }

        public void Show(PictureBox p) { p.Image = this.bitmap.ToBitmap(); }

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



        public double[] Histogram()
        {
            double[] histogram = new double[256];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    histogram[bitmap.GetPixel(x, y)]++;

            return histogram;
        }

        public double[] CumulativeHistogram()
        {
            double[] histogram = this.Histogram();
            double[] cumulativeHistogram = new double[histogram.Length];
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
