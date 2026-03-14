using System;
using System.Collections.Generic;
using System.Drawing;

namespace BreastCancerDetection.Classes
{
    public class SLIAnalyzer
    {
        private int patchSize = 64;
        private int glcmLevels = 256;
        public List<Dictionary<string, double>> LIST = new List<Dictionary<string, double>>();
        public string LISTSHOW
        {
            get
            {
                string result = "";
                foreach (var dict in LIST)
                {
                    result += "{ ";
                    foreach (var kvp in dict)
                    {
                        result += $"{kvp.Key}: {kvp.Value}, ";
                    }
                    result = result.TrimEnd(',', ' ') + " }\n";
                }
                return result;
            }
        }

        public Dictionary<string, double> Analyze(float[,] ROI)
        {

            Dictionary<string, double> features = GetTextureFeaturesFromPatch(ROI);
            double score = IsSuspicious(features);

            features["SuspiciousScore"] = score;
            return features;

        }
        public List<SuspiciousRegion> Analyze(PGM image, float limit, int size)
        {
            this.patchSize = size;
            return Analyze(image, limit);
        }
        public List<SuspiciousRegion> Analyze(PGM image, float limit)
        {
            List<SuspiciousRegion> suspiciousRegions = new List<SuspiciousRegion>();

            int height = image.height;
            int width = image.width;

            float[,] matrix = image.matrix;

            for (int y = 1; y < height - patchSize; y += patchSize)
            {
                for (int x = 0; x < width - patchSize; x += patchSize)
                {
                    float[,] patch = ExtractPatch(matrix, x, y);

                    double[,] glcm = ComputeGLCM(patch);

                    // Folosim textura din tumorData
                    Dictionary<string, double> features = GetTextureFeaturesFromPatch(patch);

                    if (IsSuspicious(features) > limit)
                    {
                        suspiciousRegions.Add(new SuspiciousRegion
                        {
                            X = x,
                            Y = y,
                            Width = patchSize,
                            Height = patchSize,
                            Features = features,
                            Scor = IsSuspicious(features)
                        });
                        LIST.Add(features);
                    }
                }
            }

            return suspiciousRegions;
        }
        private Dictionary<string, double> GetTextureFeaturesFromPatch(float[,] patch)
        {
            int levels = glcmLevels;

            // Calcule GLCM pe 4 direcții: 0°, 45°, 90°, 135°
            double[,] glcm0 = ComputeGLCM(patch, 1, 0);
            double[,] glcm45 = ComputeGLCM(patch, 1, -1);
            double[,] glcm90 = ComputeGLCM(patch, 0, 1);
            double[,] glcm135 = ComputeGLCM(patch, -1, -1);

            // Calcul caracteristici pentru fiecare GLCM
            var f0 = TumorData.GetGLCMFeatures(glcm0);
            var f45 = TumorData.GetGLCMFeatures(glcm45);
            var f90 = TumorData.GetGLCMFeatures(glcm90);
            var f135 = TumorData.GetGLCMFeatures(glcm135);

            // Media pe cele 4 direcții
            var features = new Dictionary<string, double>();
            foreach (var key in f0.Keys)
            {
                double average = (f0[key] + f45[key] + f90[key] + f135[key]) / 4.0;
                features[key] = average;
            }

            return features;
        }

        // Modificăm ComputeGLCM pentru a suporta offset (dx, dy)
        private double[,] ComputeGLCM(float[,] patch, int dx, int dy)
        {
            double[,] glcm = new double[glcmLevels, glcmLevels];
            int size = patch.GetLength(0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int nx = x + dx;
                    int ny = y + dy;

                    if (nx < 0 || nx >= size || ny < 0 || ny >= size) continue;

                    int i = Quantize(patch[y, x]);
                    int j = Quantize(patch[ny, nx]);

                    glcm[i, j]++;
                }
            }

            NormalizeGLCM(glcm);
            return glcm;
        }
        private float[,] ExtractPatch(float[,] matrix, int startX, int startY)
        {
            float[,] patch = new float[patchSize, patchSize];

            for (int y = 0; y < patchSize; y++)
                for (int x = 0; x < patchSize; x++)
                    patch[y, x] = matrix[startY + y, startX + x];

            return patch;
        }

        private double[,] ComputeGLCM(float[,] patch)
        {
            double[,] glcm = new double[glcmLevels, glcmLevels];
            int size = patch.GetLength(0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size - 1; x++)
                {
                    int i = Quantize(patch[y, x]);
                    int j = Quantize(patch[y, x + 1]);
                    glcm[i, j]++;
                }
            }

            NormalizeGLCM(glcm);
            return glcm;
        }

        private int Quantize(float value)
        {
            int level = (int)(value / (256 / glcmLevels));
            return Math.Min(level, glcmLevels - 1);
        }

        private void NormalizeGLCM(double[,] glcm)
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

        private double IsSuspicious(Dictionary<string, double> f)
        {
            double score = 0;

            // 1) Contrast – mare = rău
            score += Z(f["Contrast"], 60, 40) * 1.6;

            // 2) Entropy – mare = rău
            score += Z(f["Entropy"], 5.5, 1.0) * 1.4;

            // 3) Homogeneity – mic = rău
            score += Zinv(f["Homogeneity"], 0.35, 0.15) * 1.4;

            // 4) IDM – mic = rău
            score += Zinv(f["IDM"], 0.30, 0.12) * 1.3;

            // 5) IDN – mic = rău
            score += Zinv(f["IDN"], 0.32, 0.12) * 1.2;

            // 6) Correlation – mic = rău (masele maligne au textură dezordonată)
            score += Zinv(f["Correlation"], 0.90, 0.10) * 1.5;

            // 7) Dissimilarity – mare = rău (marginile neregulate)
            score += Z(f["Dissimilarity"], 5.0, 2.0) * 1.3;

            // 8) Energy – mic = rău (textură haotică)
            score += Zinv(f["Energy"], 0.10, 0.20) * 1.2;

            // 9) Cluster Shade – valori mari = rău
            score += Z(Math.Abs(f["ClusterShade"]), 20000, 50000) * 1.0;

            // 10) Cluster Prominence – valori mari = rău
            score += Z(f["ClusterProminence"], 2_000_000, 5_000_000) * 1.0;

            return score;
        }

        // Z-score normal
        private double Z(double x, double mean, double std)
        {
            return Math.Max(0, (x - mean) / std);
        }

        // Z-score invers (pentru feature-uri unde mic = rău)
        private double Zinv(double x, double mean, double std)
        {
            return Math.Max(0, (mean - x) / std);
        }


        // Normalizare liniară între 0 și 1
        private double Normalize(double value, double min, double max)
        {
            if (value <= min) return 0;
            if (value >= max) return 1;
            return (value - min) / (max - min);
        }

        public class SuspiciousRegion
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
            public double Scor;
            public Dictionary<string, double> Features;
        }
    }
}