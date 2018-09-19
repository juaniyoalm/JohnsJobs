using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Demandante;

namespace Core.Mapping
{
    public static class MappingDemandanteInscripcion
    {
        public static dtsDemandantesInscritosEnOfertas toDtsInscripcionDemandantes(this DemandanteInscripcion di)
        {
            dtsDemandantesInscritosEnOfertas dts = new dtsDemandantesInscritosEnOfertas();
            dtsDemandantesInscritosEnOfertas.DemandantesInscritosOfertasEmpleoRow dtsRow = dts.DemandantesInscritosOfertasEmpleo.NewDemandantesInscritosOfertasEmpleoRow();

            dtsRow.IdDemandante = di.IdDemandante;
            dtsRow.IdOfertaEmpleo = di.IdOferta;
            dtsRow.Notas = di.Notas;
            dtsRow.CV = di.CV;
            dtsRow.Estado = 0;

            dts.DemandantesInscritosOfertasEmpleo.AddDemandantesInscritosOfertasEmpleoRow(dtsRow);

            return dts;
        }

    }
}
