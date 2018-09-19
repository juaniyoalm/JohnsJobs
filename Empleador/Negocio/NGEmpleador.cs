using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usuario;
using Core.Login;
using Core.Empleador;
using Empleador.AccesoBaseDeDatos;
using BaseDeDatos;

namespace Empleador.CapaNegocio
{
    public class NGEmpleador
    {
        /// <summary>
        /// Método que devuelve un modelo de empleador através de su ID (Llamada a la capa de Acceso a Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EmpleadorModel o null</returns>
        public EmpleadorModel GetEmpleadorModelByUserId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                Core.Empleador.EmpleadorModel emp = UTempleador.GetEmpleadorModelByUserId(id);
                emp.ImagenB64 = Convert.ToBase64String(emp.LogoEmpresa);
                return emp;
            }
            return null;
        }

        /// <summary>
        /// Método que devuelve un  empleador através de su ID (Llamada a la capa de Acceso a Datos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empleador o null</returns>
        public Core.Empleador.Empleador GetEmpleadorByUserId(int id)
        {
            return UTempleador.GetEmpleadorByUserId(id);
        }

        /// <summary>
        /// Método que guarda un modelo de empleador (Llamada a la capa de Acceso a Datos). Además, comprueba que la foto de perfil haya sido introducida
        /// y parsea la cadena. En caso de que no haya sido introducida, le asigna una por defecto
        /// </summary>
        /// <param name="emp"></param>
        /// <returns>True o False</returns>
        public bool GuardarEmpleador(Core.Empleador.EmpleadorModel emp)
        {
            if (emp.ImagenB64 == null) {
                emp.ImagenB64 = "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";
            }
            else
            {
                emp.ImagenB64 = emp.ImagenB64.Replace("data:image/jpeg;base64,", "");
            }
            emp.LogoEmpresa = Convert.FromBase64String(emp.ImagenB64);
            return UTempleador.GuardarEmpleador(emp);
        }

        /// <summary>
        /// Método que carga las industrias disponibles (Llamada a la capa de Acceso a Datos)
        /// </summary>
        /// <returns>Lista de tipos de industrias o null</returns>
        public List<Industria> CargarIndustrias()
        {
            List<Industria> list = UTempleador.CargarIndustrias();
            return list.Count > 0?list:null;
        }


        #region PROPIEDADES
        private UTEmpleador _uTEmpleador { get; set; }

        private UTEmpleador UTempleador
        {
            get
            {
                if (_uTEmpleador == null)
                    return _uTEmpleador = new UTEmpleador();
                return _uTEmpleador;
            }

            set { }
        }
        #endregion
    }
}
