using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    internal class Factura
    {
        public int idFactura;
        private string nombreCliente;
        private string cedulaCliente;
        private string fechaFacturacion;


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

        public Factura (int idFactura, string nombreCliente, string cedulaCliente, string  fechaFacturacion)

        {
           this.idFactura = idFactura;
            this.fechaFacturacion= fechaFacturacion;
            this.cedulaCliente= cedulaCliente;
            this.nombreCliente= nombreCliente;
        }

        public double CalcularTotal(double precio)
        {
            double resultado = 1.07 * precio;
            return resultado;
        }

    }
}
