using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using AppBase.Models;
using Core.Login;
using Core.Usuario;
using Core.Utilidades;

namespace AppBase.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Devuelve la vista principal del login
        /// </summary>
        /// <returns>Login/Index.cshtml</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Valida el inicio de sesion del usuario y agrega la Cookie de su ID
        /// </summary>
        /// <param name="usuario">Un objeto de tipo LoginModel que se compone del usuario y el password</param>
        /// <returns>Retorna el usuario, en caso de identificarse correctamente, y null en caso contrario</returns>
        [HttpPost]
        public JsonResult IniciarSesion(LoginModels usuario)
        {
           if (ModelState.IsValid)
            {
                Negocio.NGLogin ngLogin = new Negocio.NGLogin();
                Usuario user;
                
                if ((user = ngLogin.EsValido(usuario))== null)
                    return Json(false);
                Core.Utilidades.Cookies.AddCookie("Id", user.Id.ToString());

                return Json(user);
           }
           return Json(false);

        }

        /// <summary>
        /// Devuelve una página de error si la identificación falla
        /// </summary>
        /// <returns>ErrorLogin.cshtml</returns>
        public ActionResult ErrorLogin()
        {
            return View();
        }
    }
}