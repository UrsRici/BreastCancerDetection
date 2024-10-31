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
        public string magicNumber;
        public int width;
        public int height;
        public int maxVal;
        public Bitmap bitmap;
        public double[,] matrix;
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

            this.bitmap = (Bitmap)img.bitmap.Clone();

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
            byte[] pixelData = new byte[width * height];
            sr.BaseStream.Read(pixelData, 0, pixelData.Length);

            // Create bitmap and fill it with pixel data
            bitmap = new Bitmap(width, height);
            matrix = new double[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = pixelData[y * width + x];
                    // Use the pixel value to set the color (grayscale)
                    Color color = Color.FromArgb(pixel, pixel, pixel);
                    bitmap.SetPixel(x, y, color);
                    matrix[y, x] = (float)((color.R + color.G + color.B) / 3.0);
                }
            }
        }
        public void Show(PictureBox pB) { pB.Image = (Bitmap)bitmap.Clone(); }
        public PGM Coppy() { return new PGM(this); }
    }
}
