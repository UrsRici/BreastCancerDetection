using Licenta_Mamograf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrestCancerDetection
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
