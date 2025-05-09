namespace BrestCancerDetection
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
            this.pictureBox_i = new System.Windows.Forms.PictureBox();
            this.button_ok = new Krypton.Toolkit.KryptonButton();
            this.TextBox_information = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_i)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_i
            // 
            this.pictureBox_i.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox_i.Image = global::BrestCancerDetection.Properties.Resources.blue_information_button;
            resources.ApplyResources(this.pictureBox_i, "pictureBox_i");
            this.pictureBox_i.Name = "pictureBox_i";
            this.pictureBox_i.TabStop = false;
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
            resources.ApplyResources(this.TextBox_information, "TextBox_information");
            this.TextBox_information.Name = "TextBox_information";
            this.TextBox_information.ReadOnly = true;
            this.TextBox_information.StateActive.Back.Color1 = System.Drawing.Color.DarkSlateGray;
            this.TextBox_information.StateActive.Border.Color1 = System.Drawing.Color.DarkSlateGray;
            this.TextBox_information.StateActive.Border.Rounding = 1F;
            this.TextBox_information.StateActive.Border.Width = 1;
            this.TextBox_information.StateActive.Content.Color1 = System.Drawing.Color.White;
            this.TextBox_information.StateActive.Content.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // Information
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.TextBox_information);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.pictureBox_i);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Information";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_i)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_i;
        private Krypton.Toolkit.KryptonButton button_ok;
        private Krypton.Toolkit.KryptonRichTextBox TextBox_information;
    }
}