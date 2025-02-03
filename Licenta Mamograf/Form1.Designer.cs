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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.button_select = new System.Windows.Forms.Button();
            this.info_log = new System.Windows.Forms.RichTextBox();
            this.location = new System.Windows.Forms.TextBox();
            this.button_Preprocessing = new System.Windows.Forms.Button();
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
            this.button_RemoveROI = new System.Windows.Forms.Button();
            this.button_AIonROI = new System.Windows.Forms.Button();
            this.button_AI = new System.Windows.Forms.Button();
            this.button_show_image = new System.Windows.Forms.Button();
            this.button_show_mask = new System.Windows.Forms.Button();
            this.button_show = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox = new Licenta_Mamograf.MyImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.Location = new System.Drawing.Point(15, 6);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(159, 42);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Select Image";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // info_log
            // 
            this.info_log.BackColor = System.Drawing.Color.LightBlue;
            this.info_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_log.Location = new System.Drawing.Point(6, 134);
            this.info_log.Name = "info_log";
            this.info_log.Size = new System.Drawing.Size(364, 383);
            this.info_log.TabIndex = 3;
            this.info_log.Text = "";
            // 
            // location
            // 
            this.location.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.Location = new System.Drawing.Point(6, 102);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(364, 26);
            this.location.TabIndex = 2;
            // 
            // button_Preprocessing
            // 
            this.button_Preprocessing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Preprocessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Preprocessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Preprocessing.Location = new System.Drawing.Point(15, 17);
            this.button_Preprocessing.Name = "button_Preprocessing";
            this.button_Preprocessing.Size = new System.Drawing.Size(143, 47);
            this.button_Preprocessing.TabIndex = 4;
            this.button_Preprocessing.Text = "PreProcesare";
            this.button_Preprocessing.UseVisualStyleBackColor = false;
            this.button_Preprocessing.Click += new System.EventHandler(this.button_Preprocessing_Click);
            // 
            // endPoint
            // 
            this.endPoint.AutoSize = true;
            this.endPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPoint.Location = new System.Drawing.Point(103, 91);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(56, 20);
            this.endPoint.TabIndex = 20;
            this.endPoint.Text = "P2(x,y)";
            // 
            // startPoint
            // 
            this.startPoint.AutoSize = true;
            this.startPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPoint.Location = new System.Drawing.Point(103, 65);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(56, 20);
            this.startPoint.TabIndex = 19;
            this.startPoint.Text = "P1(x,y)";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y.Location = new System.Drawing.Point(56, 91);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(16, 20);
            this.label_y.TabIndex = 18;
            this.label_y.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_x.Location = new System.Drawing.Point(56, 65);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(16, 20);
            this.label_x.TabIndex = 16;
            this.label_x.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 65);
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
            this.button_selectROI.Location = new System.Drawing.Point(25, 6);
            this.button_selectROI.Name = "button_selectROI";
            this.button_selectROI.Size = new System.Drawing.Size(168, 47);
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
            this.button_relode.Location = new System.Drawing.Point(15, 54);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(159, 42);
            this.button_relode.TabIndex = 23;
            this.button_relode.Text = "Relode Image";
            this.button_relode.UseVisualStyleBackColor = false;
            this.button_relode.Click += new System.EventHandler(this.button_relode_Click);
            // 
            // button_log
            // 
            this.button_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_log.Location = new System.Drawing.Point(289, 77);
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
            this.button_CLHE.Location = new System.Drawing.Point(15, 70);
            this.button_CLHE.Name = "button_CLHE";
            this.button_CLHE.Size = new System.Drawing.Size(143, 47);
            this.button_CLHE.TabIndex = 29;
            this.button_CLHE.Text = "CLHE";
            this.button_CLHE.UseVisualStyleBackColor = false;
            this.button_CLHE.Click += new System.EventHandler(this.button_CLHE_Click);
            // 
            // contrastLimit
            // 
            this.contrastLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastLimit.Location = new System.Drawing.Point(125, 177);
            this.contrastLimit.Margin = new System.Windows.Forms.Padding(2);
            this.contrastLimit.Name = "contrastLimit";
            this.contrastLimit.Size = new System.Drawing.Size(33, 26);
            this.contrastLimit.TabIndex = 30;
            this.contrastLimit.Text = "5";
            this.contrastLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Contrast Limit";
            // 
            // button_CLAHE
            // 
            this.button_CLAHE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_CLAHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLAHE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLAHE.Location = new System.Drawing.Point(15, 123);
            this.button_CLAHE.Name = "button_CLAHE";
            this.button_CLAHE.Size = new System.Drawing.Size(143, 47);
            this.button_CLAHE.TabIndex = 32;
            this.button_CLAHE.Text = "CLAHE";
            this.button_CLAHE.UseVisualStyleBackColor = false;
            this.button_CLAHE.Click += new System.EventHandler(this.button_CLAHE_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 207);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Window Size";
            // 
            // windowSize
            // 
            this.windowSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowSize.Location = new System.Drawing.Point(125, 204);
            this.windowSize.Margin = new System.Windows.Forms.Padding(2);
            this.windowSize.Name = "windowSize";
            this.windowSize.Size = new System.Drawing.Size(33, 26);
            this.windowSize.TabIndex = 33;
            this.windowSize.Text = "8";
            this.windowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chart_Histogram
            // 
            this.chart_Histogram.BackColor = System.Drawing.Color.Teal;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.MaximumAutoSize = 0F;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 85F;
            chartArea1.InnerPlotPosition.Width = 80F;
            chartArea1.InnerPlotPosition.X = 15F;
            chartArea1.InnerPlotPosition.Y = 5F;
            chartArea1.Name = "ChartArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chart_Histogram.ChartAreas.Add(chartArea1);
            this.chart_Histogram.Location = new System.Drawing.Point(3, 307);
            this.chart_Histogram.Name = "chart_Histogram";
            this.chart_Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Name = "Pixel";
            dataPoint1.Color = System.Drawing.Color.Black;
            series1.Points.Add(dataPoint1);
            series1.YValuesPerPoint = 2;
            this.chart_Histogram.Series.Add(series1);
            this.chart_Histogram.Size = new System.Drawing.Size(367, 210);
            this.chart_Histogram.TabIndex = 39;
            this.chart_Histogram.Text = "Histogram";
            // 
            // button_Charts
            // 
            this.button_Charts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Charts.Location = new System.Drawing.Point(260, 56);
            this.button_Charts.Name = "button_Charts";
            this.button_Charts.Size = new System.Drawing.Size(100, 27);
            this.button_Charts.TabIndex = 40;
            this.button_Charts.Text = "Update Charts";
            this.button_Charts.UseVisualStyleBackColor = true;
            this.button_Charts.Click += new System.EventHandler(this.button_Charts_Click);
            // 
            // chart_CumulativeHistogram
            // 
            this.chart_CumulativeHistogram.BackColor = System.Drawing.Color.Teal;
            chartArea2.AxisX.Maximum = 255D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 85F;
            chartArea2.InnerPlotPosition.Width = 80F;
            chartArea2.InnerPlotPosition.X = 15F;
            chartArea2.InnerPlotPosition.Y = 5F;
            chartArea2.Name = "ChartArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.chart_CumulativeHistogram.ChartAreas.Add(chartArea2);
            this.chart_CumulativeHistogram.Location = new System.Drawing.Point(6, 91);
            this.chart_CumulativeHistogram.Name = "chart_CumulativeHistogram";
            this.chart_CumulativeHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Pixel";
            series2.Points.Add(dataPoint2);
            this.chart_CumulativeHistogram.Series.Add(series2);
            this.chart_CumulativeHistogram.Size = new System.Drawing.Size(364, 210);
            this.chart_CumulativeHistogram.TabIndex = 41;
            this.chart_CumulativeHistogram.Text = "Histogram";
            // 
            // button_RemoveROI
            // 
            this.button_RemoveROI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_RemoveROI.Location = new System.Drawing.Point(199, 6);
            this.button_RemoveROI.Name = "button_RemoveROI";
            this.button_RemoveROI.Size = new System.Drawing.Size(144, 38);
            this.button_RemoveROI.TabIndex = 42;
            this.button_RemoveROI.Text = "Remove ROI";
            this.button_RemoveROI.UseVisualStyleBackColor = true;
            this.button_RemoveROI.Click += new System.EventHandler(this.button_RemoveROI_Click);
            // 
            // button_AIonROI
            // 
            this.button_AIonROI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_AIonROI.Location = new System.Drawing.Point(199, 47);
            this.button_AIonROI.Name = "button_AIonROI";
            this.button_AIonROI.Size = new System.Drawing.Size(144, 38);
            this.button_AIonROI.TabIndex = 43;
            this.button_AIonROI.Text = "Apply AI on ROI";
            this.button_AIonROI.UseVisualStyleBackColor = true;
            this.button_AIonROI.Click += new System.EventHandler(this.button_AIonROI_Click);
            // 
            // button_AI
            // 
            this.button_AI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_AI.Location = new System.Drawing.Point(199, 91);
            this.button_AI.Name = "button_AI";
            this.button_AI.Size = new System.Drawing.Size(144, 38);
            this.button_AI.TabIndex = 44;
            this.button_AI.Text = "Apply AI";
            this.button_AI.UseVisualStyleBackColor = true;
            this.button_AI.Click += new System.EventHandler(this.button_AI_Click);
            // 
            // button_show_image
            // 
            this.button_show_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_show_image.Location = new System.Drawing.Point(11, 13);
            this.button_show_image.Name = "button_show_image";
            this.button_show_image.Size = new System.Drawing.Size(138, 32);
            this.button_show_image.TabIndex = 45;
            this.button_show_image.Text = "Show Image";
            this.button_show_image.UseVisualStyleBackColor = true;
            this.button_show_image.Click += new System.EventHandler(this.button_show_image_Click);
            // 
            // button_show_mask
            // 
            this.button_show_mask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_show_mask.Location = new System.Drawing.Point(11, 51);
            this.button_show_mask.Name = "button_show_mask";
            this.button_show_mask.Size = new System.Drawing.Size(138, 32);
            this.button_show_mask.TabIndex = 46;
            this.button_show_mask.Text = "Show Mask";
            this.button_show_mask.UseVisualStyleBackColor = true;
            this.button_show_mask.Click += new System.EventHandler(this.button_show_mask_Click);
            // 
            // button_show
            // 
            this.button_show.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_show.Location = new System.Drawing.Point(155, 13);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(138, 32);
            this.button_show.TabIndex = 47;
            this.button_show.Text = "Image + Mask";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 556);
            this.tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage1.Controls.Add(this.button_select);
            this.tabPage1.Controls.Add(this.button_relode);
            this.tabPage1.Controls.Add(this.button_log);
            this.tabPage1.Controls.Add(this.info_log);
            this.tabPage1.Controls.Add(this.location);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(376, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Incarcare";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage2.Controls.Add(this.button_Preprocessing);
            this.tabPage2.Controls.Add(this.button_CLHE);
            this.tabPage2.Controls.Add(this.button_CLAHE);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.contrastLimit);
            this.tabPage2.Controls.Add(this.windowSize);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(376, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesare";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage3.Controls.Add(this.button_selectROI);
            this.tabPage3.Controls.Add(this.label_x);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button_AI);
            this.tabPage3.Controls.Add(this.label_y);
            this.tabPage3.Controls.Add(this.button_AIonROI);
            this.tabPage3.Controls.Add(this.startPoint);
            this.tabPage3.Controls.Add(this.button_RemoveROI);
            this.tabPage3.Controls.Add(this.endPoint);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(376, 523);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Aplicare AI";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage4.Controls.Add(this.button_show_image);
            this.tabPage4.Controls.Add(this.chart_CumulativeHistogram);
            this.tabPage4.Controls.Add(this.button_show);
            this.tabPage4.Controls.Add(this.chart_Histogram);
            this.tabPage4.Controls.Add(this.button_Charts);
            this.tabPage4.Controls.Add(this.button_show_mask);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(376, 523);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Vizualizare";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(402, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(556, 556);
            this.pictureBox.TabIndex = 48;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Image_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(969, 580);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Image_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.RichTextBox info_log;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.Button button_Preprocessing;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Histogram;
        private System.Windows.Forms.Button button_Charts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CumulativeHistogram;
        private System.Windows.Forms.Button button_RemoveROI;
        private System.Windows.Forms.Button button_AIonROI;
        private System.Windows.Forms.Button button_AI;
        private System.Windows.Forms.Button button_show_image;
        private System.Windows.Forms.Button button_show_mask;
        private System.Windows.Forms.Button button_show;
        private MyImageBox pictureBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

