using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Demandante;


namespace Core.Mapping
{
    public static class MappingDemandanteModel
    {
        /// <summary>
        /// Mapea los datos recibidos en una tabla con los campos de un objeto de tipo DemandanteModel
        /// </summary>
        /// <param name="dtEmp"></param>
        /// <param name="row"></param>
        /// <returns>DemandanteModel</returns>
        public static Demandante.DemandanteModel ToDemandanteModel(this dtsLecturaDemandante.DemandantesDataTable dtDem, int row = 0)
        {
            Demandante.DemandanteModel dem = new Demandante.DemandanteModel();

            dem.Usuario = dtDem.Rows[row][dtDem.UsuarioColumn.ColumnName].ToString();
            dem.IdUsuario = Convert.ToInt32(dtDem.Rows[row][dtDem.IdUsuarioColumn.ColumnName]);
            dem.Id = Convert.ToInt32(dtDem.Rows[row][dtDem.IdColumn.ColumnName]);
            dem.Telefono = dtDem.Rows[row][dtDem.TelefonoColumn.ColumnName].ToString();
            dem.Email = dtDem.Rows[row][dtDem.EmailColumn.ColumnName].ToString();
            dem.Edad = Convert.ToInt32(dtDem.Rows[row][dtDem.EdadColumn.ColumnName]);
            dem.PerfilLinkedin = dtDem.Rows[row][dtDem.PerfilLinkedinColumn.ColumnName].ToString();
            dem.NivelEstudios = Convert.ToInt32(dtDem.Rows[row][dtDem.NivelEstudiosColumn.ColumnName]);
            dem.ExperienciaLaboral = dtDem.Rows[row][dtDem.ExperienciaLaboralColumn.ColumnName].ToString();
            dem.FotoPerfil = (byte[])dtDem.Rows[row][dtDem.FotoPerfilColumn.ColumnName];
            dem.NivelEstudiosNombre = dtDem.Rows[row][dtDem.NivelEstudiosNombreColumn.ColumnName].ToString();
            dem.Nombre = dtDem.Rows[row][dtDem.NombreColumn.ColumnName].ToString();
            dem.Apellido1 = dtDem.Rows[row][dtDem.Apellido1Column.ColumnName].ToString();
            dem.Apellido2 = dtDem.Rows[row][dtDem.Apellido2Column.ColumnName].ToString();
            dem.TipoUsuario = Convert.ToInt32(dtDem.Rows[row][dtDem.TipoUsuarioColumn.ColumnName]);
            dem.Contrasena = dtDem.Rows[row][dtDem.ContrasenaColumn.ColumnName].ToString();

            return dem;
        }
    }
}
