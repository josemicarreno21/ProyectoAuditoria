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

            if (Usuario.Autentificar(txtUsuario.Text, txtContrasenia.Text) > 0)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Datos incorrectos o incompletos");
                cont = cont + 1;
            }
        }
    }
}
