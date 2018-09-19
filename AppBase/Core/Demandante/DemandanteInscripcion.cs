using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class DemandanteInscripcion
    {
        public int IdDemandante { get; set; }
        public int IdOferta { get; set; }
        public string Notas { get; set; }
        public string CV { get; set; }
        public int Estado { get; set; }
    }
}
