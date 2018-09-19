using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Empleador
{
    public class Empleador
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreEmpresa { get; set; }
        public  byte[] LogoEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int TipoIndustria { get; set; }
        public int NumeroEmpleados { get; set; }
    }
}
