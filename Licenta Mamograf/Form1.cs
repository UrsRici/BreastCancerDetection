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


namespace Licenta_Mamograf
{
    public partial class Image_Analysis : Form
    {
        private string filePath = string.Empty;
        private PGM img = new PGM();
        private PGM imgWD = new PGM();
        private PGM imgEnh = new PGM();
        private PGM curent_img = new PGM();

        private PointF ROIstartPoint = new PointF();
        private PointF ROIendPoint = new PointF();
        private Rectangle ROIfig = new Rectangle();
        private float[,] ROI;
        private Brush ROIselectionBrush = new SolidBrush(Color.FromArgb(75, 255, 255, 50));

        public Image_Analysis()
        {
            InitializeComponent();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
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
                curent_img = new PGM(img);

                textBox1.Text = filePath;
                
                info_log.Text += "------Image Load------\n";
                /*
                 * info_log.Text += Path.GetFileName(filePath) + "\n";
                 * info_log.Text += img.magicNumber + "\n";
                 * info_log.Text += img.width + " " + img.height + "\n";
                 * info_log.Text += img.maxVal + "\n";
                 */
            }
        }

        private void button_WaveletDenoising_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            { 
                info_log.Text += "No image selected!\n";
                return; 
            }
            
            // Selecting the current image and applying the WaveletDenoising algorithm...
            HaarWavelet haarWavelet = new HaarWavelet(curent_img.bitmap);
            imgWD = new PGM(curent_img);

            (imgWD.bitmap, imgWD.matrix) = haarWavelet.Denoising();
            
            imgWD.Show(pictureBox);
            curent_img = imgWD;

            info_log.Text += "------Wavelet Denoising------\n";
            /*
             * info_log.Text += imgWD.magicNumber + "\n";
             * info_log.Text += imgWD.width + " " + imgWD.height + "\n";
             * info_log.Text += imgWD.maxVal + "\n";
             */

        }

        private void button_Enhancement_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                info_log.Text += "Use Wavelet Denoising first!\n";
                return;
            }
            // Entrance data selection...
            int nbrBinx = int.Parse(bits_x_tb.Text);
            int nbrBinY = int.Parse(bits_y_tb.Text);
            int grayLevels = int.Parse(grey_level_tb.Text);
            float slope = float.Parse(slope_tb.Text);

            // Selecting the current image and applying the Enhancement algorithm...
            Clahe imClahe = new Clahe(nbrBinx, nbrBinY, grayLevels, slope, (Bitmap)curent_img.bitmap.Clone());
            imgEnh = new PGM(curent_img);
            imgEnh.bitmap = imClahe.Process();

            imgEnh.Show(pictureBox);
            curent_img = new PGM(imgEnh);

            info_log.Text += "------Enhancement------\n";
            /*
             * info_log.Text += imgEnh.magicNumber + "\n";
             * info_log.Text += imgEnh.width + " " + imgEnh.height + "\n";
             * info_log.Text += imgEnh.maxVal + "\n";
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
                    /*Point p = new Point(
                    Math.Min((int)ROIendPoint.X, (int)ROIstartPoint.X),
                    Math.Min((int)ROIendPoint.Y, (int)ROIstartPoint.Y));

                    ROI = new float[
                        Math.Abs((int)ROIendPoint.X - (int)ROIstartPoint.X),
                        Math.Abs((int)ROIendPoint.Y - (int)ROIstartPoint.Y)];

                    Bitmap aux = (Bitmap)curent_img.bitmap.Clone();
                    for (int x = 0; x < ROI.GetLength(0); x++)
                    {
                        for (int y = 0; y < ROI.GetLength(1); y++)
                        {
                            ROI[x, y] = aux.GetPixel((p.X + x), (p.Y + y)).R;
                        }
                    }
                    for (int x = 0; x < ROI.GetLength(0); x++)
                    {
                        for (int y = 0; y < ROI.GetLength(1); y++)
                        {
                            info_log.Text += ROI[x, y] + " ";
                        }
                        info_log.Text += "\n";
                    }*/
                }
            }
            else info_log.Text += "No image selected!\n";
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox.Image != null && pictureBox.ROIselect_Button_active)
            {
                if (ROIfig != null && ROIfig.Width > 0 && ROIfig.Height > 0)
                {
                    e.Graphics.FillRectangle(ROIselectionBrush, ROIfig);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Calculăm coordonatele reale ale pixelului în funcție de zoom
                ROIstartPoint = adjustPosition(e);

                // Afișăm coordonatele în startPoint.Text
                startPoint.Text = "P1(" + ROIstartPoint.X + ", " + ROIstartPoint.Y + ")";
            }
        }
        
        private PointF adjustPosition(MouseEventArgs e)
        {
            PointF adjusted = new PointF();
            adjusted.X = (float)((e.Location.X + pictureBox.HorizontalScrollBar.Value) / pictureBox.ZoomScale);
            adjusted.Y = (float)((e.Location.Y + pictureBox.VerticalScrollBar.Value) / pictureBox.ZoomScale);

            switch (pictureBox.ZoomScale)
            {
                case 2:
                    adjusted.X *= 1.6f;
                    adjusted.Y *= 1.6f;
                    break;
                case 4:
                    adjusted.X *= 2.9112081514f;
                    adjusted.Y *= 2.9112081514f;
                    break;
                case 8:
                    adjusted.X *= 5.5710306407f;
                    adjusted.Y *= 5.5710306407f;
                    break;
                case 16:
                    adjusted.X *= 10.9140518417f;
                    adjusted.Y *= 10.9140518417f;
                    break;
                case 32:
                    adjusted.X *= 21.6216216216f;
                    adjusted.Y *= 21.6216216216f;
                    break;
                case 64:
                    adjusted.X *= 43.068622097f;
                    adjusted.Y *= 43.068622097f;
                    break;
                case 128:
                    adjusted.X *= 86.0215053763f;
                    adjusted.Y *= 86.0215053763f;
                    break;

            }

            adjusted.X = (float)Math.Round(adjusted.X);
            adjusted.Y = (float)Math.Round(adjusted.Y);
            return adjusted;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.ROIselect_Button_active && e.Button == MouseButtons.Left)
            {
                // Checking if the ROIendPoint is inside the pictureBox...
                int x = (int)(e.Location.X / pictureBox.ZoomScale);
                int y = (int)(e.Location.Y / pictureBox.ZoomScale);
                int width = (int)(pictureBox.Width / (float)pictureBox.ZoomScale);
                int height = (int)(pictureBox.Height / (float)pictureBox.ZoomScale);

                ROIendPoint = new Point(
                    x < 0 ? 0 : x > width ? width : x,
                    y < 0 ? 0 : y > height ? height : y);


                label_x.Text = Math.Abs(ROIendPoint.X - ROIstartPoint.X).ToString();
                label_y.Text = Math.Abs(ROIendPoint.Y - ROIstartPoint.Y).ToString();

                endPoint.Text = "P2(" + ROIendPoint.X + "," + ROIendPoint.Y + ")";

                ROIfig.Location = new Point(
                    Math.Min((int)ROIstartPoint.X, (int)ROIendPoint.X),
                    Math.Min((int)ROIstartPoint.Y, (int)ROIendPoint.Y));
                ROIfig.Size = new Size(
                    Math.Abs((int)ROIstartPoint.X - (int)ROIendPoint.X),
                    Math.Abs((int)ROIstartPoint.Y - (int)ROIendPoint.Y));
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
            ROIfig= new Rectangle();
            img.Show(pictureBox);
            img.Show(pictureBox);
            curent_img = new PGM(img);

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

        private void button1_Click(object sender, EventArgs e)
        {
            info_log.Text += pictureBox.GetImageSize();
            info_log.Text += pictureBox.ZoomScale.ToString() + "\n";
        }
    }
}
