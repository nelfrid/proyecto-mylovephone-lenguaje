using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    /// <summary>
    /// Clase que representa una Factura del sistema
    /// Almacena información de transacciones y ventas de productos
    /// </summary>
    public class Factura
    {
        // PROPIEDADES - Información de la factura
        /// <summary>Identificador único de la factura</summary>
        public int IdFactura { get; set; }

        /// <summary>Nombre completo del cliente</summary>
        public string NombreCliente { get; set; }

        /// <summary>Cédula o identificación del cliente</summary>
        public string CedulaCliente { get; set; }

        /// <summary>Fecha en que se realizó la facturación</summary>
        public string FechaFacturacion { get; set; }

        /// <summary>Nombre del producto adquirido</summary>
        public string ProductoAdquirido { get; set; }

        /// <summary>Cantidad de unidades del producto comprado</summary>
        public int Cantidad_de_productosAdquiridos { get; set; }

        /// <summary>Correo electrónico del cliente</summary>
        public string CorreoCliente { get; set; }

        // PROPIEDADES - Valores monetarios
        /// <summary>Precio unitario del producto</summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>Subtotal sin impuestos</summary>
        public decimal Subtotal { get; set; }

        /// <summary>Monto del impuesto aplicado</summary>
        public decimal Impuesto { get; set; }

        /// <summary>Monto total a pagar</summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Constructor de la clase Factura
        /// Inicializa todas las propiedades con los valores proporcionados
        /// </summary>
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
