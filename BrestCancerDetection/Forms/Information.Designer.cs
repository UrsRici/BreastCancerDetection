namespace BreastCancerDetection
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.button_ok = new Krypton.Toolkit.KryptonButton();
            this.TextBox_information = new System.Windows.Forms.RichTextBox();
            this.pictureBox_i = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_i)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            resources.ApplyResources(this.button_ok, "button_ok");
            this.button_ok.Name = "button_ok";
            this.button_ok.StateCommon.Border.Rounding = 10F;
            this.button_ok.StateCommon.Border.Width = 1;
            this.button_ok.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_ok.Values.Text = resources.GetString("button_ok.Values.Text");
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // TextBox_information
            // 
            this.TextBox_information.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TextBox_information.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TextBox_information, "TextBox_information");
            this.TextBox_information.ForeColor = System.Drawing.Color.Black;
            this.TextBox_information.Name = "TextBox_information";
            this.TextBox_information.ReadOnly = true;
            // 
            // pictureBox_i
            // 
            this.pictureBox_i.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_i.Image = global::BrestCancerDetection.Properties.Resources.blue_information_button;
            resources.ApplyResources(this.pictureBox_i, "pictureBox_i");
            this.pictureBox_i.Name = "pictureBox_i";
            this.pictureBox_i.TabStop = false;
            // 
            // Information
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::BrestCancerDetection.Properties.Resources.background;
            this.Controls.Add(this.TextBox_information);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.pictureBox_i);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Name = "Information";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_i)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Krypton.Toolkit.KryptonButton button_ok;
        private System.Windows.Forms.RichTextBox TextBox_information;
        private System.Windows.Forms.PictureBox pictureBox_i;
    }
}