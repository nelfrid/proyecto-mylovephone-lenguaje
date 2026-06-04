using MyLoveStore.Clases;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Inventario1
{
    public partial class Inventario : Form
    {
<<<<<<< HEAD

        private Gerente adminIngresado;
        InterfazPrincipal formInterfazPrincipal;

        // Estado para flujo de agregar producto
        private int agregarStep = 0; // 0 = inactivo, 1 = pedir nombre, 2 = pedir ID, 3 = pedir cantidad
        private string nuevoNombre = string.Empty;
=======
        private int agregarStep = 0;
        private string nuevoNombre = "";
>>>>>>> 454b7b4bb225762e66cb6ccdfd69051eec75f6c1
        private int nuevoId = 0;
        private decimal nuevoPrecio = 0;
        private int nuevaCantidad = 0;

        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            PrepararTabla();
            CargarProductos();
        }

        private void PrepararTabla()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("CODIGO", "CODIGO");
            dataGridView1.Columns.Add("NOMBRE", "NOMBRE DEL PRODUCTO");
            dataGridView1.Columns.Add("PRECIO", "PRECIO");
            dataGridView1.Columns.Add("CANTIDAD", "CANTIDAD");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void CargarProductos()
        {
            try
            {
                dataGridView1.Rows.Clear();

                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"SELECT IdProducto, NombreProducto, PrecioProducto, CantidadProducto 
                                        FROM Productos";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    using (OleDbDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            dataGridView1.Rows.Add(
                                lector["IdProducto"].ToString(),
                                lector["NombreProducto"].ToString(),
                                "B/. " + (lector["PrecioProducto"] == DBNull.Value ? "0.00" : Convert.ToDecimal(lector["PrecioProducto"]).ToString("0.00")),
                                lector["CantidadProducto"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int leftX = 760;

            if (btnEliminar.Text == "ELIMINAR")
            {
                btnAgregar.Location = new Point(760, 500);
                cbTipoSeleccionEliminacion.Visible = true;
                lblIndicacion.Visible = true;
                btnVolver.Visible = true;
                textoError.Visible = false;

                cbTipoSeleccionEliminacion.Left = leftX;
                lblIndicacion.Left = leftX;
                lblIndicacion.Top = cbTipoSeleccionEliminacion.Top - lblIndicacion.Height - 6;
                lblIndicacion2.Left = leftX;
                tbSeleccion.Left = leftX;
                tbSeleccion.Width = cbTipoSeleccionEliminacion.Width;

                btnEliminar.Text = "Siguiente";
                return;
            }

            string opcion = (cbTipoSeleccionEliminacion.Text ?? "").Trim();

            if (string.IsNullOrEmpty(opcion))
            {
                textoError.Text = "Inténtelo de nuevo. Se debe elegir una opción.";
                textoError.Left = leftX;
                textoError.Top = cbTipoSeleccionEliminacion.Bottom + 6;
                textoError.Width = cbTipoSeleccionEliminacion.Width;
                textoError.ForeColor = Color.Red;
                textoError.Visible = true;
                return;
            }

            opcion = opcion.ToUpperInvariant();

            try
            {
                lblIndicacion2.Visible = true;
                tbSeleccion.Visible = true;
                textoError.Visible = false;

                cbTipoSeleccionEliminacion.Left = leftX;
                lblIndicacion2.Left = leftX;
                lblIndicacion2.Top = cbTipoSeleccionEliminacion.Bottom + 6;
                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion2.Bottom + 6;
                tbSeleccion.Width = cbTipoSeleccionEliminacion.Width;

                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta;

                    if (opcion == "ID")
                    {
                        if (!int.TryParse(tbSeleccion.Text.Trim(), out int idProducto))
                        {
                            textoError.Text = "El ID debe ser un número válido.";
                            textoError.ForeColor = Color.Red;
                            textoError.Visible = true;
                            return;
                        }

                        consulta = "DELETE FROM Productos WHERE IdProducto = ?";

                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", idProducto);
                            comando.ExecuteNonQuery();
                        }
                    }
                    else if (opcion == "NOMBRE")
                    {
                        string nombre = tbSeleccion.Text.Trim();

                        if (string.IsNullOrEmpty(nombre))
                        {
                            textoError.Text = "Ingrese el nombre del producto.";
                            textoError.ForeColor = Color.Red;
                            textoError.Visible = true;
                            return;
                        }

                        consulta = "DELETE FROM Productos WHERE NombreProducto = ?";

                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", nombre);
                            comando.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        textoError.Text = "Opción no válida.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }
                }

                textoError.Text = "Producto eliminado correctamente.";
                textoError.ForeColor = Color.Green;
                textoError.Visible = true;

                CargarProductos();

                btnEliminar.Text = "ELIMINAR";
                btnVolver.Visible = false;
                cbTipoSeleccionEliminacion.Visible = false;
                lblIndicacion.Visible = false;
                lblIndicacion2.Visible = false;
                tbSeleccion.Visible = false;
                btnAgregar.Location = new Point(760, 300);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int leftX = 760;

            if (btnAgregar.Text == "AGREGAR")
            {
                agregarStep = 1;
                textoError.Visible = false;

                lblIndicacion.Text = "Ingrese el NOMBRE del producto:";
                lblIndicacion.Left = leftX;
                lblIndicacion.Visible = true;

                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion.Bottom + 6;
                tbSeleccion.Width = 225;
                tbSeleccion.Text = "";
                tbSeleccion.Visible = true;
                tbSeleccion.Focus();

                btnAgregar.Text = "Siguiente";
                return;
            }

            if (btnAgregar.Text == "Siguiente")
            {
                if (agregarStep == 1)
                {
                    nuevoNombre = tbSeleccion.Text.Trim();

                    if (string.IsNullOrEmpty(nuevoNombre))
                    {
                        textoError.Text = "Ingrese el nombre del producto.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    agregarStep = 2;
                    lblIndicacion.Text = "Ingrese el ID del producto:";
                    tbSeleccion.Text = "";
                    tbSeleccion.Focus();
                    return;
                }

                if (agregarStep == 2)
                {
                    if (!int.TryParse(tbSeleccion.Text.Trim(), out nuevoId))
                    {
                        textoError.Text = "El ID debe ser un número válido.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    agregarStep = 3;
                    lblIndicacion.Text = "Ingrese el PRECIO del producto:";
                    tbSeleccion.Text = "";
                    tbSeleccion.Focus();
                    return;
                }

                if (agregarStep == 3)
                {
                    if (!decimal.TryParse(tbSeleccion.Text.Trim(), out nuevoPrecio))
                    {
                        textoError.Text = "El precio debe ser válido. Ejemplo: 1200";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    agregarStep = 4;
                    lblIndicacion.Text = "Ingrese la CANTIDAD del producto:";
                    tbSeleccion.Text = "";
                    tbSeleccion.Focus();
                    return;
                }

                if (agregarStep == 4)
                {
                    if (!int.TryParse(tbSeleccion.Text.Trim(), out nuevaCantidad))
                    {
                        textoError.Text = "La cantidad debe ser un número válido.";
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    try
                    {
                        using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                        {
                            conexion.Open();

                            string consulta = @"INSERT INTO Productos 
                            (IdProducto, NombreProducto, PrecioProducto, CantidadProducto, EstadoProducto)
                            VALUES (?, ?, ?, ?, ?)";

                            using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("?", nuevoId);
                                comando.Parameters.AddWithValue("?", nuevoNombre);
                                comando.Parameters.AddWithValue("?", nuevoPrecio);
                                comando.Parameters.AddWithValue("?", nuevaCantidad);
                                comando.Parameters.AddWithValue("?", "Activo");
                                comando.ExecuteNonQuery();
                            }
                        }

                        textoError.Text = "Producto agregado correctamente.";
                        textoError.ForeColor = Color.Green;
                        textoError.Visible = true;

                        agregarStep = 0;
                        btnAgregar.Text = "AGREGAR";
                        tbSeleccion.Visible = false;
                        lblIndicacion.Visible = false;

                        CargarProductos();
                    }
                    catch (Exception ex)
                    {
                        textoError.Text = "Error al agregar producto: " + ex.Message;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Después hacemos modificar cantidad.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            cbTipoSeleccionEliminacion.Visible = false;
            lblIndicacion.Visible = false;
            lblIndicacion2.Visible = false;
            tbSeleccion.Visible = false;
            textoError.Visible = false;
            btnVolver.Visible = false;

            btnAgregar.Location = new Point(760, 300);
            btnEliminar.Location = new Point(760, 200);
            btnAgregar.Text = "AGREGAR";
            btnEliminar.Text = "ELIMINAR";
            agregarStep = 0;

            InterfazPrincipal formInterfazPrincipal = new InterfazPrincipal(adminIngresado);
            formInterfazPrincipal.Show();
            this.Hide();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}