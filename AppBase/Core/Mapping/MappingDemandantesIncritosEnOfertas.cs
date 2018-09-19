using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Demandante;

namespace Core.Mapping
{
    public static class MappingDemandantesIncritosEnOfertas
    {
        public static List<DemandantesInscritosEnOfertas> toDemandantesInscritosEnOfertas(this dtsLecturaOfertasDemandante.pInscritosLecturaDataTable dataTable)
        {
            
            List<DemandantesInscritosEnOfertas> listOfertas = new List<DemandantesInscritosEnOfertas>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                DemandantesInscritosEnOfertas dio = new DemandantesInscritosEnOfertas();

                dio.Id = Convert.ToInt32(dataTable.Rows[i][dataTable.IdColumn.ColumnName]);
                dio.IdEmpleador = Convert.ToInt32(dataTable.Rows[i][dataTable.IdEmpleadorColumn.ColumnName]);
                dio.Descripcion = dataTable.Rows[i][dataTable.DescripcionColumn.ColumnName].ToString();
                dio.NumeroVacantes = Convert.ToInt32(dataTable.Rows[i][dataTable.NumeroVacantesColumn.ColumnName]);
                dio.Sueldo = Convert.ToInt32(dataTable.Rows[i][dataTable.SueldoColumn.ColumnName]);
                dio.FechaLanzamiento = (DateTime)dataTable.Rows[i][dataTable.FechaLanzamientoColumn.ColumnName];
                dio.FechaFin = (DateTime)dataTable.Rows[i][dataTable.FechaFinColumn.ColumnName];
                dio.Observaciones = dataTable.Rows[i][dataTable.ObservacionesColumn.ColumnName].ToString();
                dio.Titulo = dataTable.Rows[i][dataTable.TituloColumn.ColumnName].ToString();

                dio.CV = dataTable.Rows[i][dataTable.CVColumn.ColumnName].ToString();
                dio.Notas = dataTable.Rows[i][dataTable.NotasColumn.ColumnName].ToString();
                dio.Estado = Convert.ToInt32(dataTable.Rows[i][dataTable.EstadoColumn.ColumnName]);
                dio.Nombre = dataTable.Rows[i][dataTable.NombreColumn.ColumnName].ToString();
                dio.NombreEmpresa = dataTable.Rows[i][dataTable.NombreEmpresaColumn.ColumnName].ToString();
                dio.IdDemandante = Convert.ToInt32(dataTable.Rows[i][dataTable.IdDemandanteColumn.ColumnName]);
                dio.IdOfertaEmpleo = Convert.ToInt32(dataTable.Rows[i][dataTable.IdOfertaEmpleoColumn.ColumnName]);

                dio.FechaLanzamientoS = dio.FechaLanzamiento.ToString().Substring(0, 10);
                dio.FechaFinS = dio.FechaFin.ToString().Substring(0, 10);

                listOfertas.Add(dio);
            }

            return listOfertas;


        }

        public static dtsDemandantesInscritosEnOfertas toDtsDemandantesInscritosEnOfertas(this DemandantesInscritosEnOfertas dio)
        {
            //dtsDemandantesInscritosEnOfertas dts = new dtsDemandantesInscritosEnOfertas();
            //dtsDemandantesInscritosEnOfertas.DemandantesInscritosOfertasEmpleoRow dtsRow = dts.DemandantesInscritosOfertasEmpleo.NewDemandantesInscritosOfertasEmpleoRow();

            //dtsRow.IdDemandante = dio.IdDemandante;
            //dtsRow.IdOfertaEmpleo = dio.IdOferta;
            //dtsRow.Notas = dio.Notas;
            //dtsRow.CV = dio.CV;
            //dtsRow.Estado = (short)dio.Estado;

            //dts.DemandantesInscritosOfertasEmpleo.AddDemandantesInscritosOfertasEmpleoRow(dtsRow);

            //return dts;
            return null;
        }
    }
}
