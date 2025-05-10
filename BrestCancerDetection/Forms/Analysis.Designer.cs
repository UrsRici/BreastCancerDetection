using System.IO;
using System.Windows.Forms;
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, "0,0");
            System.Windows.Forms.DataVisualization.Charting.Title title17 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title18 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonSpecAny1 = new Krypton.Toolkit.ButtonSpecAny();
            this.timer_hover = new System.Windows.Forms.Timer(this.components);
            this.LabelInfoButton = new Krypton.Toolkit.KryptonRichTextBox();
            this.button_select = new Krypton.Toolkit.KryptonButton();
            this.button_Preprocessing = new Krypton.Toolkit.KryptonButton();
            this.button_information = new Krypton.Toolkit.KryptonButton();
            this.contrastLimit = new Krypton.Toolkit.KryptonTextBox();
            this.button_selectROI = new Krypton.Toolkit.KryptonButton();
            this.windowSize = new Krypton.Toolkit.KryptonTextBox();
            this.label_Tissue = new System.Windows.Forms.Label();
            this.button_typeTissue = new Krypton.Toolkit.KryptonButton();
            this.label_x = new System.Windows.Forms.Label();
            this.button_CLHE = new Krypton.Toolkit.KryptonButton();
            this.button_CLAHE = new Krypton.Toolkit.KryptonButton();
            this.button_save = new Krypton.Toolkit.KryptonButton();
            this.label_ContrastLimit = new System.Windows.Forms.Label();
            this.label_WindowSize = new System.Windows.Forms.Label();
            this.label_H = new System.Windows.Forms.Label();
            this.label_W = new System.Windows.Forms.Label();
            this.button_GrowCut = new Krypton.Toolkit.KryptonButton();
            this.label_y = new System.Windows.Forms.Label();
            this.button_relode = new Krypton.Toolkit.KryptonButton();
            this.button_GrowCutOnROI = new Krypton.Toolkit.KryptonButton();
            this.startPoint = new System.Windows.Forms.Label();
            this.button_RemoveROI = new Krypton.Toolkit.KryptonButton();
            this.endPoint = new System.Windows.Forms.Label();
            this.Tissue_Info = new Krypton.Toolkit.KryptonRichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chart_Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_show_image = new Krypton.Toolkit.KryptonButton();
            this.button_Charts = new Krypton.Toolkit.KryptonButton();
            this.button_show = new Krypton.Toolkit.KryptonButton();
            this.chart_CumulativeHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_show_mask = new Krypton.Toolkit.KryptonButton();
            this.pictureBox = new Licenta_Mamograf.MyImageBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).BeginInit();
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
            this.timer_hover.Tick += new System.EventHandler(this.timer_hover_Tick);
            // 
            // LabelInfoButton
            // 
            this.LabelInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelInfoButton.AutoWordSelection = true;
            this.LabelInfoButton.ButtonSpecs.Add(this.buttonSpecAny1);
            this.LabelInfoButton.Enabled = false;
            this.LabelInfoButton.Location = new System.Drawing.Point(82, 498);
            this.LabelInfoButton.Name = "LabelInfoButton";
            this.LabelInfoButton.ReadOnly = true;
            this.LabelInfoButton.Size = new System.Drawing.Size(223, 20);
            this.LabelInfoButton.StateCommon.Back.Color1 = System.Drawing.Color.LightBlue;
            this.LabelInfoButton.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LabelInfoButton.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfoButton.TabIndex = 74;
            this.LabelInfoButton.Text = "text info";
            this.LabelInfoButton.Visible = false;
            // 
            // button_select
            // 
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Location = new System.Drawing.Point(3, 3);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(147, 40);
            this.button_select.StateCommon.Border.Rounding = 10F;
            this.button_select.TabIndex = 60;
            this.button_select.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_select.Values.Text = "Select Image";
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            this.button_select.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_select.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_select.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_Preprocessing
            // 
            this.button_Preprocessing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Preprocessing.Location = new System.Drawing.Point(6, 6);
            this.button_Preprocessing.Name = "button_Preprocessing";
            this.button_Preprocessing.Size = new System.Drawing.Size(146, 40);
            this.button_Preprocessing.StateCommon.Border.Rounding = 10F;
            this.button_Preprocessing.TabIndex = 63;
            this.button_Preprocessing.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Preprocessing.Values.Text = "PreProcesare";
            this.button_Preprocessing.Click += new System.EventHandler(this.button_Preprocessing_Click);
            this.button_Preprocessing.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Preprocessing.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_Preprocessing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_information
            // 
            this.button_information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_information.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_information.Location = new System.Drawing.Point(9, 488);
            this.button_information.Margin = new System.Windows.Forms.Padding(0);
            this.button_information.Name = "button_information";
            this.button_information.Size = new System.Drawing.Size(40, 40);
            this.button_information.StateCommon.Border.Rounding = 25F;
            this.button_information.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-2, -2, 0, 0);
            this.button_information.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_information.TabIndex = 88;
            this.button_information.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_information.Values.Text = "i";
            this.button_information.Click += new System.EventHandler(this.button_information_Click);
            // 
            // contrastLimit
            // 
            this.contrastLimit.Location = new System.Drawing.Point(119, 141);
            this.contrastLimit.Margin = new System.Windows.Forms.Padding(2);
            this.contrastLimit.Name = "contrastLimit";
            this.contrastLimit.Size = new System.Drawing.Size(33, 27);
            this.contrastLimit.StateCommon.Border.Rounding = 5F;
            this.contrastLimit.StateCommon.Border.Width = 1;
            this.contrastLimit.TabIndex = 76;
            this.contrastLimit.Text = "5";
            this.contrastLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_selectROI
            // 
            this.button_selectROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_selectROI.Location = new System.Drawing.Point(158, 6);
            this.button_selectROI.Name = "button_selectROI";
            this.button_selectROI.Size = new System.Drawing.Size(146, 40);
            this.button_selectROI.StateCommon.Border.Rounding = 10F;
            this.button_selectROI.TabIndex = 70;
            this.button_selectROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_selectROI.Values.Text = "Select ROI";
            this.button_selectROI.Click += new System.EventHandler(this.button_selectROI_Click);
            this.button_selectROI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_selectROI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_selectROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // windowSize
            // 
            this.windowSize.Location = new System.Drawing.Point(119, 169);
            this.windowSize.Margin = new System.Windows.Forms.Padding(2);
            this.windowSize.Name = "windowSize";
            this.windowSize.Size = new System.Drawing.Size(33, 27);
            this.windowSize.StateCommon.Border.Rounding = 5F;
            this.windowSize.StateCommon.Border.Width = 1;
            this.windowSize.TabIndex = 79;
            this.windowSize.Text = "16";
            this.windowSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Tissue
            // 
            this.label_Tissue.AutoSize = true;
            this.label_Tissue.BackColor = System.Drawing.Color.Transparent;
            this.label_Tissue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tissue.Location = new System.Drawing.Point(177, 49);
            this.label_Tissue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Tissue.Name = "label_Tissue";
            this.label_Tissue.Size = new System.Drawing.Size(101, 20);
            this.label_Tissue.TabIndex = 85;
            this.label_Tissue.Text = "Tissue Type: ";
            // 
            // button_typeTissue
            // 
            this.button_typeTissue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_typeTissue.Location = new System.Drawing.Point(158, 6);
            this.button_typeTissue.Name = "button_typeTissue";
            this.button_typeTissue.Size = new System.Drawing.Size(130, 40);
            this.button_typeTissue.StateCommon.Border.Rounding = 10F;
            this.button_typeTissue.TabIndex = 84;
            this.button_typeTissue.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_typeTissue.Values.Text = "Tissue Type";
            this.button_typeTissue.Click += new System.EventHandler(this.button_typeTissue_Click);
            this.button_typeTissue.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_typeTissue.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_typeTissue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.BackColor = System.Drawing.Color.Transparent;
            this.label_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_x.Location = new System.Drawing.Point(178, 49);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(16, 20);
            this.label_x.TabIndex = 65;
            this.label_x.Text = "x";
            // 
            // button_CLHE
            // 
            this.button_CLHE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CLHE.Location = new System.Drawing.Point(6, 52);
            this.button_CLHE.Name = "button_CLHE";
            this.button_CLHE.Size = new System.Drawing.Size(146, 40);
            this.button_CLHE.StateCommon.Border.Rounding = 10F;
            this.button_CLHE.TabIndex = 75;
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
            this.button_CLAHE.Location = new System.Drawing.Point(6, 98);
            this.button_CLAHE.Name = "button_CLAHE";
            this.button_CLAHE.Size = new System.Drawing.Size(146, 40);
            this.button_CLAHE.StateCommon.Border.Rounding = 10F;
            this.button_CLAHE.TabIndex = 78;
            this.button_CLAHE.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_CLAHE.Values.Text = "CLAHE";
            this.button_CLAHE.Click += new System.EventHandler(this.button_CLAHE_Click);
            this.button_CLAHE.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_CLAHE.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_CLAHE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_save
            // 
            this.button_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_save.Location = new System.Drawing.Point(3, 97);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(147, 40);
            this.button_save.StateCommon.Border.Rounding = 10F;
            this.button_save.TabIndex = 73;
            this.button_save.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_save.Values.Text = "Save Image";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            this.button_save.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_save.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_save.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label_ContrastLimit
            // 
            this.label_ContrastLimit.AutoSize = true;
            this.label_ContrastLimit.BackColor = System.Drawing.Color.Transparent;
            this.label_ContrastLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ContrastLimit.Location = new System.Drawing.Point(8, 144);
            this.label_ContrastLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ContrastLimit.Name = "label_ContrastLimit";
            this.label_ContrastLimit.Size = new System.Drawing.Size(107, 20);
            this.label_ContrastLimit.TabIndex = 77;
            this.label_ContrastLimit.Text = "Contrast Limit";
            // 
            // label_WindowSize
            // 
            this.label_WindowSize.AutoSize = true;
            this.label_WindowSize.BackColor = System.Drawing.Color.Transparent;
            this.label_WindowSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WindowSize.Location = new System.Drawing.Point(8, 171);
            this.label_WindowSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_WindowSize.Name = "label_WindowSize";
            this.label_WindowSize.Size = new System.Drawing.Size(100, 20);
            this.label_WindowSize.TabIndex = 80;
            this.label_WindowSize.Text = "Window Size";
            // 
            // label_H
            // 
            this.label_H.AutoSize = true;
            this.label_H.BackColor = System.Drawing.Color.Transparent;
            this.label_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_H.Location = new System.Drawing.Point(158, 49);
            this.label_H.Name = "label_H";
            this.label_H.Size = new System.Drawing.Size(21, 20);
            this.label_H.TabIndex = 64;
            this.label_H.Text = "H";
            // 
            // label_W
            // 
            this.label_W.AutoSize = true;
            this.label_W.BackColor = System.Drawing.Color.Transparent;
            this.label_W.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_W.Location = new System.Drawing.Point(158, 75);
            this.label_W.Name = "label_W";
            this.label_W.Size = new System.Drawing.Size(24, 20);
            this.label_W.TabIndex = 66;
            this.label_W.Text = "W";
            // 
            // button_GrowCut
            // 
            this.button_GrowCut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_GrowCut.Location = new System.Drawing.Point(6, 94);
            this.button_GrowCut.Name = "button_GrowCut";
            this.button_GrowCut.Size = new System.Drawing.Size(146, 40);
            this.button_GrowCut.StateCommon.Border.Rounding = 10F;
            this.button_GrowCut.TabIndex = 83;
            this.button_GrowCut.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_GrowCut.Values.Text = "Apply GrowCut";
            this.button_GrowCut.Click += new System.EventHandler(this.button_GrowCut_Click);
            this.button_GrowCut.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_GrowCut.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_GrowCut.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.BackColor = System.Drawing.Color.Transparent;
            this.label_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y.Location = new System.Drawing.Point(178, 75);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(16, 20);
            this.label_y.TabIndex = 67;
            this.label_y.Text = "y";
            // 
            // button_relode
            // 
            this.button_relode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_relode.Location = new System.Drawing.Point(3, 49);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(147, 42);
            this.button_relode.StateCommon.Border.Rounding = 10F;
            this.button_relode.TabIndex = 71;
            this.button_relode.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_relode.Values.Text = "Relode Image";
            this.button_relode.Click += new System.EventHandler(this.button_relode_Click);
            this.button_relode.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_relode.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_relode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_GrowCutOnROI
            // 
            this.button_GrowCutOnROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_GrowCutOnROI.Location = new System.Drawing.Point(6, 50);
            this.button_GrowCutOnROI.Name = "button_GrowCutOnROI";
            this.button_GrowCutOnROI.Size = new System.Drawing.Size(146, 40);
            this.button_GrowCutOnROI.StateCommon.Border.Rounding = 10F;
            this.button_GrowCutOnROI.TabIndex = 82;
            this.button_GrowCutOnROI.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_GrowCutOnROI.Values.Text = "GrowCut pe ROI";
            this.button_GrowCutOnROI.Click += new System.EventHandler(this.button_GrowCutOnROI_Click);
            this.button_GrowCutOnROI.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_GrowCutOnROI.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_GrowCutOnROI.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // startPoint
            // 
            this.startPoint.AutoSize = true;
            this.startPoint.BackColor = System.Drawing.Color.Transparent;
            this.startPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPoint.Location = new System.Drawing.Point(213, 49);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(56, 20);
            this.startPoint.TabIndex = 68;
            this.startPoint.Text = "P1(x,y)";
            // 
            // button_RemoveROI
            // 
            this.button_RemoveROI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RemoveROI.Location = new System.Drawing.Point(6, 6);
            this.button_RemoveROI.Name = "button_RemoveROI";
            this.button_RemoveROI.Size = new System.Drawing.Size(146, 40);
            this.button_RemoveROI.StateCommon.Border.Rounding = 10F;
            this.button_RemoveROI.TabIndex = 81;
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
            this.endPoint.BackColor = System.Drawing.Color.Transparent;
            this.endPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPoint.Location = new System.Drawing.Point(213, 75);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(56, 20);
            this.endPoint.TabIndex = 69;
            this.endPoint.Text = "P2(x,y)";
            // 
            // Tissue_Info
            // 
            this.Tissue_Info.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tissue_Info.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Tissue_Info.Location = new System.Drawing.Point(158, 75);
            this.Tissue_Info.MaxLength = 2147;
            this.Tissue_Info.Name = "Tissue_Info";
            this.Tissue_Info.ReadOnly = true;
            this.Tissue_Info.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.Tissue_Info.Size = new System.Drawing.Size(236, 72);
            this.Tissue_Info.StateCommon.Back.Color1 = System.Drawing.Color.LightBlue;
            this.Tissue_Info.StateCommon.Border.Rounding = 10F;
            this.Tissue_Info.StateCommon.Border.Width = 1;
            this.Tissue_Info.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tissue_Info.TabIndex = 86;
            this.Tissue_Info.Text = "Tissue 1: 99.9%\nTissue 2: 99.9%\nTissue 3: 99.9%";
            this.Tissue_Info.UseMnemonic = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(453, 473);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 89;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.Click += new System.EventHandler(this.Image_Analysis_Resize);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.button_select);
            this.tabPage1.Controls.Add(this.button_relode);
            this.tabPage1.Controls.Add(this.button_save);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(445, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Incarcare";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.button_Preprocessing);
            this.tabPage2.Controls.Add(this.button_CLHE);
            this.tabPage2.Controls.Add(this.button_typeTissue);
            this.tabPage2.Controls.Add(this.label_Tissue);
            this.tabPage2.Controls.Add(this.Tissue_Info);
            this.tabPage2.Controls.Add(this.label_WindowSize);
            this.tabPage2.Controls.Add(this.label_ContrastLimit);
            this.tabPage2.Controls.Add(this.button_CLAHE);
            this.tabPage2.Controls.Add(this.contrastLimit);
            this.tabPage2.Controls.Add(this.windowSize);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procesare";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.button_selectROI);
            this.tabPage3.Controls.Add(this.label_y);
            this.tabPage3.Controls.Add(this.endPoint);
            this.tabPage3.Controls.Add(this.startPoint);
            this.tabPage3.Controls.Add(this.label_x);
            this.tabPage3.Controls.Add(this.label_W);
            this.tabPage3.Controls.Add(this.label_H);
            this.tabPage3.Controls.Add(this.button_RemoveROI);
            this.tabPage3.Controls.Add(this.button_GrowCut);
            this.tabPage3.Controls.Add(this.button_GrowCutOnROI);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(536, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Segmentare";
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.BackColor = System.Drawing.Color.DarkCyan;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.chart_Histogram);
            this.tabPage4.Controls.Add(this.button_show_image);
            this.tabPage4.Controls.Add(this.button_Charts);
            this.tabPage4.Controls.Add(this.button_show);
            this.tabPage4.Controls.Add(this.chart_CumulativeHistogram);
            this.tabPage4.Controls.Add(this.button_show_mask);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(458, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Vizualizare";
            // 
            // chart_Histogram
            // 
            this.chart_Histogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_Histogram.BackColor = System.Drawing.Color.DarkCyan;
            chartArea17.AxisX.Maximum = 255D;
            chartArea17.AxisX.Minimum = 0D;
            chartArea17.AxisY.LabelStyle.Format = "0.#e+0";
            chartArea17.AxisY.MaximumAutoSize = 0F;
            chartArea17.InnerPlotPosition.Auto = false;
            chartArea17.InnerPlotPosition.Height = 80F;
            chartArea17.InnerPlotPosition.Width = 85F;
            chartArea17.InnerPlotPosition.X = 10F;
            chartArea17.Name = "ChartArea";
            chartArea17.Position.Auto = false;
            chartArea17.Position.Height = 90F;
            chartArea17.Position.Width = 100F;
            chartArea17.Position.Y = 10F;
            this.chart_Histogram.ChartAreas.Add(chartArea17);
            this.chart_Histogram.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.chart_Histogram.Location = new System.Drawing.Point(0, 235);
            this.chart_Histogram.MinimumSize = new System.Drawing.Size(400, 150);
            this.chart_Histogram.Name = "chart_Histogram";
            this.chart_Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series17.ChartArea = "ChartArea";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series17.Legend = "Legend1";
            series17.Name = "Pixel";
            dataPoint17.Color = System.Drawing.Color.Black;
            series17.Points.Add(dataPoint17);
            series17.YValuesPerPoint = 2;
            this.chart_Histogram.Series.Add(series17);
            this.chart_Histogram.Size = new System.Drawing.Size(457, 186);
            this.chart_Histogram.TabIndex = 39;
            title17.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title17.Name = "Title1";
            title17.Position.Auto = false;
            title17.Position.Height = 8.378904F;
            title17.Position.Width = 94F;
            title17.Position.X = 3F;
            title17.Position.Y = 1F;
            title17.Text = "Histograma";
            this.chart_Histogram.Titles.Add(title17);
            // 
            // button_show_image
            // 
            this.button_show_image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_image.Location = new System.Drawing.Point(115, 6);
            this.button_show_image.Name = "button_show_image";
            this.button_show_image.Size = new System.Drawing.Size(102, 40);
            this.button_show_image.StateCommon.Border.Rounding = 10F;
            this.button_show_image.TabIndex = 45;
            this.button_show_image.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_image.Values.Text = "Show Image";
            this.button_show_image.Click += new System.EventHandler(this.button_show_image_Click);
            this.button_show_image.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show_image.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_Charts
            // 
            this.button_Charts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Charts.Location = new System.Drawing.Point(331, 6);
            this.button_Charts.Name = "button_Charts";
            this.button_Charts.Size = new System.Drawing.Size(102, 40);
            this.button_Charts.StateCommon.Border.Rounding = 10F;
            this.button_Charts.TabIndex = 40;
            this.button_Charts.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Charts.Values.Text = "Update Charts";
            this.button_Charts.Click += new System.EventHandler(this.button_Charts_Click);
            this.button_Charts.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_Charts.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_Charts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // button_show
            // 
            this.button_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show.Location = new System.Drawing.Point(7, 6);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(102, 40);
            this.button_show.StateCommon.Border.Rounding = 10F;
            this.button_show.TabIndex = 47;
            this.button_show.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show.Values.Text = "Image + Mask";
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            this.button_show.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // chart_CumulativeHistogram
            // 
            this.chart_CumulativeHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_CumulativeHistogram.BackColor = System.Drawing.Color.DarkCyan;
            chartArea18.AxisX.Maximum = 255D;
            chartArea18.AxisX.Minimum = 0D;
            chartArea18.AxisY.LabelStyle.Format = "0.#e+0";
            chartArea18.InnerPlotPosition.Auto = false;
            chartArea18.InnerPlotPosition.Height = 80F;
            chartArea18.InnerPlotPosition.Width = 85F;
            chartArea18.InnerPlotPosition.X = 10F;
            chartArea18.Name = "CumulativeHistogram";
            chartArea18.Position.Auto = false;
            chartArea18.Position.Height = 90F;
            chartArea18.Position.Width = 100F;
            chartArea18.Position.Y = 10F;
            this.chart_CumulativeHistogram.ChartAreas.Add(chartArea18);
            this.chart_CumulativeHistogram.Location = new System.Drawing.Point(0, 49);
            this.chart_CumulativeHistogram.MinimumSize = new System.Drawing.Size(400, 150);
            this.chart_CumulativeHistogram.Name = "chart_CumulativeHistogram";
            this.chart_CumulativeHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series18.ChartArea = "CumulativeHistogram";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series18.Name = "Pixel";
            series18.Points.Add(dataPoint18);
            this.chart_CumulativeHistogram.Series.Add(series18);
            this.chart_CumulativeHistogram.Size = new System.Drawing.Size(457, 186);
            this.chart_CumulativeHistogram.TabIndex = 41;
            title18.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title18.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            title18.DockingOffset = -10;
            title18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title18.Name = "Title1";
            title18.Position.Auto = false;
            title18.Position.Height = 8.378904F;
            title18.Position.Width = 94F;
            title18.Position.X = 3F;
            title18.Position.Y = 1F;
            title18.Text = "Histograma Cumulativa";
            this.chart_CumulativeHistogram.Titles.Add(title18);
            // 
            // button_show_mask
            // 
            this.button_show_mask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_mask.Location = new System.Drawing.Point(223, 6);
            this.button_show_mask.Name = "button_show_mask";
            this.button_show_mask.Size = new System.Drawing.Size(102, 40);
            this.button_show_mask.StateCommon.Border.Rounding = 10F;
            this.button_show_mask.TabIndex = 46;
            this.button_show_mask.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_show_mask.Values.Text = "Show Mask";
            this.button_show_mask.Click += new System.EventHandler(this.button_show_mask_Click);
            this.button_show_mask.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.button_show_mask.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            this.button_show_mask.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button_MouseMove);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox.Location = new System.Drawing.Point(471, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(537, 537);
            this.pictureBox.TabIndex = 87;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Image_Analysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::BrestCancerDetection.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.LabelInfoButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_information);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Name = "Image_Analysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Analysis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Image_Analysis_FormClosed);
            this.Resize += new System.EventHandler(this.Image_Analysis_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_CumulativeHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private System.Windows.Forms.Timer timer_hover;
        private Krypton.Toolkit.KryptonRichTextBox LabelInfoButton;
        private Krypton.Toolkit.KryptonButton button_select;
        private Krypton.Toolkit.KryptonButton button_Preprocessing;
        private Krypton.Toolkit.KryptonButton button_information;
        private Krypton.Toolkit.KryptonTextBox contrastLimit;
        private Krypton.Toolkit.KryptonButton button_selectROI;
        private Krypton.Toolkit.KryptonTextBox windowSize;
        private System.Windows.Forms.Label label_Tissue;
        private Krypton.Toolkit.KryptonButton button_typeTissue;
        private System.Windows.Forms.Label label_x;
        private Krypton.Toolkit.KryptonButton button_CLHE;
        private Krypton.Toolkit.KryptonButton button_CLAHE;
        private Krypton.Toolkit.KryptonButton button_save;
        private System.Windows.Forms.Label label_ContrastLimit;
        private System.Windows.Forms.Label label_WindowSize;
        private System.Windows.Forms.Label label_H;
        private System.Windows.Forms.Label label_W;
        private Krypton.Toolkit.KryptonButton button_GrowCut;
        private System.Windows.Forms.Label label_y;
        private Krypton.Toolkit.KryptonButton button_relode;
        private Krypton.Toolkit.KryptonButton button_GrowCutOnROI;
        private System.Windows.Forms.Label startPoint;
        private Krypton.Toolkit.KryptonButton button_RemoveROI;
        private System.Windows.Forms.Label endPoint;
        private Krypton.Toolkit.KryptonRichTextBox Tissue_Info;
        private MyImageBox pictureBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Histogram;
        private Krypton.Toolkit.KryptonButton button_show_image;
        private Krypton.Toolkit.KryptonButton button_Charts;
        private Krypton.Toolkit.KryptonButton button_show;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CumulativeHistogram;
        private Krypton.Toolkit.KryptonButton button_show_mask;
    }
}

