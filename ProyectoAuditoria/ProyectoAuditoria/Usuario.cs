using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoAuditoria
{
    class Usuario
    {
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string tipo { get; set; }
        public Usuario() { }

        public Usuario(string vus, string vco, string vti)
        {
            this.usuario = vus;
            this.contraseña = vco;
            this.tipo = vti;
        }

        public static int AutentificarAdmin(string vusuario, string vcontraseña)
        {
            int Retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select Tipo from Usuario where Usuario = '{0}' and Contraseña = '{1}' and Tipo = 'Administrador'"
                    , vusuario, vcontraseña), con);
                SqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Retorno = 1;
                }
                con.Close();
            }
            return Retorno;
        }
        public static int AutentificarEmpleado(string vusuario, string vcontraseña)
        {
            int Retorno = 0;
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select Tipo from Usuario where Usuario = '{0}' and Contraseña = '{1}' and Tipo <> 'Administrador'"
                    , vusuario, vcontraseña), con);
                SqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    Retorno = 1;
                }
                con.Close();
            }
            return Retorno;
        }
    }
}
