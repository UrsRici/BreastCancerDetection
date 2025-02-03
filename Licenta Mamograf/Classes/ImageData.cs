using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta_Mamograf.Classes
{
    public class imageData
        {
            // 1st column: MIAS database reference number
            public string ID { get; set; }

            // 2nd column: Character of background tissue (F, G, D)
            public string TissueType { get; set; }

            // 3rd column: Class of abnormality present (CALC, CIRC, SPIC, etc.)
            public string AbnormalityClass { get; set; }

            // 4th column: Severity of abnormality (B, M)
            public string Severity { get; set; }

            // 5th and 6th columns: x, y image-coordinates
            public int X { get; set; }
            public int Y { get; set; }

            // 7th column: Approximate radius in pixels
            public int Radius { get; set; }

            public imageData(string iD, string tissueType, string abnormalityClass, string severity, int x, int y, int radius)
            {
                this.ID = iD;
                this.TissueType = tissueType;
                this.AbnormalityClass = abnormalityClass;
                this.Severity = severity;
                this.X = x;
                this.Y = y;
                this.Radius = radius;
            }
            public imageData(string iD, string tissueType, string abnormalityClass)
            {
                this.ID = iD;
                this.TissueType = tissueType;
                this.AbnormalityClass = abnormalityClass;
                this.Severity = string.Empty;
                this.X = 0;
                this.Y = 0;
                this.Radius = 0;
            }
            public override string ToString()
            {
                return $"{ID} {TissueType} {AbnormalityClass} {Severity} {X} {Y} {Radius}";
            }
        }
    
    public static class ImageData
    {
        private static List<imageData> Data = new List<imageData>();
        private static List<imageData> currentData = new List<imageData>();

        public static void Load()
        {
            string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\data.txt"));
            StreamReader sr = new StreamReader(filePath);
            string buffer;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] row = buffer.Split(' ');
                if (row.Length > 4)
                {
                    Data.Add(new imageData(row[0], row[1], row[2], row[3], 1024 - int.Parse(row[4]), 1024 - int.Parse(row[5]), int.Parse(row[6])));
                }
                else
                {
                    Data.Add(new imageData(row[0], row[1], row[2]));
                }
            }
        }

        public static void LoadCurrentData(string fileName)
        {
            currentData = new List<imageData>();
            var datas = Data.Where(item => item.ID == fileName);
            foreach (imageData data in datas)
            {
                currentData.Add(data);
            }
        }

        public static List<imageData> GetDatas()
        {
            return currentData;
        }
    }
}
