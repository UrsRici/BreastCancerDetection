namespace BrestCancerDetection
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
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button_Start, "button_Start");
            this.button_Start.Name = "button_Start";
            this.button_Start.StateCommon.Border.Rounding = 20F;
            this.button_Start.StateCommon.Border.Width = 3;
            this.button_Start.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.button_Start.Values.Text = resources.GetString("button_Start.Values.Text");
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // StartPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartPage";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonButton button_Start;
    }
}