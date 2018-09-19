using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GestorBD;
using Core.Empleador;
using Core.Mapping;
using Core.Esquemas;
using BaseDeDatos;
using Core.Demandante;

namespace Empleador.AccesoBaseDeDatos
{
    public class UTOfertas : UTBase
    {

        public List<Oferta> GetOfertas(int idEmpleador)
        {

            dtsOferta dts = new dtsOferta();

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdEmpleadorColumn, idEmpleador);

            dts.OfertasEmpleo.Merge(Repo.Leer(dts.OfertasEmpleo, parametros));

            return dts.OfertasEmpleo.toOferta();
        }

        public List<Oferta> GetOfertas()
        {

            dtsOferta dts = new dtsOferta();

            dts.OfertasEmpleo.Merge(Repo.Leer(dts.OfertasEmpleo));

            return dts.OfertasEmpleo.toOferta();
        }

        public bool CrearOferta(Oferta oferta)
        {

            dtsOferta dts = MappingOferta.toDstOferta(oferta);
            Repo.Guardar(dts);

            Dictionary<DataColumn, Object> parametros = new Dictionary<DataColumn, object>();
            parametros.Add(dts.OfertasEmpleo.IdColumn, oferta.Id);

            return Repo.Count(dts.OfertasEmpleo, parametros) == 0;
        }

        public List<VerDemandanteInscritoOferta> GetUsuariosInscritos(int idOferta)
        {
            dtsDemandantesInscritosOferta dts = new dtsDemandantesInscritosOferta();

            SqlParameter param = new SqlParameter("@IdOferta", idOferta);
            dts.Merge(Repo.Leer("pDemandantesInscritosOferta", CommandType.StoredProcedure, dts.pDemandantesInscritosOferta.TableName, param));

            List<VerDemandanteInscritoOferta> list = dts.pDemandantesInscritosOferta.toVerDemandanteInscritoOferta();

            return list;
        }


        public bool CambiarEstado(VerDemandanteInscritoOferta usuarioP)
        {
            try {
                Repo.EjecutarProcedimiento("pCambiarEstado", new SqlParameter("@Estado", usuarioP.Estado), new SqlParameter("@IdDemandante", usuarioP.IdDemandante), new SqlParameter("@IdOferta", usuarioP.IdOferta));
                return true;
            }catch (Exception e) {
                throw e;
            }
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
