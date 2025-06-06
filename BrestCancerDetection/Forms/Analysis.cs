using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using System.Windows.Forms.DataVisualization.Charting;
using BreastCancerDetection.Classes;
using Krypton.Toolkit;
using BreastCancerDetection;
using OpenTK;

namespace BreastCancerDetection
{
    public partial class Image_Analysis : Form
    {
        #region Variabile Globale
        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\mdb005.pgm"));
        private PGM img = new PGM();
        
        public Point ROIstartPoint = new Point();
        public Point ROIendPoint = new Point();
        private float[,] ROI;

        private Point lastMousePosition;
        private KryptonButton currentButton;
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
            tabControl.Width = this.ClientSize.Width - pictureBox.Width - 18;
            chart_CumulativeHistogram.Width = tabControl.Width;
            chart_Histogram.Width = tabControl.Width;
            tabControl.Height = button_information.Location.Y - tabControl.Location.Y - 3;
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
        private void Button_information_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.ShowDialog();
        }
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            bool isSelected = (e.Index == tabControl.SelectedIndex);
            Color backColor = isSelected ? Color.Teal : Color.LightGray;
            Color borderColor = Color.Teal;
            Color textColor = isSelected ? Color.White : Color.Black;

            using (SolidBrush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, tabRect);

            using (Pen pen = new Pen(borderColor, 2))
                e.Graphics.DrawRectangle(pen, tabRect);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl.Font, tabRect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        #endregion

        #region Selectare Imagini
        private void Button_select_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Set the filter to accept only.pgm files
                Filter = "PGM Files (*.pgm)|*.pgm",
                Title = "Select a PGM File"
            };

            ResetROI();
            // If the user selects a file and clicks OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                img = new PGM(filePath);
                img.ShowImage(pictureBox);

                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
            }
        }
        private void Button_relode_Click(object sender, EventArgs e)
        {
            ImageVerify();

            ResetROI();

            img = new PGM(filePath);
            img.ShowImage(pictureBox);

            //info_log.Text += "------Image Reloded------\n";

            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
        }
        private void Button_save_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog
                { 
                    Description = "Select a folder to save the images" 
                };

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
        private void Button_Preprocessing_Click(object sender, EventArgs e)
        {
            //info_log.Text += "------Preprocessing------\n";
            ImageVerify();

            img.Update(Preprocessing.Apply(img));

            img.ShowImage(pictureBox);
        }
        private void Button_CLHE_Click(object sender, EventArgs e)
        {
            //info_log.Text += "-------------CLHE------------\n";
            ImageVerify();

            float cL = float.Parse(contrastLimit.Text);
            MyBitmap myBitmap = img.bitmap;

            CLHE.Apply(ref myBitmap, cL);

            img.Update(myBitmap);

            img.ShowImage(pictureBox);
        }
        private void Button_CLAHE_Click(object sender, EventArgs e)
        {
            //info_log.Text += "-------------CLAHE------------\n";
            ImageVerify();

            double cL = double.Parse(contrastLimit.Text);
            int wS = int.Parse(windowSize.Text);

            img.Update(MyClahe.Apply(img.ToBitmap(), cL, wS));

            img.ShowImage(pictureBox);
        }
        private void Button_typeTissue_Click(object sender, EventArgs e)
        {
            Dictionary<string, float> Limit = new Dictionary<string, float>
            {
                { "Fatty", 5f },
                { "Fatty-Glandular", 3f },
                { "Dense-Glandular", 2f }
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

            Tissue_Info.Text = string.Join("\n", info.Select(item => $"{item.Key}: {item.Value}%"));
            climpLimit = info.Sum(item => Limit[item.Key] * item.Value / 100f);

            contrastLimit.Text = Math.Round(climpLimit, 2).ToString();
            windowSize.Text = Size[output.PredictedLabel].ToString();

        }
        #endregion

        #region Segmentare
        private void Button_selectROI_Click(object sender, EventArgs e)
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
        private void Button_RemoveROI_Click(object sender, EventArgs e)
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
        private void Button_GrowCutOnROI_Click(object sender, EventArgs e)
        {

            if (!pictureBox.IsROIfig()) { return; }
            if (pictureBox.ROIselect_Button_active) { Button_selectROI_Click(sender, e); }

            Point p0 = new Point(
               Math.Min(ROIstartPoint.X, ROIendPoint.X),
               Math.Min(ROIstartPoint.Y, ROIendPoint.Y));

            Point p1 = new Point(
                Math.Max(ROIstartPoint.X, ROIendPoint.X),
                Math.Max(ROIstartPoint.Y, ROIendPoint.Y));

            img.ApplyMask(p0, p1, GrowCut.Apply(ROI));
            pictureBox.ResetROIfig();
            img.Show(pictureBox);
        }
        private void ResetROI()
        {
            if (pictureBox.ROIselect_Button_active)
                Button_selectROI_Click(new object(), new EventArgs());

            pictureBox.ResetROIfig();
        }
        private void Button_GrowCut_Click(object sender, EventArgs e)
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
        private void Button_Charts_Click(object sender, EventArgs e)
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
        private void Button_show_image_Click(object sender, EventArgs e)
        {
            img.ShowImage(pictureBox);
        }
        private void Button_show_mask_Click(object sender, EventArgs e)
        {
            pictureBox.BackColor = Color.Black;
            img.ShowMask(pictureBox);
        }
        private void Button_show_Click(object sender, EventArgs e)
        {
            img.Show(pictureBox);
        }
        #endregion

        #region ImageBox Events
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Calculăm coordonatele reale ale pixelului în funcție de zoom...
                ROIstartPoint = pictureBox.AdjustPoint(e.Location);

                // Afișăm coordonatele în startPoint.Text
                startPoint.Text = "P1(" + ROIstartPoint.X + "," + ROIstartPoint.Y + ")";
            }
        }
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
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

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            currentButton = sender as KryptonButton;
            timer_hover.Start();
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition != e.Location)
            {
                LabelInfoButton.Visible = false;
                currentButton.Cursor = Cursors.Hand;
                lastMousePosition = e.Location;
                timer_hover.Start();
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            LabelInfoButton.Visible = false;
            currentButton.Cursor = Cursors.Hand;
            timer_hover.Stop();
        }
        private void Timer_hover_Tick(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                LabelInfoButton.Location = new Point(
                    lastMousePosition.X + currentButton.Location.X + 28, 
                    lastMousePosition.Y + currentButton.Location.Y + 68);
                LabelInfoButton.Text = ButtonsInfo.GetInfo(currentButton.Name);
                int numarRanduri = LabelInfoButton.GetLineFromCharIndex(LabelInfoButton.Text.Length);
                LabelInfoButton.Height = 20 + 13 * numarRanduri;
                LabelInfoButton.Visible = true;
                currentButton.Cursor = Cursors.Help;
            }
            timer_hover.Stop();
        }
        #endregion
    }
}
