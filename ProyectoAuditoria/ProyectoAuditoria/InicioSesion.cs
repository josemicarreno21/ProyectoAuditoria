using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAuditoria
{
    public partial class InicioSesion : Form
    {
        int cont = 0;

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (cont == 5)
            {
                MessageBox.Show("Demasiados intentos sin exito, vuelva en un rato :)");
                Application.Exit();
            }
            if (txtContrasenia.TextLength >= 8)
            {
                if (Usuario.AutentificarAdmin(txtUsuario.Text, txtContrasenia.Text) > 0)
                {
                    MessageBox.Show("Bienvenido Administrador.");
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                {
                    if (Usuario.AutentificarEmpleado(txtUsuario.Text, txtContrasenia.Text) > 0)
                    {
                        MessageBox.Show("Bienvenido Empleado.");
                        this.Hide();
                        FormEmpleado formEmpleado = new FormEmpleado();
                        formEmpleado.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos o incompletos");
                        cont = cont + 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Formato de contraseña incorrecto.");
            }
        }
    }
}
