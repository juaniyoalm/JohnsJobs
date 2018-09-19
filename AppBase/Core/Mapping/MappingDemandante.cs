using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Demandante;

namespace Core.Mapping
{
    public static class MappingDemandante
    {
        /// <summary>
        /// Mapea los datos recibidos en una tabla con los campos de un objeto de tipo Demandante
        /// </summary>
        /// <param name="dtEmp"></param>
        /// <param name="row"></param>
        /// <returns>Demandante</returns>
        public static Demandante.Demandante ToDemandante(this dtsDemandante.DemandantesDataTable dtDem, int row = 0)
        {
            Demandante.Demandante dem = new Demandante.Demandante();
            dem.Id = Convert.ToInt32(dtDem.Rows[row][dtDem.IdColumn.ColumnName]);
            dem.IdUsuario = Convert.ToInt32(dtDem.Rows[row][dtDem.IdUsuarioColumn.ColumnName]);
            dem.Telefono = dtDem.Rows[row][dtDem.TelefonoColumn.ColumnName].ToString();
            dem.Email = dtDem.Rows[row][dtDem.EmailColumn.ColumnName].ToString();
            dem.Edad = Convert.ToInt32(dtDem.Rows[row][dtDem.EdadColumn.ColumnName]);
            dem.PerfilLinkedin = dtDem.Rows[row][dtDem.PerfilLinkedinColumn.ColumnName].ToString();
            dem.NivelEstudios = Convert.ToInt32(dtDem.Rows[row][dtDem.NivelEstudiosColumn.ColumnName]);
            dem.ExperienciaLaboral = dtDem.Rows[row][dtDem.ExperienciaLaboralColumn.ColumnName].ToString();
            dem.FotoPerfil = (byte []) dtDem.Rows[row][dtDem.FotoPerfilColumn.ColumnName];

            return dem;
        }

        /// <summary>
        /// Mapea los datos recibidos en un objeto de tipo Empleador y los introduce un una fila de  una tabla
        /// de tipo dtsEmpleadores.EmpleadoresRow
        /// </summary>
        /// <param name="dem"></param>
        /// <returns>dtsDemandante</returns>
        public static dtsDemandante ToDtsDemandantes(this Demandante.Demandante dem)
        {

            dtsDemandante dts = new dtsDemandante();
            dtsDemandante.DemandantesRow dtsRow = dts.Demandantes.NewDemandantesRow();

            dtsRow.IdUsuario = dem.IdUsuario;
            dtsRow.Telefono = dem.Telefono;
            dtsRow.Email = dem.Email;
            dtsRow.Edad = (short)dem.Edad;
            dtsRow.PerfilLinkedin = dem.PerfilLinkedin;
            dtsRow.NivelEstudios = (short)dem.NivelEstudios;
            dtsRow.ExperienciaLaboral = dem.ExperienciaLaboral;
            dtsRow.FotoPerfil = dem.FotoPerfil;
            dts.Demandantes.AddDemandantesRow(dtsRow);
            
            return dts;
        }

        public static dtsDemandante ToDtsDemandantesModificar(this Demandante.DemandanteModel dem)
        {

            dtsDemandante dts = new dtsDemandante();
            dtsDemandante.DemandantesRow dtsRow = dts.Demandantes.NewDemandantesRow();

            dtsRow.Id = dem.Id;
            dtsRow.IdUsuario = dem.IdUsuario;
            dtsRow.Telefono = dem.Telefono;
            dtsRow.Email = dem.Email;
            dtsRow.Edad = (short)dem.Edad;
            dtsRow.PerfilLinkedin = dem.PerfilLinkedin;
            dtsRow.NivelEstudios = (short)dem.NivelEstudios;
            dtsRow.ExperienciaLaboral = dem.ExperienciaLaboral;
            dtsRow.FotoPerfil = dem.FotoPerfil;

            dts.Demandantes.AddDemandantesRow(dtsRow);
            dts.Demandantes.AcceptChanges();
            dts.Demandantes[0].SetModified();

            return dts;
        }
    }
}
