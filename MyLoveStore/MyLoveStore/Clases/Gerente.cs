using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoveStore.Clases
{
    public class Gerente
    {

        private string username;
        private string key;

        public string Username
        {
            get { return username; }
            
        }

        public string Key 
        {  
            get { return key; } 
             
        }

        public Gerente(string username, string key)
        {
            this.username = "user-admin";
            this.key = "0000";
        }
    }
}
