using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;


public static class BitmapExtensions
{
    public static Mat ToMat(this Bitmap bmp)
    {
        int width = bmp.Width;
        int height = bmp.Height;

        // Creăm un Mat grayscale 8-bit (1 canal)
        Mat output = new Mat(height, width, DepthType.Cv8U, 1);

        unsafe
        {
            byte* data = (byte*)output.DataPointer;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    // Conversie simplă la grayscale
                    byte gray = (byte)((pixel.R + pixel.G + pixel.B) / 3);

                    data[y * output.Step + x] = gray;
                }
            }
        }
        return output;
    }
}
