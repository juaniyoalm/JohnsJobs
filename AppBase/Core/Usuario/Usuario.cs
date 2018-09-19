using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int TipoUsuario { get; set; }

    }
}
