using System.IO;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button_show_image = new Krypton.Toolkit.KryptonButton();
            this.chart_CumulativeHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_show = new Krypton.Toolkit.KryptonButton();
            this.chart_Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Charts = new Krypton.Toolkit.KryptonButton();
            this.button_show_mask = new Krypton.Toolkit.KryptonButton();
            this.button_selectROI = new Krypton.Toolkit.KryptonButton();
            this.label_x = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_AI = new Krypton.Toolkit.KryptonButton();
            this.label_y = new System.Windows.Forms.Label();
            this.button_AIonROI = new Krypton.Toolkit.KryptonButton();
            this.startPoint = new System.Windows.Forms.Label();
            this.button_RemoveROI = new Krypton.Toolkit.KryptonButton();
            this.endPoint = new System.Windows.Forms.Label();
            this.Tissue_Info = new Krypton.Toolkit.KryptonRichTextBox();
            this.contrastLimit = new Krypton.Toolkit.KryptonTextBox();
            this.windowSize = new Krypton.Toolkit.KryptonTextBox();
            this.label_Tissue0 = new System.Windows.Forms.Label();
            this.button_Preprocessing = new Krypton.Toolkit.KryptonButton();
            this.button_typeTissue = new Krypton.Toolkit.KryptonButton();
            this.button_CLHE = new Krypton.Toolkit.KryptonButton();
            this.button_CLAHE = new Krypton.Toolkit.KryptonButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_save = new Krypton.Toolkit.KryptonButton();
            this.button_select = new Krypton.Toolkit.KryptonButton();
            this.button_relode = new Krypton.Toolkit.KryptonButton();
            this.button_log = new Krypton.Toolkit.KryptonButton();
            this.info_log = new System.Windows.Forms.RichTextBox();
            this.location = new Krypton.Toolkit.KryptonTextBox();
            this.LabelInfoButton = new Krypton.Toolkit.KryptonRichTextBox();
            this.buttonSpecAny1 = new Krypton.Toolkit.ButtonSpecAny();
            this.timer_hover = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new Licenta_Mamograf.MyImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_show_image
            // 
            this.button_show_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_image.Location = new System.Drawing.Point(253, 413);
            this.button_show_image.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_show_image.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_show_image.Name = "button_show_image";
            this.button_show_image.Size = new System.Drawing.Size(138, 40);
            this.button_show_image.StateCommon.Border.Rounding = 10F;
            this.button_show_image.StateCommon.Border.Width = 1;
            this.button_show_image.TabIndex = 45;
            this.button_show_image.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_image.Values.Text = "Show Image";
            this.button_show_image.Click += new System.EventHandler(this.button_show_image_Click);
            this.button_show_image.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show_image.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // chart_CumulativeHistogram
            // 
            this.chart_CumulativeHistogram.BackColor = System.Drawing.Color.Teal;
            chartArea3.AxisX.Maximum = 255D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 80F;
            chartArea3.InnerPlotPosition.Width = 85F;
            chartArea3.InnerPlotPosition.X = 10F;
            chartArea3.InnerPlotPosition.Y = 10F;
            chartArea3.Name = "CumulativeHistogram";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 100F;
            chartArea3.Position.Width = 100F;
            this.chart_CumulativeHistogram.ChartAreas.Add(chartArea3);
            this.chart_CumulativeHistogram.Location = new System.Drawing.Point(404, 432);
            this.chart_CumulativeHistogram.Name = "chart_CumulativeHistogram";
            this.chart_CumulativeHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.ChartArea = "CumulativeHistogram";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Name = "Pixel";
            series3.Points.Add(dataPoint3);
            this.chart_CumulativeHistogram.Series.Add(series3);
            this.chart_CumulativeHistogram.Size = new System.Drawing.Size(282, 154);
            this.chart_CumulativeHistogram.TabIndex = 41;
            title3.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            title3.DockingOffset = -10;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Position.Auto = false;
            title3.Position.Height = 8.378904F;
            title3.Position.Width = 94F;
            title3.Position.X = 3F;
            title3.Position.Y = 1F;
            title3.Text = "Histograma Cumulativa";
            this.chart_CumulativeHistogram.Titles.Add(title3);
            // 
            // button_show
            // 
            this.button_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show.Location = new System.Drawing.Point(253, 548);
            this.button_show.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_show.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(138, 40);
            this.button_show.StateCommon.Border.Rounding = 10F;
            this.button_show.StateCommon.Border.Width = 1;
            this.button_show.TabIndex = 47;
            this.button_show.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show.Values.Text = "Image + Mask";
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            this.button_show.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // chart_Histogram
            // 
            this.chart_Histogram.BackColor = System.Drawing.Color.Teal;
            chartArea4.AxisX.Maximum = 255D;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisY.MaximumAutoSize = 0F;
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 80F;
            chartArea4.InnerPlotPosition.Width = 85F;
            chartArea4.InnerPlotPosition.X = 10F;
            chartArea4.InnerPlotPosition.Y = 10F;
            chartArea4.Name = "ChartArea";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 100F;
            chartArea4.Position.Width = 100F;
            this.chart_Histogram.ChartAreas.Add(chartArea4);
            this.chart_Histogram.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chart_Histogram.Location = new System.Drawing.Point(404, 272);
            this.chart_Histogram.Name = "chart_Histogram";
            this.chart_Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.ChartArea = "ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series4.Name = "Pixel";
            dataPoint4.Color = System.Drawing.Color.Black;
            series4.Points.Add(dataPoint4);
            series4.YValuesPerPoint = 2;
            this.chart_Histogram.Series.Add(series4);
            this.chart_Histogram.Size = new System.Drawing.Size(282, 154);
            this.chart_Histogram.TabIndex = 39;
            title4.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title1";
            title4.Position.Auto = false;
            title4.Position.Height = 8.378904F;
            title4.Position.Width = 94F;
            title4.Position.X = 3F;
            title4.Position.Y = 1F;
            title4.Text = "Histograma";
            this.chart_Histogram.Titles.Add(title4);
            // 
            // button_Charts
            // 
            this.button_Charts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Charts.Location = new System.Drawing.Point(253, 505);
            this.button_Charts.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_Charts.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_Charts.Name = "button_Charts";
            this.button_Charts.Size = new System.Drawing.Size(138, 40);
            this.button_Charts.StateCommon.Border.Rounding = 10F;
            this.button_Charts.StateCommon.Border.Width = 1;
            this.button_Charts.TabIndex = 40;
            this.button_Charts.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Charts.Values.Text = "Update Charts";
            this.button_Charts.Click += new System.EventHandler(this.button_Charts_Click);
            this.button_Charts.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Charts.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_Charts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_show_mask
            // 
            this.button_show_mask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_mask.Location = new System.Drawing.Point(253, 459);
            this.button_show_mask.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_show_mask.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_show_mask.Name = "button_show_mask";
            this.button_show_mask.Size = new System.Drawing.Size(138, 40);
            this.button_show_mask.StateCommon.Border.Rounding = 10F;
            this.button_show_mask.StateCommon.Border.Width = 1;
            this.button_show_mask.TabIndex = 46;
            this.button_show_mask.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_mask.Values.Text = "Show Mask";
            this.button_show_mask.Click += new System.EventHandler(this.button_show_mask_Click);
            this.button_show_mask.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show_mask.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show_mask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_selectROI
            // 
            this.button_selectROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_selectROI.Location = new System.Drawing.Point(393, 12);
            this.button_selectROI.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_selectROI.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_selectROI.Name = "button_selectROI";
            this.button_selectROI.Size = new System.Drawing.Size(130, 40);
            this.button_selectROI.StateCommon.Border.Rounding = 10F;
            this.button_selectROI.StateCommon.Border.Width = 1;
            this.button_selectROI.TabIndex = 21;
            this.button_selectROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_selectROI.Values.Text = "Select ROI";
            this.button_selectROI.Click += new System.EventHandler(this.button_selectROI_Click);
            this.button_selectROI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_selectROI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_selectROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_x.Location = new System.Drawing.Point(413, 55);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(16, 20);
            this.label_x.TabIndex = 16;
            this.label_x.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(393, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(393, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "W";
            // 
            // button_AI
            // 
            this.button_AI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_AI.Location = new System.Drawing.Point(393, 195);
            this.button_AI.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_AI.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_AI.Name = "button_AI";
            this.button_AI.Size = new System.Drawing.Size(130, 40);
            this.button_AI.StateCommon.Border.Rounding = 10F;
            this.button_AI.StateCommon.Border.Width = 1;
            this.button_AI.TabIndex = 44;
            this.button_AI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_AI.Values.Text = "Apply AI";
            this.button_AI.Click += new System.EventHandler(this.button_AI_Click);
            this.button_AI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_AI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_AI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y.Location = new System.Drawing.Point(413, 81);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(16, 20);
            this.label_y.TabIndex = 18;
            this.label_y.Text = "y";
            // 
            // button_AIonROI
            // 
            this.button_AIonROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_AIonROI.Location = new System.Drawing.Point(393, 151);
            this.button_AIonROI.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_AIonROI.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_AIonROI.Name = "button_AIonROI";
            this.button_AIonROI.Size = new System.Drawing.Size(130, 40);
            this.button_AIonROI.StateCommon.Border.Rounding = 10F;
            this.button_AIonROI.StateCommon.Border.Width = 1;
            this.button_AIonROI.TabIndex = 43;
            this.button_AIonROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_AIonROI.Values.Text = "Apply AI on ROI";
            this.button_AIonROI.Click += new System.EventHandler(this.button_AIonROI_Click);
            this.button_AIonROI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_AIonROI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_AIonROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // startPoint
            // 
            this.startPoint.AutoSize = true;
            this.startPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPoint.Location = new System.Drawing.Point(460, 55);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(56, 20);
            this.startPoint.TabIndex = 19;
            this.startPoint.Text = "P1(x,y)";
            // 
            // button_RemoveROI
            // 
            this.button_RemoveROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoveROI.Location = new System.Drawing.Point(393, 107);
            this.button_RemoveROI.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_RemoveROI.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_RemoveROI.Name = "button_RemoveROI";
            this.button_RemoveROI.Size = new System.Drawing.Size(130, 40);
            this.button_RemoveROI.StateCommon.Border.Rounding = 10F;
            this.button_RemoveROI.StateCommon.Border.Width = 1;
            this.button_RemoveROI.TabIndex = 42;
            this.button_RemoveROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_RemoveROI.Values.Text = "Remove ROI";
            this.button_RemoveROI.Click += new System.EventHandler(this.button_RemoveROI_Click);
            this.button_RemoveROI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_RemoveROI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_RemoveROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // endPoint
            // 
            this.endPoint.AutoSize = true;
            this.endPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPoint.Location = new System.Drawing.Point(460, 81);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(56, 20);
            this.endPoint.TabIndex = 20;
            this.endPoint.Text = "P2(x,y)";
            // 
            // Tissue_Info
            // 
            this.Tissue_Info.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Tissue_Info.Location = new System.Drawing.Point(173, 272);
            this.Tissue_Info.MaxLength = 2147;
            this.Tissue_Info.Name = "Tissue_Info";
            this.Tissue_Info.ReadOnly = true;
            this.Tissue_Info.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Tissue_Info.Size = new System.Drawing.Size(225, 72);
            this.Tissue_Info.StateCommon.Back.Color1 = System.Drawing.Color.DarkCyan;
            this.Tissue_Info.StateCommon.Border.Rounding = 10F;
            this.Tissue_Info.StateCommon.Border.Width = 1;
            this.Tissue_Info.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tissue_Info.TabIndex = 47;
            this.Tissue_Info.Text = "Tissue 1: 99.9%\nTissue 2: 99.9%\nTissue 3: 99.9%";
            // 
            // contrastLimit
            // 
            this.contrastLimit.Location = new System.Drawing.Point(286, 147);
            this.contrastLimit.Margin = new System.Windows.Forms.Padding(2);
            this.contrastLimit.Name = "contrastLimit";
            this.contrastLimit.Size = new System.Drawing.Size(33, 27);
            this.contrastLimit.StateCommon.Border.Rounding = 5F;
            this.contrastLimit.StateCommon.Border.Width = 1;
            this.contrastLimit.TabIndex = 30;
            this.contrastLimit.Text = "5";
            this.contrastLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // windowSize
            // 
            this.windowSize.Location = new System.Drawing.Point(286, 175);
            this.windowSize.Margin = new System.Windows.Forms.Padding(2);
            this.windowSize.Name = "windowSize";
            this.windowSize.Size = new System.Drawing.Size(33, 27);
            this.windowSize.StateCommon.Border.Rounding = 5F;
            this.windowSize.StateCommon.Border.Width = 1;
            this.windowSize.TabIndex = 33;
            this.windowSize.Text = "16";
            this.windowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Tissue0
            // 
            this.label_Tissue0.AutoSize = true;
            this.label_Tissue0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tissue0.Location = new System.Drawing.Point(172, 249);
            this.label_Tissue0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Tissue0.Name = "label_Tissue0";
            this.label_Tissue0.Size = new System.Drawing.Size(101, 20);
            this.label_Tissue0.TabIndex = 46;
            this.label_Tissue0.Text = "Tissue Type: ";
            // 
            // button_Preprocessing
            // 
            this.button_Preprocessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Preprocessing.Location = new System.Drawing.Point(173, 12);
            this.button_Preprocessing.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_Preprocessing.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_Preprocessing.Name = "button_Preprocessing";
            this.button_Preprocessing.Size = new System.Drawing.Size(130, 40);
            this.button_Preprocessing.StateCommon.Border.Rounding = 10F;
            this.button_Preprocessing.StateCommon.Border.Width = 1;
            this.button_Preprocessing.TabIndex = 4;
            this.button_Preprocessing.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Preprocessing.Values.Text = "PreProcesare";
            this.button_Preprocessing.Click += new System.EventHandler(this.button_Preprocessing_Click);
            this.button_Preprocessing.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Preprocessing.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_Preprocessing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_typeTissue
            // 
            this.button_typeTissue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_typeTissue.Location = new System.Drawing.Point(173, 206);
            this.button_typeTissue.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_typeTissue.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_typeTissue.Name = "button_typeTissue";
            this.button_typeTissue.Size = new System.Drawing.Size(130, 40);
            this.button_typeTissue.StateCommon.Border.Rounding = 10F;
            this.button_typeTissue.StateCommon.Border.Width = 1;
            this.button_typeTissue.TabIndex = 45;
            this.button_typeTissue.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_typeTissue.Values.Text = "Tissue Type";
            this.button_typeTissue.Click += new System.EventHandler(this.button_typeTissue_Click);
            this.button_typeTissue.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_typeTissue.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_typeTissue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_CLHE
            // 
            this.button_CLHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLHE.Location = new System.Drawing.Point(173, 58);
            this.button_CLHE.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_CLHE.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_CLHE.Name = "button_CLHE";
            this.button_CLHE.Size = new System.Drawing.Size(130, 40);
            this.button_CLHE.StateCommon.Border.Rounding = 10F;
            this.button_CLHE.StateCommon.Border.Width = 1;
            this.button_CLHE.TabIndex = 29;
            this.button_CLHE.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_CLHE.Values.Text = "CLHE";
            this.button_CLHE.Click += new System.EventHandler(this.button_CLHE_Click);
            this.button_CLHE.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_CLHE.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_CLHE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_CLAHE
            // 
            this.button_CLAHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLAHE.Location = new System.Drawing.Point(173, 104);
            this.button_CLAHE.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_CLAHE.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_CLAHE.Name = "button_CLAHE";
            this.button_CLAHE.Size = new System.Drawing.Size(130, 40);
            this.button_CLAHE.StateCommon.Border.Rounding = 10F;
            this.button_CLAHE.StateCommon.Border.Width = 1;
            this.button_CLAHE.TabIndex = 32;
            this.button_CLAHE.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_CLAHE.Values.Text = "CLAHE";
            this.button_CLAHE.Click += new System.EventHandler(this.button_CLAHE_Click);
            this.button_CLAHE.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_CLAHE.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_CLAHE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Contrast Limit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(175, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Window Size";
            // 
            // button_save
            // 
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.Location = new System.Drawing.Point(12, 106);
            this.button_save.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_save.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(130, 40);
            this.button_save.StateCommon.Border.Rounding = 10F;
            this.button_save.StateCommon.Border.Width = 1;
            this.button_save.TabIndex = 25;
            this.button_save.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_save.Values.Text = "Save Image";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            this.button_save.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_save.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_save.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_select
            // 
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Location = new System.Drawing.Point(12, 12);
            this.button_select.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_select.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(130, 40);
            this.button_select.StateCommon.Border.Rounding = 10F;
            this.button_select.StateCommon.Border.Width = 1;
            this.button_select.TabIndex = 1;
            this.button_select.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_select.Values.Text = "Select Image";
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            this.button_select.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_select.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_select.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_relode
            // 
            this.button_relode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_relode.Location = new System.Drawing.Point(12, 58);
            this.button_relode.MaximumSize = new System.Drawing.Size(300, 400);
            this.button_relode.MinimumSize = new System.Drawing.Size(130, 40);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(130, 42);
            this.button_relode.StateCommon.Border.Rounding = 10F;
            this.button_relode.StateCommon.Border.Width = 1;
            this.button_relode.TabIndex = 23;
            this.button_relode.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_relode.Values.Text = "Relode Image";
            this.button_relode.Click += new System.EventHandler(this.button_relode_Click);
            this.button_relode.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_relode.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_relode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_log
            // 
            this.button_log.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_log.Location = new System.Drawing.Point(29, 213);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(78, 19);
            this.button_log.TabIndex = 24;
            this.button_log.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_log.Values.Text = "Clean LOG";
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // info_log
            // 
            this.info_log.BackColor = System.Drawing.Color.LightBlue;
            this.info_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_log.Location = new System.Drawing.Point(12, 153);
            this.info_log.MinimumSize = new System.Drawing.Size(100, 100);
            this.info_log.Name = "info_log";
            this.info_log.Size = new System.Drawing.Size(117, 100);
            this.info_log.TabIndex = 3;
            this.info_log.Text = "";
            // 
            // location
            // 
            this.location.Location = new System.Drawing.Point(12, 291);
            this.location.MinimumSize = new System.Drawing.Size(100, 10);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(100, 23);
            this.location.TabIndex = 2;
            // 
            // LabelInfoButton
            // 
            this.LabelInfoButton.AutoWordSelection = true;
            this.LabelInfoButton.ButtonSpecs.Add(this.buttonSpecAny1);
            this.LabelInfoButton.Location = new System.Drawing.Point(5, 413);
            this.LabelInfoButton.Name = "LabelInfoButton";
            this.LabelInfoButton.Size = new System.Drawing.Size(223, 120);
            this.LabelInfoButton.StateCommon.Back.Color1 = System.Drawing.Color.LightBlue;
            this.LabelInfoButton.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelInfoButton.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfoButton.TabIndex = 26;
            this.LabelInfoButton.Text = "text info";
            this.LabelInfoButton.Visible = false;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "80082fa31559462b8bead619446962f3";
            // 
            // timer_hover
            // 
            this.timer_hover.Interval = 1000;
            this.timer_hover.Tick += new System.EventHandler(this.timer_hover_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox.Location = new System.Drawing.Point(699, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(578, 578);
            this.pictureBox.TabIndex = 48;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Image_Analysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1289, 600);
            this.Controls.Add(this.LabelInfoButton);
            this.Controls.Add(this.Tissue_Info);
            this.Controls.Add(this.button_show_image);
            this.Controls.Add(this.contrastLimit);
            this.Controls.Add(this.button_selectROI);
            this.Controls.Add(this.windowSize);
            this.Controls.Add(this.chart_CumulativeHistogram);
            this.Controls.Add(this.label_Tissue0);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.button_Preprocessing);
            this.Controls.Add(this.button_typeTissue);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.button_CLHE);
            this.Controls.Add(this.chart_Histogram);
            this.Controls.Add(this.button_CLAHE);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_Charts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_show_mask);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.button_AI);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.button_relode);
            this.Controls.Add(this.button_AIonROI);
            this.Controls.Add(this.startPoint);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.button_RemoveROI);
            this.Controls.Add(this.info_log);
            this.Controls.Add(this.endPoint);
            this.Controls.Add(this.location);
            this.Name = "Image_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Image_Analysis_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private MyImageBox pictureBox;
        private Krypton.Toolkit.KryptonButton button_show_image;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CumulativeHistogram;
        private Krypton.Toolkit.KryptonButton button_show;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Histogram;
        private Krypton.Toolkit.KryptonButton button_Charts;
        private Krypton.Toolkit.KryptonButton button_show_mask;
        private Krypton.Toolkit.KryptonButton button_selectROI;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Krypton.Toolkit.KryptonButton button_AI;
        private System.Windows.Forms.Label label_y;
        private Krypton.Toolkit.KryptonButton button_AIonROI;
        private System.Windows.Forms.Label startPoint;
        private Krypton.Toolkit.KryptonButton button_RemoveROI;
        private System.Windows.Forms.Label endPoint;
        private Krypton.Toolkit.KryptonRichTextBox Tissue_Info;
        private Krypton.Toolkit.KryptonTextBox contrastLimit;
        private Krypton.Toolkit.KryptonTextBox windowSize;
        private System.Windows.Forms.Label label_Tissue0;
        private Krypton.Toolkit.KryptonButton button_Preprocessing;
        private Krypton.Toolkit.KryptonButton button_typeTissue;
        private Krypton.Toolkit.KryptonButton button_CLHE;
        private Krypton.Toolkit.KryptonButton button_CLAHE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Krypton.Toolkit.KryptonButton button_select;
        private Krypton.Toolkit.KryptonButton button_relode;
        private Krypton.Toolkit.KryptonButton button_log;
        private Krypton.Toolkit.KryptonButton button_save;
        private Krypton.Toolkit.KryptonRichTextBox LabelInfoButton;
        private Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.RichTextBox info_log;
        private Krypton.Toolkit.KryptonTextBox location;
        private System.Windows.Forms.Timer timer_hover;
    }
}

