using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoAuditoria
{
    class Matriz
    {
        public string Nombre { get; set; }
        public double RPO { get; set; }
        public double RTO { get; set; }
        public string Detalle { get; set; }
        public double LBC { get; set; }
        public int Prioridad { get; set; }
        public string TMTI { get; set; }
        public Matriz() { }

        public Matriz(string vnom, double vrpo, double vrto, string vdet, double vlbc, int vpri, string vtmti)
        {
            this.Nombre = vnom;
            this.RPO = vrpo;
            this.RTO = vrto;
            this.Detalle = vdet;
            this.LBC = vlbc;
            this.Prioridad = vpri;
            this.TMTI = vtmti;
        }
        public static DataTable Listado()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string queryString = "Select Nombre, RPO, RTO, Detalle, LBC, Prioridad, TMTI from Matriz;";
                SqlCommand command = new SqlCommand(queryString, con);
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "Matriz");
                con.Close();
                DataTable tabla = datos.Tables["Matriz"];
                return tabla;
            }
        }

        public static DataTable Buscar(String vnom)
        {
            Matriz vc = new Matriz();
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                String queryString = "Select * from Matriz where Nombre=@nom";
                SqlCommand command = new SqlCommand(queryString, con);
                command.Parameters.AddWithValue("@nom", vnom);
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(datos, "Matriz");
                con.Close();
                DataTable tabla = datos.Tables["Matriz"];
                return tabla;
            }
        }

        public static int Agregar(Matriz P)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format(@"insert into Matriz(Nombre, RPO, RTO, Detalle, LBC, Prioridad, TMTI)values 
                    ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", P.Nombre, P.RPO, P.RTO, P.Detalle, P.LBC, P.Prioridad, P.TMTI), con);
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        public static int Modificar(Matriz P)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string update = "Update Matriz set RPO=@RPO, RTO=@RTO, Detalle=@Det, LBC=@LBC, Prioridad=@Pri, TMTI=@TMTI where Nombre=@Nom;";
                SqlCommand command = new SqlCommand(update, con);
                command.Parameters.AddWithValue("@Nom", P.Nombre);
                command.Parameters.AddWithValue("@RPO", P.RPO);
                command.Parameters.AddWithValue("@RTO", P.RTO);
                command.Parameters.AddWithValue("@Det", P.Detalle);
                command.Parameters.AddWithValue("@LBC", P.LBC);
                command.Parameters.AddWithValue("@Pri", P.Prioridad);
                command.Parameters.AddWithValue("@TMTI", P.TMTI);
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }

        public static int Eliminar(String P)
        {
            int retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "Delete from Matriz where Nombre=@nom;";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@nom", P);
                retorno = command.ExecuteNonQuery();
                con.Close();
            }
            return retorno;
        }
    }
}
