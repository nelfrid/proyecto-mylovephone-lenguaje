using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace MyLoveStore
{
    public class ConexionBD
    {
        public static OleDbConnection ObtenerConexion()
        {
            string ruta = Path.Combine(Application.StartupPath, "Basedatos", "Inventario del proyecto2.accdb");

            string cadena = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};Persist Security Info=False;";

            return new OleDbConnection(cadena);
        }
    }
}