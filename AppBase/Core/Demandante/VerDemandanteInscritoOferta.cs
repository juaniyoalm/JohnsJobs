using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class VerDemandanteInscritoOferta
    {

        public int IdDemandante { get; set; }
        public int IdOferta { get; set; }
        public string Notas { get; set; }
        public string CV { get; set; }
        public int Estado { get; set; }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public byte[] FotoPerfil { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string PerfilLinkedin { get; set; }
        public int NivelEstudios { get; set; }
        public string ExperienciaLAboral { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }

    }
}
