using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GestorBD;

namespace BaseDeDatos
{
   public class UTBase
    {
       /// <summary>
       /// Constructor de la clase
       /// </summary>
        public UTBase()
        {
            //Se crea la conexión con la cadena anterior.
            SqlConnection connection = new SqlConnection(StringConnection);
            Repo = new Repositorio(connection);
        }

        #region propiedades
        string StringConnection = "Data Source=PRODUCCION;Initial Catalog=Prueba;Persist Security Info=True;User ID=sa;Password=Nivelsql*55";
        protected Repositorio Repo;
        #endregion
    }
}
