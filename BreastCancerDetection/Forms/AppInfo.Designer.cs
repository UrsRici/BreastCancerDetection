namespace BreastCancerDetection
{
    partial class AppInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppInfo));
            this.label_content = new System.Windows.Forms.Label();
            this.button_ok = new Krypton.Toolkit.KryptonButton();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_content
            // 
            this.label_content.BackColor = System.Drawing.Color.Transparent;
            this.label_content.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_content.ForeColor = System.Drawing.Color.Black;
            this.label_content.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_content.Location = new System.Drawing.Point(0, 0);
            this.label_content.Margin = new System.Windows.Forms.Padding(0);
            this.label_content.Name = "label_content";
            this.label_content.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_content.Size = new System.Drawing.Size(560, 322);
            this.label_content.TabIndex = 6;
            this.label_content.Text = resources.GetString("label_content.Text");
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(468, 305);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(89, 29);
            this.button_ok.StateCommon.Border.Rounding = 10F;
            this.button_ok.StateCommon.Border.Width = 1;
            this.button_ok.TabIndex = 7;
            this.button_ok.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_ok.Values.Text = "OK";
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel.Controls.Add(this.button_ok);
            this.panel.Controls.Add(this.label_content);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(560, 337);
            this.panel.TabIndex = 8;
            // 
            // AppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BreastCancerDetection.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "AppInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info";
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_content;
        private Krypton.Toolkit.KryptonButton button_ok;
        private System.Windows.Forms.Panel panel;
    }
}