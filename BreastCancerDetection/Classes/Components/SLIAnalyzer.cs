using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace BreastCancerDetection.Classes
{
    public class SLIAnalyzer
    {
        private int minPatchSize = 64;
        private int glcmLevels = 256;

        private byte[,] imageData;
        private int width;
        private int height;
        private Dictionary<int, List<Dictionary<string, double>>> featureStorage = new Dictionary<int, List<Dictionary<string, double>>>();

        public Bitmap Analyze(Bitmap image)
        {
            width = image.Width;
            height = image.Height;

            imageData = BitmapToGrayArray(image);

            Bitmap result = new Bitmap(image);
            Graphics g = Graphics.FromImage(result);

            AnalyzeRegion(new Rectangle(0, 0, width, height), g);

            g.Dispose();
            return result;
        }

        private void AnalyzeRegion(Rectangle region, Graphics g)
        {
            if (region.Width < minPatchSize || region.Height < minPatchSize)
                return;

            var features = ExtractTextureFeatures(region);


            if (!IsMostlyBlack(region) && region.Width < 500)
            {
                int size = region.Width;

                if (!featureStorage.ContainsKey(size))
                    featureStorage[size] = new List<Dictionary<string, double>>();

                featureStorage[size].Add(features);

                if (IsSuspicious(features))
                {
                    DrawSuspicious(g, region);
                    //return;
                }
                /*if (region.Width > 100 && region.Height < 158)
                    ShowDebugPopup(region, features, IsSuspicioussss(features));*/


            }

            


            if (region.Width <= minPatchSize)
                return;

            int halfW = region.Width / 2;
            int halfH = region.Height / 2;

            AnalyzeRegion(new Rectangle(region.X, region.Y, halfW, halfH), g);
            AnalyzeRegion(new Rectangle(region.X + halfW, region.Y, halfW, halfH), g);
            AnalyzeRegion(new Rectangle(region.X, region.Y + halfH, halfW, halfH), g);
            AnalyzeRegion(new Rectangle(region.X + halfW, region.Y + halfH, halfW, halfH), g);
        }
        public void ShowStatisticsPopup()
        {
            string report = BuildFeatureStatisticsReport();

            Form f = new Form();
            f.Width = 700;
            f.Height = 500;
            f.Text = "Texture Feature Statistics";

            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.ScrollBars = ScrollBars.Both;
            tb.Dock = DockStyle.Fill;
            tb.Font = new Font("Consolas", 10);
            tb.Text = report;

            f.Controls.Add(tb);

            f.Show();
        }
        private (double mean, double min, double max, double std) ComputeStats(List<double> values)
        {
            double mean = values.Average();
            double min = values.Min();
            double max = values.Max();

            double variance = values.Sum(v => Math.Pow(v - mean, 2)) / values.Count;
            double std = Math.Sqrt(variance);

            return (mean, min, max, std);
        }
        public string BuildFeatureStatisticsReport()
        {
            var report = new System.Text.StringBuilder();

            foreach (var sizeGroup in featureStorage)
            {
                int size = sizeGroup.Key;
                var list = sizeGroup.Value;

                report.AppendLine("=================================");
                report.AppendLine("Patch Size: " + size + " x " + size);

                foreach (var feature in list[0].Keys)
                {
                    List<double> values = new List<double>();

                    foreach (var f in list)
                        values.Add(f[feature]);

                    var stats = ComputeStats(values);

                    report.AppendLine(
                        feature +
                        "  Mean=" + stats.mean.ToString("F3") +
                        "  Min=" + stats.min.ToString("F3") +
                        "  Max=" + stats.max.ToString("F3") +
                        "  Std=" + stats.std.ToString("F3"));
                }

                report.AppendLine();
            }

            return report.ToString();
        }

        public Dictionary<int, Dictionary<string, double>> ComputeFeatureMeans()
        {
            var result = new Dictionary<int, Dictionary<string, double>>();

            foreach (var sizeGroup in featureStorage)
            {
                int size = sizeGroup.Key;
                var list = sizeGroup.Value;

                Dictionary<string, double> mean = new Dictionary<string, double>();

                foreach (var key in list[0].Keys)
                {
                    double sum = 0;

                    foreach (var f in list)
                        sum += f[key];

                    mean[key] = sum / list.Count;
                }

                result[size] = mean;
            }

            return result;
        }

        public void ShowFeatureChart(string featureName)
        {
            var means = ComputeFeatureMeans();

            Form chartForm = new Form();
            chartForm.Width = 600;
            chartForm.Height = 400;

            var chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.Dock = DockStyle.Fill;

            var area = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chart.ChartAreas.Add(area);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            foreach (var size in means.Keys)
            {
                double value = means[size][featureName];
                series.Points.AddXY(size, value);
            }

            chart.Series.Add(series);
            chartForm.Controls.Add(chart);

            chartForm.Show();
        }
        private Dictionary<string, double> ExtractTextureFeatures(Rectangle region)
        {
            double[,] glcm0 = ComputeGLCM(region, 1, 0);
            double[,] glcm45 = ComputeGLCM(region, 1, -1);
            double[,] glcm90 = ComputeGLCM(region, 0, 1);
            double[,] glcm135 = ComputeGLCM(region, -1, -1);

            var f0 = TumorData.GetGLCMFeatures(glcm0);
            var f45 = TumorData.GetGLCMFeatures(glcm45);
            var f90 = TumorData.GetGLCMFeatures(glcm90);
            var f135 = TumorData.GetGLCMFeatures(glcm135);

            Dictionary<string, double> features = new Dictionary<string, double>();

            foreach (var key in f0.Keys)
                features[key] = (f0[key] + f45[key] + f90[key] + f135[key]) / 4.0;

            return features;
        }

        private double[,] ComputeGLCM(Rectangle region, int dx, int dy)
        {
            double[,] glcm = new double[glcmLevels, glcmLevels];

            for (int y = region.Y; y < region.Y + region.Height; y++)
            {
                for (int x = region.X; x < region.X + region.Width; x++)
                {
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx < region.X || nx >= region.Right ||
                        ny < region.Y || ny >= region.Bottom)
                        continue;

                    int i = Quantize(imageData[y, x]);
                    int j = Quantize(imageData[ny, nx]);

                    glcm[i, j]++;
                }
            }

            Normalize(glcm);
            return glcm;
        }

        private int Quantize(int value)
        {
            int level = value / (256 / glcmLevels);
            return Math.Min(level, glcmLevels - 1);
        }

        private void Normalize(double[,] glcm)
        {
            double sum = 0;

            int levels = glcm.GetLength(0);

            for (int i = 0; i < levels; i++)
                for (int j = 0; j < levels; j++)
                    sum += glcm[i, j];

            if (sum == 0) return;

            for (int i = 0; i < levels; i++)
                for (int j = 0; j < levels; j++)
                    glcm[i, j] /= sum;
        }
        private bool IsMostlyBlack(Rectangle region)
        {
            int blackPixels = 0;
            int total = region.Width * region.Height;

            int threshold = 10; // pixel considerat negru

            for (int y = region.Y; y < region.Y + region.Height; y++)
            {
                for (int x = region.X; x < region.X + region.Width; x++)
                {
                    if (imageData[y, x] < threshold)
                        blackPixels++;
                }
            }

            double ratio = (double)blackPixels / total;

            return ratio > 0.60;
        }
        private bool IsSuspicious(Dictionary<string, double> f)
        {
            double contrast = f["Contrast"];
            double entropy = f["Entropy"];
            double homogeneity = f["Homogeneity"];

            //return contrast > 6 && entropy > 4 && homogeneity < 0.7;
            return contrast > 6.8 && entropy > 5.2 && homogeneity < 0.38;
        }
        private double IsSuspiciouss(Dictionary<string, double> f)
        {
            double score = 0;

            double contrast = f["Contrast"];
            double entropy = f["Entropy"];
            double homogeneity = f["Homogeneity"];
            double energy = f["Energy"];
            double correlation = f["Correlation"];
            double dissimilarity = f["Dissimilarity"];

            // Contrast mare → suspect
            score += Math.Max(0, Z(contrast, 35, 40)) * 1.5;

            // Entropy mare → suspect
            score += Math.Max(0, Z(entropy, 5.1, 0.7)) * 1.4;

            // Homogeneity mic → suspect
            score += Math.Max(0, -Z(homogeneity, 0.45, 0.1)) * 1.4;

            // Energy mic → suspect
            score += Math.Max(0, -Z(energy, 0.05, 0.07)) * 1.2;

            // Correlation mic → suspect
            score += Math.Max(0, -Z(correlation, 0.93, 0.1)) * 1.3;

            // Dissimilarity mare → suspect
            score += Math.Max(0, Z(dissimilarity, 2.0, 0.4)) * 1.3;

            return score;
        }

        private void ShowDebugPopup(Rectangle region, Dictionary<string, double> features, double score)
        {
            Bitmap patch = new Bitmap(region.Width, region.Height);

            for (int y = 0; y < region.Height; y++)
            {
                for (int x = 0; x < region.Width; x++)
                {
                    byte v = imageData[region.Y + y, region.X + x];
                    patch.SetPixel(x, y, Color.FromArgb(v, v, v));
                }
            }

            Form f = new Form();
            f.Width = 300;
            f.Height = 350;
            f.Text = "Patch Analysis";

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Top;
            pb.Height = 200;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = patch;

            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.Dock = DockStyle.Fill;

            tb.Text =
                "Score: " + score.ToString("F2") + Environment.NewLine +
                "Contrast: " + features["Contrast"].ToString("F2") + Environment.NewLine +
                "Entropy: " + features["Entropy"].ToString("F2") + Environment.NewLine +
                "Homogeneity: " + features["Homogeneity"].ToString("F2") + Environment.NewLine +
                "Energy: " + features["Energy"].ToString("F2") + Environment.NewLine +
                "Dissimilarity: " + features["Dissimilarity"].ToString("F2");

            f.Controls.Add(tb);
            f.Controls.Add(pb);

            f.Show();
        }

        public double GetSuspicionScore(float[,] ROI)
        {
            int h = ROI.GetLength(0);
            int w = ROI.GetLength(1);

            Rectangle region = new Rectangle(0, 0, w, h);

            // conversie ROI -> imageData temporar
            imageData = new byte[h, w];

            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    imageData[y, x] = (byte)(ROI[y, x] < 0 ? 0 : (ROI[y, x] > 255 ? 255 : ROI[y, x]));

            // verificăm dacă zona e prea neagră
            if (IsMostlyBlack(region))
                return 0;

            var features = ExtractTextureFeatures(region);

            double score = IsSuspiciouss(features);

            return score;
        }
        private double Z(double value, double mean, double std)
        {
            if (std == 0) return 0;
            return (value - mean) / std;
        }
        private void DrawSuspicious(Graphics g, Rectangle rect)
        {
            Pen pen = new Pen(Color.Red, 2);

            g.DrawRectangle(pen, rect);

            g.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Bottom);
            g.DrawLine(pen, rect.Right, rect.Top, rect.Left, rect.Bottom);
        }

        private byte[,] BitmapToGrayArray(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            byte[,] data = new byte[h, w];

            BitmapData bd = bmp.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)bd.Scan0;

                for (int y = 0; y < h; y++)
                {
                    byte* row = ptr + y * bd.Stride;

                    for (int x = 0; x < w; x++)
                    {
                        byte b = row[x * 3];
                        byte g = row[x * 3 + 1];
                        byte r = row[x * 3 + 2];

                        data[y, x] = (byte)((r + g + b) / 3);
                    }
                }
            }

            bmp.UnlockBits(bd);

            return data;
        }
    }
}