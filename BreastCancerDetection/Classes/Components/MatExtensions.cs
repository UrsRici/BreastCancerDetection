using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Emgu.CV;

public static class MatExtensions
{
    public static Bitmap ToBitmapSafe(this Mat mat)
    {
        if (mat == null || mat.IsEmpty)
            return null;

        if (mat.NumberOfChannels != 1 || mat.Depth != Emgu.CV.CvEnum.DepthType.Cv8U)
            throw new NotSupportedException("Funcția suportă doar imagini grayscale 8-bit (1 canal).");

        int width = /*mat.SizeOfDimension[0]*/ mat.Width;
        int height = /*mat.SizeOfDimension[1]*/ mat.Height;

        Bitmap bmp = new Bitmap(width, height);

        unsafe
        {
            byte* data = (byte*)mat.DataPointer;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte value = data[y * mat.Step + x];
                    bmp.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }
        }

        return bmp;
    }
}
