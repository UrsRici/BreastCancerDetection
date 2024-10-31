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
            this.button_select = new System.Windows.Forms.Button();
            this.info_log = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_WaveletDenoising = new System.Windows.Forms.Button();
            this.button_Enhancement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bits_x_tb = new System.Windows.Forms.TextBox();
            this.bits_y_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grey_level_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.slope_tb = new System.Windows.Forms.TextBox();
            this.endPoint = new System.Windows.Forms.Label();
            this.startPoint = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_selectROI = new System.Windows.Forms.Button();
            this.button_relode = new System.Windows.Forms.Button();
            this.button_log = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_aux = new System.Windows.Forms.Label();
            this.pictureBox = new Licenta_Mamograf.MyImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select.Location = new System.Drawing.Point(584, 16);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(137, 42);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Select IMG";
            this.button_select.UseVisualStyleBackColor = false;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // info_log
            // 
            this.info_log.Location = new System.Drawing.Point(548, 113);
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
            this.button_WaveletDenoising.Location = new System.Drawing.Point(780, 16);
            this.button_WaveletDenoising.Name = "button_WaveletDenoising";
            this.button_WaveletDenoising.Size = new System.Drawing.Size(163, 47);
            this.button_WaveletDenoising.TabIndex = 4;
            this.button_WaveletDenoising.Text = "Wavelet Denoising";
            this.button_WaveletDenoising.UseVisualStyleBackColor = false;
            this.button_WaveletDenoising.Click += new System.EventHandler(this.button_WaveletDenoising_Click);
            // 
            // button_Enhancement
            // 
            this.button_Enhancement.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Enhancement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Enhancement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Enhancement.Location = new System.Drawing.Point(780, 86);
            this.button_Enhancement.Name = "button_Enhancement";
            this.button_Enhancement.Size = new System.Drawing.Size(163, 47);
            this.button_Enhancement.TabIndex = 5;
            this.button_Enhancement.Text = "Enhancement";
            this.button_Enhancement.UseVisualStyleBackColor = false;
            this.button_Enhancement.Click += new System.EventHandler(this.button_Enhancement_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(777, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // bits_x_tb
            // 
            this.bits_x_tb.Location = new System.Drawing.Point(793, 138);
            this.bits_x_tb.Margin = new System.Windows.Forms.Padding(2);
            this.bits_x_tb.Name = "bits_x_tb";
            this.bits_x_tb.Size = new System.Drawing.Size(22, 20);
            this.bits_x_tb.TabIndex = 9;
            this.bits_x_tb.Text = "8";
            this.bits_x_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bits_y_tb
            // 
            this.bits_y_tb.Location = new System.Drawing.Point(793, 162);
            this.bits_y_tb.Margin = new System.Windows.Forms.Padding(2);
            this.bits_y_tb.Name = "bits_y_tb";
            this.bits_y_tb.Size = new System.Drawing.Size(22, 20);
            this.bits_y_tb.TabIndex = 10;
            this.bits_y_tb.Text = "8";
            this.bits_y_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(833, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "grey levels";
            // 
            // grey_level_tb
            // 
            this.grey_level_tb.Location = new System.Drawing.Point(910, 138);
            this.grey_level_tb.Margin = new System.Windows.Forms.Padding(2);
            this.grey_level_tb.Name = "grey_level_tb";
            this.grey_level_tb.Size = new System.Drawing.Size(33, 20);
            this.grey_level_tb.TabIndex = 12;
            this.grey_level_tb.Text = "256";
            this.grey_level_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(865, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "slope";
            // 
            // slope_tb
            // 
            this.slope_tb.Location = new System.Drawing.Point(910, 162);
            this.slope_tb.Margin = new System.Windows.Forms.Padding(2);
            this.slope_tb.Name = "slope_tb";
            this.slope_tb.Size = new System.Drawing.Size(33, 20);
            this.slope_tb.TabIndex = 14;
            this.slope_tb.Text = "2.5";
            this.slope_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // endPoint
            // 
            this.endPoint.AutoSize = true;
            this.endPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPoint.Location = new System.Drawing.Point(850, 291);
            this.endPoint.Name = "endPoint";
            this.endPoint.Size = new System.Drawing.Size(56, 20);
            this.endPoint.TabIndex = 20;
            this.endPoint.Text = "P2(x,y)";
            // 
            // startPoint
            // 
            this.startPoint.AutoSize = true;
            this.startPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPoint.Location = new System.Drawing.Point(850, 261);
            this.startPoint.Name = "startPoint";
            this.startPoint.Size = new System.Drawing.Size(56, 20);
            this.startPoint.TabIndex = 19;
            this.startPoint.Text = "P1(x,y)";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y.Location = new System.Drawing.Point(803, 291);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(16, 20);
            this.label_y.TabIndex = 18;
            this.label_y.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(783, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Y";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_x.Location = new System.Drawing.Point(803, 261);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(16, 20);
            this.label_x.TabIndex = 16;
            this.label_x.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(783, 261);
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
            this.button_selectROI.Location = new System.Drawing.Point(780, 211);
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
            this.button_relode.Location = new System.Drawing.Point(584, 65);
            this.button_relode.Name = "button_relode";
            this.button_relode.Size = new System.Drawing.Size(137, 42);
            this.button_relode.TabIndex = 23;
            this.button_relode.Text = "Relode IMG";
            this.button_relode.UseVisualStyleBackColor = false;
            this.button_relode.Click += new System.EventHandler(this.button_relode_Click);
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(640, 276);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(81, 19);
            this.button_log.TabIndex = 24;
            this.button_log.Text = "Clean LOG";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(615, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 19);
            this.button1.TabIndex = 26;
            this.button1.Text = "Clean LOG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_aux
            // 
            this.label_aux.AutoSize = true;
            this.label_aux.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_aux.Location = new System.Drawing.Point(823, 347);
            this.label_aux.Name = "label_aux";
            this.label_aux.Size = new System.Drawing.Size(56, 20);
            this.label_aux.TabIndex = 27;
            this.label_aux.Text = "P1(x,y)";
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Image = global::Licenta_Mamograf.Properties.Resources._48Alqh;
            this.pictureBox.Location = new System.Drawing.Point(12, 65);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.ROIselect_Button_active = false;
            this.pictureBox.Size = new System.Drawing.Size(529, 529);
            this.pictureBox.TabIndex = 25;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Image_Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1262, 611);
            this.Controls.Add(this.label_aux);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.button_relode);
            this.Controls.Add(this.button_selectROI);
            this.Controls.Add(this.endPoint);
            this.Controls.Add(this.startPoint);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.slope_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grey_level_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bits_y_tb);
            this.Controls.Add(this.bits_x_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Enhancement);
            this.Controls.Add(this.button_WaveletDenoising);
            this.Controls.Add(this.info_log);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_select);
            this.Name = "Image_Analysis";
            this.Text = "Image_analysis";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.RichTextBox info_log;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_WaveletDenoising;
        private System.Windows.Forms.Button button_Enhancement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bits_x_tb;
        private System.Windows.Forms.TextBox bits_y_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox grey_level_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox slope_tb;
        private System.Windows.Forms.Label endPoint;
        private System.Windows.Forms.Label startPoint;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_selectROI;
        private System.Windows.Forms.Button button_relode;
        private System.Windows.Forms.Button button_log;
        private MyImageBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_aux;
    }
}

