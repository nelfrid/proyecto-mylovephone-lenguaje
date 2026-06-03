using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            btnAgregar.Location = new Point(760, 500); // Quitar visibilidad a agregar

            // Hacer visible opciones de eliminacion de producto


            cbTipoSeleccionEliminacion.Visible = true;
            lblIndicacion.Visible = true;

            btnEliminar.Text = "Siguiente";
            btnVolver.Visible = true;

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
