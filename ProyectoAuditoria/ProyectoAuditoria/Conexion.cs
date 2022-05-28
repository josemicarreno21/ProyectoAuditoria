using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoAuditoria
{
    class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            //xD
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-37R7SNI;Initial Catalog=ProyectoFinalAuditoria;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}
