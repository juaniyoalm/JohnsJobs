using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Empleador;

namespace Core.Mapping
{
    public static class MappingIndustria
    {
        /// <summary>
        /// Mapea los datos recibidos en la tabla con un nuevo objeto de tipo Industria
        /// </summary>
        /// <param name="dtInd"></param>
        /// <param name="row"></param>
        /// <returns>Objeto Industria</returns>
        public static Empleador.Industria ToIndustria(this dtsIndustria.IndustriasDataTable dtInd, int row = 0)
        {
            Empleador.Industria ind = new Empleador.Industria();
            ind.TipoIndustria = Convert.ToInt32(dtInd.Rows[row][dtInd.TipoIndustriaColumn.ColumnName]);
            ind.Nombre = dtInd.Rows[row][dtInd.NombreColumn.ColumnName].ToString();
            return ind;
        }
    }
}
