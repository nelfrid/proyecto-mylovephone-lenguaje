using MyLoveStore.Clases;
using MyLoveStore.Formularios.Inventario1;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Sistema_Facturación
{
    public partial class FormEntradaDatosFactura : Form
    {
        private Gerente adminIngresado;
        InterfazPrincipal formInterfazPrincipal;

        public FormEntradaDatosFactura(Gerente admin_que_viene)
        {
            InitializeComponent();
            this.adminIngresado = admin_que_viene;
            CargarProductosEnCombo();
        }

        private void CargarProductosEnCombo()
        {
            try
            {
                cmbProducto.Items.Clear();

                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = "SELECT NombreProducto FROM Productos WHERE EstadoProducto = 'Activo'";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    using (OleDbDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            cmbProducto.Items.Add(lector["NombreProducto"].ToString());
                        }
                    }
                }

                if (cmbProducto.Items.Count > 0)
                {
                    cmbProducto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
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

        private int GuardarFactura(int idCliente, decimal subtotal, decimal impuesto, decimal total)
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
                    comando.Parameters.AddWithValue("?", subtotal);
                    comando.Parameters.AddWithValue("?", impuesto);
                    comando.Parameters.AddWithValue("?", total);
                    comando.Parameters.AddWithValue("?", "Pendiente");

                    comando.ExecuteNonQuery();
                }

                using (OleDbCommand obtenerId = new OleDbCommand("SELECT @@IDENTITY", conexion))
                {
                    return Convert.ToInt32(obtenerId.ExecuteScalar());
                }
            }
        }

        private int ObtenerIdProducto(string nombreProducto)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT IdProducto FROM Productos WHERE NombreProducto = ?";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", nombreProducto);

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToInt32(resultado);
                }
            }
        }

        private decimal ObtenerPrecioProducto(string nombreProducto)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT PrecioProducto FROM Productos WHERE UCASE(TRIM(NombreProducto)) = UCASE(TRIM(?))";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", nombreProducto);

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        MessageBox.Show("El producto no tiene precio registrado.");
                        return 0;
                    }

                    return Convert.ToDecimal(resultado);
                }
            }
        }

        // NUEVO:
        // Este método consulta cuántas unidades quedan disponibles del producto.
        // Se usa antes de guardar la factura para evitar vender productos sin stock.
        private int ObtenerStockProducto(int idProducto)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT CantidadProducto FROM Productos WHERE IdProducto = ?";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", idProducto);

                    object resultado = comando.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        return 0;
                    }

                    return Convert.ToInt32(resultado);
                }
            }
        }

        private void GuardarDetalleFactura(int idFactura, int idProducto, int cantidad, decimal precioUnitario, decimal subtotal)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"INSERT INTO DetalleFactura
                (IdFactura, IdProducto, CantidadProducto, PrecioUnitario, SubtotalLinea)
                VALUES (?, ?, ?, ?, ?)";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", idFactura);
                    comando.Parameters.AddWithValue("?", idProducto);
                    comando.Parameters.AddWithValue("?", cantidad);
                    comando.Parameters.AddWithValue("?", precioUnitario);
                    comando.Parameters.AddWithValue("?", subtotal);

                    comando.ExecuteNonQuery();
                }
            }
        }

        // Este método descuenta del inventario la cantidad vendida.
        // Ejemplo: si hay 60 productos y el cliente compra 1, la base de datos queda con 59.
        private void DescontarInventario(int idProducto, int cantidadVendida)
        {
            using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = @"UPDATE Productos
                                    SET CantidadProducto = CantidadProducto - ?
                                    WHERE IdProducto = ?";

                using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", cantidadVendida);
                    comando.Parameters.AddWithValue("?", idProducto);
                    comando.ExecuteNonQuery();
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                string producto = cmbProducto.Text;

                if (string.IsNullOrWhiteSpace(producto))
                {
                    MessageBox.Show("Debe seleccionar un producto.");
                    return;
                }

                int cantidad = Convert.ToInt32(numCantidadProducto.Value);

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor que cero.");
                    return;
                }

                int idProducto = ObtenerIdProducto(producto);

                if (idProducto == 0)
                {
                    MessageBox.Show("Producto no encontrado.");
                    return;
                }

                // NUEVO:
                // Aquí se valida el stock antes de guardar cualquier dato.
                // Si el producto tiene 0 unidades, no se vende y no se genera factura.
                // Si el cliente pide más unidades de las disponibles, tampoco se genera factura.
                int stockDisponible = ObtenerStockProducto(idProducto);

                if (stockDisponible <= 0)
                {
                    MessageBox.Show("No se puede vender este producto porque no hay stock disponible.");
                    return;
                }

                if (cantidad > stockDisponible)
                {
                    MessageBox.Show("No se puede vender esa cantidad. Solo hay " + stockDisponible + " disponible(s).");
                    return;
                }

                decimal precioUnitario = ObtenerPrecioProducto(producto);
                decimal subtotal = precioUnitario * cantidad;
                decimal impuesto = subtotal * 0.07m;
                decimal total = subtotal + impuesto;

                int idCliente = GuardarCliente();
                int idFacturaBD = GuardarFactura(idCliente, subtotal, impuesto, total);

                GuardarDetalleFactura(idFacturaBD, idProducto, cantidad, precioUnitario, subtotal);

                // Aquí se actualiza el inventario después de guardar la factura.
                // Esto solo ocurre si sí había stock suficiente.
                DescontarInventario(idProducto, cantidad);

                Factura facturaFinal = new Factura(
                    Convert.ToInt32(txtNumeroFactura.Text),
                    txtNombre.Text,
                    txtCedula.Text,
                    txtFechaProducto.Text,
                    producto,
                    cantidad,
                    txtCorreo.Text,
                    precioUnitario,
                    subtotal,
                    impuesto,
                    total
                );

                MessageBox.Show("Factura guardada correctamente.");

                FormFacturaFinal formFacturaFinal = new FormFacturaFinal(facturaFinal, adminIngresado);
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

        private void cmbProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            InterfazPrincipal formInterfazPrincipal = new InterfazPrincipal(adminIngresado);
            formInterfazPrincipal.Show();
            this.Hide();
        }
    }
}