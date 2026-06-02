using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    public class Factura
    {
        public int idFactura;
        private string nombreCliente;
        private string cedulaCliente;
        private string fechaFacturacion;
        private string productoAdquirido;
        private int cantidad_de_productosAdquiridos;
        private string correoCliente;

        public int IdFactura
        {
            get { return idFactura; }
                set { idFactura = value; }
            } 
        public string NombreCliente
        {  get { return nombreCliente; }
           set { nombreCliente = value; }
        }

        public string CedulaCliente
        {
            get { return cedulaCliente; }
            set {  cedulaCliente = value; }
        }

        public string FechaFacturacion
        {
            get { return fechaFacturacion; }
            set {  fechaFacturacion = value; }
        }

        public string ProductoAdquirido
        {
            get { return productoAdquirido; }
            set {  productoAdquirido = value; }
        }

        public int Cantidad_de_productosAdquiridos
        {
            get { return cantidad_de_productosAdquiridos;  }
            set { cantidad_de_productosAdquiridos = value; }
        }

        public string CorreoCliente
        {
            get { return correoCliente; }
            set { correoCliente = value; }
        }

        public Factura (int idFactura, string nombreCliente, string cedulaCliente, string  fechaFacturacion, string productoAdquirido, int cantidad_de_productosAdquiridos, string correoCliente)

        {
           this.idFactura = idFactura;
            this.fechaFacturacion= fechaFacturacion;
            this.cedulaCliente= cedulaCliente;
            this.nombreCliente= nombreCliente;
            this.productoAdquirido= productoAdquirido;
            this.cantidad_de_productosAdquiridos = cantidad_de_productosAdquiridos;
        }

        public double ObtenerPrecio(string productoAdquirido)
        {

        }
        public double CalcularTotal(double precio)
        {
            double resultado = 1.07 * (precio * this.cantidad_de_productosAdquiridos);
            return resultado;
        }

    }
}
