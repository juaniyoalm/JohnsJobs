using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Demandante
{
    public class DemandantesInscritosEnOfertas
    {
        public int Id { get; set; }
        public int IdEmpleador { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una descripción.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario introducir el número de vacantes.")]
        public int NumeroVacantes { get; set; }
        public int Sueldo { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una fecha de comienzo.")]
        public DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "Es necesario introducir una fecha de fin.")]
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; }
        public string Titulo { get; set; }
        public string NombreEmpresa { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public string Notas { get; set; }
        public string CV { get; set; }
        public int IdOfertaEmpleo { get; set; }
        public int IdDemandante { get; set; }
        public string FechaFinS { get; set; }
        public string FechaLanzamientoS { get; set; }

    }
}
