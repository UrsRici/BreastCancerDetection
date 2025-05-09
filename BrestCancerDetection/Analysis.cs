using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using System.Windows.Forms.DataVisualization.Charting;
using Licenta_Mamograf.Classes;
using BrestCancerDetection.Classes;
using Krypton.Toolkit;
using BrestCancerDetection;

namespace Licenta_Mamograf
{
    public partial class Image_Analysis : Form
    {
        #region Variabile Globale
        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\mdb005.pgm"));
        private PGM img = new PGM();
        DateTime t = new DateTime();

        private KryptonButton currentButton;

        public Point ROIstartPoint = new Point();
        public Point ROIendPoint = new Point();
        private float[,] ROI;
        #endregion

        #region Image Analysis Form
        public Image_Analysis()
        {
            InitializeComponent();


            img = new PGM(filePath);
            img.ShowImage(pictureBox);
        }
        private void Image_Analysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Image_Analysis_Resize(object sender, EventArgs e)
        {
            tabControl.Width = this.ClientSize.Width - pictureBox.Width - 30;
            int chartLocation = 50;
            int chartSpace = tabPage4.Height - chartLocation;
            chart_CumulativeHistogram.Height = chartSpace / 2;
            chart_Histogram.Height = chartSpace / 2;
            chart_CumulativeHistogram.Location = new Point(0, chartLocation);
            chart_Histogram.Location = new Point(0, chartLocation + chart_CumulativeHistogram.Height);
        }
        private void ImageVerify()
        {
            if (pictureBox.Image == null)
                MessageBox.Show("Please select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                img = new PGM(filePath);
                img.ShowImage(pictureBox);

                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

                // Afisare datele despre imaginea initiala din fisierul "data.txt"...
                List<imageData> a = ImageData.GetDatas();
            }
        }
        private void button_relode_Click(object sender, EventArgs e)
        {
            ImageVerify();

            ResetROI();

            img = new PGM(filePath);
            img.ShowImage(pictureBox);

            //info_log.Text += "------Image Reloded------\n";

            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

            // Afisare datele despre imaginea initiala din fisierul "data.txt"...
            List<imageData> a = ImageData.GetDatas();

        }
        private void button_save_Click(object sender, EventArgs e)
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

                    // Calea pentru imaginea combinată
                    string combinedImagePath = Path.Combine(newFolderPath, fileName + "_combine.jpg");
                    Bitmap combinedImage = new Bitmap(img.width, img.height);
                    for (int y = 0; y < img.height; y++)
                    {
                        for (int x = 0; x < img.width; x++)
                        {
                            if (img.mask.GetPixel(y, x).R != 0)
                                combinedImage.SetPixel(y, x, img.mask.GetPixel(y, x));
                            else
                            {
                                byte c = img.bitmap.GetPixel(x, y);
                                Color color = Color.FromArgb(c, c, c); // Conversie grayscale
                                combinedImage.SetPixel(y, x, color);
                            }
                        }
                    }
                    combinedImage.Save(combinedImagePath);

                    // Log info
                    MessageBox.Show("Images saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Preprocesare
        private void button_Preprocessing_Click(object sender, EventArgs e)
        {
            //info_log.Text += "------Preprocessing------\n";
            ImageVerify();

            t = DateTime.Now;
            img.Update(Preprocessing.Apply(img));
            string Time = (DateTime.Now - t).ToString() + " ms\n";

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
            string Time = (DateTime.Now - t).ToString() + " ms\n";

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
            string Time = (DateTime.Now - t).ToString() + " ms\n";

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
            label_Tissue.Text = "Tissue Type: " + output.PredictedLabel;
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

        #region Segmentare
        private void button_selectROI_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.ROIselect_Button_active = !pictureBox.ROIselect_Button_active;
                if (pictureBox.ROIselect_Button_active)
                {
                    pictureBox.Cursor = Cursors.Cross;
                }
                else
                {
                    pictureBox.Cursor = Cursors.Hand;

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
                }
            }
            else MessageBox.Show("Please select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void button_GrowCutOnROI_Click(object sender, EventArgs e)
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
        private void button_GrowCut_Click(object sender, EventArgs e)
        {
            ImageData.Load();
            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
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

        #region Button Hover
        private void button_MouseEnter(object sender, EventArgs e)
        {
            currentButton = sender as Krypton.Toolkit.KryptonButton;
            timer_hover.Start();
        }
        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            // Actualizăm locația etichetei în funcție de poziția mouse-ului
            if (currentButton != null && LabelInfoButton.Visible)
            {
                Point mouseLocation = new Point(e.X + currentButton.Location.X + 22, e.Y + currentButton.Location.Y + 22);
                LabelInfoButton.Location = mouseLocation;
            }
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            LabelInfoButton.Visible = false;
            timer_hover.Stop(); // Oprim timerul
        }
        private void timer_hover_Tick(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                LabelInfoButton.Text = ButtonsInfo.GetInfo(currentButton.Name);
                int numarRanduri = LabelInfoButton.GetLineFromCharIndex(LabelInfoButton.Text.Length);
                LabelInfoButton.Height = 22 + 13 * numarRanduri;
                LabelInfoButton.Visible = true;
            }
            timer_hover.Stop();
        }
        #endregion

        private void button_information_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.ShowDialog();
        }
        public bool isActive1 = false;
        public bool isActive2 = false;
        public bool isActive3 = false;
        public bool isActive4 = false;
        private void Active1()
        {
            if (isActive1)
            {
                button_select.Visible = false;
                button_relode.Visible = false;
                button_save.Visible = false;
            }
            else
            {
                button_select.Visible = true;
                button_relode.Visible = true;
                button_save.Visible = true;
            }
            isActive1 = !isActive1;
        }
        private void Active2()
        {
            if (isActive2)
            {
                button_Preprocessing.Visible = false;
                button_CLHE.Visible = false;
                button_CLAHE.Visible = false;
                label_ContrastLimit.Visible = false;
                label_WindowSize.Visible = false;
                contrastLimit.Visible = false;
                windowSize.Visible = false;
                button_typeTissue.Visible = false;
                label_Tissue.Visible = false;
                Tissue_Info.Visible = false;
            }
            else
            {
                button_Preprocessing.Visible = true;
                button_CLHE.Visible = true;
                button_CLAHE.Visible = true;
                label_ContrastLimit.Visible = true;
                label_WindowSize.Visible = true;
                contrastLimit.Visible = true;
                windowSize.Visible = true;
                button_typeTissue.Visible = true;
                label_Tissue.Visible = true;
                Tissue_Info.Visible = true;
            }
            isActive2 = !isActive2;
        }
        private void Active3()
        {
            if (isActive3)
            {
                button_GrowCut.Visible = false;
                button_GrowCutOnROI.Visible = false;
                button_RemoveROI.Visible = false;
                button_selectROI.Visible = false;
                label_H.Visible = false;
                label_W.Visible = false;
                label_x.Visible = false;
                label_y.Visible = false;
                startPoint.Visible = false;
                endPoint.Visible = false;
            }
            else
            {
                button_GrowCut.Visible = true;
                button_GrowCutOnROI.Visible = true;
                button_RemoveROI.Visible = true;
                button_selectROI.Visible = true;
                label_H.Visible = true;
                label_W.Visible = true;
                label_x.Visible = true;
                label_y.Visible = true;
                startPoint.Visible = true;
                endPoint.Visible = true;
            }
            isActive3 = !isActive3;
        }
        private void Active4()
        {
            if (isActive4)
            {
                button_show.Visible = false;                button_show.Location = new Point(25, 61);
                button_show_image.Visible = false;          button_show_image.Location = new Point(133, 61);
                button_show_mask.Visible = false;           button_show_mask.Location = new Point(241, 61);
                button_Charts.Visible = false;              button_Charts.Location = new Point(349, 61);
                chart_Histogram.Visible = false;            chart_Histogram.Location = new Point(9, 110);
                chart_CumulativeHistogram.Visible = false;  chart_CumulativeHistogram.Location = new Point(9, 284);
            }
            else
            {
                button_show.Visible = true;
                button_show_image.Visible = true;
                button_show_mask.Visible = true;
                button_Charts.Visible = true;
                chart_Histogram.Visible = true;
                chart_CumulativeHistogram.Visible = true;
            }
            isActive4 = !isActive4;
        }
        private void button_Initializare_Click(object sender, EventArgs e)
        {
            if (!isActive1) { Active1(); }
            if (isActive2) { Active2(); }
            if (isActive3) { Active3(); }
            if (isActive4) { Active4(); }
        }
        private void button_Procesare_Click(object sender, EventArgs e)
        {
            if (isActive1) { Active1(); }
            if (!isActive2) { Active2(); }
            if (isActive3) { Active3(); }
            if (isActive4) { Active4(); }
        }
        private void button_Segmentare_Click(object sender, EventArgs e)
        {
            if (isActive1) { Active1(); }
            if (isActive2) { Active2(); }
            if (!isActive3) { Active3(); }
            if (isActive4) { Active4(); }
        }
        private void button_Vizualizare_Click(object sender, EventArgs e)
        {
            if (isActive1) { Active1(); }
            if (isActive2) { Active2(); }
            if (isActive3) { Active3(); }
            if (!isActive4) { Active4(); }
        }
    }
}
