using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoveStore
{
    public partial class InterfazPrincipal : Form
    {
        public InterfazPrincipal()
        {
            InitializeComponent();
        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // ActivateDarkModePage();
        }

        private void panelEntrada_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 20; // Controla qué tan redondo es el borde

            ruta.AddArc(0, 0, radio, radio, 180, 90);
            ruta.AddArc(panelEntrada.Width - radio, 0, radio, radio, 270, 90);
            ruta.AddArc(panelEntrada.Width - radio, panelEntrada.Height - radio, radio, radio, 0, 90);
            ruta.AddArc(0, panelEntrada.Height - radio, radio, radio, 90, 90);

            // Aplicar la región redondeada al panel
            panelEntrada.Region = new Region(ruta);
        }

        private void panelEntrada_Click(object sender, EventArgs e)
        {

        }

        private void panelInventario_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 20; // Controla qué tan redondo es el borde

            ruta.AddArc(0, 0, radio, radio, 180, 90);
            ruta.AddArc(panelInventario.Width - radio, 0, radio, radio, 270, 90);
            ruta.AddArc(panelInventario.Width - radio, panelInventario.Height - radio, radio, radio, 0, 90);
            ruta.AddArc(0, panelInventario.Height - radio, radio, radio, 90, 90);

            // Aplicar la región redondeada al panel
            panelInventario.Region = new Region(ruta);
        }

        private void panelInventario_Click(object sender, EventArgs e)
        {

        }
    }
}