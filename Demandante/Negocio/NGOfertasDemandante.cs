using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usuario;
using Core.Login;
using Core.Empleador;
using Core.Demandante;
using BaseDeDatos;
using Demandante.AccesoBaseDeDatos;

namespace Demandante.CapaNegocio
{
    public class NGOfertasDemandante
    {
        public List<DemandantesInscritosEnOfertas> getOfertasDemandante(int idDemandante)
        {
            return utOfertasDemandante.getOfertasDemandante(idDemandante);
        }

        public bool InscribirseOferta(DemandanteInscripcion di)
        {
            return utOfertasDemandante.InscribirOferta(di);
        }

        public List<Oferta> GetOfertasSinSuscribir(int idDemandante)
        {
            return utOfertasDemandante.getOfertasSinSuscribir(idDemandante);
        }


        public bool AnularInscripcion(DemandanteInscripcion di)
        {
            return utOfertasDemandante.AnularInscripcion(di);
        }


        #region PROPIEDADES
        private UTOfertasDemandante _uTOfertasDemandante { get; set; }

        private UTOfertasDemandante utOfertasDemandante
        {
            get
            {
                if (_uTOfertasDemandante == null)
                    return _uTOfertasDemandante = new UTOfertasDemandante();
                return _uTOfertasDemandante;
            }
            set { }
        }

        #endregion

    }
}
