namespace Licenta_Mamograf
{
    partial class Image_Analysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.button_select = new System.Windows.Forms.Button();
            this.info_log = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_WaveletDenoising = new System.Windows.Forms.Button();
            this.endPoint = new System.Windows.Forms.Label();
            this.startPoint = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_selectROI = new System.Windows.Forms.Button();
            this.button_relode = new System.Windows.Forms.Button();
            this.button_log = new System.Windows.Forms.Button();
            this.button_CLHE = new System.Windows.Forms.Button();
            this.contrastLimit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_CLAHE = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.windowSize = new System.Windows.Forms.TextBox();
            this.chart_Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Charts = new System.Windows.Forms.Button();
            this.chart_CumulativeHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox = new Licenta_Mamograf.MyImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.Location = new System.Drawing.Point(530, 51);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(137, 42);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Select IMG";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // info_log
            // 
            this.info_log.BackColor = System.Drawing.Color.LightBlue;
            this.info_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_log.Location = new System.Drawing.Point(673, 12);
            this.info_log.Name = "info_log";
            this.info_log.Size = new System.Drawing.Size(173, 157);
            this.info_log.TabIndex = 3;
            this.info_log.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(530, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button_WaveletDenoising
            // 
            this.button_WaveletDenoising.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_WaveletDenoising.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_WaveletDenoising.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_WaveletDenoising.Location = new System.Drawing.Point(683, 189);
            this.button_WaveletDenoising.Name = "button_WaveletDenoising";
            this.button_WaveletDenoising.Size = new System.Drawing.Size(163, 47);
            this.button_WaveletDenoising.TabIndex = 4;
            this.button_WaveletDenoising.Text = "Wavelet Denoising";
            this.button_WaveletDenoising.UseVisualStyleBackColor = false;
            this.button_WaveletDenoising.Click += new System.EventHandler(this.button_WaveletDenoising_Click);
            // 
            // endPoint
            // 
            this.endPoint.AutoSize = true;
            this.endPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPoint.Location = new System.Drawing.Point(932, 216);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(56, 20);
            this.endPoint.TabIndex = 20;
            this.endPoint.Text = "P2(x,y)";
            // 
            // startPoint
            // 
            this.startPoint.AutoSize = true;
            this.startPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPoint.Location = new System.Drawing.Point(932, 186);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(56, 20);
            this.startPoint.TabIndex = 19;
            this.startPoint.Text = "P1(x,y)";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y.Location = new System.Drawing.Point(885, 216);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(16, 20);
            this.label_y.TabIndex = 18;
            this.label_y.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(865, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_x.Location = new System.Drawing.Point(885, 186);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(16, 20);
            this.label_x.TabIndex = 16;
            this.label_x.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(865, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "X";
            // 
            // button_selectROI
            // 
            this.button_selectROI.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_selectROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_selectROI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_selectROI.Location = new System.Drawing.Point(862, 136);
            this.button_selectROI.Name = "button_selectROI";
            this.button_selectROI.Size = new System.Drawing.Size(163, 47);
            this.button_selectROI.TabIndex = 21;
            this.button_selectROI.Text = "Select ROI";
            this.button_selectROI.UseVisualStyleBackColor = false;
            this.button_selectROI.Click += new System.EventHandler(this.button_selectROI_Click);
            // 
            // button_relode
            // 
            this.button_relode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_relode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_relode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_relode.Location = new System.Drawing.Point(530, 113);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(137, 42);
            this.button_relode.TabIndex = 23;
            this.button_relode.Text = "Relode IMG";
            this.button_relode.UseVisualStyleBackColor = false;
            this.button_relode.Click += new System.EventHandler(this.button_relode_Click);
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(765, 167);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(81, 19);
            this.button_log.TabIndex = 24;
            this.button_log.Text = "Clean LOG";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // button_CLHE
            // 
            this.button_CLHE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_CLHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLHE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLHE.Location = new System.Drawing.Point(875, 12);
            this.button_CLHE.Name = "button_CLHE";
            this.button_CLHE.Size = new System.Drawing.Size(72, 47);
            this.button_CLHE.TabIndex = 29;
            this.button_CLHE.Text = "CLHE";
            this.button_CLHE.UseVisualStyleBackColor = false;
            this.button_CLHE.Click += new System.EventHandler(this.button_CLHE_Click);
            // 
            // contrastLimit
            // 
            this.contrastLimit.Location = new System.Drawing.Point(962, 74);
            this.contrastLimit.Margin = new System.Windows.Forms.Padding(2);
            this.contrastLimit.Name = "contrastLimit";
            this.contrastLimit.Size = new System.Drawing.Size(33, 20);
            this.contrastLimit.TabIndex = 30;
            this.contrastLimit.Text = "5";
            this.contrastLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(872, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Contrast Limit";
            // 
            // button_CLAHE
            // 
            this.button_CLAHE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_CLAHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLAHE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLAHE.Location = new System.Drawing.Point(953, 12);
            this.button_CLAHE.Name = "button_CLAHE";
            this.button_CLAHE.Size = new System.Drawing.Size(72, 47);
            this.button_CLAHE.TabIndex = 32;
            this.button_CLAHE.Text = "CLAHE";
            this.button_CLAHE.UseVisualStyleBackColor = false;
            this.button_CLAHE.Click += new System.EventHandler(this.button_CLAHE_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(872, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Window Size";
            // 
            // windowSize
            // 
            this.windowSize.Location = new System.Drawing.Point(962, 99);
            this.windowSize.Margin = new System.Windows.Forms.Padding(2);
            this.windowSize.Name = "windowSize";
            this.windowSize.Size = new System.Drawing.Size(33, 20);
            this.windowSize.TabIndex = 33;
            this.windowSize.Text = "64";
            this.windowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chart_Histogram
            // 
            this.chart_Histogram.BackColor = System.Drawing.Color.SkyBlue;
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.MaximumAutoSize = 0F;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 85F;
            chartArea3.InnerPlotPosition.Width = 85F;
            chartArea3.InnerPlotPosition.X = 10F;
            chartArea3.InnerPlotPosition.Y = 5F;
            chartArea3.Name = "ChartArea";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 100F;
            chartArea3.Position.Width = 100F;
            this.chart_Histogram.ChartAreas.Add(chartArea3);
            this.chart_Histogram.Location = new System.Drawing.Point(530, 277);
            this.chart_Histogram.Name = "chart_Histogram";
            this.chart_Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "ChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series3.Name = "Pixel";
            series3.Points.Add(dataPoint3);
            series3.YValuesPerPoint = 2;
            this.chart_Histogram.Series.Add(series3);
            this.chart_Histogram.Size = new System.Drawing.Size(300, 300);
            this.chart_Histogram.TabIndex = 39;
            this.chart_Histogram.Text = "Histogram";
            // 
            // button_Charts
            // 
            this.button_Charts.Location = new System.Drawing.Point(530, 244);
            this.button_Charts.Name = "button_Charts";
            this.button_Charts.Size = new System.Drawing.Size(100, 27);
            this.button_Charts.TabIndex = 40;
            this.button_Charts.Text = "Show Charts";
            this.button_Charts.UseVisualStyleBackColor = true;
            this.button_Charts.Click += new System.EventHandler(this.button_Charts_Click);
            // 
            // chart_CumulativeHistogram
            // 
            this.chart_CumulativeHistogram.BackColor = System.Drawing.Color.SkyBlue;
            chartArea4.AxisX.Maximum = 255D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 85F;
            chartArea4.InnerPlotPosition.Width = 85F;
            chartArea4.InnerPlotPosition.X = 10F;
            chartArea4.InnerPlotPosition.Y = 5F;
            chartArea4.Name = "ChartArea";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 100F;
            chartArea4.Position.Width = 100F;
            this.chart_CumulativeHistogram.ChartAreas.Add(chartArea4);
            this.chart_CumulativeHistogram.Location = new System.Drawing.Point(836, 277);
            this.chart_CumulativeHistogram.Name = "chart_CumulativeHistogram";
            this.chart_CumulativeHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.ChartArea = "ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Name = "Pixel";
            series4.Points.Add(dataPoint4);
            this.chart_CumulativeHistogram.Series.Add(series4);
            this.chart_CumulativeHistogram.Size = new System.Drawing.Size(300, 300);
            this.chart_CumulativeHistogram.TabIndex = 41;
            this.chart_CumulativeHistogram.Text = "Histogram";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.SkyBlue;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Location = new System.Drawing.Point(12, 65);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.TabIndex = 25;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Image_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1150, 598);
            this.Controls.Add(this.chart_CumulativeHistogram);
            this.Controls.Add(this.button_Charts);
            this.Controls.Add(this.chart_Histogram);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.windowSize);
            this.Controls.Add(this.button_CLAHE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.contrastLimit);
            this.Controls.Add(this.button_CLHE);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.button_relode);
            this.Controls.Add(this.button_selectROI);
            this.Controls.Add(this.endPoint);
            this.Controls.Add(this.startPoint);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_WaveletDenoising);
            this.Controls.Add(this.info_log);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.pictureBox);
            this.Name = "Image_Analysis";
            this.Text = "Image Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.RichTextBox info_log;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_WaveletDenoising;
        private System.Windows.Forms.Label endPoint;
        private System.Windows.Forms.Label startPoint;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_selectROI;
        private System.Windows.Forms.Button button_relode;
        private System.Windows.Forms.Button button_log;
        private System.Windows.Forms.Button button_CLHE;
        private System.Windows.Forms.TextBox contrastLimit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_CLAHE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox windowSize;
        internal MyImageBox pictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Histogram;
        private System.Windows.Forms.Button button_Charts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CumulativeHistogram;
    }
}

