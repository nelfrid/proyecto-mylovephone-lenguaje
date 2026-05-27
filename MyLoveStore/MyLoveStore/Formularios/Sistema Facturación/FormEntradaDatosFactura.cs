using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Sistema_Facturación
{
    public partial class FormEntradaDatosFactura : Form
    {
        public FormEntradaDatosFactura()
        {
            InitializeComponent();
        }

        private void FormEntradaDatosFactura_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelDatos_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 20; // Controla qué tan redondo es el borde

            ruta.AddArc(0, 0, radio, radio, 180, 90);
            ruta.AddArc(panelDatos.Width - radio, 0, radio, radio, 270, 90);
            ruta.AddArc(panelDatos.Width - radio, panelDatos.Height - radio, radio, radio, 0, 90);
            ruta.AddArc(0, panelDatos.Height - radio, radio, radio, 90, 90);

            // Aplicar la región redondeada al panel
            panelDatos.Region = new Region(ruta);
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 20; // Nivel de redondeado
            ruta.AddArc(0, 0, radio, radio, 180, 90);
            ruta.AddArc(panelCard.Width - radio, 0, radio, radio, 270, 90);
            ruta.AddArc(panelCard.Width - radio, panelCard.Height - radio, radio, radio, 0, 90);
            ruta.AddArc(0, panelCard.Height - radio, radio, radio, 90, 90);
            panelCard.Region = new Region(ruta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa con Access.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }
    }
}
