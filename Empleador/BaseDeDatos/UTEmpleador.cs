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
using Core.Empleador;
using BaseDeDatos;

namespace Empleador.AccesoBaseDeDatos
{
    public class UTEmpleador : UTBase
    {
        /// <summary>
        /// Método que devuelve un modelo de empleador através de su ID (Llamada a la Base de Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EmpleadorModel o null</returns>
        public Core.Empleador.EmpleadorModel GetEmpleadorModelByUserId(string id)
        {
            dtsLecturaEmpleadores dts = new dtsLecturaEmpleadores();
            EmpleadorModel user;
            SqlParameter param = new SqlParameter("@idUsuario", id);
            dts.Merge(this.Repo.Leer("pEmpleadosLectura", CommandType.StoredProcedure, dts.Empleadores.TableName, param));
            user = dts.Empleadores.ToEmpleadorModel();
            return dts.Empleadores.Rows.Count > 0 ? user : null;
        }

        /// <summary>
        /// Método que devuelve un  empleador através de su ID (Llamada a la Base de Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empleador o null</returns>
        public Core.Empleador.Empleador GetEmpleadorByUserId(int id)
        {
            dtsEmpleadores dts = new dtsEmpleadores();
            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Empleadores.IdUsuarioColumn, id);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            dtsEmpleadores.EmpleadoresDataTable dtEmp = (dtsEmpleadores.EmpleadoresDataTable)Repo.Leer(dts.Empleadores, parametros);

            Core.Empleador.Empleador emp;
            if (dtEmp.Rows.Count > 0)
                emp = MappingEmpleador.ToEmpleador(dtEmp, 0);
            else
                emp = null;

            return emp;
        }

        /// <summary>
        /// Método que guarda un modelo de empleador (Llamada a la Base de Datos). Además, comprueba que la foto de perfil haya sido introducida
        /// y parsea la cadena. En caso de que no haya sido introducida, le asigna una por defecto
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>True o False</returns>
        public bool GuardarEmpleador(Core.Empleador.Empleador emp)
        {
            Core.Empleador.Empleador aux = GetEmpleadorByUserId(emp.IdUsuario);

            if (aux != null)
                return false;

            dtsEmpleadores dts = MappingEmpleador.ToDtsEmpleadores(emp);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Empleadores.IdUsuarioColumn, emp.IdUsuario);

            return Repo.Count(dts.Empleadores, parametros) == 1;
        }

        /// <summary>
        /// Método que carga las industrias disponibles (Llamada a la Base de Datos)
        /// </summary>
        /// <returns>Lista de tipos de industrias o null</returns>
        public List<Industria> CargarIndustrias()
        {
            List<Industria> industrias = new List<Industria>();
            dtsIndustria dts = new dtsIndustria();

            dts.Merge(Repo.Leer(dts.Industrias));



            for (int i = 0; i < dts.Industrias.Rows.Count; i++ )
            {
                Industria ind = new Industria();
                ind = MappingIndustria.ToIndustria(dts.Industrias, i);
                industrias.Add(ind);
            }

            return industrias;
        }
    }
}
