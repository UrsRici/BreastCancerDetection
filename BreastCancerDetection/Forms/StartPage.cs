using System;
using System.Windows.Forms;

namespace BreastCancerDetection
{
    public partial class StartPage: Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            Image_Analysis imageAnalysis = new Image_Analysis();
            imageAnalysis.Show();
            this.Hide();
        }

        private void button_Info_Click(object sender, EventArgs e)
        {
            AppInfo appInfo = new AppInfo();
            appInfo.Show();
        }
    }
}
