using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

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
            int radio = 20;

            ruta.AddArc(0, 0, radio, radio, 180, 90);
            ruta.AddArc(panelDatos.Width - radio, 0, radio, radio, 270, 90);
            ruta.AddArc(panelDatos.Width - radio, panelDatos.Height - radio, radio, radio, 0, 90);
            ruta.AddArc(0, panelDatos.Height - radio, radio, radio, 90, 90);

            panelDatos.Region = new Region(ruta);
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath ruta = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 20;

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

        private void GuardarCliente()
        {
            try
            {
                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = "INSERT INTO Clientes (NombreCliente, CedulaCliente, CorreoCliente) VALUES (?, ?, ?)";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("?", txtNombre.Text);
                        comando.Parameters.AddWithValue("?", txtCedula.Text);
                        comando.Parameters.AddWithValue("?", txtCorreo.Text);

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente guardado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}