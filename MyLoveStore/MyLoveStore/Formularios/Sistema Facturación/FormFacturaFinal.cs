using MyLoveStore.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Sistema_Facturación
{
    public partial class FormFacturaFinal : Form
    {
        private string nombreClienteIngresado;
        private int idFacturaIngresado;
        private string cedulaClienteIngresado;
        private string fechaFacturacionIngresado;
        private string productoAdquirido;
        private int cantidad_productosIngresado;
        private string correoClienteIngresado;
        public FormFacturaFinal(Factura factura_que_viene)
        {
            InitializeComponent();
            this.nombreClienteIngresado = factura_que_viene.NombreCliente;
            this.idFacturaIngresado = factura_que_viene.IdFactura;
            this.cedulaClienteIngresado = factura_que_viene.CedulaCliente;
            this.fechaFacturacionIngresado = factura_que_viene.FechaFacturacion;
            this.productoAdquirido = factura_que_viene.ProductoAdquirido;
            this.cantidad_productosIngresado = factura_que_viene.Cantidad_de_productosAdquiridos;
            this.correoClienteIngresado = factura_que_viene.CorreoCliente;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FormFacturaFinal_Load(object sender, EventArgs e)
        {
            lblCliente.Text = nombreClienteIngresado;
            lblCedula.Text = cedulaClienteIngresado;
            lblProductoAdquirido.Text = productoAdquirido;
            lblCantidadProductos.Text = cantidad_productosIngresado.ToString();
            lblCorreo.Text = correoClienteIngresado;
            lblFechaFacturacion.Text = fechaFacturacionIngresado;
            lbl_IdFactura.Text = idFacturaIngresado.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
