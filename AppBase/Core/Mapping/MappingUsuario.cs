using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Esquemas;
using Core.Usuario;
using Core.Registro;
using Core.Login;

namespace Core.Mapping
{
    public static class MappingUsuario
    {
        /// <summary>
        /// Mapea los datos de la tabla recibida en un usuario y lo devuelve 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static Usuario.Usuario ToUsuario(this dtsUsuarios.UsuariosDataTable dataTable, int row = 0)
        {
            Usuario.Usuario u = new Usuario.Usuario();
            u.Id = Convert.ToInt32(dataTable.Rows[row][dataTable.IdColumn.ColumnName]);
            u.User = dataTable.Rows[row][dataTable.UsuarioColumn.ColumnName].ToString();
            u.Contrasena = dataTable.Rows[row][dataTable.ContrasenaColumn.ColumnName].ToString();
            u.Nombre = dataTable.Rows[row][dataTable.NombreColumn.ColumnName].ToString();
            u.Apellido1 = dataTable.Rows[row][dataTable.Apellido1Column.ColumnName].ToString();
            u.Apellido2 = dataTable.Rows[row][dataTable.Apellido2Column.ColumnName].ToString();
            
            var dtPrueba = dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName];

            if (dtPrueba != null)
            {
                u.TipoUsuario = Convert.ToInt32(dataTable.Rows[row][dataTable.TipoUsuarioColumn.ColumnName]);
            }

            return u;
        }

        /// <summary>
        /// Mapea los datos del usuario recibido y los introduce un una fila de una tabla de Usuarios. Devuelve la tabla 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        
        public static dtsUsuarios ToDtsUsuarios(this RegistroModels usuario)
        {

            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Usuario = usuario.User;
            dtsRow.Contrasena = usuario.Password;
            dtsRow.Nombre = usuario.Nombre;
            dtsRow.Apellido1 = usuario.Apellido1;
            dtsRow.Apellido2 = usuario.Apellido2;
            dtsRow.TipoUsuario = (short)usuario.TipoUsuario;
            dts.Usuarios.AddUsuariosRow(dtsRow);

            return dts;
        }

        /// <summary>
        /// Mapea los datos del usuario recibido y los introduce un una fila de una tabla de Usuarios. Devuelve la tabla 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        public static dtsUsuarios ToDtsUsuarios(this LoginModels usuario)
        {

            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Usuario = usuario.User;
            dtsRow.Contrasena = usuario.Password;
            dts.Usuarios.AddUsuariosRow(dtsRow);

            return dts;
        }


        public static dtsUsuarios ToDtsUsuarios(this Demandante.DemandanteModel usuario)
        {

            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Usuario = usuario.Usuario;
            dtsRow.Contrasena = usuario.Contrasena;
            dtsRow.Nombre = usuario.Nombre;
            dtsRow.Apellido1 = usuario.Apellido1;
            dtsRow.Apellido2 = usuario.Apellido2;
            dtsRow.TipoUsuario = (short)usuario.TipoUsuario;

            dts.Usuarios.AddUsuariosRow(dtsRow);

            return dts;
        }

        public static dtsUsuarios ToModificarUsuario(this Demandante.DemandanteModel usuario)
        {

            dtsUsuarios dts = new dtsUsuarios();
            dtsUsuarios.UsuariosRow dtsRow = dts.Usuarios.NewUsuariosRow();

            dtsRow.Id = usuario.IdUsuario;
            dtsRow.Usuario = usuario.Usuario;
            dtsRow.Contrasena = usuario.Contrasena;
            dtsRow.Nombre = usuario.Nombre;
            dtsRow.Apellido1 = usuario.Apellido1;
            dtsRow.Apellido2 = usuario.Apellido2;
            dtsRow.TipoUsuario = (short)usuario.TipoUsuario;

            dts.Usuarios.AddUsuariosRow(dtsRow);
            dts.Usuarios.AcceptChanges();
            dts.Usuarios[0].SetModified();

            return dts;
        }

    }
}
