using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Inventario1
{
    public partial class Inventario : Form
    {
        // Estado para flujo de agregar producto
        private int agregarStep = 0; // 0 = inactivo, 1 = pedir nombre, 2 = pedir ID, 3 = pedir cantidad
        private string nuevoNombre = string.Empty;
        private int nuevoId = 0;
        private int nuevaCantidad = 0;

        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = @"SELECT 
                    IdProducto AS CODIGO,
                    NombreProducto AS [NOMBRE DEL PRODUCTO],
                    CantidadProducto AS CANTIDAD
                    FROM Productos";

                    OleDbDataAdapter adaptador = new OleDbDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = tabla;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Simplificado: usar X = 760 para alinear todos los controles
            int leftX = 760;

            // Estado inicial: mostrar opciones
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

            // Segundo clic: procesar selección
            string opcion = (cbTipoSeleccionEliminacion.Text ?? string.Empty).Trim();

            // Si combobox está vacío, mostrar error abajo y la indicación arriba
            if (string.IsNullOrEmpty(opcion))
            {
                textoError.Text = "Intentelo de nuevo. Se debe elegir una opcion.";
                textoError.Left = leftX;
                textoError.Top = cbTipoSeleccionEliminacion.Bottom + 6;
                textoError.Width = cbTipoSeleccionEliminacion.Width;
                textoError.ForeColor = Color.Red;
                textoError.Visible = true;

                lblIndicacion.Left = leftX;
                lblIndicacion.Top = cbTipoSeleccionEliminacion.Top - lblIndicacion.Height - 6;
                lblIndicacion.Visible = true;
                return;
            }

            // Opciones válidas: ID o NOMBRE
            opcion = opcion.ToUpperInvariant();
            if (opcion != "ID" && opcion != "NOMBRE")
            {
                textoError.Text = "Opción no válida.";
                textoError.Left = leftX;
                textoError.Top = cbTipoSeleccionEliminacion.Bottom + 6;
                textoError.Width = cbTipoSeleccionEliminacion.Width;
                textoError.ForeColor = Color.Red;
                textoError.Visible = true;
                return;
            }

            try
            {
                lblIndicacion2.Visible = true;
                tbSeleccion.Visible = true;
                textoError.Visible = false;

                // posicionar cajas en X común
                cbTipoSeleccionEliminacion.Left = leftX;
                lblIndicacion2.Left = leftX;
                lblIndicacion2.Top = cbTipoSeleccionEliminacion.Bottom + 6;
                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion2.Bottom + 6;
                tbSeleccion.Width = cbTipoSeleccionEliminacion.Width;

                if (opcion == "ID")
                {
                    if (!int.TryParse(tbSeleccion.Text?.Trim(), out int idProducto))
                    {
                        textoError.Text = "El ID debe ser un número válido.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 6;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM Productos WHERE IdProducto = ?";
                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", idProducto);
                            int rows = comando.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                textoError.Text = "No se encontró ningún producto con ese ID.";
                                textoError.Left = leftX;
                                textoError.Top = tbSeleccion.Bottom + 6;
                                textoError.Width = tbSeleccion.Width;
                                textoError.ForeColor = Color.Red;
                                textoError.Visible = true;
                                return;
                            }
                        }
                    }
                }
                else // NOMBRE
                {
                    string nombre = (tbSeleccion.Text ?? string.Empty).Trim();
                    if (string.IsNullOrEmpty(nombre))
                    {
                        textoError.Text = "Ingrese el nombre del producto a eliminar.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 6;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                    {
                        conexion.Open();
                        string consulta = "DELETE FROM Productos WHERE NombreProducto = ?";
                        using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("?", nombre);
                            int rows = comando.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                textoError.Text = "No se encontró ningún producto con ese nombre.";
                                textoError.Left = leftX;
                                textoError.Top = tbSeleccion.Bottom + 6;
                                textoError.Width = tbSeleccion.Width;
                                textoError.ForeColor = Color.Red;
                                textoError.Visible = true;
                                return;
                            }
                        }
                    }
                }

                // éxito
                textoError.Text = "Operación completada.";
                textoError.Left = leftX;
                textoError.Top = tbSeleccion.Bottom - 30; // -----------------------
                textoError.Width = tbSeleccion.Width;
                textoError.ForeColor = Color.Green;
                textoError.Visible = true;

                CargarProductos();
                btnEliminar.Text = "ELIMINAR";
                btnVolver.Visible = false;
                cbTipoSeleccionEliminacion.Visible = false;
                lblIndicacion.Visible = false;
                lblIndicacion2.Visible = false;
                tbSeleccion.Visible = false;
                btnAgregar.Location = new Point(760, 300); /////////////
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
    }

            

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int leftX = 760;

            // Iniciar flujo de agregar
            if (btnAgregar.Text == "AGREGAR")
            {
                agregarStep = 1;
                textoError.Visible = false;

                // Mostrar e indicar
                lblIndicacion.Text = "Ingrese el NOMBRE del producto:";
                lblIndicacion.Left = leftX;
                lblIndicacion.Top = cbTipoSeleccionEliminacion.Top; // usar posición conocida
                lblIndicacion.Visible = true;

                lblIndicacion2.Visible = false;
                tbSeleccion.Left = leftX;
                tbSeleccion.Top = lblIndicacion.Bottom + 6;
                tbSeleccion.Width = 225;
                tbSeleccion.Text = string.Empty;
                tbSeleccion.Visible = true;
                tbSeleccion.Focus();

                btnAgregar.Text = "Siguiente";
                return;
            }

            // Continuar flujo según paso
            if (btnAgregar.Text == "Siguiente")
            {
                // paso 1: obtener nombre
                if (agregarStep == 1)
                {
                    string nombre = (tbSeleccion.Text ?? string.Empty).Trim();
                    if (string.IsNullOrEmpty(nombre))
                    {
                        textoError.Text = "Ingrese el nombre del producto.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 30;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    nuevoNombre = nombre;
                    agregarStep = 2;
                    lblIndicacion.Text = "Ingrese el ID del producto:";
                    tbSeleccion.Text = string.Empty;
                    tbSeleccion.Focus();
                    textoError.Visible = false;
                    return;
                }

                // paso 2: obtener ID
                if (agregarStep == 2)
                {
                    if (!int.TryParse(tbSeleccion.Text?.Trim(), out int id))
                    {
                        textoError.Text = "El ID debe ser un número válido.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 30;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    nuevoId = id;
                    agregarStep = 3;
                    lblIndicacion.Text = "Ingrese la CANTIDAD del producto:";
                    tbSeleccion.Text = string.Empty;
                    tbSeleccion.Focus();
                    textoError.Visible = false;
                    return;
                }

                // paso 3: obtener cantidad e insertar
                if (agregarStep == 3)
                {
                    if (!int.TryParse(tbSeleccion.Text?.Trim(), out int cantidad))
                    {
                        textoError.Text = "La cantidad debe ser un número válido.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 30;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                        return;
                    }

                    nuevaCantidad = cantidad;

                    try
                    {
                        using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                        {
                            conexion.Open();
                            string consulta = "INSERT INTO Productos (IdProducto, NombreProducto, CantidadProducto) VALUES (?, ?, ?)";
                            using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("?", nuevoId);
                                comando.Parameters.AddWithValue("?", nuevoNombre);
                                comando.Parameters.AddWithValue("?", nuevaCantidad);
                                comando.ExecuteNonQuery();
                            }
                        }

                        textoError.Text = "Producto agregado correctamente.";
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 6;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Green;
                        textoError.Visible = true;

                        // Restaurar estado
                        agregarStep = 0;
                        btnAgregar.Text = "AGREGAR";
                        tbSeleccion.Visible = false;
                        lblIndicacion.Visible = false;
                        lblIndicacion2.Visible = false;
                        textoError.Visible = true;
                        CargarProductos();
                        btnAgregar.Location = new Point(760, 329);
                    }
                    catch (Exception ex)
                    {
                        textoError.Text = "Error al agregar producto: " + ex.Message;
                        textoError.Left = leftX;
                        textoError.Top = tbSeleccion.Bottom + 6;
                        textoError.Width = tbSeleccion.Width;
                        textoError.ForeColor = Color.Red;
                        textoError.Visible = true;
                    }

                    return;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para modificar productos falta crear campo de nueva cantidad.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Restaurar vista inicial: solo botones Eliminar y Agregar visibles
            cbTipoSeleccionEliminacion.Visible = false;
            lblIndicacion.Visible = false;
            lblIndicacion2.Visible = false;
            tbSeleccion.Visible = false;
            textoError.Visible = false;
            btnVolver.Visible = false;

            btnAgregar.Location = new Point(760, 300);
            btnEliminar.Location = new Point(760, 200);
            btnAgregar.Text = "AGREGAR";
            agregarStep = 0;
        }
    }
}