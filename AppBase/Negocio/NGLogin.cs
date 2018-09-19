using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Login;
using Core.Usuario;

namespace Negocio
{
    public class NGLogin
    {
        /// <summary>
        /// Método que comprueba que los campos de inicio de sesión del usuario sean correctos y llama al método del acceso a datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>el usuario si se ha logueaado correctamente o null en caso contrario</returns>
        public Usuario EsValido(LoginModels usuario)
        {
            int maxLength = 20;
            int minLength = 0;

            if(!String.IsNullOrEmpty(usuario.User) && !String.IsNullOrEmpty(usuario.Password)
                && usuario.Password.Length > minLength && usuario.Password.Length < maxLength){

                Usuario user = UTlogin.EsValido(usuario);
                return user;
            }
            return null;
        }

        #region PROPIEDADES
        private BaseDeDatos.UTLogin _uTLogin { get; set; }

        private BaseDeDatos.UTLogin UTlogin
        {
            get
            {
                if (_uTLogin == null)
                    return _uTLogin = new BaseDeDatos.UTLogin();
                return _uTLogin;
            }
            set { }
        }


        #endregion 

    }
}
