using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrestCancerDetection.Classes
{
    public static class ButtonsInfo
    {
        private static readonly Dictionary<string, string> buttonsInfo = new Dictionary<string, string>
        {
            { "button_show_image", "Afișează imaginea originală pentru analiza de cancer mamar." },
            { "button_show", "Afișează imaginea împreună cu masca aplicată pentru vizualizarea detaliilor procesării." },
            { "button_Charts", "Reactualizează graficele pentru a reflecta modificările din imagine și masca." },
            { "button_show_mask", "Afișează doar masca, fără imaginea de bază, pentru a vizualiza zonele de interes." },
            { "button_selectROI", "Selectează o zonă de interes (ROI) pentru a aplica algoritmul GrowCut pe imagine." },
            { "button_GrowCut", "Aplică algoritmul AI pe întreaga imagine sau pe zonele predefinite pentru detectarea anomaliilor." },
            { "button_GrowCutOnROI", "Aplică algoritmul AI pe zona selectată (ROI). Dacă nu ai selectat o zonă, folosește mai întâi butonul \"Select ROI\" pentu selectarea unei zone." },
            { "button_RemoveROI", "Elimină complet zona selectată din imagine. Pentru a selecta o regiune, folosește \"Select ROI\" mai întâi." },
            { "button_Preprocessing", "Preprocesarea imaginii elimină artefactele și zgomotul de fundal folosind algoritmi specifici pentru a îmbunătăți analiza." },
            { "button_typeTissue", "Detectează tipul de țesut din imagine (ex. țesut adipos, glandular sau dens). Folosește un model ML.NET antrenat cu aproximativ 3000 de imagini de mamografie." },
            { "button_CLHE", "Aplică Contrast Limited Histogram Equalization (CLHE) pentru îmbunătățirea contrastului imaginii." },
            { "button_CLAHE", "Aplică algoritmul CLAHE pentru îmbunătățirea contrastului imaginii în zonele de interes. Permite personalizarea prin parametrii \"Contrast Limit\" și \"Window Size\", iar aceștia vor fi setați automat dacă folosești butonul \"Tissue Type\" înainte." },
            { "button_save", "Salvează imaginea originală, masca și imaginea combinată cu masca pentru analiza ulterioară." },
            { "button_select", "Permite selectarea unei imagini PGM pentru a o încărca în aplicația de detecție a cancerului mamar." },
            { "button_relode", "Reîncarcă imaginea curentă, refăcând toate operațiile de preprocesare și mascare aplicate anterior." },
            };
        public static string GetInfo(string button)
        {
            return buttonsInfo[button];
        }
    }
    public class TableLayoutPanel : KryptonTableLayoutPanel
    {
        public int BorderRadius { get; set; } = 25;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var bounds = this.ClientRectangle;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, BorderRadius, BorderRadius, 180, 90);
                path.AddArc(bounds.Right - BorderRadius, bounds.Y, BorderRadius, BorderRadius, 270, 90);
                path.AddArc(bounds.Right - BorderRadius, bounds.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }
    }
    public class LayoutPanel : KryptonPanel
    {
        public int BorderRadius { get; set; } = 25;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var path = new GraphicsPath();
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
    }
}
