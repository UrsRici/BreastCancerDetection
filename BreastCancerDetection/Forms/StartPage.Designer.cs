namespace BreastCancerDetection
{
    partial class StartPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.button_Start = new Krypton.Toolkit.KryptonButton();
            this.button_Info = new Krypton.Toolkit.KryptonButton();
            this.label_title = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button_Start, "button_Start");
            this.button_Start.Name = "button_Start";
            this.button_Start.StateCommon.Border.Rounding = 20F;
            this.button_Start.StateCommon.Border.Width = 3;
            this.button_Start.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Start.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Start.Values.Text = resources.GetString("button_Start.Values.Text");
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Info
            // 
            this.button_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button_Info, "button_Info");
            this.button_Info.Name = "button_Info";
            this.button_Info.StateCommon.Border.Rounding = 20F;
            this.button_Info.StateCommon.Border.Width = 3;
            this.button_Info.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Info.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Info.Values.Text = resources.GetString("button_Info.Values.Text");
            this.button_Info.Click += new System.EventHandler(this.button_Info_Click);
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.label_title, "label_title");
            this.label_title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_title.Name = "label_title";
            // 
            // label_name
            // 
            this.label_name.BackColor = System.Drawing.Color.Transparent;
            this.label_name.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.label_name, "label_name");
            this.label_name.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_name.Name = "label_name";
            // 
            // label_content
            // 
            this.label_content.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label_content, "label_content");
            this.label_content.ForeColor = System.Drawing.Color.White;
            this.label_content.Name = "label_content";
            // 
            // StartPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::BreastCancerDetection.Properties.Resources.background;
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Info);
            this.Controls.Add(this.label_content);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonButton button_Start;
        private Krypton.Toolkit.KryptonButton button_Info;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_content;
    }
}