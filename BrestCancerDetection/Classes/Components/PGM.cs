using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BrestCancerDetection.Classes
{
    /// <summary>
    /// Clasă pentru gestionarea imaginilor în format PGM (Portable Gray Map).
    /// </summary>
    public class PGM
    {
        #region Atribute
        public string magicNumber = "P5"; // Magic number pentru formatul PGM binar
        public int width = 1024; // Lățimea imaginii
        public int height = 1024; // Înălțimea imaginii
        public int maxVal = 255; // Valoarea maximă a pixelilor (255 pentru imagini în alb-negru)
        public MyBitmap bitmap { get; set; } // Bitmap-ul imaginii în format MyBitmap
        public Bitmap mask { get; set; } // Mască pentru imagini
        public float[,] matrix { get; set; } // Reprezentare matriceală a imaginii
        #endregion

        #region Constructori
        public PGM()
        {
            // Constructorul implicit care inițializează variabilele
            magicNumber = string.Empty;
            width = 0;
            height = 0;
            maxVal = 0;
            bitmap = null;
            mask = null;
            matrix = null;
        }

        /// <summary>
        /// Constructor care încarcă o imagine PGM dintr-un fișier.
        /// </summary>
        /// <param name="filePath">Calea către fișierul PGM</param>
        public PGM(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            // Citim "magic number" (ar trebui să fie "P5" pentru PGM binar)
            this.magicNumber = sr.ReadLine();

            // Citim lățimea și înălțimea imaginii
            string[] line = sr.ReadLine().Split(' ');
            this.width = int.Parse(line[0]);
            this.height = int.Parse(line[1]);

            // Citim valoarea maximă a pixelilor
            this.maxVal = int.Parse(sr.ReadLine());

            // Citim datele pixelilor
            byte[] pixelData = new byte[height * width];
            sr.BaseStream.Read(pixelData, 0, pixelData.Length);

            // Creăm obiecte pentru bitmap și mască
            this.bitmap = new MyBitmap(this.height, this.width);
            this.mask = new Bitmap(this.width, this.height);
            this.matrix = new float[this.height, this.width];

            // Populăm imaginea și matricea cu valorile citite
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    byte pixel = pixelData[y * this.height + x];    // ← corecție indexare
                    // Setăm pixelul pe baza valorii citite
                    this.bitmap.SetPixel(y, this.width - x - 1, pixel);
                    this.matrix[y, this.width - x - 1] = pixel;
                }
            }
        }
        #endregion

        #region Actualizări
        /// <summary>
        /// Actualizează imaginea folosind un obiect MyBitmap.
        /// </summary>
        /// <param name="bmp">Noua imagine MyBitmap</param>
        public void Update(MyBitmap bmp)
        {
            this.bitmap = bmp;
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.matrix = new float[this.height, this.width];
            // Copiem valorile pixelilor din MyBitmap în matrice
            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    matrix[y, x] = bmp.GetPixel(y, x);
                }
            }
        }

        /// <summary>
        /// Actualizează imaginea folosind o matrice de pixeli (float).
        /// </summary>
        /// <param name="matrix">Matricea de pixeli</param>
        public void Update(float[,] matrix)
        {
            this.width = matrix.GetLength(0);
            this.height = matrix.GetLength(1);
            this.bitmap = new MyBitmap(width, height);
            // Setăm fiecare pixel în funcție de valorile din matrice
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte pixel = (byte)matrix[y, x];
                    this.bitmap.SetPixel(y, x, pixel);
                }
            }
        }

        /// <summary>
        /// Actualizează imaginea folosind un obiect Bitmap.
        /// </summary>
        /// <param name="bmp">Noua imagine Bitmap</param>
        public void Update(Bitmap bmp)
        {
            this.magicNumber = "P5"; // Format standard pentru PGM binar
            this.width = bmp.Width;
            this.height = bmp.Height;
            this.maxVal = 255;

            this.bitmap = new MyBitmap(bmp.Height, bmp.Width);
            this.mask = new Bitmap(bmp);
            this.matrix = new float[bmp.Height, bmp.Width];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    byte gray = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);

                    this.bitmap.SetPixel(y, x, gray); // Setăm pixelul în MyBitmap
                    this.matrix[y, x] = gray; // Actualizăm matricea
                }
            }
        }
        #endregion

        #region Conversii
        /// <summary>
        /// Transformă obiectul PGM într-o imagine Bitmap.
        /// </summary>
        public Bitmap ToBitmap() { return this.bitmap.ToBitmap(); }

        /// <summary>
        /// Transformă obiectul PGM într-un array de bytes pentru utilizare ca sursă de imagine.
        /// </summary>
        public byte[] ToImageSource()
        {
            string cacheCath = Path.GetTempPath() + "cache.jpg";
            this.ToBitmap().Save(cacheCath);
            return File.ReadAllBytes(cacheCath);
        }

        /// <summary>
        /// Transformă obiectul PGM într-un obiect ModelInput.
        /// </summary>
        public ModelInput ToModelInput()
        {
            ModelInput input = new ModelInput()
            {
                ImageSource = this.ToImageSource()
            };
            return input;
        }
        #endregion

        #region Afișări
        /// <summary>
        /// Afișează imaginea în controlul PictureBox.
        /// </summary>
        public void ShowImage(PictureBox p) { p.Image = this.bitmap.ToBitmap(); }

        /// <summary>
        /// Afișează masca în controlul PictureBox.
        /// </summary>
        public void ShowMask(PictureBox p) { p.Image = this.mask; }

        /// <summary>
        /// Afișează imaginea cu masca aplicată în controlul PictureBox.
        /// </summary>
        public void Show(PictureBox p)
        {
            Bitmap image = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Aplicăm masca pe imagine
                    if (this.mask.GetPixel(x, y).R == 0)
                    {
                        byte pixel = (byte)this.bitmap.GetPixel(y, x);
                        Color color = Color.FromArgb(pixel, pixel, pixel);
                        image.SetPixel(x, y, color);
                    }
                    else
                    {
                        image.SetPixel(x, y, this.mask.GetPixel(x, y)); // Setăm culoarea din mască
                    }
                }
            }
            p.Image = image;
        }
        #endregion

        #region Manipulare ROI
        /// <summary>
        /// Elimină o zonă din imagine (pixeli setați la 0).
        /// </summary>
        public void RemoveArea(Point p0, Point p1)
        {
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++)
                {
                    this.matrix[y, x] = 0; // Setăm pixelii din zona selectată la 0
                }
            }
            this.Update(this.matrix);
        }

        /// <summary>
        /// Aplică o mască pe o zonă specificată din imagine.
        /// </summary>
        public void ApplyMask(Point p0, Point p1, float[,] roi)
        {
            for (int y = p0.Y; y < p1.Y; y++)
            {
                for (int x = p0.X; x < p1.X; x++)
                {
                    Color color = Color.FromArgb((byte)roi[y - p0.Y, x - p0.X], 0, 0);
                    this.mask.SetPixel(x, y, color); // Aplicăm culoarea din ROI pe mască
                }
            }
        }

        /// <summary>
        /// Aplică o mască pe întreaga imagine folosind o matrice de pixeli (ROI).
        /// </summary>
        public void ApplyMask(float[,] roi)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = Color.FromArgb((byte)roi[y, x], 0, 0);
                    this.mask.SetPixel(x, y, color); // Aplicăm masca pe întreaga imagine
                }
            }
        }
        #endregion

        #region Histograme
        /// <summary>
        /// Calculează histogramă pentru imagine.
        /// </summary>
        public float[] Histogram()
        {
            float[] histogram = new float[256];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    histogram[bitmap.GetPixel(x, y)]++; // Incrementăm histograma pe baza valorii pixelilor

            return histogram;
        }

        /// <summary>
        /// Calculează histograma cumulativă pentru imagine.
        /// </summary>
        public float[] CumulativeHistogram()
        {
            float[] histogram = this.Histogram();
            float[] cumulativeHistogram = new float[histogram.Length];
            cumulativeHistogram[0] = histogram[0]; // Setăm primul element

            // Calculăm suma cumulativă
            for (int i = 1; i < histogram.Length; i++)
            {
                cumulativeHistogram[i] = cumulativeHistogram[i - 1] + histogram[i];
            }

            return cumulativeHistogram; // Returnăm histograma cumulativă
        }
        #endregion
    }
}
