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
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace BreastCancerDetection
{
    public partial class Image_Analysis : Form
    {
        #region Variabile Globale
        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\mdb005.pgm"));
        private PGM img = new PGM();
        private Bitmap original_iamge;
        private Bitmap preproces_iamge;

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
            original_iamge = img.ToBitmap();

            img.ShowImage(pictureBox);
        }
        private void Image_Analysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Image_Analysis_Resize(object sender, EventArgs e)
        {
            tabControl.Width = this.ClientSize.Width - pictureBox.Width - 18;
            tabControl.Height = button_information.Location.Y - tabControl.Location.Y - 3;
            ModeleChart.Location = pictureBox.Location;
            ModeleChart.Size = pictureBox.Size;
        }
        private void ImageVerify()
        {
            if (pictureBox.Image == null)
                MessageBox.Show("Please select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void RunWithWaitCursor(Action action)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // schimbă cursorul
                Application.DoEvents();           // forțează refresh imediat
                action();                         // execută acțiunea dorită
            }
            finally
            {
                this.Cursor = Cursors.Default;    // revine la normal
            }
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
            this.Cursor = Cursors.WaitCursor;
            // Create an OpenFileDialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Set the filter to accept only.pgm files
                Filter = "Image Files (*.pgm;*.png;*.jpg;*.jpeg)|*.pgm;*.png;*.jpg;*.jpeg",
                Title = "Select a image"
            };

            ResetROI();
            // If the user selects a file and clicks OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                img = new PGM(filePath);
                img.ShowImage(pictureBox);

                original_iamge = img.ToBitmap();

                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
            }
            this.Cursor = Cursors.Default;
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
                    string originalImagePath = Path.Combine(newFolderPath, fileName + ".png");
                    img.bitmap.ToBitmap().Save(originalImagePath);

                    // Calea pentru imaginea mască
                    string maskImagePath = Path.Combine(newFolderPath, fileName + "_mask.png");
                    img.mask.Save(maskImagePath);

                    // Calea pentru imaginea combinată  // Calea pentru imaginea tumorii (pixelii reali din imagine)
                    string combinedImagePath = Path.Combine(newFolderPath, fileName + "_combine.png");
                    string tumorImagePath = Path.Combine(newFolderPath, fileName + "_tumor.png");
                    Bitmap combinedImage = new Bitmap(img.width, img.height);
                    Bitmap tumorImage = new Bitmap(img.width, img.height);
                    for (int y = 0; y < img.height; y++)
                    {
                        for (int x = 0; x < img.width; x++)
                        {
                            if (img.mask.GetPixel(y, x).R != 0)
                            {
                                combinedImage.SetPixel(y, x, img.mask.GetPixel(y, x));

                                byte c = img.bitmap.GetPixel(x, y);
                                Color color = Color.FromArgb(c, c, c);
                                tumorImage.SetPixel(y, x, color);
                            }
                            else
                            {
                                byte c = img.bitmap.GetPixel(x, y);
                                Color color = Color.FromArgb(c, c, c); // Conversie grayscale
                                combinedImage.SetPixel(y, x, color);

                                tumorImage.SetPixel(y, x, img.mask.GetPixel(y, x));
                            }
                        }
                    }
                    combinedImage.Save(combinedImagePath);
                    tumorImage.Save(tumorImagePath);

                    // Calea pentru imaginea preprocesată
                    if (preproces_iamge != null)
                    {
                        string preprocessedImagePath = Path.Combine(newFolderPath, fileName + "_preprocessed.png");
                        preproces_iamge.Save(preprocessedImagePath);
                    }

                    // Calea pentru imaginea originală (fără preprocesare)
                    if (original_iamge != null)
                    {
                        string originalImageUnprocessedPath = Path.Combine(newFolderPath, fileName + "_original.png");
                        original_iamge.Save(originalImageUnprocessedPath);
                    }

                    // Save charts as images
                    Button_Charts_Click(sender, e);
                    string cumulativeHistogramPath = Path.Combine(newFolderPath, fileName + "_cumulative_histogram.png");
                    string histogramPath = Path.Combine(newFolderPath, fileName + "_histogram.png");
                    chart_CumulativeHistogram.SaveImage(cumulativeHistogramPath, ChartImageFormat.Png);
                    chart_Histogram.SaveImage(histogramPath, ChartImageFormat.Png);

                    // Log info
                    MessageBox.Show("Images saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Preprocesare

        private void Button_autoProcessing_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                ImageVerify();

                Button_Preprocessing_Click(sender, e);  // Preprocessing
                Button_typeTissue_Click(sender, e);     // Tissue Type
                Button_CLAHE_Click(sender, e);          // CLAHE
                Button_GrowCut_Click(sender, e);        // GrowCut
                Button_Charts_Click(sender, e);         // Charts
            });
        }

        private void Button_Preprocessing_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                //info_log.Text += "------Preprocessing------\n";
                ImageVerify();

                img.Update(Preprocessing.Apply(img));
                preproces_iamge = img.ToBitmap();

                img.ShowImage(pictureBox);
            });
        }
        private void Button_CLHE_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                //info_log.Text += "-------------CLHE------------\n";
                ImageVerify();

                float cL = float.Parse(contrastLimit.Text);
                MyBitmap myBitmap = img.bitmap;

                CLHE.Apply(ref myBitmap, cL);

                img.Update(myBitmap);

                img.ShowImage(pictureBox);
            });
        }
        private void Button_CLAHE_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                //info_log.Text += "-------------CLAHE------------\n";
                ImageVerify();

                double cL = (double)contrastLimit.Value;
                int wS = (int)windowSize.Value;

                img.Update(MyClahe.Apply(img.ToBitmap(), cL, wS));

                img.ShowImage(pictureBox);
            });
        }
        private void Button_typeTissue_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
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
                label_Tissue.Text = output.PredictedLabel;
                Tissue_Info.Text = string.Empty;

                Tissue_Info.Text = string.Join("\n", info.Select(item => $"{item.Key}: {item.Value}%"));
                climpLimit = info.Sum(item => Limit[item.Key] * item.Value / 100f);

                contrastLimit.Text = Math.Round(climpLimit, 2).ToString();
                windowSize.Text = Size[output.PredictedLabel].ToString();

            });
        }
        #endregion

        #region Segmentare
        private void Button_selectROI_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
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
            });        
        }
        private void Button_RemoveROI_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
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
            });
        }
        private void Button_GrowCutOnROI_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                if (!pictureBox.IsROIfig()) { return; }
                if (pictureBox.ROIselect_Button_active) { Button_selectROI_Click(sender, e); }

                Point p0 = new Point(
                   Math.Min(ROIstartPoint.X, ROIendPoint.X),
                   Math.Min(ROIstartPoint.Y, ROIendPoint.Y));

                Point p1 = new Point(
                    Math.Max(ROIstartPoint.X, ROIendPoint.X),
                    Math.Max(ROIstartPoint.Y, ROIendPoint.Y));

                img.ApplyMask(GrowCut.Apply(img.matrix, (float)thresHold.Value, p0, p1));
                //img.ApplyMask(p0, p1, GrowCut.Apply(ROI, (float)thresHold.Value));
                pictureBox.ResetROIfig();
                img.Show(pictureBox);
            });
        }
        private void ResetROI()
        {
            if (pictureBox.ROIselect_Button_active)
                Button_selectROI_Click(new object(), new EventArgs());

            pictureBox.ResetROIfig();
        }
        private void Button_GrowCut_Click(object sender, EventArgs e)
        {
            RunWithWaitCursor(() =>
            {
                ImageData.Load();
                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
                float[,] mask = GrowCut.ApplyData(img.matrix, (float)thresHold.Value);

                img.ApplyMask(mask);
                pictureBox.ResetROIfig();
                img.Show(pictureBox);
            });
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

        private void button_Tumod_Info_Click(object sender, EventArgs e)
        {
            Mat grayMask = img.mask.ToMat();

            Mat binaryMask = new Mat();
            CvInvoke.Threshold(grayMask, binaryMask, 1, 255, ThresholdType.Binary);
            pictureBox.Image = binaryMask.Bitmap;

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(binaryMask, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            Mat image = img.ToBitmap().ToMat();
            Mat mat = image.Clone();
            CvInvoke.DrawContours(mat, contours, -1, new MCvScalar(0, 255, 0), 1);
            pictureBox.Image = mat.Bitmap;

            TumorsData tumorsData = new TumorsData(contours, image);

            TextBoxTumors.Text = tumorsData.ToString();
        }
        private void button_Fourier_Click(object sender, EventArgs e)
        {
            Fourier imgfourier = new Fourier(img.ToBitmap());
            imgfourier.CreateFilter((int)filter_number_a.Value, (int)filter_number_b.Value);

            Bitmap completImage = new Bitmap(2 * img.width, 2 * img.height);

            /*ImagePopup.Show(imgfourier.fourier, "Fourier");
            ImagePopup.Show(imgfourier.spectrum, "Spectrum");
            ImagePopup.Show(imgfourier.image, "Original Image");
            ImagePopup.Show(imgfourier.filteredImage, "Filtered Image");*/

            for (int y = 0; y < completImage.Height / 2; y++)
                for (int x = 0; x < completImage.Width / 2; x++)
                {
                    completImage.SetPixel(x, y, imgfourier.image.GetPixel(x, y));
                    completImage.SetPixel(x + img.width, y, imgfourier.fourier.GetPixel(x, y));
                    completImage.SetPixel(x, y + img.height, imgfourier.spectrum.GetPixel(x, y));
                    completImage.SetPixel(x + img.width, y + img.height, imgfourier.filteredImage.GetPixel(x, y));
                }
            pictureBox.Image = /*imgfourier.spectrum;*/completImage;
        }
        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            /*FolderBrowserDialog folderDialog = new FolderBrowserDialog
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

                string preprocessedImagePath = Path.Combine(newFolderPath, fileName + "_preprocessed.png");
                pictureBox.Image.Save(preprocessedImagePath);
            }*/
            SLIAnalyzer analyzer = new SLIAnalyzer();
            Bitmap bmp = analyzer.Analyze(img.ToBitmap());

            ImagePopup.Show(bmp, "SLI Analysis");

            analyzer.ShowStatisticsPopup();

            /*analyzer.ShowFeatureChart("Contrast");
            analyzer.ShowFeatureChart("Entropy");
            analyzer.ShowFeatureChart("Homogeneity");*/

            /*if (pictureBox.ROIselect_Button_active)
                Button_selectROI_Click(new object(), new EventArgs());

            double score = analyzer.GetSuspicionScore(ROI);

            MessageBox.Show("Suspicion score = " + score);*/
        }

        public void Button_Charts(ModelMath solver)
        {
            var solution = solver.SolveMain();
            var trajectories = solver.SolvePhase();

            // 🔵 chart1
            chart1.Series.Clear();
            chart1.SuspendLayout();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            chart1.ChartAreas[0].AxisX.Interval = chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisX.Title = "Timp";
            chart1.ChartAreas[0].AxisY.Title = "Populație";
            chart1.ChartAreas[0].AxisX.TitleFont = chart1.ChartAreas[0].AxisY.TitleFont = new Font("Times New ROman", 12, FontStyle.Bold);

            var s1 = chart1.Series.Add("f(x,y)");
            var s2 = chart1.Series.Add("g(x,y)");

            s1.ChartType = s2.ChartType = SeriesChartType.Line;
            s1.BorderWidth = s2.BorderWidth = 4;

            foreach (var p in solution)
            {
                s1.Points.AddXY(p.t, p.x);
                s2.Points.AddXY(p.t, p.y);
            }

            chart1.ResumeLayout();

            // 🔴 chart2
            chart2.Series.Clear();
            chart2.SuspendLayout();
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = chart2.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            chart2.ChartAreas[0].AxisX.Minimum = chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart2.ChartAreas[0].AxisX.Interval = chart2.ChartAreas[0].AxisY.Interval = 10;
            chart2.Legends.Clear();

            int index = 0;

            foreach (var traj in trajectories)
            {
                var s = chart2.Series.Add("traj" + index++);
                s.ChartType = SeriesChartType.Line;
                s.BorderWidth = 3;

                foreach (var p in traj)
                {
                    s.Points.AddXY(p.x, p.y);
                }
            }

            chart2.ResumeLayout();

            // 📄 tabel

            foreach (var p in solution)
            {
                dataGridView.Rows.Add(p.t, p.x, p.y);
            }
        }
        private void Button_predictie_Click(object sender, EventArgs e)
        {
            ModeleChart.Visible = true;

            ModelMath solver = new ModelMath
            {
                F1Expr = f_function.Text,
                F2Expr = g_function.Text,

                TEnd = (double)T_number.Value,

                X0 = (double)x0_number.Value,
                Y0 = (double)y0_number.Value,
            };

            solver.Initialize();

            Button_Charts(solver);
        }
        private void Button_close_Click(object sender, EventArgs e)
        {
            ModeleChart.Visible = false;
        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
            f_function.Text = "0.1*x*(1-(x+y)/100)-0.2*x";
            g_function.Text = "0.15*y*(1-(x+y)/100)-0.3*y";
            Button_predictie_Click(sender, e);
        }
        private void ButtonB_Click(object sender, EventArgs e)
        {
            f_function.Text = "0.5*x*(1-(x+y)/100)-0.05*x";
            g_function.Text = "0.6*y*(1-(x+y)/100)-0.18*y";
            Button_predictie_Click(sender, e);
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            f_function.Text = "0.4*x*(1-(x+y)/100)-0.16*x";
            g_function.Text = "0.6*y*(1-(x+y)/100)-0.12*y";
            Button_predictie_Click(sender, e);
        }
        private void ButtonD_Click(object sender, EventArgs e)
        {
            f_function.Text = "0.5*x*(1-(x+y)/100)-0.1*x";
            g_function.Text = "1.0*y*(1-(x+y)/100)-0.2*y";
            Button_predictie_Click(sender, e);
        }
    }
}
