using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace MyLoveStore
{
    internal class ConexionBD
    {
        public static OleDbConnection ObtenerConexion()
        {
            string ruta = Path.Combine(
                Directory.GetParent(Application.StartupPath).Parent.Parent.FullName,
                "Basedatos",
                "Inventario del proyecto2.accdb"
            );

            string conexion = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};Persist Security Info=False;";

            return new OleDbConnection(conexion);
        }
    }
}