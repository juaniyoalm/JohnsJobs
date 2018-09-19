using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Empleador
{
    public class Oferta
    {
        public int Id { get; set; }
        public int IdEmpleador { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int NumeroVacantes { get; set; }
        public int Sueldo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaLanzamientoS { get; set; }
        public string FechaFinS { get; set; }
        public string Observaciones { get; set; }
    }
}
