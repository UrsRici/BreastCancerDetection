using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using OpenTK;
using System.Windows.Forms.DataVisualization.Charting;
using Licenta_Mamograf.Classes;

namespace Licenta_Mamograf
{
    public partial class Image_Analysis : Form
    {
        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\mdb005.pgm"));
        private PGM img = new PGM();
        DateTime t = new DateTime();

        public Point ROIstartPoint = new Point();
        public Point ROIendPoint = new Point();
        private float[,] ROI;
        
        public Image_Analysis()
        {
            InitializeComponent();
            ImageData.Load();
            ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));
            img = new PGM(filePath);
            img.ShowImage(pictureBox);
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            t = DateTime.Now;
            // Create an OpenFileDialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to accept only.pgm files
            openFileDialog.Filter = "PGM Files (*.pgm)|*.pgm";
            openFileDialog.Title = "Select a PGM File";

            // If the user selects a file and clicks OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                button_relode_Click(sender, e);

                location.Text = filePath;
                
                ImageData.LoadCurrentData(Path.GetFileNameWithoutExtension(filePath));

                info_log.Text += "------Image Load------\n";
            }
            info_log.Text = (DateTime.Now - t).ToString() + " ms\n";
        }
        private void button_relode_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                info_log.Text += "No image selected!\n";
                return;
            }
            if (pictureBox.ROIselect_Button_active) { button_selectROI_Click(sender, e); }
            pictureBox.ResetROIfig();

            img = new PGM(filePath);
            img.ShowImage(pictureBox);

            info_log.Text += "------Image Reloded------\n";
            /*
             * info_log.Text += img.magicNumber + "\n";
             * info_log.Text += img.width + " " + img.height + "\n";
             * info_log.Text += img.maxVal + "\n";
             */
        }

        private void button_Preprocessing_Click(object sender, EventArgs e)
        {
            info_log.Text += "------Preprocessing------\n";
            if (pictureBox.Image == null)
            { 
                info_log.Text += "No image selected!\n";
                return; 
            }

            t = DateTime.Now;
            img.Update(Preprocessing.Apply(img));    
            info_log.Text += (DateTime.Now - t).ToString() + " ms\n";

            img.ShowImage(pictureBox);
        }

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
                        Math.Abs(ROIendPoint.X - ROIstartPoint.X),
                        Math.Abs(ROIendPoint.Y - ROIstartPoint.Y)];

                    MyBitmap aux = img.bitmap;
                    for (int x = 0; x < ROI.GetLength(0); x++)
                    {
                        for (int y = 0; y < ROI.GetLength(1); y++)
                        {
                            ROI[x, y] = aux.GetPixel((p.X + x), (p.Y + y));
                            //info_log.Text += ROI[x, y] + " ";
                        }
                        //info_log.Text += "\n";
                    }
   
                    info_log.Text += ROI.GetLength(0)+ " " + ROI.GetLength(1);

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
        private void button_AI_on_ROI_Click(object sender, EventArgs e)
        {
            
            if (!pictureBox.IsROIfig()) { return; }
            if (pictureBox.ROIselect_Button_active) { button_selectROI_Click(sender, e); }

            Point p0 = new Point(
               Math.Min(ROIstartPoint.X, ROIendPoint.X),
               Math.Min(ROIstartPoint.Y, ROIendPoint.Y));

            Point p1 = new Point(
                Math.Max(ROIstartPoint.X, ROIendPoint.X),
                Math.Max(ROIstartPoint.Y, ROIendPoint.Y));    

            // float[,] mask = GrowCut.Apply(ROI);
            img.ApplyMask(p0, p1, GrowCut.Apply(ROI));
            pictureBox.ResetROIfig();
            img.Show(pictureBox);
        }

        private void button_AI_Click(object sender, EventArgs e)
        {
            float[,] mask = GrowCut.ApplyData(img.matrix);
            
            img.ApplyMask(mask);
            pictureBox.ResetROIfig();
            img.Show(pictureBox);
        }

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

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Calculăm coordonatele reale ale pixelului în funcție de zoom...
                ROIstartPoint = pictureBox.AdjustPoint(e.Location);

                // Afișăm coordonatele în startPoint.Text
                startPoint.Text = "P1(" + ROIstartPoint.X + ", " + ROIstartPoint.Y + ")";
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

        private void button_log_Click(object sender, EventArgs e)
        {
            info_log.Text = string.Empty;
        }

        private void button_CLHE_Click(object sender, EventArgs e)
        {
            info_log.Text += "-------------CLHE------------\n";
            if (pictureBox.Image == null)
            {
                info_log.Text += "Use Wavelet Denoising first!\n";
                return;
            }

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
            info_log.Text += "-------------CLAHE------------\n";
            if (pictureBox.Image == null)
            {
                info_log.Text += "Use Wavelet Denoising first!\n";
                return;
            }

            double cL = double.Parse(contrastLimit.Text);
            int wS = int.Parse(windowSize.Text);
            t = DateTime.Now;

            /*MyBitmap myBitmap = img.bitmap;

            CLAHE.Apply(ref myBitmap, wS, cL);
            
            img.Update(MyClahe.Apply(img.ToBitmap(), contrastLimit.Text, 8));*/


            img.Update(MyClahe.Apply(img.ToBitmap(), cL, wS));

            info_log.Text += (DateTime.Now - t).ToString() + " ms\n";

            img.ShowImage(pictureBox);
        }

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
            chart_Histogram.ChartAreas[0].AxisY.Maximum = 15000;

            PointPairList points = new PointPairList();
            for (int i = 0; i < cumulativeHistogram.Length; i++) 
            {
                points.Add(i, cumulativeHistogram[i]);
            }
        }

    }
}
