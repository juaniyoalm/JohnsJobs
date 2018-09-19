using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using AppBase.Models;
using Core.Registro;

namespace AppBase.Controllers
{
    public class RegistroController : Controller
    {
        /// <summary>
        /// Devuelve la vista principal del registro
        /// </summary>
        /// <returns>Registro/Index.cshtml</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Inicia el procedimiento de registro y devuelve un JSON al controlador JS con el resultado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>JSON con los datos del usuario o false</returns>
        [HttpPost]
        public JsonResult RegistrarUsuario(RegistroModels usuario)
        {
            Negocio.NGRegistro ngRegistro = new Negocio.NGRegistro();
            if (ngRegistro.esRegistrable(usuario))
            {
                return Json(true);
            }
            return Json(false);
        }

        /// <summary>
        /// Devuelve una vista que indica que el registro ha sido correcto
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistroCorrecto()
        {
            return View();
        }

        /// <summary>
        /// Devuelve una vista que indica que el registro ha sido erróneo
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorRegistro()
        {
            return View();
        }


    }
}