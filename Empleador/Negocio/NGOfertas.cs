using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Empleador;
using Empleador.AccesoBaseDeDatos;
using Core.Demandante;

namespace Empleador.CapaNegocio
{
    public class NGOfertas
    {
        public List<Oferta> GetOfertas(int idEmpleador)
        {
            return UTofertas.GetOfertas(idEmpleador); 
        }

        public List<Oferta> GetOfertas()
        {
            return UTofertas.GetOfertas();
        }

        public bool CrearOferta(Oferta oferta)
        {
            if(oferta.FechaFin!=null && oferta.Titulo != null && oferta.NumeroVacantes >= 0 && oferta.Sueldo >= 0)
                return UTofertas.CrearOferta(oferta);
            return false;
        }

        public List<VerDemandanteInscritoOferta> GetUsuariosInscritos(int idOferta)
        {
            return UTofertas.GetUsuariosInscritos(idOferta);
        }

        public bool CambiarEstado(VerDemandanteInscritoOferta usuarioP)
        {
            return UTofertas.CambiarEstado(usuarioP);
        }


        #region PROPIEDADES
        private UTOfertas _uTOfertas { get; set; }

        private UTOfertas UTofertas
        {
            get
            {
                if (_uTOfertas == null)
                    return _uTOfertas = new UTOfertas();
                return _uTOfertas;
            }

            set { }
        }
        #endregion


    }
}
