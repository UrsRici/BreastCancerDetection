using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BreastCancerDetection.Classes
{
    public static class ImagePopup
    {
        /// <summary>
        /// Creează un popup cu imaginea afișată într-un PictureBox.
        /// </summary>
        /// <param name="bitmap">Bitmap-ul care se afișează</param>
        public static void Show(Bitmap bitmap, string textMessage)
        {
            if (bitmap == null) return;

            Form popup = new Form
            {
                Text = textMessage,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(800, 600)
            };

            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = (Bitmap)bitmap.Clone(),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            popup.Controls.Add(pictureBox);

            popup.ShowDialog(); // fereastră modală (blochează până se închide)
                                // sau popup.Show();  dacă vrei non-modal
        }

        public static void Show(Mat mat, string textMessage)
        {
            if (mat == null) return;

            Bitmap bmp = mat.Bitmap; 
            Show(bmp, textMessage);
            bmp.Dispose();
        }
        public static void Show(float[,] matrix, string textMassage)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Bitmap bmp = new Bitmap(cols, rows);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    // Normalizare în [0..255]
                    int value = (int)matrix[y, x];
                    value = Math.Max(0, Math.Min(255, value));
                    bmp.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }
            Show(bmp, textMassage);
        }
        public static void Show(byte[,,] data, string textMessage)
        {
            Bitmap bitmap = ByteArrayToBitmapGray(data);
            Show(bitmap, textMessage);
            bitmap.Dispose();
        }
        public static void Show(double[,] data, string textMessage)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            Bitmap bmp = new Bitmap(cols, rows);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    // Normalizare în [0..255]
                    int value = (int)data[y, x];
                    value = Math.Max(0, Math.Min(255, value));
                    bmp.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }
            Show(bmp, textMessage);
        }
        public static Bitmap ByteArrayToBitmapGray(byte[,,] data)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            Bitmap bmp = new Bitmap(cols, rows);

            // Copiem valorile pixelilor
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    byte value = data[y, x, 0];
                    bmp.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }

            return bmp;
        }
    }
}



public class cs
{
    public static Dictionary<string, double> GetGLCMFeatures(double[,] glcm)
    {
        int levels = glcm.GetLength(0);
        // inițializări
        double contrast = 0, correlation = 0, energy = 0, homogeneity = 0, entropy = 0, dissimilarity = 0;
        double clusterShade = 0, clusterProminence = 0, IMC1 = 0, IMC2 = 0, maxProb = 0, sumOfSquares = 0;
        double sumAverage = 0, sumVariance = 0, sumEntropy = 0, differenceVariance = 0, differenceEntropy = 0;
        double IDN = 0, IDM = 0; // IDM = inverse difference moment (classic)
        double ux = 0, uy = 0, sigmax = 0, sigmay = 0;
        double HXY = 0, HXY1 = 0, HXY2 = 0, HX = 0, HY = 0;

        double[] px = new double[levels];
        double[] py = new double[levels];
        double[] p_xPy = new double[2 * levels];
        double[] p_xMy = new double[levels];

        // 1) calc px, py, p_xPy, p_xMy
        for (int i = 0; i < levels; i++)
        {
            for (int j = 0; j < levels; j++)
            {
                double p = glcm[i, j];
                if (p <= 0) continue;
                px[i] += p;
                py[j] += p;
                p_xPy[i + j] += p;
                p_xMy[Math.Abs(i - j)] += p;
                maxProb = Math.Max(maxProb, p);
            }
        }

        // 2) ux, uy
        for (int i = 0; i < levels; i++)
        {
            ux += i * px[i];
            uy += i * py[i];
        }

        // 3) sigmax, sigmay, HX, HY (folosim log natural)
        for (int i = 0; i < levels; i++)
        {
            sigmax += Math.Pow(i - ux, 2) * px[i];
            sigmay += Math.Pow(i - uy, 2) * py[i];

            if (px[i] > 0) HX -= px[i] * Math.Log(px[i]);
            if (py[i] > 0) HY -= py[i] * Math.Log(py[i]);
        }
        sigmax = sigmax > 0 ? Math.Sqrt(sigmax) : 0.0;
        sigmay = sigmay > 0 ? Math.Sqrt(sigmay) : 0.0;

        // 4) principale (cu protecții)
        for (int i = 0; i < levels; i++)
        {
            for (int j = 0; j < levels; j++)
            {
                double p = glcm[i, j];
                if (p <= 0) continue;

                contrast += Math.Pow(i - j, 2) * p;

                if (sigmax > 0 && sigmay > 0)
                    correlation += ((i - ux) * (j - uy) * p) / (sigmax * sigmay);

                energy += p * p;
                homogeneity += p / (1.0 + Math.Pow(i - j, 2)); // homogeneity (variantă)
                entropy -= p * Math.Log(p); // p>0 garantat

                clusterShade += Math.Pow(i + j - ux - uy, 3) * p;
                clusterProminence += Math.Pow(i + j - ux - uy, 4) * p;

                dissimilarity += Math.Abs(i - j) * p;
                sumOfSquares += Math.Pow(i - ux, 2) * p;

                // IDM clasic și IDN (inverse diff normalized simplificat)
                IDM += p / (1.0 + Math.Pow(i - j, 2));          // inverse difference moment
                IDN += p / (1.0 + Math.Abs(i - j));             // inverse diff (not normalized by levels)
            }
        }

        // 5) sum-based measures (folosim doar termeni >0)
        for (int k = 0; k < p_xPy.Length; k++)
        {
            double v = p_xPy[k];
            if (v > 0)
            {
                sumAverage += k * v;
                sumEntropy -= v * Math.Log(v);
                sumVariance += Math.Pow(k - sumAverage, 2) * v; // aproximare
            }
        }

        for (int k = 0; k < p_xMy.Length; k++)
        {
            double v = p_xMy[k];
            if (v > 0)
            {
                differenceEntropy -= v * Math.Log(v);
                // differenceVariance similar
                differenceVariance += Math.Pow(k - (p_xMy.Select((val, idx) => val * idx).Sum()), 2) * v; // simplificat
            }
        }

        // HXY, HXY1, HXY2 (folosite în IMC)
        for (int i = 0; i < levels; i++)
        {
            for (int j = 0; j < levels; j++)
            {
                double p = glcm[i, j];
                if (p <= 0) continue;

                HXY -= p * Math.Log(p);

                double prod = px[i] * py[j];
                if (prod > 0)
                {
                    HXY1 -= p * Math.Log(prod);
                    HXY2 -= prod * Math.Log(prod);
                }
            }
        }

        // IMC1 și IMC2 protejate
        double maxHXHY = Math.Max(HX, HY);
        if (maxHXHY > 0)
            IMC1 = (HXY - HXY1) / maxHXHY;
        else
            IMC1 = 0.0;

        double temp = HXY2 - HXY;
        double inner = 1.0 - Math.Exp(-2.0 * temp);
        inner = Math.Max(0.0, Math.Min(1.0, inner)); // clamp la [0,1]
        IMC2 = Math.Sqrt(inner);

        // Construim output
        var output = new Dictionary<string, double>
        {
            ["contrast"] = contrast,
            ["correlation"] = correlation,
            ["energy"] = energy,
            ["homogeneity"] = homogeneity,
            ["entropy"] = entropy,
            ["dissimilarity"] = dissimilarity,
            ["clusterShade"] = clusterShade,
            ["clusterProminence"] = clusterProminence,
            ["IMC1"] = IMC1,
            ["IMC2"] = IMC2,
            ["maxProb"] = maxProb,
            ["sumOfSquares"] = sumOfSquares,
            ["sumAverage"] = sumAverage,
            ["sumVariance"] = sumVariance,
            ["sumEntropy"] = sumEntropy,
            ["differenceVariance"] = differenceVariance,
            ["differenceEntropy"] = differenceEntropy,
            ["IDN"] = IDN,
            ["IDM"] = IDM
        };

        return output;
    }
}
