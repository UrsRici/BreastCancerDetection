namespace Licenta_Mamograf.Classes
{
    public class pixel
    {
        public int x { get; set; }
        public int y { get; set; }
        public float i { get; set; }
        public pixel(int y, int x, float i)
        {
            this.i = i;
            this.x = x;
            this.y = y;
        }
        public override string ToString() { return $"Pixel: ({y}, {x}), Intensity: {i}"; }
    }
}
