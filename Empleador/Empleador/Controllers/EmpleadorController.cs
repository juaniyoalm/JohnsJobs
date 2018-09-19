using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Usuario;
using Core.Login;
using Core.Utilidades;
using Empleador.CapaNegocio;
using Core.Empleador;
using Core.Demandante;


namespace Empleador.Controllers
{
    public class EmpleadorController : Controller
    {
        /// <summary>
        /// Recupera las cookies y, segun sea el primer inicio del ususario o no, llama a un método u otro
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            string id = Cookies.GetCookie("Id");
            NGEmpleador NGVez = new NGEmpleador();
            Core.Empleador.Empleador user = NGVez.GetEmpleadorByUserId(Convert.ToInt32(id));

            return user == null ? RedirectToAction("FirstSession") : RedirectToAction("Inicio");
        }

        /// <summary>
        /// Devuelve la página de inicio del Empleador
        /// </summary>
        /// <returns></returns>
        public ActionResult Inicio()
        {
            Core.Empleador.Empleador emp = new Core.Empleador.Empleador();
            return View("~/Views/Empleador/Index.cshtml");
        }

        /// <summary>
        /// Devuelve la pagina de registro avanzado del Empleador
        /// </summary>
        /// <returns></returns>
        public ActionResult FirstSession()
        {
            return View();
        }

        /// <summary>
        /// Guarda un Empleador (llamada la a capa de Negocio) y devuelve un Json con los datos de dicho empleador si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarEmpleador(Core.Empleador.EmpleadorModel emp)
        {
            if (ModelState.IsValid)
            {
                emp.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));
                CapaNegocio.NGEmpleador ngEmp = new CapaNegocio.NGEmpleador();
                return ngEmp.GuardarEmpleador(emp)?Json(emp):Json(false);
            }
            return Json(false);
        }

        /// <summary>
        /// Carga las industrias (llamada a la capa de Negocio) y devuelve un Json con los datos de las industrias si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <returns></returns>
        public JsonResult CargarIndustrias()
        {
            CapaNegocio.NGEmpleador ngEmp = new CapaNegocio.NGEmpleador();
            var result = ngEmp.CargarIndustrias();
            return result != null ? Json(result) : Json(false);
        }

        /// <summary>
        /// Carga los datos de un Modelo de Empleador y devuelve un Json con los datos de dicho empleador si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <returns></returns>
        public JsonResult CargarDatosEmpleadorModel()
        {
            string id = Cookies.GetCookie("Id");
            NGEmpleador NGVez = new NGEmpleador();
            Core.Empleador.EmpleadorModel user = NGVez.GetEmpleadorModelByUserId(id);

            return user != null ? Json(user) : Json(false);
        }


        public JsonResult GetOfertas(int idEmpleador)
        {
            NGOfertas NGoferta = new NGOfertas();
            List<Oferta> ofertas = NGoferta.GetOfertas(idEmpleador);
            return ofertas!=null?Json(ofertas):null;
        }

        public JsonResult CrearOferta(Oferta oferta)
        {
            NGOfertas ngEmp = new NGOfertas();
            return ngEmp.CrearOferta(oferta)?Json(true):Json(false);
        }

        public JsonResult GetUsuariosInscritos(int idOferta)
        {
            NGOfertas NGoferta = new NGOfertas();
            List<VerDemandanteInscritoOferta> list = NGoferta.GetUsuariosInscritos(idOferta);
            return list != null ? Json(list) : null;
        }

        public JsonResult CambiarEstado(VerDemandanteInscritoOferta usuarioP)
        {
            NGOfertas NGoferta = new NGOfertas();
            return NGoferta.CambiarEstado(usuarioP)?Json(true):Json(false);
        }

    }

}