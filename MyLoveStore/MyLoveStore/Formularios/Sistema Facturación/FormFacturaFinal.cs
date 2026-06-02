using MyLoveStore.Clases;
using System;
using System.Drawing;
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

        private decimal precioUnitario;
        private decimal subtotal;
        private decimal impuesto;
        private decimal total;

        public FormFacturaFinal(Factura factura_que_viene)
        {
            InitializeComponent();

            nombreClienteIngresado = factura_que_viene.NombreCliente;
            idFacturaIngresado = factura_que_viene.IdFactura;
            cedulaClienteIngresado = factura_que_viene.CedulaCliente;
            fechaFacturacionIngresado = factura_que_viene.FechaFacturacion;
            productoAdquirido = factura_que_viene.ProductoAdquirido;
            cantidad_productosIngresado = factura_que_viene.Cantidad_de_productosAdquiridos;
            correoClienteIngresado = factura_que_viene.CorreoCliente;

            precioUnitario = factura_que_viene.PrecioUnitario;
            subtotal = factura_que_viene.Subtotal;
            impuesto = factura_que_viene.Impuesto;
            total = factura_que_viene.Total;
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

            lblPrecioUnitario.Text = "B/. " + precioUnitario.ToString("0.00");
            lblSubtotal.Text = "B/. " + subtotal.ToString("0.00");
            lblImpuesto.Text = "B/. " + impuesto.ToString("0.00");
            lblTotal.Text = "B/. " + total.ToString("0.00");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}