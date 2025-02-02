using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf.Classes
{
    public static class MyClahe
    {       
        public static Bitmap Apply(Bitmap bitmap, double clipLimit, int s)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(bitmap);
            
            Mat input = image.Mat;
            Mat output = new Mat();

            CvInvoke.CLAHE(input, clipLimit, new Size(s, s), output);

            return output.Bitmap;
        }
    }
}
