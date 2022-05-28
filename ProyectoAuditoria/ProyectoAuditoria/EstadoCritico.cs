using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoAuditoria
{
    class EstadoCritico
    {
        public string Nombre { get; set; }
        public EstadoCritico(string vnom)
        {
            this.Nombre = vnom;
        }

        public static DataTable Listado()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string queryString = "Select Nombre from EstadoCritico;";
                SqlCommand command = new SqlCommand(queryString, con);
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "EstadoCritico");
                con.Close();
                DataTable tabla = datos.Tables["EstadoCritico"];
                return tabla;
            }
        }

        public static int Agregar(EstadoCritico P)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format(@"insert into EstadoCritico(Nombre)values 
                    ('{0}')", P.Nombre), con);
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }
    }
}
