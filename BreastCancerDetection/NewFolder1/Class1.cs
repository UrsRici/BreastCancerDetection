using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace BreastCancerDetection.NewFolder1
{
    public class CLAHEProcessor
    {
        private Mat inputImage;
        private int windowSize;
        private double clipLimit;

        public CLAHEProcessor(Mat image, int windowSize, double clipLimit)
        {
            this.inputImage = image.Clone();
            this.windowSize = windowSize;
            this.clipLimit = clipLimit;
        }

        public CLAHEProcessor(Bitmap bitmap, int windowSize, double clipLimit)
        {
            this.inputImage = bitmap.ToMat();
            this.windowSize = windowSize;
            this.clipLimit = clipLimit;

            if (inputImage.NumberOfChannels > 1)
                CvInvoke.CvtColor(inputImage, inputImage, ColorConversion.Bgr2Gray);
        }

        public CLAHEProcessor(float[,] imageMatrix, int windowSize, double clipLimit)
        {
            this.windowSize = windowSize;
            this.clipLimit = clipLimit;

            int rows = imageMatrix.GetLength(0);
            int cols = imageMatrix.GetLength(1);

            inputImage = new Mat(rows, cols, DepthType.Cv8U, 1);

            Image<Gray, byte> img = new Image<Gray, byte>(cols, rows);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    img.Data[i, j, 0] = (byte)(imageMatrix[i, j] < 0 ? 0 : (imageMatrix[i, j] > 255 ? 255 : imageMatrix[i, j]));


            inputImage = img.Mat;
        }

        public Mat Apply()
        {
            Mat result = new Mat();

            CvInvoke.CLAHE(inputImage, clipLimit, new Size(windowSize, windowSize), result);

            return result;
        }
    }
    public class SuspiciousRegion
    {
        public Rectangle BoundingBox { get; set; }

        public double Area { get; set; }

        public double MeanIntensity { get; set; }

        public double SuspicionScore { get; set; }
    }

    public class Segmentation
    {
        private Mat image;

        public Segmentation(Mat input)
        {
            image = input.Clone();

            if (image.NumberOfChannels > 1)
                CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
        }

        public List<SuspiciousRegion> DetectSuspiciousRegions()
        {
            List<SuspiciousRegion> regions = new List<SuspiciousRegion>();

            Mat blurred = new Mat();
            Mat binary = new Mat();

            CvInvoke.GaussianBlur(image, blurred, new Size(5, 5), 1.5);

            CvInvoke.Threshold(
                blurred,
                binary,
                0,
                255,
                ThresholdType.Binary | ThresholdType.Otsu);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(
                binary,
                contours,
                null,
                RetrType.External,
                ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                double area = CvInvoke.ContourArea(contours[i]);

                if (area < 50)
                    continue;

                Mat roi = new Mat(image, rect);

                MCvScalar mean = CvInvoke.Mean(roi);

                SuspiciousRegion region = new SuspiciousRegion
                {
                    BoundingBox = rect,
                    Area = area,
                    MeanIntensity = mean.V0,
                    SuspicionScore = mean.V0 / 255.0
                };

                regions.Add(region);
            }

            return regions;
        }
    }
}
