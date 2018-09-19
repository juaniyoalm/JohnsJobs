using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Usuario;
using Core.Login;
using Core.Demandante;
using Core.Utilidades;
using Demandante.CapaNegocio;
using Core.Demandante;
using Empleador.CapaNegocio;
using Core.Empleador;

namespace Demandante.Controllers
{
    public class DemandanteController : Controller
    {
        /// <summary>
        /// Recupera las cookies y, segun sea el primer inicio del ususario o no, llama a un método u otro
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string id = Cookies.GetCookie("Id");
            NGDemandante NGVez = new NGDemandante();
            Core.Demandante.Demandante user = NGVez.GetDemandanteByUserId(Convert.ToInt32(id));

            return user == null ? RedirectToAction("FirstSession") : RedirectToAction("Inicio");
        }

        /// <summary>
        /// Devuelve la página de inicio del Demandante
        /// </summary>
        /// <returns></returns>
        public ActionResult Inicio()
        {
            Core.Demandante.Demandante dem = new Core.Demandante.Demandante();
            return View("~/Views/Demandante/Index.cshtml");
        }

        /// <summary>
        /// Devuelve la pagina de registro avanzado del Demandante
        /// </summary>
        /// <returns></returns>
        public ActionResult FirstSession()
        {
            return View();
        }

        /// <summary>
        /// Guarda un Demandante (llamada la a capa de Negocio) y devuelve un Json con los datos de dicho demandante si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <param name="dem"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarDemandante(Core.Demandante.DemandanteModel dem)
        {
            if (ModelState.IsValid)
            {
                dem.IdUsuario = Convert.ToInt32(Cookies.GetCookie("Id"));
                CapaNegocio.NGDemandante ngDem = new CapaNegocio.NGDemandante();
                return ngDem.GuardarDemandante(dem) ? Json(dem) : Json(false);
            }
            return Json(false);
        }

        /// <summary>
        /// Carga los datos de un Modelo de Demandante y devuelve un Json con los datos de dicho demandante si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <returns></returns>
        public JsonResult CargarDatosDemandanteModel()
        {
            string id = Cookies.GetCookie("Id");
            NGDemandante NGVez = new NGDemandante();
            Core.Demandante.DemandanteModel user = NGVez.GetDemandanteModelByUserId(id);

            return user != null ? Json(user) : Json(false);
        }

        /// <summary>
        /// Carga los niveles de estudios (llamada a la capa de Negocio) y devuelve un Json con los datos de dichos niveles si
        /// todo ha ido bien o con el valor de False en caso contrario
        /// </summary>
        /// <returns></returns>
        public JsonResult CargarNiveles()
        {
            CapaNegocio.NGDemandante ngDem = new CapaNegocio.NGDemandante();
            var result = ngDem.CargarNiveles();
            return result != null ? Json(result) : Json(false);
        }

        public JsonResult CargarTotalOfertasSinSuscribir(int idDemandante)
        {
            NGOfertasDemandante ngOferta = new NGOfertasDemandante();
            List<Oferta> ofertas = ngOferta.GetOfertasSinSuscribir(idDemandante);
            return ofertas != null ? Json(ofertas) : null;

        }

        public JsonResult CargarTotalOfertasDemandante(int idDemandante)
        {
            NGOfertasDemandante ngOfertas = new NGOfertasDemandante();
            List<DemandantesInscritosEnOfertas> ofertas = ngOfertas.getOfertasDemandante(Convert.ToInt32(idDemandante));
            return ofertas != null ? Json(ofertas) : null;
        }

        public JsonResult InscribirseOferta(DemandanteInscripcion di)
        {
            NGOfertasDemandante ngOfertas = new NGOfertasDemandante();
            return ngOfertas.InscribirseOferta(di)?Json(true):Json(false);
        }

        public JsonResult AnularInscripcion(DemandanteInscripcion di)
        {
            NGOfertasDemandante ngOfertas = new NGOfertasDemandante();
            return ngOfertas.AnularInscripcion(di) ? Json(true) : Json(false);
        }

        public JsonResult ModificarDemandante(DemandanteModel dem)
        {
            NGDemandante ngDem = new NGDemandante();
            return ngDem.ModificarDemandante(dem)?Json(true):Json(false);
        }
    }
}