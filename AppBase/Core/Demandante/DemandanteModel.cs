using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class DemandanteModel : Demandante
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int TipoUsuario { get; set; }
        public string NivelEstudiosNombre { get; set; }
        public string ImagenB64 { get; set; }
        public string Contrasena { get; set; }
    }
}
