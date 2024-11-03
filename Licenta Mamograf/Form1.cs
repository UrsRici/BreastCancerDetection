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
using Emgu.CV.UI;
using Emgu.CV;
using ZedGraph;
using OpenTK;
using System.Windows.Forms.DataVisualization.Charting;
using Emgu.CV.Flann;

namespace Licenta_Mamograf
{
    public partial class Image_Analysis : Form
    {
        private string filePath = "D:\\Aplicatii\\Facultate\\Informatica\\Licenta\\archive\\all-mias\\mdb005.pgm";
        private PGM img = new PGM();
        DateTime t0 = new DateTime(), t1 = new DateTime();

        public Point ROIstartPoint = new Point();
        public Point ROIendPoint = new Point();
        private float[,] ROI;

        public Image_Analysis()
        {
            InitializeComponent();
            img = new PGM(filePath);
            img.Show(pictureBox);
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            t0 = DateTime.Now;
            // Create an OpenFileDialog to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to accept only.pgm files
            openFileDialog.Filter = "PGM Files (*.pgm)|*.pgm";
            openFileDialog.Title = "Select a PGM File";

            // If the user selects a file and clicks OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                img = new PGM(filePath);
                img.Show(pictureBox);

                textBox1.Text = filePath;
                
                info_log.Text += "------Image Load------\n";
                /*
                 * info_log.Text += Path.GetFileName(filePath) + "\n";
                 * info_log.Text += img.magicNumber + "\n";
                 * info_log.Text += img.width + " " + img.height + "\n";
                 * info_log.Text += img.maxVal + "\n";
                 */
            }

            t1 = DateTime.Now;

            info_log.Text = (t1 - t0).ToString() + " ms\n";
        }

        private void button_WaveletDenoising_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            { 
                info_log.Text += "No image selected!\n";
                return; 
            }
            
            // Selecting the current image and applying the WaveletDenoising algorithm...
            img.Update(HaarWavelet.Denoising(img));

            
            img.Show(pictureBox);

            info_log.Text += "------Wavelet Denoising------\n";
            /*
             * info_log.Text += imgWD.magicNumber + "\n";
             * info_log.Text += imgWD.width + " " + imgWD.height + "\n";
             * info_log.Text += imgWD.maxVal + "\n";
             */

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

        private void button_relode_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                info_log.Text += "No image selected!\n";
                return; 
            }
            pictureBox.ResetROIfig();

            img = new PGM(filePath);
            img.Show(pictureBox);

            //curent_img = new PGM(original_img);

            info_log.Text += "------Image Reloded------\n";
            /*
             * info_log.Text += img.magicNumber + "\n";
             * info_log.Text += img.width + " " + img.height + "\n";
             * info_log.Text += img.maxVal + "\n";
             */
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            info_log.Text = string.Empty;
        }

        private void button_CLHE_Click(object sender, EventArgs e)
        {
            DateTime t0 = DateTime.Now;
            if (pictureBox.Image == null)
            {
                info_log.Text += "Use Wavelet Denoising first!\n";
                return;
            }

            double cL = double.Parse(contrastLimit.Text);
            MyBitmap myBitmap = img.bitmap;
            CLHE.Apply(ref myBitmap, cL);
            img.Update(myBitmap);

            img.Show(pictureBox);

            DateTime t1 = DateTime.Now;
            info_log.Text += (t1 - t0).ToString() + " ms\n";
        }

        private void button_CLAHE_Click(object sender, EventArgs e)
        {
            DateTime t0 = DateTime.Now;
            if (pictureBox.Image == null)
            {
                info_log.Text += "Use Wavelet Denoising first!\n";
                return;
            }

            double cL = double.Parse(contrastLimit.Text);
            int wS = int.Parse(windowSize.Text);

            MyBitmap myBitmap = img.bitmap;
            CLAHE.Apply(ref myBitmap, wS, cL);
            img.Update(myBitmap);

            img.Show(pictureBox);
            DateTime t1 = DateTime.Now;
            info_log.Text += (t1 - t0).ToString() + " ms\n";
        }

        private void button_Charts_Click(object sender, EventArgs e)
        {
            double[] histogram = img.Histogram();
            double[] cumulativeHistogram = img.CumulativeHistogram();

            Series his = chart_Histogram.Series["Pixel"];
            Series cHis = chart_CumulativeHistogram.Series["Pixel"];

            his.Points.Clear();
            cHis.Points.Clear();

            for (int i = 0; i < histogram.Length; i++)
            {
                his.Points.AddXY(i, histogram[i]);
                cHis.Points.AddXY(i, cumulativeHistogram[i]);
            }
            histogram[0] = histogram[1];
            his.Points[0].YValues[0] = his.Points[1].YValues[0];
            his.Points[0].YValues[0] = histogram.Max();

            chart_CumulativeHistogram.ChartAreas[0].AxisY.Minimum = cumulativeHistogram.Min();
            chart_CumulativeHistogram.ChartAreas[0].AxisY.Maximum = cumulativeHistogram.Max();
        }

    }
}
