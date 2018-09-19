using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Demandante;

namespace Core.Mapping
{
    public static class MappingNivelEstudios
    {
        /// <summary>
        /// Mapea los datos recibidos en la tabla con un nuevo objeto de tipo NivelesEstudios
        /// </summary>
        /// <param name="dtNest"></param>
        /// <param name="row"></param>
        /// <returns>Objeto NivelesEstudios</returns>
        public static Demandante.NivelesEstudios ToEstudios(this dtsNivelEstudios.EstudiosDataTable dtNest, int row = 0)
        {
            Demandante.NivelesEstudios nEst = new Demandante.NivelesEstudios();
            nEst.NivelEstudios = Convert.ToInt32(dtNest.Rows[row][dtNest.NivelEstudiosColumn.ColumnName]);
            nEst.Nombre = dtNest.Rows[row][dtNest.NombreColumn.ColumnName].ToString();
            return nEst;
        }
    }
}
