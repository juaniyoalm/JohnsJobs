using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Registro;

namespace Negocio
{
    public class NGRegistro
    {
        /// <summary>
        /// Método que comprueba que los campos de registro del usuario sean correctos y llama al método del acceso a datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true si el usuario se ha registrado en la BD o false en caso contrario</returns>
        public bool esRegistrable(RegistroModels usuario)
        {
            int maxLength = 20;
            int minLength = 5;


            bool tipoUsuarioCorrecto;
            if (usuario.TipoUsuario == 1 || usuario.TipoUsuario == 0)
                tipoUsuarioCorrecto = true;
            else
                tipoUsuarioCorrecto = false;


            if (!String.IsNullOrEmpty(usuario.User) && !String.IsNullOrEmpty(usuario.Password) && !String.IsNullOrEmpty(usuario.Nombre) && !String.IsNullOrEmpty(usuario.Apellido1) && !String.IsNullOrEmpty(usuario.Apellido2) &&
                tipoUsuarioCorrecto && usuario.Password.Length > minLength && usuario.Password.Length < maxLength)
            {

                if (UTregistro.EsRegistrable(usuario))
                {
                    return UTregistro.Registrar(usuario);
                }
            }

            return false;
        }

        #region PROPIEDADES
        private BaseDeDatos.UTRegistro _uTRegistro { get; set; }

        private BaseDeDatos.UTRegistro UTregistro
        {
            get
            {
                if (_uTRegistro == null)
                    return _uTRegistro = new BaseDeDatos.UTRegistro();
                return _uTRegistro;
            }
            set { }
        }
        #endregion

    }
}
