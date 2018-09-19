using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Utilidades
{
    public class Cookies
    {
        private static string cookieName = "AppBase";
        public const String Usuario = "Usuario";


        /// <summary>
        /// Agrega una Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AddCookie(string name, string value)
        {
            if (System.Web.HttpContext.Current.Response.Cookies[cookieName] == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(1);

                if (value == null)
                    cookie.Values[name] = null;
                else
                    cookie.Values[name] = value;
            }
            else
            {
                if (value == null)
                    System.Web.HttpContext.Current.Response.Cookies[cookieName][name] = null;
                else
                    System.Web.HttpContext.Current.Response.Cookies[cookieName][name] = value;
            }
        }


        /// <summary>
        /// Recupera una Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            return System.Web.HttpContext.Current.Request.Cookies[cookieName][name];
        }

    }
}