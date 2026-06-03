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

        }
    }
}