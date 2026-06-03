using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Inventario1
{
    public partial class Inventario : Form
    {
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
<<<<<<< HEAD
            btnAgregar.Location = new Point(760, 500); // Quitar visibilidad a agregar

            // Hacer visible opciones de eliminacion de producto


            cbTipoSeleccionEliminacion.Visible = true;
            lblIndicacion.Visible = true;

            btnEliminar.Text = "Siguiente";
            btnVolver.Visible = true;
=======
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un producto.");
                    return;
                }

                int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CODIGO"].Value);

                using (OleDbConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    string consulta = "DELETE FROM Productos WHERE IdProducto = ?";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("?", idProducto);
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Producto eliminado correctamente.");
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para agregar productos falta crear campos de nombre y cantidad.");
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
>>>>>>> 98f7f40f02769432a52a0ade25020f8f5f4d2867

            if (cbTipoSeleccionEliminacion.Text.ToString() == "ID") // ---------------------------------------------------------------
            {

                // Se selecciona el producto a eliminar por ID

                lblIndicacion2.Visible = true;
                lblIndicacion2.Text = "Ingrese el ID del producto a eliminar: ";
                tbSeleccion.Visible = true;

                // Condicional para eliminar producto por ID

            }

            else if (cbTipoSeleccionEliminacion.Text.ToString() == "NOMBRE") // ---------------------------------------------------------------
            {
                // Se selecciona el producto a eliminar por Nombre
                lblIndicacion2.Visible = true;
                lblIndicacion2.Text = "Ingrese el Nombre del producto a eliminar: ";
                tbSeleccion.Visible = true;
                // Condicional para eliminar producto por Nombre)

                // CONDICIONAL PARA ELIMINAR PRODUCTO POR NOMBRE

            }
            else
            {
                textoError.Visible = true;
                lblIndicacion.Location = new Point(1007, 352);
                cbTipoSeleccionEliminacion.Location = new Point(1011, 380);
            }


            }
    }
}