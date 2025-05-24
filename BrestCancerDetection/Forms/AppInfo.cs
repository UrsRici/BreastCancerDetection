using System;
using System.Windows.Forms;

namespace BreastCancerDetection
{
    public partial class AppInfo: Form
    {
        public AppInfo()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
