using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf.Classes
{
    public static class GrowCut
    {
        
        public static float[,] Apply(float[,] ROI)
        {
            float[,] points = new float[ROI.GetLength(0),ROI.GetLength(1)];
            /*for (int y = 0; y < points.GetLength(0); y++)
            {
                for (int x = 0; x < points.GetLength(1); x++)
                {
                    points[y, x] = 0;
                }
            }*/
            /*GROW CUT ALGORITM*/

            return points;
        }
    }
}
