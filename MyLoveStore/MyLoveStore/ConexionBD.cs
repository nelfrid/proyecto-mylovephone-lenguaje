using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace MyLoveStore
{
    /// <summary>
    /// Clase encargada de gestionar la conexión a la base de datos
    /// Utiliza Microsoft Access para almacenar los datos del inventario
    /// </summary>
    internal class ConexionBD
    {
        /// <summary>
        /// Método estático que obtiene una conexión a la base de datos
        /// Construye la ruta dinámicamente desde la carpeta del proyecto
        /// </summary>
        /// <returns>OleDbConnection - Conexión a la base de datos Access</returns>
        public static OleDbConnection ObtenerConexion()
        {
            // BLOQUE 1: Construcción de la ruta del archivo de base de datos
            // Navega desde la carpeta de ejecución hasta la carpeta Basedatos
            string ruta = Path.Combine(
                Directory.GetParent(Application.StartupPath).Parent.Parent.FullName,
                "Basedatos",
                "Inventario del proyecto2.accdb"
            );

            // BLOQUE 2: Construcción de la cadena de conexión
            // Configura el proveedor OLE DB para Microsoft Access
            string conexion = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ruta};Persist Security Info=False;";

            // BLOQUE 3: Retorno de la conexión
            // Devuelve una nueva instancia de conexión a la base de datos
            return new OleDbConnection(conexion);
        }
    }
}
