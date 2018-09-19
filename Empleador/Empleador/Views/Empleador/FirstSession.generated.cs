﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Empleador;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Empleador/FirstSession.cshtml")]
    public partial class _Views_Empleador_FirstSession_cshtml : System.Web.Mvc.WebViewPage<Core.Empleador.Empleador>
    {
        public _Views_Empleador_FirstSession_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<!-- Scripts-->\r\n<script");

WriteLiteral(" src=\"http://ajax.googleapis.com/ajax/libs/angularjs/1.3.10/angular.min.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"http://angular-ui.github.io/bootstrap/ui-bootstrap-tpls-0.13.0.min.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"https://cdnjs.cloudflare.com/ajax/libs/angular-i18n/1.5.0/angular-locale_es" +
"-es.min.js\"");

WriteLiteral("></script>\r\n\r\n\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 365), Tuple.Create("\"", 411)
, Tuple.Create(Tuple.Create("", 371), Tuple.Create<System.Object, System.Int32>(Href("~/Scripts")
, 371), false)
, Tuple.Create(Tuple.Create(" ", 380), Tuple.Create("propios/empleadorController.js", 381), true)
);

WriteLiteral("></script>\r\n\r\n<div");

WriteLiteral(" ng-app=\"app\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" ng-controller=\"EmpleadorController\"");

WriteLiteral(" data-ng-init=\"cargarIndustrias()\"");

WriteLiteral(" class=\"demo\"");

WriteLiteral(" style=\"width:auto\"");

WriteLiteral(">\r\n        <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-sm-3\"");

WriteLiteral("></div>\r\n                <div");

WriteLiteral(" class=\"col-lg-6\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"titulo\"");

WriteLiteral(@">
                        <br><br>
                        <h4>Esta es la <b>primera vez que accedes</b>, por favor rellena los datos siguientes para registrarte como nuevo empleador.</h4><br><br>
                    </div>
                </div>
                <div");

WriteLiteral(" class=\"col-sm-3\"");

WriteLiteral("></div>\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral("></div>\r\n\r\n                <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Empresa:</b><br />\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" ng-model=\"emp.NombreEmpresa\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"nombreEmpresa\"");

WriteLiteral(" id=\"nombreEmpresa\"");

WriteLiteral(" ng-model=\"nombreEmpresa\"");

WriteLiteral(" required>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Dirección:</b><br />\r\n                        <inpu" +
"t");

WriteLiteral(" type=\"text\"");

WriteLiteral(" ng-model=\"emp.Direccion\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"direccion\"");

WriteLiteral(" id=\"direccion\"");

WriteLiteral(" required />\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Teléfono</b> <i>(opcional):</i><br />\r\n            " +
"            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" ng-model=\"emp.Telefono\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"telefono\"");

WriteLiteral(" id=\"telefono\"");

WriteLiteral(" />\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Email</b> <i><small>(opcional):</small></i><br />\r\n" +
"                        <input");

WriteLiteral(" type=\"email\"");

WriteLiteral(" ng-model=\"emp.Email\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"email\"");

WriteLiteral(" id=\"email\"");

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n\r\n\r\n\r\n                <d" +
"iv");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral(">\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Logo de la empresa</b> <i>(opcional):</i><br />\r\n  " +
"                      <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" fileread=\"emp.ImagenB64\"");

WriteLiteral("  class=\"form-control\"");

WriteLiteral(" name=\"logoEmpresa\"");

WriteLiteral(" id=\"logoEmpresa\"");

WriteLiteral(" />\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Número de empleados:</b><br />\r\n                   " +
"     <input");

WriteLiteral(" type=\"number\"");

WriteLiteral(" ng-model=\"emp.NumeroEmpleados\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" name=\"numeroEmpleados\"");

WriteLiteral(" id=\"numeroEmpleados\"");

WriteLiteral(" required />\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <b>Tipo de industria:</b><br />\r\n                     " +
"   <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" ng-model=\"emp.TipoIndustria\"");

WriteLiteral(" ng-options=\"industria.TipoIndustria as industria.Nombre for industria in industr" +
"ias\"");

WriteLiteral(" required></select>\r\n                    </div>\r\n\r\n\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <br /><br /><br />\r\n                        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-block btn-success\"");

WriteLiteral(" value=\" Registrar empleador\"");

WriteLiteral(" id=\"btn-submit\"");

WriteLiteral(" ng-click=\"guardarDatosEmpleador()\"");

WriteLiteral(">\r\n                        <br /><br /><br />\r\n                    </div>\r\n\r\n    " +
"            </div>\r\n\r\n                <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral("></div>\r\n\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
