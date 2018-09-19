using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class Demandante
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string PerfilLinkedin { get; set; }
        public int NivelEstudios { get; set; }
        public string ExperienciaLaboral { get; set; }
        public byte[] FotoPerfil { get; set; }

    }
}
