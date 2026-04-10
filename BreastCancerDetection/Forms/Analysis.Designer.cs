using System.IO;
using System.Windows.Forms;
using Krypton.Toolkit;
using BreastCancerDetection.Classes;
using System.Drawing;
namespace BreastCancerDetection
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Analysis));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonSpecAny1 = new Krypton.Toolkit.ButtonSpecAny();
            this.timer_hover = new System.Windows.Forms.Timer(this.components);
            this.LabelInfoButton = new Krypton.Toolkit.KryptonRichTextBox();
            this.button_select = new Krypton.Toolkit.KryptonButton();
            this.button_Preprocessing = new Krypton.Toolkit.KryptonButton();
            this.button_information = new Krypton.Toolkit.KryptonButton();
            this.button_selectROI = new Krypton.Toolkit.KryptonButton();
            this.button_typeTissue = new Krypton.Toolkit.KryptonButton();
            this.button_CLHE = new Krypton.Toolkit.KryptonButton();
            this.button_CLAHE = new Krypton.Toolkit.KryptonButton();
            this.button_save = new Krypton.Toolkit.KryptonButton();
            this.label_ContrastLimit = new System.Windows.Forms.Label();
            this.label_WindowSize = new System.Windows.Forms.Label();
            this.button_GrowCut = new Krypton.Toolkit.KryptonButton();
            this.button_relode = new Krypton.Toolkit.KryptonButton();
            this.button_GrowCutOnROI = new Krypton.Toolkit.KryptonButton();
            this.button_RemoveROI = new Krypton.Toolkit.KryptonButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel4 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.button_autoProcessing = new Krypton.Toolkit.KryptonButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel7 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.label_Tissue = new System.Windows.Forms.Label();
            this.Tissue_Info = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonTableLayoutPanel5 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.windowSize = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTableLayoutPanel6 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.contrastLimit = new Krypton.Toolkit.KryptonNumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel3 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kryptonTableLayoutPanel9 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.thresHold = new Krypton.Toolkit.KryptonNumericUpDown();
            this.label_Threshold = new System.Windows.Forms.Label();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.label_H = new System.Windows.Forms.Label();
            this.label_W = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel8 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.chart_Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_CumulativeHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.KryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.button_show_image = new Krypton.Toolkit.KryptonButton();
            this.button_show_mask = new Krypton.Toolkit.KryptonButton();
            this.button_Charts = new Krypton.Toolkit.KryptonButton();
            this.button_show = new Krypton.Toolkit.KryptonButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel10 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.button_Tumod_Info = new Krypton.Toolkit.KryptonButton();
            this.TextBoxTumors = new Krypton.Toolkit.KryptonRichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.kryptonTableLayoutPanel11 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.button_Fourier = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonTableLayoutPanel12 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.filter_number_a = new Krypton.Toolkit.KryptonNumericUpDown();
            this.filter_number_b = new Krypton.Toolkit.KryptonNumericUpDown();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonTableLayoutPanel13 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.ButtonA = new Krypton.Toolkit.KryptonButton();
            this.ButtonB = new Krypton.Toolkit.KryptonButton();
            this.ButtonC = new Krypton.Toolkit.KryptonButton();
            this.Button_close = new Krypton.Toolkit.KryptonButton();
            this.Button_predictie = new Krypton.Toolkit.KryptonButton();
            this.ButtonD = new Krypton.Toolkit.KryptonButton();
            this.kryptonTableLayoutPanel14 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.T_number = new Krypton.Toolkit.KryptonNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.y0_number = new Krypton.Toolkit.KryptonNumericUpDown();
            this.x0_number = new Krypton.Toolkit.KryptonNumericUpDown();
            this.f_function = new System.Windows.Forms.TextBox();
            this.g_function = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ModeleChart = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.label_x = new System.Windows.Forms.TextBox();
            this.label_y = new System.Windows.Forms.TextBox();
            this.startPoint = new System.Windows.Forms.TextBox();
            this.endPoint = new System.Windows.Forms.TextBox();
            this.pictureBox = new BreastCancerDetection.Classes.MyImageBox();
            this.kryptonContextMenu1 = new Krypton.Toolkit.KryptonContextMenu();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.kryptonTableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.kryptonTableLayoutPanel7.SuspendLayout();
            this.kryptonTableLayoutPanel5.SuspendLayout();
            this.kryptonTableLayoutPanel6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.kryptonTableLayoutPanel3.SuspendLayout();
            this.kryptonTableLayoutPanel9.SuspendLayout();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.kryptonTableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).BeginInit();
            this.KryptonTableLayoutPanel1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.kryptonTableLayoutPanel10.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.kryptonTableLayoutPanel11.SuspendLayout();
            this.kryptonTableLayoutPanel12.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.kryptonTableLayoutPanel13.SuspendLayout();
            this.kryptonTableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.ModeleChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "80082fa31559462b8bead619446962f3";
            // 
            // timer_hover
            // 
            this.timer_hover.Interval = 1000;
            this.timer_hover.Tick += new System.EventHandler(this.Timer_hover_Tick);
            // 
            // LabelInfoButton
            // 
            this.LabelInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelInfoButton.AutoWordSelection = true;
            this.LabelInfoButton.ButtonSpecs.Add(this.buttonSpecAny1);
            this.LabelInfoButton.Enabled = false;
            this.LabelInfoButton.Location = new System.Drawing.Point(52, 498);
            this.LabelInfoButton.Name = "LabelInfoButton";
            this.LabelInfoButton.ReadOnly = true;
            this.LabelInfoButton.Size = new System.Drawing.Size(220, 37);
            this.LabelInfoButton.StateCommon.Back.Color1 = System.Drawing.Color.LightBlue;
            this.LabelInfoButton.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelInfoButton.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfoButton.TabIndex = 74;
            this.LabelInfoButton.Text = "text info";
            this.LabelInfoButton.Visible = false;
            // 
            // button_select
            // 
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_select.Location = new System.Drawing.Point(3, 3);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(218, 44);
            this.button_select.StateCommon.Border.Rounding = 10F;
            this.button_select.StateCommon.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.StateNormal.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.TabIndex = 60;
            this.button_select.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_select.Values.Text = "Select Image";
            this.button_select.Click += new System.EventHandler(this.Button_select_Click);
            this.button_select.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_select.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_select.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_Preprocessing
            // 
            this.button_Preprocessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Preprocessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Preprocessing.Location = new System.Drawing.Point(3, 3);
            this.button_Preprocessing.Name = "button_Preprocessing";
            this.button_Preprocessing.Size = new System.Drawing.Size(218, 44);
            this.button_Preprocessing.StateCommon.Border.Rounding = 10F;
            this.button_Preprocessing.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Preprocessing.TabIndex = 63;
            this.button_Preprocessing.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Preprocessing.Values.Text = "PreProcesare";
            this.button_Preprocessing.Click += new System.EventHandler(this.Button_Preprocessing_Click);
            this.button_Preprocessing.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_Preprocessing.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_Preprocessing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_information
            // 
            this.button_information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_information.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_information.Location = new System.Drawing.Point(9, 495);
            this.button_information.Margin = new System.Windows.Forms.Padding(0);
            this.button_information.Name = "button_information";
            this.button_information.Size = new System.Drawing.Size(40, 40);
            this.button_information.StateCommon.Border.Rounding = 25F;
            this.button_information.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2, -2, 0, 0);
            this.button_information.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_information.TabIndex = 88;
            this.button_information.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_information.Values.Text = "i";
            this.button_information.Click += new System.EventHandler(this.Button_information_Click);
            // 
            // button_selectROI
            // 
            this.button_selectROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_selectROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_selectROI.Location = new System.Drawing.Point(227, 52);
            this.button_selectROI.Name = "button_selectROI";
            this.button_selectROI.Size = new System.Drawing.Size(218, 43);
            this.button_selectROI.StateCommon.Border.Rounding = 10F;
            this.button_selectROI.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_selectROI.TabIndex = 70;
            this.button_selectROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_selectROI.Values.Text = "Select ROI";
            this.button_selectROI.Click += new System.EventHandler(this.Button_selectROI_Click);
            this.button_selectROI.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_selectROI.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_selectROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_typeTissue
            // 
            this.button_typeTissue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_typeTissue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_typeTissue.Location = new System.Drawing.Point(3, 53);
            this.button_typeTissue.Name = "button_typeTissue";
            this.button_typeTissue.Size = new System.Drawing.Size(218, 44);
            this.button_typeTissue.StateCommon.Border.Rounding = 10F;
            this.button_typeTissue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_typeTissue.TabIndex = 84;
            this.button_typeTissue.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_typeTissue.Values.Text = "Tissue Type";
            this.button_typeTissue.Click += new System.EventHandler(this.Button_typeTissue_Click);
            this.button_typeTissue.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_typeTissue.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_typeTissue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_CLHE
            // 
            this.button_CLHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLHE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CLHE.Location = new System.Drawing.Point(227, 3);
            this.button_CLHE.Name = "button_CLHE";
            this.button_CLHE.Size = new System.Drawing.Size(218, 44);
            this.button_CLHE.StateCommon.Border.Rounding = 10F;
            this.button_CLHE.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLHE.TabIndex = 75;
            this.button_CLHE.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_CLHE.Values.Text = "CLHE";
            this.button_CLHE.Click += new System.EventHandler(this.Button_CLHE_Click);
            this.button_CLHE.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_CLHE.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_CLHE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_CLAHE
            // 
            this.button_CLAHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLAHE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_CLAHE.Location = new System.Drawing.Point(227, 53);
            this.button_CLAHE.Name = "button_CLAHE";
            this.button_CLAHE.Size = new System.Drawing.Size(218, 44);
            this.button_CLAHE.StateCommon.Border.Rounding = 10F;
            this.button_CLAHE.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CLAHE.TabIndex = 78;
            this.button_CLAHE.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_CLAHE.Values.Text = "CLAHE";
            this.button_CLAHE.Click += new System.EventHandler(this.Button_CLAHE_Click);
            this.button_CLAHE.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_CLAHE.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_CLAHE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_save
            // 
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.Location = new System.Drawing.Point(3, 53);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(218, 44);
            this.button_save.StateCommon.Border.Rounding = 10F;
            this.button_save.StateCommon.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.StateNormal.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.TabIndex = 73;
            this.button_save.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_save.Values.Text = "Save Image";
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            this.button_save.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_save.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_save.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // label_ContrastLimit
            // 
            this.label_ContrastLimit.AutoSize = true;
            this.label_ContrastLimit.BackColor = System.Drawing.Color.Transparent;
            this.label_ContrastLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ContrastLimit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ContrastLimit.Location = new System.Drawing.Point(2, 0);
            this.label_ContrastLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ContrastLimit.Name = "label_ContrastLimit";
            this.label_ContrastLimit.Size = new System.Drawing.Size(124, 30);
            this.label_ContrastLimit.TabIndex = 77;
            this.label_ContrastLimit.Text = "Contrast Limit";
            this.label_ContrastLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_WindowSize
            // 
            this.label_WindowSize.AutoSize = true;
            this.label_WindowSize.BackColor = System.Drawing.Color.Transparent;
            this.label_WindowSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_WindowSize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WindowSize.Location = new System.Drawing.Point(2, 0);
            this.label_WindowSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_WindowSize.Name = "label_WindowSize";
            this.label_WindowSize.Size = new System.Drawing.Size(124, 30);
            this.label_WindowSize.TabIndex = 80;
            this.label_WindowSize.Text = "Window Size";
            this.label_WindowSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_GrowCut
            // 
            this.button_GrowCut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_GrowCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_GrowCut.Location = new System.Drawing.Point(3, 3);
            this.button_GrowCut.Name = "button_GrowCut";
            this.button_GrowCut.Size = new System.Drawing.Size(218, 43);
            this.button_GrowCut.StateCommon.Border.Rounding = 10F;
            this.button_GrowCut.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GrowCut.TabIndex = 83;
            this.button_GrowCut.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_GrowCut.Values.Text = "Apply GrowCut";
            this.button_GrowCut.Click += new System.EventHandler(this.Button_GrowCut_Click);
            this.button_GrowCut.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_GrowCut.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_GrowCut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_relode
            // 
            this.button_relode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_relode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_relode.Location = new System.Drawing.Point(227, 3);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(218, 44);
            this.button_relode.StateCommon.Border.Rounding = 10F;
            this.button_relode.StateCommon.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_relode.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_relode.StateNormal.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_relode.TabIndex = 71;
            this.button_relode.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_relode.Values.Text = "Relode Image";
            this.button_relode.Click += new System.EventHandler(this.Button_relode_Click);
            this.button_relode.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_relode.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_relode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_GrowCutOnROI
            // 
            this.button_GrowCutOnROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_GrowCutOnROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_GrowCutOnROI.Location = new System.Drawing.Point(3, 52);
            this.button_GrowCutOnROI.Name = "button_GrowCutOnROI";
            this.button_GrowCutOnROI.Size = new System.Drawing.Size(218, 43);
            this.button_GrowCutOnROI.StateCommon.Border.Rounding = 10F;
            this.button_GrowCutOnROI.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GrowCutOnROI.TabIndex = 82;
            this.button_GrowCutOnROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_GrowCutOnROI.Values.Text = "GrowCut pe ROI";
            this.button_GrowCutOnROI.Click += new System.EventHandler(this.Button_GrowCutOnROI_Click);
            this.button_GrowCutOnROI.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_GrowCutOnROI.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_GrowCutOnROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_RemoveROI
            // 
            this.button_RemoveROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoveROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RemoveROI.Location = new System.Drawing.Point(227, 3);
            this.button_RemoveROI.Name = "button_RemoveROI";
            this.button_RemoveROI.Size = new System.Drawing.Size(218, 43);
            this.button_RemoveROI.StateCommon.Border.Rounding = 10F;
            this.button_RemoveROI.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_RemoveROI.TabIndex = 81;
            this.button_RemoveROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_RemoveROI.Values.Text = "Remove ROI";
            this.button_RemoveROI.Click += new System.EventHandler(this.Button_RemoveROI_Click);
            this.button_RemoveROI.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_RemoveROI.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_RemoveROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // tabControl
            // 
            this.tabControl.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl.Location = new System.Drawing.Point(9, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(458, 480);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 89;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.AutoScrollMinSize = new System.Drawing.Size(400, 100);
            this.tabPage1.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.kryptonTableLayoutPanel4);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(450, 442);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Incarcare";
            // 
            // kryptonTableLayoutPanel4
            // 
            this.kryptonTableLayoutPanel4.ColumnCount = 2;
            this.kryptonTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel4.Controls.Add(this.button_autoProcessing, 1, 1);
            this.kryptonTableLayoutPanel4.Controls.Add(this.button_select, 0, 0);
            this.kryptonTableLayoutPanel4.Controls.Add(this.button_relode, 1, 0);
            this.kryptonTableLayoutPanel4.Controls.Add(this.button_save, 0, 1);
            this.kryptonTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel4.MinimumSize = new System.Drawing.Size(400, 100);
            this.kryptonTableLayoutPanel4.Name = "kryptonTableLayoutPanel4";
            this.kryptonTableLayoutPanel4.RowCount = 2;
            this.kryptonTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel4.Size = new System.Drawing.Size(448, 100);
            this.kryptonTableLayoutPanel4.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel4.TabIndex = 74;
            // 
            // button_autoProcessing
            // 
            this.button_autoProcessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_autoProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_autoProcessing.Location = new System.Drawing.Point(227, 53);
            this.button_autoProcessing.Name = "button_autoProcessing";
            this.button_autoProcessing.Size = new System.Drawing.Size(218, 44);
            this.button_autoProcessing.StateCommon.Border.Rounding = 10F;
            this.button_autoProcessing.StateCommon.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_autoProcessing.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_autoProcessing.StateNormal.Content.LongText.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_autoProcessing.TabIndex = 74;
            this.button_autoProcessing.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_autoProcessing.Values.Text = "Auto Processing";
            this.button_autoProcessing.Click += new System.EventHandler(this.Button_autoProcessing_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.AutoScrollMinSize = new System.Drawing.Size(400, 0);
            this.tabPage2.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.kryptonTableLayoutPanel7);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(450, 442);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesare";
            // 
            // kryptonTableLayoutPanel7
            // 
            this.kryptonTableLayoutPanel7.ColumnCount = 2;
            this.kryptonTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel7.Controls.Add(this.label_Tissue, 0, 2);
            this.kryptonTableLayoutPanel7.Controls.Add(this.Tissue_Info, 0, 3);
            this.kryptonTableLayoutPanel7.Controls.Add(this.kryptonTableLayoutPanel5, 1, 3);
            this.kryptonTableLayoutPanel7.Controls.Add(this.kryptonTableLayoutPanel6, 1, 2);
            this.kryptonTableLayoutPanel7.Controls.Add(this.button_Preprocessing, 0, 0);
            this.kryptonTableLayoutPanel7.Controls.Add(this.button_CLHE, 1, 0);
            this.kryptonTableLayoutPanel7.Controls.Add(this.button_typeTissue, 0, 1);
            this.kryptonTableLayoutPanel7.Controls.Add(this.button_CLAHE, 1, 1);
            this.kryptonTableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel7.MinimumSize = new System.Drawing.Size(400, 200);
            this.kryptonTableLayoutPanel7.Name = "kryptonTableLayoutPanel7";
            this.kryptonTableLayoutPanel7.RowCount = 4;
            this.kryptonTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.kryptonTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.kryptonTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.kryptonTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.kryptonTableLayoutPanel7.Size = new System.Drawing.Size(448, 211);
            this.kryptonTableLayoutPanel7.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel7.TabIndex = 87;
            // 
            // label_Tissue
            // 
            this.label_Tissue.AutoSize = true;
            this.label_Tissue.BackColor = System.Drawing.Color.Transparent;
            this.label_Tissue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tissue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tissue.Location = new System.Drawing.Point(3, 103);
            this.label_Tissue.Margin = new System.Windows.Forms.Padding(3);
            this.label_Tissue.Name = "label_Tissue";
            this.label_Tissue.Size = new System.Drawing.Size(218, 30);
            this.label_Tissue.TabIndex = 89;
            this.label_Tissue.Text = "Dense-Glandular";
            this.label_Tissue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tissue_Info
            // 
            this.Tissue_Info.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tissue_Info.Location = new System.Drawing.Point(3, 139);
            this.Tissue_Info.Name = "Tissue_Info";
            this.Tissue_Info.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tissue_Info.Size = new System.Drawing.Size(198, 69);
            this.Tissue_Info.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tissue_Info.StateCommon.Border.Rounding = 5F;
            this.Tissue_Info.StateCommon.Border.Width = 1;
            this.Tissue_Info.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Tissue_Info.TabIndex = 88;
            this.Tissue_Info.Text = "Fatty: 99.9%\nFatty-Glandular: 99.9%\nDense-Glandular: 99.9%";
            // 
            // kryptonTableLayoutPanel5
            // 
            this.kryptonTableLayoutPanel5.ColumnCount = 2;
            this.kryptonTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.kryptonTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel5.Controls.Add(this.windowSize, 1, 0);
            this.kryptonTableLayoutPanel5.Controls.Add(this.label_WindowSize, 0, 0);
            this.kryptonTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel5.Location = new System.Drawing.Point(227, 139);
            this.kryptonTableLayoutPanel5.MinimumSize = new System.Drawing.Size(0, 30);
            this.kryptonTableLayoutPanel5.Name = "kryptonTableLayoutPanel5";
            this.kryptonTableLayoutPanel5.RowCount = 1;
            this.kryptonTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel5.Size = new System.Drawing.Size(218, 30);
            this.kryptonTableLayoutPanel5.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel5.TabIndex = 94;
            // 
            // windowSize
            // 
            this.windowSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.windowSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.windowSize.Location = new System.Drawing.Point(128, 0);
            this.windowSize.Margin = new System.Windows.Forms.Padding(0);
            this.windowSize.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.windowSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.windowSize.Name = "windowSize";
            this.windowSize.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.windowSize.Size = new System.Drawing.Size(75, 29);
            this.windowSize.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.windowSize.StateCommon.Border.Rounding = 5F;
            this.windowSize.StateCommon.Border.Width = 1;
            this.windowSize.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.windowSize.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.windowSize.TabIndex = 91;
            this.windowSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // kryptonTableLayoutPanel6
            // 
            this.kryptonTableLayoutPanel6.ColumnCount = 2;
            this.kryptonTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.kryptonTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel6.Controls.Add(this.contrastLimit, 1, 0);
            this.kryptonTableLayoutPanel6.Controls.Add(this.label_ContrastLimit, 0, 0);
            this.kryptonTableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel6.Location = new System.Drawing.Point(227, 103);
            this.kryptonTableLayoutPanel6.Name = "kryptonTableLayoutPanel6";
            this.kryptonTableLayoutPanel6.RowCount = 1;
            this.kryptonTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel6.Size = new System.Drawing.Size(218, 30);
            this.kryptonTableLayoutPanel6.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel6.TabIndex = 92;
            // 
            // contrastLimit
            // 
            this.contrastLimit.AllowDecimals = true;
            this.contrastLimit.DecimalPlaces = 2;
            this.contrastLimit.Dock = System.Windows.Forms.DockStyle.Left;
            this.contrastLimit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contrastLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.contrastLimit.Location = new System.Drawing.Point(128, 0);
            this.contrastLimit.Margin = new System.Windows.Forms.Padding(0);
            this.contrastLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.contrastLimit.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.contrastLimit.Name = "contrastLimit";
            this.contrastLimit.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.contrastLimit.Size = new System.Drawing.Size(75, 29);
            this.contrastLimit.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contrastLimit.StateCommon.Border.Rounding = 5F;
            this.contrastLimit.StateCommon.Border.Width = 1;
            this.contrastLimit.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastLimit.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.contrastLimit.TabIndex = 90;
            this.contrastLimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.AutoScrollMinSize = new System.Drawing.Size(400, 0);
            this.tabPage3.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.kryptonTableLayoutPanel3);
            this.tabPage3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(450, 442);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Segmentare";
            // 
            // kryptonTableLayoutPanel3
            // 
            this.kryptonTableLayoutPanel3.ColumnCount = 2;
            this.kryptonTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel3.Controls.Add(this.kryptonTableLayoutPanel9, 0, 2);
            this.kryptonTableLayoutPanel3.Controls.Add(this.button_GrowCut, 0, 0);
            this.kryptonTableLayoutPanel3.Controls.Add(this.button_RemoveROI, 1, 0);
            this.kryptonTableLayoutPanel3.Controls.Add(this.button_GrowCutOnROI, 0, 1);
            this.kryptonTableLayoutPanel3.Controls.Add(this.button_selectROI, 1, 1);
            this.kryptonTableLayoutPanel3.Controls.Add(this.kryptonTableLayoutPanel2, 1, 2);
            this.kryptonTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel3.MinimumSize = new System.Drawing.Size(400, 150);
            this.kryptonTableLayoutPanel3.Name = "kryptonTableLayoutPanel3";
            this.kryptonTableLayoutPanel3.RowCount = 3;
            this.kryptonTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel3.Size = new System.Drawing.Size(448, 150);
            this.kryptonTableLayoutPanel3.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel3.TabIndex = 84;
            // 
            // kryptonTableLayoutPanel9
            // 
            this.kryptonTableLayoutPanel9.ColumnCount = 2;
            this.kryptonTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.kryptonTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel9.Controls.Add(this.thresHold, 1, 0);
            this.kryptonTableLayoutPanel9.Controls.Add(this.label_Threshold, 0, 0);
            this.kryptonTableLayoutPanel9.Location = new System.Drawing.Point(3, 101);
            this.kryptonTableLayoutPanel9.Name = "kryptonTableLayoutPanel9";
            this.kryptonTableLayoutPanel9.RowCount = 1;
            this.kryptonTableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel9.Size = new System.Drawing.Size(218, 30);
            this.kryptonTableLayoutPanel9.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel9.TabIndex = 96;
            // 
            // thresHold
            // 
            this.thresHold.AllowDecimals = true;
            this.thresHold.DecimalPlaces = 2;
            this.thresHold.Dock = System.Windows.Forms.DockStyle.Left;
            this.thresHold.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.thresHold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thresHold.Location = new System.Drawing.Point(90, 0);
            this.thresHold.Margin = new System.Windows.Forms.Padding(0);
            this.thresHold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thresHold.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.thresHold.Name = "thresHold";
            this.thresHold.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.thresHold.Size = new System.Drawing.Size(66, 29);
            this.thresHold.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.thresHold.StateCommon.Border.Rounding = 5F;
            this.thresHold.StateCommon.Border.Width = 1;
            this.thresHold.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thresHold.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.thresHold.TabIndex = 85;
            this.thresHold.Value = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            // 
            // label_Threshold
            // 
            this.label_Threshold.AutoSize = true;
            this.label_Threshold.BackColor = System.Drawing.Color.Transparent;
            this.label_Threshold.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Threshold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Threshold.Location = new System.Drawing.Point(2, 0);
            this.label_Threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Threshold.Name = "label_Threshold";
            this.label_Threshold.Size = new System.Drawing.Size(81, 30);
            this.label_Threshold.TabIndex = 77;
            this.label_Threshold.Text = "Threshold:";
            this.label_Threshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.ColumnCount = 3;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Controls.Add(this.endPoint, 2, 1);
            this.kryptonTableLayoutPanel2.Controls.Add(this.label_y, 1, 1);
            this.kryptonTableLayoutPanel2.Controls.Add(this.startPoint, 2, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.label_x, 1, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.label_H, 0, 1);
            this.kryptonTableLayoutPanel2.Controls.Add(this.label_W, 0, 0);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(224, 98);
            this.kryptonTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 2;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(224, 52);
            this.kryptonTableLayoutPanel2.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel2.TabIndex = 86;
            // 
            // label_H
            // 
            this.label_H.AutoSize = true;
            this.label_H.BackColor = System.Drawing.Color.Transparent;
            this.label_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_H.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_H.Location = new System.Drawing.Point(3, 26);
            this.label_H.Name = "label_H";
            this.label_H.Size = new System.Drawing.Size(39, 26);
            this.label_H.TabIndex = 64;
            this.label_H.Text = "H =";
            this.label_H.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.BackColor = System.Drawing.Color.Transparent;
            this.label_W.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_W.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_W.Location = new System.Drawing.Point(3, 0);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(39, 26);
            this.label_W.TabIndex = 66;
            this.label_W.Text = "W =";
            this.label_W.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.AutoScrollMinSize = new System.Drawing.Size(430, 390);
            this.tabPage4.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.kryptonTableLayoutPanel8);
            this.tabPage4.Controls.Add(this.KryptonTableLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(450, 442);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Vizualizare";
            // 
            // kryptonTableLayoutPanel8
            // 
            this.kryptonTableLayoutPanel8.ColumnCount = 1;
            this.kryptonTableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel8.Controls.Add(this.chart_Histogram, 0, 0);
            this.kryptonTableLayoutPanel8.Controls.Add(this.chart_CumulativeHistogram, 0, 1);
            this.kryptonTableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel8.Location = new System.Drawing.Point(0, 50);
            this.kryptonTableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonTableLayoutPanel8.MinimumSize = new System.Drawing.Size(430, 340);
            this.kryptonTableLayoutPanel8.Name = "kryptonTableLayoutPanel8";
            this.kryptonTableLayoutPanel8.RowCount = 2;
            this.kryptonTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel8.Size = new System.Drawing.Size(448, 390);
            this.kryptonTableLayoutPanel8.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel8.TabIndex = 82;
            // 
            // chart_Histogram
            // 
            this.chart_Histogram.BackColor = System.Drawing.Color.DarkCyan;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.LabelStyle.Format = "0.#e+0";
            chartArea1.AxisY.MaximumAutoSize = 0F;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 80F;
            chartArea1.InnerPlotPosition.Width = 85F;
            chartArea1.InnerPlotPosition.X = 10F;
            chartArea1.Name = "ChartArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 90F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 10F;
            this.chart_Histogram.ChartAreas.Add(chartArea1);
            this.chart_Histogram.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chart_Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_Histogram.Location = new System.Drawing.Point(3, 3);
            this.chart_Histogram.MinimumSize = new System.Drawing.Size(400, 170);
            this.chart_Histogram.Name = "chart_Histogram";
            this.chart_Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Pixel";
            dataPoint1.Color = System.Drawing.Color.Black;
            series1.Points.Add(dataPoint1);
            series1.YValuesPerPoint = 2;
            this.chart_Histogram.Series.Add(series1);
            this.chart_Histogram.Size = new System.Drawing.Size(442, 189);
            this.chart_Histogram.TabIndex = 39;
            title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Position.Auto = false;
            title1.Position.Height = 8.378904F;
            title1.Position.Width = 94F;
            title1.Position.X = 3F;
            title1.Position.Y = 1F;
            title1.Text = "Histograma";
            this.chart_Histogram.Titles.Add(title1);
            // 
            // chart_CumulativeHistogram
            // 
            this.chart_CumulativeHistogram.BackColor = System.Drawing.Color.DarkCyan;
            chartArea2.AxisX.Maximum = 255D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisY.LabelStyle.Format = "0.#e+0";
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 80F;
            chartArea2.InnerPlotPosition.Width = 85F;
            chartArea2.InnerPlotPosition.X = 10F;
            chartArea2.Name = "CumulativeHistogram";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 90F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 10F;
            this.chart_CumulativeHistogram.ChartAreas.Add(chartArea2);
            this.chart_CumulativeHistogram.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart_CumulativeHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_CumulativeHistogram.Location = new System.Drawing.Point(3, 198);
            this.chart_CumulativeHistogram.MinimumSize = new System.Drawing.Size(400, 170);
            this.chart_CumulativeHistogram.Name = "chart_CumulativeHistogram";
            this.chart_CumulativeHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "CumulativeHistogram";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Pixel";
            series2.Points.Add(dataPoint2);
            this.chart_CumulativeHistogram.Series.Add(series2);
            this.chart_CumulativeHistogram.Size = new System.Drawing.Size(442, 189);
            this.chart_CumulativeHistogram.TabIndex = 41;
            title2.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            title2.DockingOffset = -10;
            title2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Position.Auto = false;
            title2.Position.Height = 8.378904F;
            title2.Position.Width = 94F;
            title2.Position.X = 3F;
            title2.Position.Y = 1F;
            title2.Text = "Histograma Cumulativa";
            this.chart_CumulativeHistogram.Titles.Add(title2);
            // 
            // KryptonTableLayoutPanel1
            // 
            this.KryptonTableLayoutPanel1.ColumnCount = 4;
            this.KryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.KryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.KryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.KryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.KryptonTableLayoutPanel1.Controls.Add(this.button_show_image, 1, 0);
            this.KryptonTableLayoutPanel1.Controls.Add(this.button_show_mask, 2, 0);
            this.KryptonTableLayoutPanel1.Controls.Add(this.button_Charts, 3, 0);
            this.KryptonTableLayoutPanel1.Controls.Add(this.button_show, 0, 0);
            this.KryptonTableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.KryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.KryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.KryptonTableLayoutPanel1.MinimumSize = new System.Drawing.Size(430, 50);
            this.KryptonTableLayoutPanel1.Name = "KryptonTableLayoutPanel1";
            this.KryptonTableLayoutPanel1.RowCount = 1;
            this.KryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KryptonTableLayoutPanel1.Size = new System.Drawing.Size(448, 50);
            this.KryptonTableLayoutPanel1.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.KryptonTableLayoutPanel1.TabIndex = 76;
            // 
            // button_show_image
            // 
            this.button_show_image.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_show_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_image.Location = new System.Drawing.Point(115, 3);
            this.button_show_image.Name = "button_show_image";
            this.button_show_image.Size = new System.Drawing.Size(106, 43);
            this.button_show_image.StateCommon.Border.Rounding = 10F;
            this.button_show_image.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_show_image.TabIndex = 45;
            this.button_show_image.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_image.Values.Text = "Show Image";
            this.button_show_image.Click += new System.EventHandler(this.Button_show_image_Click);
            this.button_show_image.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_show_image.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_show_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_show_mask
            // 
            this.button_show_mask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_show_mask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_mask.Location = new System.Drawing.Point(227, 3);
            this.button_show_mask.Name = "button_show_mask";
            this.button_show_mask.Size = new System.Drawing.Size(106, 43);
            this.button_show_mask.StateCommon.Border.Rounding = 10F;
            this.button_show_mask.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_show_mask.TabIndex = 46;
            this.button_show_mask.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_mask.Values.Text = "Show Mask";
            this.button_show_mask.Click += new System.EventHandler(this.Button_show_mask_Click);
            this.button_show_mask.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_show_mask.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_show_mask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_Charts
            // 
            this.button_Charts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Charts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Charts.Location = new System.Drawing.Point(339, 3);
            this.button_Charts.Name = "button_Charts";
            this.button_Charts.Size = new System.Drawing.Size(106, 43);
            this.button_Charts.StateCommon.Border.Rounding = 10F;
            this.button_Charts.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Charts.TabIndex = 40;
            this.button_Charts.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Charts.Values.Text = "Update Charts";
            this.button_Charts.Click += new System.EventHandler(this.Button_Charts_Click);
            this.button_Charts.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_Charts.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_Charts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // button_show
            // 
            this.button_show.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show.Location = new System.Drawing.Point(3, 3);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(106, 43);
            this.button_show.StateCommon.Border.Rounding = 10F;
            this.button_show.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_show.TabIndex = 47;
            this.button_show.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show.Values.Text = "Image + Mask";
            this.button_show.Click += new System.EventHandler(this.Button_show_Click);
            this.button_show.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.button_show.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.button_show.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_MouseMove);
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.AutoScrollMinSize = new System.Drawing.Size(400, 100);
            this.tabPage5.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage5.Controls.Add(this.kryptonTableLayoutPanel10);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(450, 442);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Date Tumora";
            // 
            // kryptonTableLayoutPanel10
            // 
            this.kryptonTableLayoutPanel10.ColumnCount = 1;
            this.kryptonTableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel10.Controls.Add(this.button_Tumod_Info, 0, 0);
            this.kryptonTableLayoutPanel10.Controls.Add(this.TextBoxTumors, 0, 1);
            this.kryptonTableLayoutPanel10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.kryptonTableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel10.Name = "kryptonTableLayoutPanel10";
            this.kryptonTableLayoutPanel10.RowCount = 2;
            this.kryptonTableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.kryptonTableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel10.Size = new System.Drawing.Size(450, 442);
            this.kryptonTableLayoutPanel10.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel10.TabIndex = 77;
            // 
            // button_Tumod_Info
            // 
            this.button_Tumod_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Tumod_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Tumod_Info.Location = new System.Drawing.Point(3, 3);
            this.button_Tumod_Info.Name = "button_Tumod_Info";
            this.button_Tumod_Info.Size = new System.Drawing.Size(218, 44);
            this.button_Tumod_Info.StateCommon.Border.Rounding = 10F;
            this.button_Tumod_Info.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Tumod_Info.TabIndex = 76;
            this.button_Tumod_Info.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Tumod_Info.Values.Text = "Tumors Info";
            this.button_Tumod_Info.Click += new System.EventHandler(this.button_Tumod_Info_Click);
            // 
            // TextBoxTumors
            // 
            this.TextBoxTumors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxTumors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxTumors.Location = new System.Drawing.Point(3, 53);
            this.TextBoxTumors.Name = "TextBoxTumors";
            this.TextBoxTumors.ReadOnly = true;
            this.TextBoxTumors.Size = new System.Drawing.Size(444, 386);
            this.TextBoxTumors.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TextBoxTumors.StateActive.Border.Color1 = System.Drawing.Color.DarkCyan;
            this.TextBoxTumors.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTumors.StateCommon.Back.Color1 = System.Drawing.Color.DarkCyan;
            this.TextBoxTumors.StateCommon.Border.Color1 = System.Drawing.Color.DarkCyan;
            this.TextBoxTumors.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.TextBoxTumors.TabIndex = 77;
            this.TextBoxTumors.Text = resources.GetString("TextBoxTumors.Text");
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage6.Controls.Add(this.kryptonTableLayoutPanel11);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(450, 442);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Filtre Fourier";
            // 
            // kryptonTableLayoutPanel11
            // 
            this.kryptonTableLayoutPanel11.ColumnCount = 2;
            this.kryptonTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel11.Controls.Add(this.button_Fourier, 0, 0);
            this.kryptonTableLayoutPanel11.Controls.Add(this.kryptonButton2, 0, 1);
            this.kryptonTableLayoutPanel11.Controls.Add(this.kryptonTableLayoutPanel12, 1, 0);
            this.kryptonTableLayoutPanel11.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonTableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.kryptonTableLayoutPanel11.Name = "kryptonTableLayoutPanel11";
            this.kryptonTableLayoutPanel11.RowCount = 2;
            this.kryptonTableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.kryptonTableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel11.Size = new System.Drawing.Size(444, 436);
            this.kryptonTableLayoutPanel11.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel11.TabIndex = 12;
            // 
            // button_Fourier
            // 
            this.button_Fourier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Fourier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Fourier.Location = new System.Drawing.Point(3, 3);
            this.button_Fourier.Name = "button_Fourier";
            this.button_Fourier.Size = new System.Drawing.Size(216, 44);
            this.button_Fourier.StateCommon.Border.Rounding = 10F;
            this.button_Fourier.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Fourier.TabIndex = 91;
            this.button_Fourier.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Fourier.Values.Text = "Fourier Filter";
            this.button_Fourier.Click += new System.EventHandler(this.button_Fourier_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(3, 53);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(180, 25);
            this.kryptonButton2.StateCommon.Border.Rounding = 5F;
            this.kryptonButton2.TabIndex = 8;
            this.kryptonButton2.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton2.Values.Text = "spatii suspicioase";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click_1);
            // 
            // kryptonTableLayoutPanel12
            // 
            this.kryptonTableLayoutPanel12.ColumnCount = 2;
            this.kryptonTableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.kryptonTableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel12.Controls.Add(this.filter_number_a, 0, 0);
            this.kryptonTableLayoutPanel12.Controls.Add(this.filter_number_b, 1, 0);
            this.kryptonTableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel12.Location = new System.Drawing.Point(225, 3);
            this.kryptonTableLayoutPanel12.Name = "kryptonTableLayoutPanel12";
            this.kryptonTableLayoutPanel12.RowCount = 1;
            this.kryptonTableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel12.Size = new System.Drawing.Size(216, 44);
            this.kryptonTableLayoutPanel12.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel12.TabIndex = 89;
            // 
            // filter_number_a
            // 
            this.filter_number_a.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.filter_number_a.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.filter_number_a.Location = new System.Drawing.Point(0, 0);
            this.filter_number_a.Margin = new System.Windows.Forms.Padding(0);
            this.filter_number_a.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.filter_number_a.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.filter_number_a.Name = "filter_number_a";
            this.filter_number_a.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.filter_number_a.Size = new System.Drawing.Size(66, 29);
            this.filter_number_a.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filter_number_a.StateCommon.Border.Rounding = 5F;
            this.filter_number_a.StateCommon.Border.Width = 1;
            this.filter_number_a.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_number_a.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.filter_number_a.TabIndex = 87;
            this.filter_number_a.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // filter_number_b
            // 
            this.filter_number_b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.filter_number_b.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.filter_number_b.Location = new System.Drawing.Point(70, 0);
            this.filter_number_b.Margin = new System.Windows.Forms.Padding(0);
            this.filter_number_b.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.filter_number_b.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.filter_number_b.Name = "filter_number_b";
            this.filter_number_b.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.filter_number_b.Size = new System.Drawing.Size(66, 29);
            this.filter_number_b.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filter_number_b.StateCommon.Border.Rounding = 5F;
            this.filter_number_b.StateCommon.Border.Width = 1;
            this.filter_number_b.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_number_b.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.filter_number_b.TabIndex = 88;
            this.filter_number_b.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage7.Controls.Add(this.textBox2);
            this.tabPage7.Controls.Add(this.textBox1);
            this.tabPage7.Controls.Add(this.dataGridView);
            this.tabPage7.Controls.Add(this.kryptonTableLayoutPanel13);
            this.tabPage7.Controls.Add(this.y0_number);
            this.tabPage7.Controls.Add(this.x0_number);
            this.tabPage7.Controls.Add(this.f_function);
            this.tabPage7.Controls.Add(this.g_function);
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.label4);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(450, 442);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Simulare";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.t,
            this.f,
            this.g});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView.Location = new System.Drawing.Point(6, 164);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 20;
            this.dataGridView.Size = new System.Drawing.Size(385, 272);
            this.dataGridView.TabIndex = 110;
            // 
            // t
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.t.DefaultCellStyle = dataGridViewCellStyle3;
            this.t.HeaderText = "ΔT";
            this.t.Name = "t";
            this.t.ReadOnly = true;
            this.t.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.t.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.t.Width = 50;
            // 
            // f
            // 
            this.f.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.f.DefaultCellStyle = dataGridViewCellStyle4;
            this.f.HeaderText = "f(x,y)";
            this.f.Name = "f";
            this.f.ReadOnly = true;
            this.f.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.f.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // g
            // 
            this.g.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F);
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.g.DefaultCellStyle = dataGridViewCellStyle5;
            this.g.HeaderText = "g(x,y)";
            this.g.Name = "g";
            this.g.ReadOnly = true;
            this.g.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.g.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // kryptonTableLayoutPanel13
            // 
            this.kryptonTableLayoutPanel13.ColumnCount = 4;
            this.kryptonTableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.Controls.Add(this.ButtonA, 0, 0);
            this.kryptonTableLayoutPanel13.Controls.Add(this.ButtonB, 2, 0);
            this.kryptonTableLayoutPanel13.Controls.Add(this.ButtonC, 3, 0);
            this.kryptonTableLayoutPanel13.Controls.Add(this.Button_close, 1, 1);
            this.kryptonTableLayoutPanel13.Controls.Add(this.Button_predictie, 0, 1);
            this.kryptonTableLayoutPanel13.Controls.Add(this.ButtonD, 1, 0);
            this.kryptonTableLayoutPanel13.Controls.Add(this.kryptonTableLayoutPanel14, 2, 1);
            this.kryptonTableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
            this.kryptonTableLayoutPanel13.Name = "kryptonTableLayoutPanel13";
            this.kryptonTableLayoutPanel13.RowCount = 2;
            this.kryptonTableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kryptonTableLayoutPanel13.Size = new System.Drawing.Size(444, 94);
            this.kryptonTableLayoutPanel13.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel13.TabIndex = 109;
            // 
            // ButtonA
            // 
            this.ButtonA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonA.Location = new System.Drawing.Point(3, 3);
            this.ButtonA.Name = "ButtonA";
            this.ButtonA.Size = new System.Drawing.Size(105, 41);
            this.ButtonA.StateCommon.Border.Rounding = 10F;
            this.ButtonA.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonA.TabIndex = 97;
            this.ButtonA.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ButtonA.Values.Text = "Inexistenta";
            this.ButtonA.Click += new System.EventHandler(this.ButtonA_Click);
            // 
            // ButtonB
            // 
            this.ButtonB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonB.Location = new System.Drawing.Point(225, 3);
            this.ButtonB.Name = "ButtonB";
            this.ButtonB.Size = new System.Drawing.Size(105, 41);
            this.ButtonB.StateCommon.Border.Rounding = 10F;
            this.ButtonB.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonB.TabIndex = 98;
            this.ButtonB.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ButtonB.Values.Text = "Sanatos";
            this.ButtonB.Click += new System.EventHandler(this.ButtonB_Click);
            // 
            // ButtonC
            // 
            this.ButtonC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonC.Location = new System.Drawing.Point(336, 3);
            this.ButtonC.Name = "ButtonC";
            this.ButtonC.Size = new System.Drawing.Size(105, 41);
            this.ButtonC.StateCommon.Border.Rounding = 10F;
            this.ButtonC.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonC.TabIndex = 99;
            this.ButtonC.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ButtonC.Values.Text = "Cancer";
            this.ButtonC.Click += new System.EventHandler(this.ButtonC_Click);
            // 
            // Button_close
            // 
            this.Button_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_close.Location = new System.Drawing.Point(114, 50);
            this.Button_close.Name = "Button_close";
            this.Button_close.Size = new System.Drawing.Size(105, 41);
            this.Button_close.StateCommon.Border.Rounding = 10F;
            this.Button_close.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_close.TabIndex = 89;
            this.Button_close.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.Button_close.Values.Text = "Close";
            this.Button_close.Click += new System.EventHandler(this.Button_close_Click);
            // 
            // Button_predictie
            // 
            this.Button_predictie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_predictie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_predictie.Location = new System.Drawing.Point(3, 50);
            this.Button_predictie.Name = "Button_predictie";
            this.Button_predictie.Size = new System.Drawing.Size(105, 41);
            this.Button_predictie.StateCommon.Border.Rounding = 10F;
            this.Button_predictie.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_predictie.TabIndex = 77;
            this.Button_predictie.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.Button_predictie.Values.Text = "Solve";
            this.Button_predictie.Click += new System.EventHandler(this.Button_predictie_Click);
            // 
            // ButtonD
            // 
            this.ButtonD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonD.Location = new System.Drawing.Point(114, 3);
            this.ButtonD.Name = "ButtonD";
            this.ButtonD.Size = new System.Drawing.Size(105, 41);
            this.ButtonD.StateCommon.Border.Rounding = 10F;
            this.ButtonD.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonD.TabIndex = 100;
            this.ButtonD.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.ButtonD.Values.Text = "Coexistenta";
            this.ButtonD.Click += new System.EventHandler(this.ButtonD_Click);
            // 
            // kryptonTableLayoutPanel14
            // 
            this.kryptonTableLayoutPanel14.ColumnCount = 2;
            this.kryptonTableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.kryptonTableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel14.Controls.Add(this.T_number, 1, 0);
            this.kryptonTableLayoutPanel14.Controls.Add(this.label5, 0, 0);
            this.kryptonTableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel14.Location = new System.Drawing.Point(225, 50);
            this.kryptonTableLayoutPanel14.Name = "kryptonTableLayoutPanel14";
            this.kryptonTableLayoutPanel14.RowCount = 1;
            this.kryptonTableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel14.Size = new System.Drawing.Size(105, 41);
            this.kryptonTableLayoutPanel14.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.kryptonTableLayoutPanel14.TabIndex = 101;
            // 
            // T_number
            // 
            this.T_number.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.T_number.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.T_number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.T_number.Location = new System.Drawing.Point(25, 6);
            this.T_number.Margin = new System.Windows.Forms.Padding(0);
            this.T_number.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.T_number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.T_number.Name = "T_number";
            this.T_number.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.T_number.Size = new System.Drawing.Size(57, 29);
            this.T_number.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.T_number.StateCommon.Border.Rounding = 5F;
            this.T_number.StateCommon.Border.Width = 1;
            this.T_number.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_number.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.T_number.TabIndex = 108;
            this.T_number.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 27);
            this.label5.TabIndex = 107;
            this.label5.Text = "T";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // y0_number
            // 
            this.y0_number.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.y0_number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.y0_number.Location = new System.Drawing.Point(334, 132);
            this.y0_number.Margin = new System.Windows.Forms.Padding(0);
            this.y0_number.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.y0_number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.y0_number.Name = "y0_number";
            this.y0_number.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.y0_number.Size = new System.Drawing.Size(57, 29);
            this.y0_number.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.y0_number.StateCommon.Border.Rounding = 5F;
            this.y0_number.StateCommon.Border.Width = 1;
            this.y0_number.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y0_number.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.y0_number.TabIndex = 106;
            this.y0_number.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // x0_number
            // 
            this.x0_number.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.x0_number.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.x0_number.Location = new System.Drawing.Point(334, 100);
            this.x0_number.Margin = new System.Windows.Forms.Padding(0);
            this.x0_number.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.x0_number.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.x0_number.Name = "x0_number";
            this.x0_number.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.x0_number.Size = new System.Drawing.Size(57, 29);
            this.x0_number.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.x0_number.StateCommon.Border.Rounding = 5F;
            this.x0_number.StateCommon.Border.Width = 1;
            this.x0_number.StateCommon.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x0_number.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.x0_number.TabIndex = 105;
            this.x0_number.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // f_function
            // 
            this.f_function.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.f_function.Location = new System.Drawing.Point(62, 103);
            this.f_function.Name = "f_function";
            this.f_function.Size = new System.Drawing.Size(224, 26);
            this.f_function.TabIndex = 93;
            this.f_function.Text = "0.5*x*(1-(x+y)/100)-0.05*x";
            // 
            // g_function
            // 
            this.g_function.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.g_function.Location = new System.Drawing.Point(62, 132);
            this.g_function.Name = "g_function";
            this.g_function.Size = new System.Drawing.Size(224, 26);
            this.g_function.TabIndex = 94;
            this.g_function.Text = "0.6*y*(1-(x+y)/100)-0.18*y";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(307, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 27);
            this.label3.TabIndex = 104;
            this.label3.Text = "y0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Location = new System.Drawing.Point(307, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 27);
            this.label4.TabIndex = 103;
            this.label4.Text = "x0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DarkCyan;
            this.chart1.BorderlineColor = System.Drawing.Color.DarkCyan;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(538, 266);
            this.chart1.TabIndex = 89;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.DarkCyan;
            this.chart2.BorderlineColor = System.Drawing.Color.DarkCyan;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(3, 275);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(538, 266);
            this.chart2.TabIndex = 90;
            this.chart2.Text = "chart2";
            // 
            // ModeleChart
            // 
            this.ModeleChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ModeleChart.ColumnCount = 1;
            this.ModeleChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ModeleChart.Controls.Add(this.chart2, 0, 1);
            this.ModeleChart.Controls.Add(this.chart1, 0, 0);
            this.ModeleChart.Location = new System.Drawing.Point(473, 0);
            this.ModeleChart.Name = "ModeleChart";
            this.ModeleChart.RowCount = 2;
            this.ModeleChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ModeleChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ModeleChart.Size = new System.Drawing.Size(544, 544);
            this.ModeleChart.StateCommon.Color1 = System.Drawing.Color.DarkCyan;
            this.ModeleChart.TabIndex = 0;
            this.ModeleChart.Visible = false;
            // 
            // label_x
            // 
            this.label_x.BackColor = System.Drawing.Color.DarkCyan;
            this.label_x.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label_x.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_x.Location = new System.Drawing.Point(48, 3);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(64, 19);
            this.label_x.TabIndex = 85;
            this.label_x.Text = "x";
            // 
            // label_y
            // 
            this.label_y.BackColor = System.Drawing.Color.DarkCyan;
            this.label_y.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label_y.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_y.Location = new System.Drawing.Point(48, 29);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(64, 19);
            this.label_y.TabIndex = 86;
            this.label_y.Text = "y";
            // 
            // startPoint
            // 
            this.startPoint.BackColor = System.Drawing.Color.DarkCyan;
            this.startPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPoint.Location = new System.Drawing.Point(118, 3);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(103, 19);
            this.startPoint.TabIndex = 86;
            this.startPoint.Text = "P1(x,y)";
            // 
            // endPoint
            // 
            this.endPoint.BackColor = System.Drawing.Color.DarkCyan;
            this.endPoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.endPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endPoint.Location = new System.Drawing.Point(118, 29);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(103, 19);
            this.endPoint.TabIndex = 87;
            this.endPoint.Text = "P2(x,y)";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Location = new System.Drawing.Point(473, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(544, 544);
            this.pictureBox.TabIndex = 87;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(6, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 26);
            this.textBox1.TabIndex = 111;
            this.textBox1.Text = "f(x,y) = ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Location = new System.Drawing.Point(6, 132);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 26);
            this.textBox2.TabIndex = 112;
            this.textBox2.Text = "g(x,y) = ";
            // 
            // Image_Analysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 544);
            this.Controls.Add(this.LabelInfoButton);
            this.Controls.Add(this.ModeleChart);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button_information);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Image_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Image_Analysis_FormClosed);
            this.Resize += new System.EventHandler(this.Image_Analysis_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.kryptonTableLayoutPanel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.kryptonTableLayoutPanel7.ResumeLayout(false);
            this.kryptonTableLayoutPanel7.PerformLayout();
            this.kryptonTableLayoutPanel5.ResumeLayout(false);
            this.kryptonTableLayoutPanel5.PerformLayout();
            this.kryptonTableLayoutPanel6.ResumeLayout(false);
            this.kryptonTableLayoutPanel6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.kryptonTableLayoutPanel3.ResumeLayout(false);
            this.kryptonTableLayoutPanel9.ResumeLayout(false);
            this.kryptonTableLayoutPanel9.PerformLayout();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.kryptonTableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).EndInit();
            this.KryptonTableLayoutPanel1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.kryptonTableLayoutPanel10.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.kryptonTableLayoutPanel11.ResumeLayout(false);
            this.kryptonTableLayoutPanel12.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.kryptonTableLayoutPanel13.ResumeLayout(false);
            this.kryptonTableLayoutPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ModeleChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.Timer timer_hover;
        private KryptonRichTextBox LabelInfoButton;
        private KryptonButton button_select;
        private KryptonButton button_Preprocessing;
        private KryptonButton button_information;
        private KryptonButton button_selectROI;
        private KryptonButton button_typeTissue;
        private KryptonButton button_CLHE;
        private KryptonButton button_CLAHE;
        private KryptonButton button_save;
        private System.Windows.Forms.Label label_ContrastLimit;
        private System.Windows.Forms.Label label_WindowSize;
        private KryptonButton button_GrowCut;
        private KryptonButton button_relode;
        private KryptonButton button_GrowCutOnROI;
        private KryptonButton button_RemoveROI;
        private MyImageBox pictureBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Histogram;
        private KryptonButton button_show_image;
        private KryptonButton button_Charts;
        private KryptonButton button_show;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CumulativeHistogram;
        private KryptonButton button_show_mask;
        private KryptonTableLayoutPanel KryptonTableLayoutPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel3;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel4;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel7;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel6;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel5;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel8;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private Label label_H;
        private Label label_W;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel9;
        private Label label_Threshold;
        private KryptonNumericUpDown thresHold;
        private KryptonNumericUpDown contrastLimit;
        private KryptonNumericUpDown windowSize;
        private KryptonButton button_autoProcessing;
        private TabPage tabPage5;
        private KryptonButton button_Tumod_Info;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel10;
        private TabPage tabPage6;
        private KryptonButton kryptonButton2;
        private KryptonRichTextBox TextBoxTumors;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel11;
        private KryptonNumericUpDown filter_number_b;
        private KryptonNumericUpDown filter_number_a;
        private KryptonButton button_Fourier;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel12;
        private TabPage tabPage7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private KryptonTableLayoutPanel ModeleChart;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel13;
        private KryptonButton ButtonA;
        private KryptonButton ButtonB;
        private KryptonButton ButtonC;
        private KryptonButton Button_predictie;
        private KryptonButton Button_close;
        private KryptonButton ButtonD;
        private KryptonNumericUpDown T_number;
        private Label label5;
        private KryptonNumericUpDown y0_number;
        private KryptonNumericUpDown x0_number;
        private Label label3;
        private Label label4;
        private TextBox g_function;
        private TextBox f_function;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel14;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn t;
        private DataGridViewTextBoxColumn f;
        private DataGridViewTextBoxColumn g;
        private KryptonRichTextBox Tissue_Info;
        private Label label_Tissue;
        private TextBox label_x;
        private TextBox label_y;
        private TextBox endPoint;
        private TextBox startPoint;
        private KryptonContextMenu kryptonContextMenu1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}

