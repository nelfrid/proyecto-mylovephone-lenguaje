using MyLoveStore.Clases;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyLoveStore.Formularios.Sistema_Facturación
{
    public partial class FormFacturaFinal : Form
    {
        private Factura factura;
        private PrintDocument documento = new PrintDocument();
        private Bitmap imagenFactura;

        public FormFacturaFinal(Factura factura_que_viene)
        {
            InitializeComponent();

            factura = factura_que_viene;

            documento.PrintPage += Documento_PrintPage;
        }

        private void FormFacturaFinal_Load(object sender, EventArgs e)
        {
            lblClientes.Text = factura.NombreCliente;
            lblCedulas.Text = factura.CedulaCliente;
            lblCorreos.Text = factura.CorreoCliente;
            lblProductos.Text = factura.ProductoAdquirido;
            lblCantidades.Text = factura.Cantidad_de_productosAdquiridos.ToString();
            lblFechas.Text = factura.FechaFacturacion;
            lblID.Text = factura.IdFactura.ToString();

            lblPU.Text = "B/. " + factura.PrecioUnitario.ToString("0.00");
            lblSubtotal.Text = "B/. " + factura.Subtotal.ToString("0.00");
            lblItbms.Text = "B/. " + factura.Impuesto.ToString("0.00");
            lblTotales.Text = "B/. " + factura.Total.ToString("0.00");
        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imagenFactura, 50, 50);
        }

        private void btnEnviarFactura_Click(object sender, EventArgs e)
        {
            imagenFactura = new Bitmap(panel2.Width, panel2.Height);

            panel2.DrawToBitmap(
                imagenFactura,
                new Rectangle(0, 0, panel2.Width, panel2.Height)
            );

            documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintDialog dialogo = new PrintDialog();
            dialogo.Document = documento;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                documento.Print();
                MessageBox.Show("Factura PDF generada correctamente.");
            }
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

        private void lblTotales_Click(object sender, EventArgs e)
        {
        }
    }
}