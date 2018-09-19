using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usuario;
using Core.Login;
using System.Data;
using System.Data.SqlClient;
using GestorBD;
using Core.Esquemas;
using Core.Mapping;
using Core.Demandante;
using BaseDeDatos;

namespace Demandante.AccesoBaseDeDatos
{
    public class UTDemandante : UTBase
    {
        /// <summary>
        /// Método que devuelve un modelo de demandante através de su ID (Llamada a la Base de Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DemandanteModel o null</returns>
        public DemandanteModel GetDemandanteModelByUserId(string id)
        {
            dtsLecturaDemandante dts = new dtsLecturaDemandante();
            DemandanteModel user;
            SqlParameter param = new SqlParameter("@idUsuario", id);
            dts.Merge(this.Repo.Leer("pDemandantesLectura", CommandType.StoredProcedure, dts.Demandantes.TableName, param));
            user = dts.Demandantes.ToDemandanteModel();
            return dts.Demandantes.Rows.Count > 0 ? user : null;
        }

        /// <summary>
        /// Método que devuelve un  demandante através de su ID (Llamada a la Base de Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Demandante o null</returns>
        public Core.Demandante.Demandante GetDemandanteByUserId(int id)
        {
            dtsDemandante dts = new dtsDemandante();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Demandantes.IdUsuarioColumn, id);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
           // dtsDemandante.DemandantesDataTable dtDem = (dtsDemandante.DemandantesDataTable)Repo.Leer(dts.Demandantes, parametros);
            dtsDemandante.DemandantesDataTable dtDem = (dtsDemandante.DemandantesDataTable)Repo.Leer(dts.Demandantes, parametros);

            Core.Demandante.Demandante dem;
            if (dtDem.Rows.Count > 0)
                dem = MappingDemandante.ToDemandante(dtDem, 0);
            else
                dem = null;

            return dem;
        }

        /// <summary>
        /// Método que guarda un modelo de demandante (Llamada a la Base de Datos). Además, comprueba que el logo de la empresa haya sido introducido
        /// y parsea la cadena. En caso de que no haya sido introducido, le asigna uno por defecto
        /// </summary>
        /// <param name="dem"></param>
        /// <returns>True o False</returns>
        public bool GuardarDemandante(Core.Demandante.Demandante dem)
        {
            Core.Demandante.Demandante aux = GetDemandanteByUserId(dem.IdUsuario);

            if (aux != null)
                return false;

            dtsDemandante dts = MappingDemandante.ToDtsDemandantes(dem);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Demandantes.IdUsuarioColumn, dem.IdUsuario);

            return Repo.Count(dts.Demandantes, parametros) == 1;
        }

        /// <summary>
        /// Método que carga los niveles de estudios disponibles (Llamada a la Base de Datos)
        /// </summary>
        /// <returns>Lista de niveles de estudios o null</returns>
        public List<NivelesEstudios> CargarNiveles()
        {
            List<NivelesEstudios> niveles = new List<NivelesEstudios>();
            dtsNivelEstudios dts = new dtsNivelEstudios();

            dts.Merge(Repo.Leer(dts.Estudios));


            for (int i = 0; i < dts.Estudios.Rows.Count; i++)
            {
                NivelesEstudios nEst = new NivelesEstudios();
                nEst = MappingNivelEstudios.ToEstudios(dts.Estudios, i);
                niveles.Add(nEst);
            }

            return niveles;
        }

        public bool ModificarDemandante(DemandanteModel dem)
        {
               
            Core.Demandante.Demandante aux = GetDemandanteByUserId(dem.IdUsuario);
            if (aux == null)
                return false;

            dtsUsuarios dtsUsu = MappingUsuario.ToModificarUsuario(dem);
            Repo.Guardar(dtsUsu);

            dtsDemandante dts = MappingDemandante.ToDtsDemandantesModificar(dem);
            Repo.Guardar(dts);

            return true;
        }
    }
}
