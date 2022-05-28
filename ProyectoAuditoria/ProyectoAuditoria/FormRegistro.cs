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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtRPO.Text) || String.IsNullOrEmpty(cmbDetRPO.Text) 
                || String.IsNullOrEmpty(txtRTO.Text) || String.IsNullOrEmpty(cmbDetRTO.Text))
            {
                MessageBox.Show("No puede dejar campos vacios para el registro.");
            }
            else
            {
                MessageBox.Show("Registro exitoso.");
                Registrar();
                this.Hide();
            }
        }

        private void Registrar()
        {

        }

        private void txtRPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
