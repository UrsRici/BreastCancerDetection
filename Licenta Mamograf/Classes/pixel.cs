using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta_Mamograf.Classes
{
    public class pixel
    {
        public int x { get; set; }
        public int y { get; set; }
        public float i { get; set; }
        public pixel(int x, int y, float i)
        {
            this.i = i;
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"Pixel: ({x}, {y}), Intensity: {i}";
        }
    }
}
