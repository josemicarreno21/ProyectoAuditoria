using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoAuditoria
{
    public partial class InicioSesion : Form
    {
        int cont = 0;

        public InicioSesion()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imgSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imgMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void InicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
