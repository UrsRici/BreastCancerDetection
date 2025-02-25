using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

namespace Licenta_Mamograf.Classes
{
    public static class MyClahe
    {       
        public static Bitmap Apply(Bitmap bitmap, double clipLimit, int size)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(bitmap);
            
            Mat input = image.Mat;
            Mat output = new Mat();

            CvInvoke.CLAHE(input, clipLimit, new Size(size, size), output);

            return RemoveNoise(output.Bitmap);
        }
        private static Bitmap RemoveNoise(Bitmap mat)
        {
            Bitmap bitmap = new Bitmap(mat.Width, mat.Height);
            for (int y = 0; y < mat.Height; y++)
            {
                for(int x = 0; x < mat.Width; x++)
                {
                    if (mat.GetPixel(y, x).R < 10)
                    {
                        bitmap.SetPixel(y, x, Color.FromArgb(0, 0, 0));
                    }
                    else
                        bitmap.SetPixel(y, x, mat.GetPixel(y, x));
                }
            }
            return bitmap;
        }
    }
}
