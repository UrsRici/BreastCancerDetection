using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using System.Windows.Forms.DataVisualization.Charting;
using BrestCancerDetection.Classes;

namespace BrestCancerDetection
{
    public partial class Image_Analysis : Form
    {
        #region Variabile Globale
        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\mdb005.pgm"));
        private PGM img = new PGM();
        DateTime t = new DateTime();

        public Point ROIstartPoint = new Point();
        public Point ROIendPoint = new Point();
        private float[,] ROI;
        #endregion

        #region Image Analysis Form
        public Image_Analysis()
        {
            InitializeComponent();
            Image_Analysis_Resize(new object(), new EventArgs());
            ImageData.Load();
            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

            // Afisare datele despre imaginea initiala din fisierul "data.txt"...
            /*List<imageData> a = ImageData.GetDatas();
            for (int i = 0; i < a.Count; i++)
                info_log.Text += a[i].ToString() + "\n";
            */
            location.Text = filePath;

            img = new PGM(filePath);
            img.ShowImage(pictureBox);
        }
        private void Image_Analysis_Resize(object sender, EventArgs e)
        {
            tabControl.Width = this.ClientSize.Width - pictureBox.Width - pictureBox.Location.Y * 3;
            int chartLocation = button_show_image.Location.Y + button_show_mask.Location.Y + button_show_mask.Height;
            int chartSpace = tabPage4.Height - chartLocation;
            chart_CumulativeHistogram.Height = chartSpace / 2 - 6;
            chart_Histogram.Height = chartSpace / 2 - 6;
            chart_CumulativeHistogram.Location = new Point(chart_CumulativeHistogram.Location.X, chartLocation);
            chart_Histogram.Location = new Point(chart_CumulativeHistogram.Location.X, chartLocation + chart_CumulativeHistogram.Height + 6);
        }
        private void ImageVerify()
        {
            if (pictureBox.Image == null)
                info_log.Text += "No image selected!\n";
        }
        #endregion

        #region Selectare Imagini
        private void button_select_Click(object sender, EventArgs e)
        {
            t = DateTime.Now; 
            // Create an OpenFileDialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to accept only.pgm files
            openFileDialog.Filter = "PGM Files (*.pgm)|*.pgm";
            openFileDialog.Title = "Select a PGM File";

            ResetROI();
            // If the user selects a file and clicks OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                location.Text = filePath;

                img = new PGM(filePath);
                img.ShowImage(pictureBox);

                info_log.Text += "------Image Load------\n";

                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

                // Afisare datele despre imaginea initiala din fisierul "data.txt"...
                List<imageData> a = ImageData.GetDatas();
                for (int i = 0; i < a.Count; i++)
                    info_log.Text += a[i].ToString() + "\n";
            }
            info_log.Text = (DateTime.Now - t).ToString();
        }
        private void button_relode_Click(object sender, EventArgs e)
        {
            ImageVerify();
            location.Text = filePath;

            ResetROI();

            img = new PGM(filePath);
            img.ShowImage(pictureBox);

            //info_log.Text += "------Image Reloded------\n";

            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

            // Afisare datele despre imaginea initiala din fisierul "data.txt"...
            List<imageData> a = ImageData.GetDatas();
            for (int i = 0; i < a.Count; i++)
                info_log.Text += a[i].ToString() + "\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Select a folder to save the images";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Numele fișierului fără extensie (ex: mdb005)
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Creează un folder nou în locația aleasă, cu numele fișierului
                    string newFolderPath = Path.Combine(folderDialog.SelectedPath, fileName);
                    Directory.CreateDirectory(newFolderPath);

                    // Calea pentru imaginea originală
                    string originalImagePath = Path.Combine(newFolderPath, fileName + ".jpg");
                    img.bitmap.ToBitmap().Save(originalImagePath);

                    // Calea pentru imaginea mască
                    string maskImagePath = Path.Combine(newFolderPath, fileName + "_mask.jpg");
                    img.mask.Save(maskImagePath);

                    // Log info
                    info_log.Text += "Original image saved to: " + originalImagePath + "\n";
                    info_log.Text += "Mask image saved to: " + maskImagePath + "\n";
                }
            }
        }
        private void button_log_Click(object sender, EventArgs e)
        {
            info_log.Text = string.Empty;
        }
        #endregion

        #region Preprocesare
        private void button_Preprocessing_Click(object sender, EventArgs e)
        {
            //info_log.Text += "------Preprocessing------\n";
            ImageVerify();

            t = DateTime.Now;
            img.Update(Preprocessing.Apply(img));
            info_log.Text += (DateTime.Now - t).ToString() + " ms\n";

            img.ShowImage(pictureBox);
        }
        private void button_CLHE_Click(object sender, EventArgs e)
        {
            //info_log.Text += "-------------CLHE------------\n";
            ImageVerify();

            float cL = float.Parse(contrastLimit.Text);
            MyBitmap myBitmap = img.bitmap;

            t = DateTime.Now;
            CLHE.Apply(ref myBitmap, cL);
            info_log.Text += (DateTime.Now - t).ToString() + " ms\n";

            img.Update(myBitmap);

            img.ShowImage(pictureBox);
        }
        private void button_CLAHE_Click(object sender, EventArgs e)
        {
            //info_log.Text += "-------------CLAHE------------\n";
            ImageVerify();

            double cL = double.Parse(contrastLimit.Text);
            int wS = int.Parse(windowSize.Text);

            t = DateTime.Now;
            img.Update(MyClahe.Apply(img.ToBitmap(), cL, wS));
            info_log.Text += (DateTime.Now - t).ToString() + " ms\n";

            img.ShowImage(pictureBox);
        }
        private void button_typeTissue_Click(object sender, EventArgs e)
        {
            Dictionary<string, float> Limit = new Dictionary<string, float>
            {
                { "Fatty", 2f },
                { "Fatty-Glandular", 3.5f },
                { "Dense-Glandular", 4.5f }
            };
            Dictionary<string, int> Size = new Dictionary<string, int>
            {
                { "Fatty", 4 },
                { "Fatty-Glandular", 6 },
                { "Dense-Glandular", 8 }
            };

            float climpLimit = 0f;
            ModelOutput output = MLTissue.Predict(img.ToModelInput());
            var info = MLTissue.GetSortedScoresWithLabels(output);
            label_Tissue0.Text = "Tissue Type: " + output.PredictedLabel;
            Tissue_Info.Text = string.Empty;
            foreach (var item in info)
            { 
                Tissue_Info.Text += $"{item.Key}: {item.Value}%\n";
                climpLimit += Limit[item.Key] * item.Value / 100f;
            }
            contrastLimit.Text = Math.Round(climpLimit, 1).ToString();
            windowSize.Text = Size[output.PredictedLabel].ToString();

        }
        #endregion

        #region AI
        private void button_selectROI_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.ROIselect_Button_active = !pictureBox.ROIselect_Button_active;
                if (pictureBox.ROIselect_Button_active)
                {
                    pictureBox.Cursor = Cursors.Cross;
                    /*
                     * SelectROI_button.BackColor = Color.Gray;
                     * SelectROI_button.ForeColor = Color.White;
                     */
                }
                else
                {
                    pictureBox.Cursor = Cursors.Hand;
                    /*
                     * SelectROI_button.BackColor = BackColor;
                     * SelectROI_button.ForeColor = Color.Black;
                     */
                    Point p = new Point(
                        Math.Min(ROIendPoint.X, ROIstartPoint.X),
                        Math.Min(ROIendPoint.Y, ROIstartPoint.Y));

                    ROI = new float[
                        Math.Abs(ROIendPoint.Y - ROIstartPoint.Y),
                        Math.Abs(ROIendPoint.X - ROIstartPoint.X)];

                    MyBitmap aux = img.bitmap;

                    for (int y = 0; y < ROI.GetLength(0); y++)
                        for (int x = 0; x < ROI.GetLength(1); x++)
                            ROI[y, x] = aux.GetPixel((p.Y + y), (p.X + x));

                    info_log.Text += ROI.GetLength(0) + " " + ROI.GetLength(1) + "\n";

                }
            }
            else info_log.Text += "No image selected!\n";
        }
        private void button_RemoveROI_Click(object sender, EventArgs e)
        {
            if (!pictureBox.IsROIfig()) { return; }

            Point p0 = new Point(
                Math.Min(ROIstartPoint.X, ROIendPoint.X),
                Math.Min(ROIstartPoint.Y, ROIendPoint.Y));

            Point p1 = new Point(
                Math.Max(ROIstartPoint.X, ROIendPoint.X),
                Math.Max(ROIstartPoint.Y, ROIendPoint.Y));

            img.RemoveArea(p0, p1);
            pictureBox.ResetROIfig();
            img.ShowImage(pictureBox);
        }
        private void button_AIonROI_Click(object sender, EventArgs e)
        {

            if (!pictureBox.IsROIfig()) { return; }
            if (pictureBox.ROIselect_Button_active) { button_selectROI_Click(sender, e); }

            Point p0 = new Point(
               Math.Min(ROIstartPoint.X, ROIendPoint.X),
               Math.Min(ROIstartPoint.Y, ROIendPoint.Y));

            Point p1 = new Point(
                Math.Max(ROIstartPoint.X, ROIendPoint.X),
                Math.Max(ROIstartPoint.Y, ROIendPoint.Y));

            //float[,] mask = GrowCut.Apply(ROI);
            img.ApplyMask(p0, p1, GrowCut.Apply(ROI));
            pictureBox.ResetROIfig();
            img.Show(pictureBox);
        }
        private void ResetROI()
        {
            if (pictureBox.ROIselect_Button_active)
                button_selectROI_Click(new object(), new EventArgs());

            pictureBox.ResetROIfig();
        }
        private void button_AI_Click(object sender, EventArgs e)
        {
            float[,] mask = GrowCut.ApplyData(img.matrix);

            img.ApplyMask(mask);
            pictureBox.ResetROIfig();
            img.Show(pictureBox);
        }
        #endregion

        #region Diagrame
        private void button_Charts_Click(object sender, EventArgs e)
        {
            float[] histogram = img.Histogram();
            float[] cumulativeHistogram = img.CumulativeHistogram();

            Series his = chart_Histogram.Series["Pixel"];
            Series cHis = chart_CumulativeHistogram.Series["Pixel"];

            his.Points.Clear();
            cHis.Points.Clear();

            for (int i = 0; i < histogram.Length; i++)
            {
                his.Points.AddXY(i, histogram[i]);
                cHis.Points.AddXY(i, cumulativeHistogram[i]);
            }

            chart_CumulativeHistogram.ChartAreas[0].AxisY.Minimum = cumulativeHistogram.Min();
            chart_CumulativeHistogram.ChartAreas[0].AxisY.Maximum = cumulativeHistogram.Max();
            histogram[0] = histogram[1];
            chart_Histogram.ChartAreas[0].AxisY.Maximum = histogram.Max() + histogram.Max() * .05;

            PointPairList points = new PointPairList();
            for (int i = 0; i < cumulativeHistogram.Length; i++)
            {
                points.Add(i, cumulativeHistogram[i]);
            }
        }
        #endregion

        #region Vizualizare Imagini
        private void button_show_image_Click(object sender, EventArgs e)
        {
            img.ShowImage(pictureBox);
        }
        private void button_show_mask_Click(object sender, EventArgs e)
        {
            pictureBox.BackColor = Color.Black;
            img.ShowMask(pictureBox);
        }
        private void button_show_Click(object sender, EventArgs e)
        {
            img.Show(pictureBox);
        }
        #endregion

        #region ImageBox Events
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Calculăm coordonatele reale ale pixelului în funcție de zoom...
                ROIstartPoint = pictureBox.AdjustPoint(e.Location);

                // Afișăm coordonatele în startPoint.Text
                startPoint.Text = "P1(" + ROIstartPoint.X + "," + ROIstartPoint.Y + ")";
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Checking if the pictureBox.ROIendPoint is inside the pictureBox...
                ROIendPoint = pictureBox.AdjustPoint(e.Location);


                label_x.Text = Math.Abs(ROIendPoint.X - ROIstartPoint.X).ToString();
                label_y.Text = Math.Abs(ROIendPoint.Y - ROIstartPoint.Y).ToString();

                endPoint.Text = "P2(" + ROIendPoint.X + "," + ROIendPoint.Y + ")";

                Point location = new Point(
                    Math.Min(ROIstartPoint.X, ROIendPoint.X),
                    Math.Min(ROIstartPoint.Y, ROIendPoint.Y));
                Size size = new Size(
                    Math.Abs(ROIstartPoint.X - ROIendPoint.X),
                    Math.Abs(ROIstartPoint.Y - ROIendPoint.Y));

                pictureBox.SetROIfig(location, size);

                pictureBox.Invalidate();
            }
        }
        #endregion

    }
}
