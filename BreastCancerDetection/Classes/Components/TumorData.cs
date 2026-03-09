using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;


namespace BreastCancerDetection.Classes
{
    public class TumorsData
    {
        Dictionary<int, TumorData> tumors = new Dictionary<int, TumorData>();
        public TumorsData()
        {
            this.tumors = new Dictionary<int, TumorData>();
        }
        public TumorsData(VectorOfVectorOfPoint contours, Mat image)
        {
            for (int i = 0; i < contours.Size; i++)
            {
                VectorOfPoint contour = contours[i];
                tumors.Add(i, new TumorData(contour, image));
            }
        }
        public void Add(TumorData tumor)
        {
            this.tumors.Add(this.tumors.Count + 1,tumor);
        }
        public override string ToString()
        {
            return string.Join("\n\n", tumors.Select(kv => $"Tumor {kv.Key}:\n{kv.Value.ToString()}"));
        }
    }
    public class TumorData
    {
        public Dictionary<string, double> statisticsDatas = new Dictionary<string, double>();
        public Dictionary<string, double> textureDatas = new Dictionary<string, double>();
        public Dictionary<string, double> morphologyDatas = new Dictionary<string, double>();
        public double prediction = 0.0;
        public TumorData()
        {
            this.statisticsDatas = new Dictionary<string, double>();
            this.textureDatas = new Dictionary<string, double>();
            this.morphologyDatas = new Dictionary<string, double>();
            this.prediction = 0.0;
        }

        public TumorData(VectorOfPoint contour, Mat image)
        {
            CalculateStatisticsDatas(contour, image);
            CalculateTextureDatas(contour, image);
            CalculateMorphologyDatas(contour);
            EstimateMalignancyScore();
        }
        public void EstimateMalignancyScore()
        {
            Dictionary<string, double> stats = this.statisticsDatas;
            Dictionary< string, double> texture = this.textureDatas;
            Dictionary<string, double> morph = this.morphologyDatas;

            // Normalizări aproximative (bazate pe intervale tipice)
            double norm(double value, double min, double max)
            {
                double result = (value - min) / (max - min);
                return Math.Max(0.0, Math.Min(1.0, result));
            }

            // Morfologie (pondere mare)
            double compactness = norm(morph["Compactness"], 1.0, 6.0);
            double solidity = 1 - norm(morph["Solidity"], 0.5, 1.0);
            double extent = 1 - norm(morph["Extent"], 0.4, 1.0);
            double eccentricity = norm(morph["Eccentricity"], 0.3, 1.0);

            double morphScore = (compactness * 0.35 +
                                 solidity * 0.30 +
                                 extent * 0.20 +
                                 eccentricity * 0.15);

            // Textură (pondere medie)
            double contrast = norm(texture["Contrast"], 0, 3000);
            double entropy = norm(texture["Entropy"], 3, 7);
            double homogeneity = 1 - norm(texture["Homogeneity"], 0.2, 0.8);
            double idm = 1 - norm(texture["IDM"], 0.2, 0.8);

            double textureScore = (contrast * 0.35 +
                                   entropy * 0.30 +
                                   homogeneity * 0.20 +
                                   idm * 0.15);

            // Intensitate (pondere mică)
            double variance = norm(stats["Variance"], 50, 400);
            double stddev = norm(stats["StdDev"], 5, 25);

            double statsScore = (variance * 0.6 + stddev * 0.4);

            // Scor final (morfologia contează cel mai mult)
            double finalScore = (morphScore * 0.55 +
                                 textureScore * 0.35 +
                                 statsScore * 0.10);

            this.prediction = finalScore;
        }
        public void CalculateStatisticsDatas(VectorOfPoint contour, Mat image)
        {
            // 1. Creăm masca ROI din contur
            Mat mask = new Mat(image.Rows, image.Cols, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(0));
            CvInvoke.DrawContours(mask, new VectorOfVectorOfPoint(contour), -1, new MCvScalar(255), -1);

            // 2. Convertim imaginea și masca în Image<Gray, byte> pentru acces rapid
            var imgGray = image.ToImage<Gray, byte>();
            var maskGray = mask.ToImage<Gray, byte>();

            byte[,,] imageData = imgGray.Data; // H x W x 1
            byte[,,] maskData = maskGray.Data; // H x W x 1

            // 3. Extragem pixelii din ROI 
            List<byte> pixelValues = new List<byte>();

            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    if (maskData[y, x, 0] > 0) // pixel în mască
                    {
                        pixelValues.Add(imageData[y, x, 0]); // pixel din imagine
                    }
                }
            }


            // 4. Statistici de intensitate
            double mean = pixelValues.Select(p => (double)p).ToList().Average();
            double variance = pixelValues.Select(p => Math.Pow(p - mean, 2)).Average();
            double stdDev = Math.Sqrt(variance);
            double skewness = pixelValues.Select(p => Math.Pow((p - mean) / stdDev, 3)).Average();
            double kurtosis = pixelValues.Select(p => Math.Pow((p - mean) / stdDev, 4)).Average();

            this.statisticsDatas["Mean"] = mean;
            this.statisticsDatas["Variance"] = variance;
            this.statisticsDatas["StdDev"] = stdDev;
            this.statisticsDatas["Skewness"] = skewness;
            this.statisticsDatas["Kurtosis"] = kurtosis;
        }

        public void CalculateTextureDatas(VectorOfPoint contour, Mat image)
        { 
            // 1. Creăm masca ROI
            Mat mask = new Mat(image.Rows, image.Cols, DepthType.Cv8U, 1);
            CvInvoke.DrawContours(mask, new VectorOfVectorOfPoint(contour), -1, new MCvScalar(255), -1);

            // 2. Extragem sub-imaginea ROI
            Mat roiImage = new Mat();
            image.CopyTo(roiImage, mask);

            // 3. Calculăm GLCM (offset: ex. dx=1, dy=0)
            double[,] glcm0 = ComputeGLCM(roiImage, 1, 0);
            double[,] glcm45 = ComputeGLCM(roiImage, 1, -1);
            double[,] glcm90 = ComputeGLCM(roiImage, 0, 1);
            double[,] glcm135 = ComputeGLCM(roiImage, -1, -1);

            // 4. Extragem caracteristici din GLCM
            Dictionary<string, double> f0 = GetGLCMFeatures(glcm0);
            Dictionary<string, double> f45 = GetGLCMFeatures(glcm45);
            Dictionary<string, double> f90 = GetGLCMFeatures(glcm90);
            Dictionary<string, double> f135 = GetGLCMFeatures(glcm135);

            foreach (var key in f0.Keys)
            {
                double average = (f0[key] + f45[key] + f90[key] + f135[key]) / 4.0;
                this.textureDatas.Add(key, average);
            }
            this.textureDatas = f0;
        }

        public void CalculateMorphologyDatas(VectorOfPoint contour)
        {
            // 1. Area și Perimeter
            double area = CvInvoke.ContourArea(contour);
            double perimeter = CvInvoke.ArcLength(contour, true);

            // 2. Compactness / Circularity
            double compactness = perimeter * perimeter / (4 * Math.PI * area);

            // 3. Eccentricity prin fit ellipse
            RotatedRect ellipse = CvInvoke.FitEllipse(contour);
            double a = Math.Max(ellipse.Size.Width / 2.0, ellipse.Size.Height / 2.0);
            double b = Math.Min(ellipse.Size.Width / 2.0, ellipse.Size.Height / 2.0);
            double eccentricity = Math.Sqrt(1 - ((b * b) / (a * a)));

            // 4. Solidity
            VectorOfPoint hull = new VectorOfPoint();
            CvInvoke.ConvexHull(contour, hull);
            double hullArea = CvInvoke.ContourArea(hull);
            double solidity = area / hullArea;

            // 5. Extent
            Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
            double extent = area / (boundingBox.Width * boundingBox.Height);

            this.morphologyDatas["Area"] = area;
            this.morphologyDatas["Perimeter"] = perimeter;
            this.morphologyDatas["Compactness"] = compactness;
            this.morphologyDatas["Eccentricity"] = eccentricity;
            this.morphologyDatas["Solidity"] = solidity;
            this.morphologyDatas["Extent"] = extent;
        }

        public static Dictionary<string, double> GetGLCMFeatures(double[,] glcm)
        {
            /*int levels = glcm.GetLength(0);
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

            // calc px, py, p_xPy, p_xMy
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

            // ux, uy
            for (int i = 0; i < levels; i++)
            {
                ux += i * px[i];
                uy += i * py[i];
            }

            // sigmax, sigmay, HX, HY (folosim log natural)
            for (int i = 0; i < levels; i++)
            {
                sigmax += Math.Pow(i - ux, 2) * px[i];
                sigmay += Math.Pow(i - uy, 2) * py[i];
                if (px[i] > 0) HX -= px[i] * Math.Log(px[i]);
                if (py[i] > 0) HY -= py[i] * Math.Log(py[i]);
            }
            sigmax = sigmax > 0 ? Math.Sqrt(sigmax) : 0.0;
            sigmay = sigmay > 0 ? Math.Sqrt(sigmay) : 0.0;

            // principale caracteristici GLCM
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

                    // HXY, HXY1, HXY2 (folosite în IMC)
                    HXY -= p * Math.Log(p);

                    double prod = px[i] * py[j];
                    if (prod > 0)
                    {
                        HXY1 -= p * Math.Log(prod);
                        HXY2 -= prod * Math.Log(prod);
                    }
                }
            }

            // sum/dif based measures (folosim doar termeni >0)
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

            // IMC1 și IMC2 protejate
            double maxHXHY = Math.Max(HX, HY);
            /*if (maxHXHY > 0)
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
                ["Contrast"] = contrast,
                ["Correlation"] = correlation,
                ["Energy"] = energy,
                ["Homogeneity"] = homogeneity,
                ["Entropy"] = entropy,
                ["Dissimilarity"] = dissimilarity,
                ["ClusterShade"] = clusterShade,
                ["ClusterProminence"] = clusterProminence,
                ["IDN"] = IDN,
                ["IDM"] = IDM
            };
                        return output;
            */
            int levels = glcm.GetLength(0);

            double contrast = 0, correlation = 0, energy = 0;
            double homogeneity = 0, entropy = 0, dissimilarity = 0;
            double clusterShade = 0, clusterProminence = 0;
            double IDN = 0, IDM = 0;

            double ux = 0, uy = 0, sigmax = 0, sigmay = 0;

            double[] px = new double[levels];
            double[] py = new double[levels];

            // Calcul px si py
            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < levels; j++)
                {
                    double p = glcm[i, j];
                    if (p <= 0) continue;

                    px[i] += p;
                    py[j] += p;
                }
            }

            // Calcul medii
            for (int i = 0; i < levels; i++)
            {
                ux += i * px[i];
                uy += i * py[i];
            }

            // Calcul deviatii standard
            for (int i = 0; i < levels; i++)
            {
                sigmax += Math.Pow(i - ux, 2) * px[i];
                sigmay += Math.Pow(i - uy, 2) * py[i];
            }

            sigmax = sigmax > 0 ? Math.Sqrt(sigmax) : 0.0;
            sigmay = sigmay > 0 ? Math.Sqrt(sigmay) : 0.0;

            // Caracteristici principale
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

                    homogeneity += p / (1.0 + Math.Pow(i - j, 2));

                    entropy -= p * Math.Log(p);

                    dissimilarity += Math.Abs(i - j) * p;

                    clusterShade += Math.Pow(i + j - ux - uy, 3) * p;

                    clusterProminence += Math.Pow(i + j - ux - uy, 4) * p;

                    IDM += p / (1.0 + Math.Pow(i - j, 2));

                    IDN += p / (1.0 + Math.Abs(i - j));
                }
            }

            return new Dictionary<string, double>
            {
                ["Contrast"] = contrast,
                ["Correlation"] = correlation,
                ["Energy"] = energy,
                ["Homogeneity"] = homogeneity,
                ["Entropy"] = entropy,
                ["Dissimilarity"] = dissimilarity,
                ["ClusterShade"] = clusterShade,
                ["ClusterProminence"] = clusterProminence,
                ["IDN"] = IDN,
                ["IDM"] = IDM
            };

        }

        private double[,] ComputeGLCM(Mat grayImage, int dx, int dy)
        {
            int levels = 256;
            int rows = grayImage.Rows;
            int cols = grayImage.Cols;

            double[,] glcm = new double[levels, levels];

            byte[,,] data = grayImage.ToImage<Gray, byte>().Data;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (y + dy < 0 || x + dx < 0 || y + dy > 1023 || x + dx > 1023) continue;
                    int i = data[y, x, 0];              // pixel curent
                    int j = data[y + dy, x + dx, 0];    // pixel vecin

                    glcm[i, j]++;
                }
            }
            glcm[0, 0] = 0; // Eliminăm fundalul
            // Normalizare la probabilitate (împărțim la numărul total de perechi)
            double sum = 0;
            foreach (var val in glcm) sum += val;
            for (int i = 0; i < levels; i++)
                for (int j = 0; j < levels; j++)
                    glcm[i, j] /= sum;

            return glcm;
        }

        public override string ToString()
        {
            return
                " • Statistics Data:\n" + string.Join("\n", statisticsDatas.Select(kv => $"     - {kv.Key}: {kv.Value:F4}")) +
                "\n • Texture Data:\n" + string.Join("\n", textureDatas.Select(kv => $"     - {kv.Key}: {kv.Value:F4}")) +
                "\n • Morphology Data:\n" + string.Join("\n", morphologyDatas.Select(kv => $"     - {kv.Key}: {kv.Value:F4}")) +
                "\n • Malignancy Score: " + prediction.ToString("F4");
        }
    }
}
