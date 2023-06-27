using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public ML.Automovil Automovil { get; set; }
        public List<object> Usuarios { get; set;}
    }
}
