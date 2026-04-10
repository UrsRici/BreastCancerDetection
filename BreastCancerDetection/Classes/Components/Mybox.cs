using Microsoft.ML.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace BreastCancerDetection.Classes
{

    public class KryptonLabeledTextBox : UserControl
    {
        private KryptonLabel label;
        private KryptonTextBox textBox;

        public KryptonLabeledTextBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label = new KryptonLabel();
            textBox = new KryptonTextBox();

            // Label
            label.Location = new Point(0, 0);
            label.AutoSize = true;
            label.Text = "Labels:";
            label.BackColor = Color.Wheat;

            // TextBox
            textBox.Location = new Point(0, 0);
            textBox.Width = this.Width - label.Width;
            textBox.BackColor = Color.Black;

            // Control size
            this.Height = textBox.Height;
            this.Width = 280;

            // Add controls
            this.Controls.Add(label);
            this.Controls.Add(textBox);
        }
    }
}
