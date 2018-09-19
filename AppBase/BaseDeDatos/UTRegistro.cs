using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorBD;
using Core.Registro;
using Core.Esquemas;
using Core.Mapping;

namespace BaseDeDatos
{
    public class UTRegistro : UTBase
    {
        /// <summary>
        /// Método que registra un usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true en caso de que el registro sea correcto o null en caso de que falle</returns>
        public bool Registrar(RegistroModels usuario)
        {
            dtsUsuarios dts = MappingUsuario.ToDtsUsuarios(usuario);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Usuarios.UsuarioColumn, usuario.User);

            return Repo.Count(dts.Usuarios, parametros) == 1;
        }

        /// <summary>
        /// Comprueba si no exixte un usuario con el mismo nombre de usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true en caso de que no exixta ningun usuario en la BD o false en caso contrario</returns>
        public bool EsRegistrable(RegistroModels usuario)
        {
            dtsUsuarios dts = MappingUsuario.ToDtsUsuarios(usuario);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.Usuarios.UsuarioColumn, usuario.User);

            return Repo.Count(dts.Usuarios, parametros) == 0;
        }
    }
}
