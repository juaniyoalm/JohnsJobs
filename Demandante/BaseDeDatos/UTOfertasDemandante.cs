using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GestorBD;
using Core.Esquemas;
using Core.Mapping;
using Core.Demandante;
using Core.Empleador;
using BaseDeDatos;

namespace Demandante.AccesoBaseDeDatos
{
    public class UTOfertasDemandante : UTBase
    {
        public List<DemandantesInscritosEnOfertas> getOfertasDemandante(int idDemandante)
        {
            dtsLecturaOfertasDemandante dts = new dtsLecturaOfertasDemandante();
            SqlParameter param = new SqlParameter("@IdDemandante", idDemandante);

            // Realizamos un merge con la tabla vacia del dtsUsuario con los resultados de la tabla obtenida
            // dtsDemandante.DemandantesDataTable dtDem = (dtsDemandante.DemandantesDataTable)Repo.Leer(dts.Demandantes, parametros);
            dts.Merge(Repo.Leer("pInscritosLectura", CommandType.StoredProcedure,dts.pInscritosLectura.TableName , param));

            List<Core.Demandante.DemandantesInscritosEnOfertas> dem = dts.pInscritosLectura.toDemandantesInscritosEnOfertas();

            return dem.Count > 0 ? dem : null;
        }

        public bool InscribirOferta(DemandanteInscripcion di)
        {
            dtsDemandantesInscritosEnOfertas dts = new dtsDemandantesInscritosEnOfertas();
            dts = MappingDemandanteInscripcion.toDtsInscripcionDemandantes(di);
            Repo.Guardar(dts);
            return true;
        }

        public List<Core.Empleador.Oferta> getOfertasSinSuscribir(int idDemandante)
        {
            dtsOferta dts = new dtsOferta();
            SqlParameter param = new SqlParameter("@IdDemandante", idDemandante);

            dts.Merge(Repo.Leer("pObtenerOfertasNoInscrito", CommandType.StoredProcedure, dts.OfertasEmpleo.TableName, param));

            List<Oferta> list = dts.OfertasEmpleo.toOferta();

            return list.Count > 0 ? list : null;
        }

        public bool AnularInscripcion(DemandanteInscripcion di)
        {

            try {
                Repo.EjecutarProcedimiento("pDesinscribirse", new SqlParameter("@IdDemandante", di.IdDemandante), new SqlParameter("@IdOferta", di.IdOferta));
                return true;
            }catch (Exception e) {
                throw e;
            }
        }
    }
}
