namespace BreastCancerDetection.Classes
{
    /// <summary>
    /// Clasa care reprezintă un pixel într-o imagine, conținând coordonatele și valoarea de intensitate.
    /// </summary>
    public class pixel
    {
        public int x { get; set; } ///Coordonata X

        public int y { get; set; } ///Coordonata Y

        public float i { get; set; } /// Valoarea de intensitate

        /// <summary>
        /// Constructor pentru inițializarea unui obiect pixel cu coordonatele și intensitatea specificate.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="i"></param>
        public pixel(int y, int x, float i)
        {
            this.i = i;
            this.x = x;
            this.y = y;
        }
    }
}
