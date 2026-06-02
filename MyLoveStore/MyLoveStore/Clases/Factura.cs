using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string NombreCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string FechaFacturacion { get; set; }
        public string ProductoAdquirido { get; set; }
        public int Cantidad_de_productosAdquiridos { get; set; }
        public string CorreoCliente { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

        public Factura(
            int idFactura,
            string nombreCliente,
            string cedulaCliente,
            string fechaFacturacion,
            string productoAdquirido,
            int cantidad,
            string correoCliente,
            decimal precioUnitario,
            decimal subtotal,
            decimal impuesto,
            decimal total)
        {
            IdFactura = idFactura;
            NombreCliente = nombreCliente;
            CedulaCliente = cedulaCliente;
            FechaFacturacion = fechaFacturacion;
            ProductoAdquirido = productoAdquirido;
            Cantidad_de_productosAdquiridos = cantidad;
            CorreoCliente = correoCliente;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
            Impuesto = impuesto;
            Total = total;
        }
    }
}