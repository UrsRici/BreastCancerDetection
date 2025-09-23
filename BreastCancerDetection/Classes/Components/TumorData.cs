using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using static Tensorflow.LogMessage.Types;

namespace BreastCancerDetection.Classes
{
    public class tumorsData
    {
        public List<tumorData> tumors = new List<tumorData>();
        public tumorsData()
        {
            tumors = new System.Collections.Generic.List<tumorData>();
        }
        public tumorsData(VectorOfVectorOfPoint contours, Mat image)
        {
            for (int i = 0; i < contours.Size; i++)
            {
                VectorOfPoint contour = contours[i];
                tumors.Add(new tumorData(contour, i, image));
            }
        }
        public void Add(tumorData tumor)
        {
            tumors.Add(tumor);
        }
        public override string ToString()
        {
            string result = "";
            foreach (var tumor in tumors)
            {
                result += tumor.ToString() + "\n\n";
            }
            return result;
        }
    }
    public class tumorData
    {
        #region Atribute
        public int Id;
        public Dictionary<string, double> statisticsDatas = new Dictionary<string, double>();
        public Dictionary<string, double> textureDatas = new Dictionary<string, double>();
        public Dictionary<string, double> morphologyDatas = new Dictionary<string, double>();

        #endregion
        public tumorData()
        {
            this.Id = -1;
            this.statisticsDatas = new Dictionary<string, double>();
            this.textureDatas = new Dictionary<string, double>();
            this.morphologyDatas = new Dictionary<string, double>();
        }

        public tumorData(VectorOfPoint contour, int id, Mat image)
        {
            this.Id = id;

            CalculateStatisticsDatas(contour, image);
            CalculateTextureDatas(contour, image);
            CalculateMorphologyDatas(contour, image);
        }

        public void CalculateStatisticsDatas(VectorOfPoint contour, Mat image)
        {
            // 1. Creăm masca ROI din contur
            Mat mask = new Mat(image.Rows, image.Cols, DepthType.Cv8U, 1);
            CvInvoke.DrawContours(mask, new VectorOfVectorOfPoint(contour), -1, new MCvScalar(255), -1);

            // 2. Extragem pixelii din ROI
            byte[,] roiPixels = new byte[image.Rows, image.Cols];
            image.CopyTo(mask, mask); // Aplicăm masca pe imagine

            Image<Gray, byte> imgGray = image.ToImage<Gray, byte>();
            byte[,,] data = imgGray.Data;

            List<double> pixelValues = new List<double>();
            for (int y = 0; y < image.Rows; y++)
            {
                for (int x = 0; x < image.Cols; x++)
                {
                    if (mask.GetData(y, x)[0] > 0)
                    {
                        pixelValues.Add(data[y, x, 0]);
                    }
                }
            }

            if (pixelValues.Count == 0)
            {
                Console.WriteLine("ROI este gol.");
                return;
            }

            // 3. Statistici de intensitate
            double mean = pixelValues.Average();
            double variance = pixelValues.Select(p => Math.Pow(p - mean, 2)).Average();
            double stdDev = Math.Sqrt(variance);
            double skewness = pixelValues.Select(p => Math.Pow((p - mean) / stdDev, 3)).Average();
            double kurtosis = pixelValues.Select(p => Math.Pow((p - mean) / stdDev, 4)).Average();

            // 4. Caracteristici morfologice
            double area = CvInvoke.ContourArea(contour);
            double perimeter = CvInvoke.ArcLength(contour, true);
            double compactness = perimeter * perimeter / (4 * Math.PI * area);

            // Eccentricity (aproximăm cu ellipse)
            RotatedRect ellipse = CvInvoke.FitEllipse(contour);
            double a = ellipse.Size.Width / 2.0;
            double b = ellipse.Size.Height / 2.0;
            double eccentricity = Math.Sqrt(1 - (b * b) / (a * a));

            // Solidity = Area / Convex Hull Area
            VectorOfPoint hull = new VectorOfPoint();
            CvInvoke.ConvexHull(contour, hull);
            double hullArea = CvInvoke.ContourArea(hull);
            double solidity = area / hullArea;
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
        }
        public void CalculateMorphologyDatas(VectorOfPoint contour, Mat image)
        {
            // 1. Area și Perimeter
            double area = CvInvoke.ContourArea(contour);
            double perimeter = CvInvoke.ArcLength(contour, true);

            // 2. Compactness / Circularity
            double compactness = perimeter * perimeter / (4 * Math.PI * area);

            // 3. Eccentricity prin fit ellipse
            RotatedRect ellipse = CvInvoke.FitEllipse(contour);
            double a = ellipse.Size.Width / 2.0;
            double b = ellipse.Size.Height / 2.0;
            double eccentricity = Math.Sqrt(1 - (b * b) / (a * a));

            // 4. Solidity
            VectorOfPoint hull = new VectorOfPoint();
            CvInvoke.ConvexHull(contour, hull);
            double hullArea = CvInvoke.ContourArea(hull);
            double solidity = area / hullArea;

            // 5. Extent
            Rectangle boundingBox = CvInvoke.BoundingRectangle(contour);
            double extent = area / (boundingBox.Width * boundingBox.Height);
        }


        static Dictionary<string, double> GetGLCMFeatures(double[,] glcm)
        {
            int levels = 256; // Numărul de nivele de gri
            #region Inițializare variabile pentru caracteristici
            double contrast = 0, correlation = 0, energy = 0, homogeneity = 0, entropy = 0, dissimilarity = 0;
            double clusterShade = 0, clusterProminence = 0, IMC1 = 0, IMC2 = 0, maxProb = 0, sumOfSquares = 0;
            double sumAverage = 0, sumVariance = 0, sumEntropy = 0, differenceVariance = 0, differenceEntropy = 0;
            double IDN = 0, IDMN = 0;

            double ux = 0, uy = 0, sigmax = 0, sigmay = 0, niu_xPy = 0, niu_xMy = 0;
            double HXY = 0, HXY1 = 0, HXY2 = 0, HX = 0, HY = 0;
            double[] px = new double[levels];
            double[] py = new double[levels];
            double[] p_xPy = new double[2 * levels];
            double[] p_xMy = new double[levels];
            #endregion

            #region Calcul componente adiționale
            // Calculăm px, py, p_xPy, p_xMy
            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < levels; j++)
                {
                    px[i] += glcm[i, j];
                    py[j] += glcm[i, j];
                    p_xPy[i + j] += glcm[i, j];
                    p_xMy[Math.Abs(i - j)] += glcm[i, j];
                }
            }

            // Calculăm miu_xy, miu_x-y
            niu_xPy = p_xPy.Sum();
            niu_xMy = p_xMy.Sum();

            // Calculăm ux și uy
            for (int i = 0; i < levels; i++)
            {
                ux += i * px[i];
                uy += i * py[i];
            }

            // Calcul sigmax, sigmay și HX, HY
            for (int i = 0; i < levels; i++)
            {
                sigmax += Math.Pow(i - ux, 2) * px[i];
                sigmay += Math.Pow(i - uy, 2) * py[i];

                if (px[i] > 0) HX -= px[i] * Math.Log(px[i], Math.E);
                if (py[i] > 0) HY -= py[i] * Math.Log(py[i], Math.E);
            }
            sigmax = Math.Sqrt(sigmax);
            sigmay = Math.Sqrt(sigmay);
            #endregion

            // Calcul caracteristici GLCM
            for (int i = 0; i < levels; i++)
            {
                for (int j = 0; j < levels; j++)
                {
                    double p = glcm[i, j];
                    if (p < 0) p = 0;

                    #region Componente importante
                    contrast += Math.Pow(i - j, 2) * p;//
                    correlation += ((i - ux) * (j - uy) * p) / (sigmax * sigmay);//
                    energy += p * p;//
                    homogeneity += p / (1 + Math.Pow(i - j, 2));//
                    entropy -= p * Math.Log(p, Math.E);//
                    clusterShade += Math.Pow(i + j - ux - uy, 3) * p;//
                    clusterProminence += Math.Pow(i + j - ux - uy, 4) * p;//
                    maxProb = Math.Max(maxProb, p);//

                    dissimilarity += Math.Abs(1 - j) * p;
                    sumOfSquares += (i - ux) * (i - ux) * p;
                    #endregion

                    #region Componente adiționale
                    sumAverage += (i + j) * p_xPy[i + j];
                    sumVariance += Math.Pow((i + j - niu_xPy), 2) * p_xPy[i + j];
                    sumEntropy -= p_xPy[i + j] * Math.Log(p_xPy[i + j], Math.E);
                    differenceVariance += Math.Pow((i - j - niu_xMy), 2) * p_xMy[Math.Abs(i - j)];
                    differenceEntropy -= p_xMy[Math.Abs(i - j)] * Math.Log(p_xMy[Math.Abs(i - j)], Math.E);
                    IDN += p / (1 + (Math.Abs(i - j) / levels));//
                    IDMN += p / (1 + Math.Pow((i - j) / levels, 2));//
                    #endregion

                    HXY -= p * Math.Log(p, Math.E);
                    HXY1 -= p * Math.Log(px[i] * py[j]);
                    HXY2 -= px[i] * py[j] * Math.Log(px[i] * py[j]);
                }
            }

            IMC1 = (HXY - HXY1) / Math.Max(HX, HY);
            IMC2 = Math.Sqrt(1 - Math.Exp(-2 * (HXY2 - HXY)));

            Dictionary<string, double> output = new Dictionary<string, double>();
            #region Output caracteristici
            output["contrast"] = contrast;
            output["correlation"] = correlation;
            output["energy"] = energy;
            output["homogeneity"] = homogeneity;
            output["entropy"] = entropy;
            output["dissimilarity"] = dissimilarity;
            output["clusterShade"] = clusterShade;
            output["clusterProminence"] = clusterProminence;
            output["IMC1"] = IMC1;
            output["IMC2"] = IMC2;
            output["maxProb"] = maxProb;
            output["sumOfSquares"] = sumOfSquares;
            output["sumAverage"] = sumAverage;
            output["sumVariance"] = sumVariance;
            output["sumEntropy"] = sumEntropy;
            output["differenceVariance"] = differenceVariance;
            output["differenceEntropy"] = differenceEntropy;
            output["IDN"] = IDN;
            output["IDMN"] = IDMN;
            #endregion
            return output;
        }
        public static double[,] ComputeGLCM(Mat grayImage, int dx, int dy, int levels = 256)
        {
            int rows = grayImage.Rows;
            int cols = grayImage.Cols;

            double[,] glcm = new double[levels, levels];

            Image<Gray, byte> gray = grayImage.ToImage<Gray, byte>();
            byte[,,] data = gray.Data;

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
            return base.ToString();//
        }
    }
}
