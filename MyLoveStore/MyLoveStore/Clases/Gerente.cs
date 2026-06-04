using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    /// <summary>
    /// Clase que representa a un Gerente del sistema
    /// Contiene información de autenticación del administrador
    /// </summary>
    public class Gerente
    {
        // Variables privadas para almacenar credenciales del gerente
        private string username;
        private string key;

        /// <summary>
        /// Propiedad para obtener el nombre de usuario del gerente
        /// </summary>
        public string Username
        {
            get { return username; }

        }

        /// <summary>
        /// Propiedad para obtener la contraseña del gerente
        /// </summary>
        public string Key 
        {  
            get { return key; } 

        }

        /// <summary>
        /// Constructor del Gerente
        /// Inicializa las credenciales predeterminadas del administrador
        /// </summary>
        /// <param name="username">Nombre de usuario (no se utiliza, se usa el valor por defecto)</param>
        /// <param name="key">Contraseña (no se utiliza, se usa el valor por defecto)</param>
        public Gerente(string username, string key)
        {
            this.username = "user-admin";
            this.key = "0000";
        }
    }
}

