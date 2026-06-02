using MyLoveStore.Clases;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyLoveStore.Formularios.Sistema_Facturación
{
    public partial class FormEntradaDatosFactura : Form
    {
        public FormEntradaDatosFactura()
        {
            InitializeComponent();

            cmbProducto.Items.Clear();


            cmbProducto.Items.Add("Samsung S24 Ultra");
            cmbProducto.Items.Add("Iphone 17 Pro Max");
            cmbProducto.Items.Add("Google Pixel 10 Pro");
            cmbProducto.Items.Add("Apple Airpods Gen 4");
            cmbProducto.Items.Add("Audífonos Inalámbricos JBL Tune 720BT");
            cmbProducto.Items.Add("Auriculares Inalámbricos JBL TUNE 130NC TWS");

            if (cmbProducto.Items.Count > 0)
            {
                cmbProducto.SelectedIndex = 0;
            }

        }

        private int GuardarCliente()
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO Clientes
                (NombreCliente, CedulaCliente, CorreoCliente)
                VALUES (?, ?, ?)";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", txtNombre.Text);
                    comando.Parameters.AddWithValue("?", txtCedula.Text);
                    comando.Parameters.AddWithValue("?", txtCorreo.Text);
                    comando.ExecuteNonQuery();
                }

                using (OleDbCommand obtenerId = new OleDbCommand("SELECT @@IDENTITY", conexion))
                {
                    return Convert.ToInt32(obtenerId.ExecuteScalar());
                }
            }
        }

        private int GuardarFactura(int idCliente)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO Facturas
                (IdCliente, NumeroFactura, FechaFacturacion, SubtotalFactura, ImpuestoFactura, TotalFactura, EstadoFactura)
                VALUES (?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", idCliente);
                    comando.Parameters.AddWithValue("?", txtNumeroFactura.Text);
                    comando.Parameters.AddWithValue("?", txtFechaProducto.Text);
                    comando.Parameters.AddWithValue("?", 0);
                    comando.Parameters.AddWithValue("?", 0);
                    comando.Parameters.AddWithValue("?", 0);
                    comando.Parameters.AddWithValue("?", "Pendiente");

                    comando.ExecuteNonQuery();
                }

                using (OleDbCommand obtenerId = new OleDbCommand("SELECT @@IDENTITY", conexion))
                {
                    return Convert.ToInt32(obtenerId.ExecuteScalar());
                }
            }
        }

        private void GuardarDetalleFactura(int idFactura)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string buscarProducto = "SELECT IdProducto, PrecioProducto FROM Productos WHERE NombreProducto = ?";

                int idProducto = 0;
                decimal precio = 0;

                using (OleDbCommand buscar = new OleDbCommand(buscarProducto, conexion))
                {
                    buscar.Parameters.AddWithValue("?", cmbProducto.Text);

                    using (OleDbDataReader lector = buscar.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            idProducto = Convert.ToInt32(lector["IdProducto"]);
                            precio = Convert.ToDecimal(lector["PrecioProducto"]);
                        }
                        else
                        {
                            MessageBox.Show("Producto no encontrado.");
                            return;
                        }
                    }
                }

                int cantidad = Convert.ToInt32(numCantidadProducto.Value);
                decimal subtotal = precio * cantidad;

                string consulta = @"INSERT INTO DetalleFactura
                (IdFactura, IdProducto, CantidadProducto, PrecioUnitario, SubtotalLinea)
                VALUES (?, ?, ?, ?, ?)";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", idFactura);
                    comando.Parameters.AddWithValue("?", idProducto);
                    comando.Parameters.AddWithValue("?", cantidad);
                    comando.Parameters.AddWithValue("?", precio);
                    comando.Parameters.AddWithValue("?", subtotal);

                    comando.ExecuteNonQuery();
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int idFacturaIngresado = Convert.ToInt32(txtNumeroFactura.Text);
            string nombreClienteIngresado = txtNombre.Text;
            string cedulaClienteIngresado = txtCedula.Text;
            string fechaFacturacionIngresado = txtFechaProducto.Text;
            string productoAdquirido = cmbProducto.Text;
            int cantidad_productosIngresado = Convert.ToInt32(numCantidadProducto);
            string correoClienteIngresado= txtCorreo.Text;


            Factura facturaFinal;

            facturaFinal = new Factura(idFacturaIngresado, nombreClienteIngresado, cedulaClienteIngresado, fechaFacturacionIngresado, productoAdquirido, cantidad_productosIngresado, correoClienteIngresado);





            try
            {
                int idCliente = GuardarCliente();
                int idFactura = GuardarFactura(idCliente);
                GuardarDetalleFactura(idFactura);

                MessageBox.Show("Factura guardada correctamente.");

                FormFacturaFinal formFacturaFinal = new FormFacturaFinal(facturaFinal);
                formFacturaFinal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
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

        private void FormEntradaDatosFactura_Load(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
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

        private void txtNumeroFactura_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFechaProducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void numCantidadProducto_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}