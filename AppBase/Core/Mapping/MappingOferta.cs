using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Empleador;
using Core.Esquemas;
using Core.Demandante;

namespace Core.Mapping
{
    public static class MappingOferta
    {
        public static List<Oferta> toOferta(this dtsOferta.OfertasEmpleoDataTable dtOferta)
        {
            List<Oferta> listOfertas = new List<Oferta>();

            for (int i = 0; i < dtOferta.Rows.Count; i++)
            {
                Oferta oferta = new Oferta();
                oferta.Id = Convert.ToInt32(dtOferta.Rows[i][dtOferta.IdColumn.ColumnName]);
                oferta.IdEmpleador = Convert.ToInt32(dtOferta.Rows[i][dtOferta.IdEmpleadorColumn.ColumnName]);
                oferta.Titulo = dtOferta.Rows[i][dtOferta.TituloColumn.ColumnName].ToString();
                oferta.FechaLanzamiento = (DateTime)dtOferta.Rows[i][dtOferta.FechaLanzamientoColumn.ColumnName];
                oferta.FechaFin = (DateTime)dtOferta.Rows[i][dtOferta.FechaFinColumn.ColumnName];
                oferta.Descripcion = dtOferta.Rows[i][dtOferta.DescripcionColumn.ColumnName].ToString();
                oferta.NumeroVacantes = Convert.ToInt32(dtOferta.Rows[i][dtOferta.NumeroVacantesColumn.ColumnName]);
                oferta.Sueldo = Convert.ToInt32(dtOferta.Rows[i][dtOferta.SueldoColumn.ColumnName]);
                oferta.Observaciones = dtOferta.Rows[i][dtOferta.ObservacionesColumn.ColumnName].ToString();
                oferta.FechaLanzamientoS = oferta.FechaLanzamiento.ToString().Substring(0, 10);
                oferta.FechaFinS = oferta.FechaFin.ToString().Substring(0, 10);

                listOfertas.Add(oferta);
            }

            return listOfertas.Count > 0 ? listOfertas : null;
        }

        public static List<VerDemandanteInscritoOferta> toVerDemandanteInscritoOferta(this dtsDemandantesInscritosOferta.pDemandantesInscritosOfertaDataTable dt)
        {
            List<VerDemandanteInscritoOferta> list = new List<VerDemandanteInscritoOferta>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VerDemandanteInscritoOferta dio = new VerDemandanteInscritoOferta();
                dio.IdDemandante = Convert.ToInt32(dt.Rows[i][dt.IdDemandanteColumn.ColumnName]);
                dio.IdOferta = Convert.ToInt32(dt.Rows[i][dt.IdOfertaEmpleoColumn.ColumnName]);
                dio.Notas = dt.Rows[i][dt.NotasColumn.ColumnName].ToString();
                dio.CV = dt.Rows[i][dt.CVColumn.ColumnName].ToString();
                dio.Id = Convert.ToInt32(dt.Rows[i][dt.IdColumn.ColumnName]);
                dio.IdUsuario = Convert.ToInt32(dt.Rows[i][dt.IdUsuarioColumn.ColumnName]);
                dio.FotoPerfil = (byte [])dt.Rows[i][dt.FotoPerfilColumn.ColumnName];
                dio.Edad = Convert.ToInt32(dt.Rows[i][dt.EdadColumn.ColumnName]);
                dio.Telefono = dt.Rows[i][dt.TelefonoColumn.ColumnName].ToString();
                dio.PerfilLinkedin = dt.Rows[i][dt.PerfilLinkedinColumn.ColumnName].ToString();
                dio.NivelEstudios = Convert.ToInt32(dt.Rows[i][dt.NivelEstudiosColumn.ColumnName]);
                dio.ExperienciaLAboral = dt.Rows[i][dt.ExperienciaLaboralColumn.ColumnName].ToString();
                dio.Nombre = dt.Rows[i][dt.NombreColumn.ColumnName].ToString();
                dio.Apellido1 = dt.Rows[i][dt.Apellido1Column.ColumnName].ToString();
                dio.Apellido2 = dt.Rows[i][dt.Apellido2Column.ColumnName].ToString();

                list.Add(dio);
            }

            return list;
        }



        public static dtsOferta toDstOferta(this Empleador.Oferta oferta)
        {
            dtsOferta dts = new dtsOferta();
            dtsOferta.OfertasEmpleoRow dtsRow = dts.OfertasEmpleo.NewOfertasEmpleoRow();

            dtsRow.IdEmpleador = oferta.IdEmpleador;
            dtsRow.Titulo = oferta.Titulo;
            dtsRow.FechaLanzamiento = DateTime.Now;
            dtsRow.FechaFin = oferta.FechaFin;
            dtsRow.Descripcion = oferta.Descripcion;
            dtsRow.NumeroVacantes = oferta.NumeroVacantes;
            dtsRow.Sueldo = oferta.Sueldo;
            dtsRow.Observaciones = oferta.Observaciones;

            dts.OfertasEmpleo.AddOfertasEmpleoRow(dtsRow);

            return dts;
        }
    }
}
