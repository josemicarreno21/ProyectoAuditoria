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

        private void AgregarEstadoCritico()
        {
            EstadoCritico x = new EstadoCritico(txtNombre.Text);
            x.Nombre = txtNombre.Text;

            try
            {
                EstadoCritico.Agregar(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Datos incorectos vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sugerencia()
        {
            string sugRPO="- ", sugRTO="- ";
            switch (cmbDetRPO.Text)
            {
                case "Alta disponibilidad":
                    sugRPO = "- Un RPO de alta disponibilidad requiere que sea de inmediato.";
                    break;
                case "Replicación asíncrona":
                    sugRPO = "- Un RPO de replicación asíncrona requiere que sea de menos de una hora.";
                    break;
                case "Respaldo":
                    sugRPO = "- Un RPO de respaldo requiere que sea de más de una hora.";
                    break;
            }
            switch (cmbDetRTO.Text)
            {
                case "Sitio Caliente":
                    sugRTO = "- Un RTO de sitio caliente requiere que sea de inmediato a 1 hora.";
                    break;
                case "Sitio Tibio":
                    sugRTO = "- Un RTO de sitio tibio requiere que sea de más de 1 hora a menos de un día.";
                    break;
                case "Sitio Frio":
                    sugRTO = "- Un RTO de sitio frio requiere que sea de más de un día.";
                    break;
            }
            string sug = "Sugerencias" + "\n\r" + sugRPO + "\n\r" + sugRTO;
            MessageBox.Show(sug);
        }

        private void Registrar()
        {
            Matriz x = new Matriz();
            x.Nombre = txtNombre.Text;
            x.RPO = double.Parse(txtRPO.Text);
            x.RTO = double.Parse(txtRTO.Text);
            x.Detalle = cmbDetRPO.Text + "/" + cmbDetRTO.Text;
            x.LBC = double.Parse(txtRPO.Text)+ double.Parse(txtRTO.Text);
            x.Prioridad = CalcularPrioridad((int)Math.Ceiling(double.Parse(txtRPO.Text) + double.Parse(txtRTO.Text)));
            x.TMTI = CalcularTMTI();

            try
            {
                if (Matriz.Agregar(x) > 0)
                {

                    MessageBox.Show("Registro exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Datos incorectos vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CalcularTMTI()
        {
            string min = "", max = "";
            if (double.Parse(txtRPO.Text) < 0.25)
            {
                min = "De inmediato";
            }
            if (double.Parse(txtRPO.Text) < 1.0 && double.Parse(txtRPO.Text) != 0.01)
            {
                min = "De " + (60 * double.Parse(txtRPO.Text)) + " min";
            }
            if (double.Parse(txtRPO.Text) >= 1.0)
            {
                min = "De " + txtRPO.Text + " Horas";
            }

            if (double.Parse(txtRPO.Text) >= 24.0)
            {
                double diasrpo = (int)Math.Ceiling(double.Parse(txtRPO.Text) / 24.0);
                if (diasrpo > 1.0)
                {
                    min = "De " + diasrpo + " Días";
                }
                else
                {
                    min = "De " + diasrpo + " Día";
                }
            }
            double maxrto = (int)Math.Ceiling(double.Parse(txtRPO.Text) + double.Parse(txtRTO.Text));

            if (maxrto >= 24.0)
            {
                double diasrto = (int)Math.Ceiling(maxrto / 24.0);
                if (diasrto > 1)
                {
                    max = " a " + diasrto + " Días.";
                }
                else
                {
                    max = " a " + diasrto + " Día.";
                }
            }
            else
            {
                if (maxrto > 1)
                {
                    max = " a " + maxrto + " Horas.";
                }
                else
                {
                    max = " a " + maxrto + " Hora.";
                }
            }
            return min + max;
        }

        private int CalcularPrioridad(int x)
        {
            if (x<=1)
            {
                return 1;
            }
            else
            {
                if (x > 1 && x < 24)
                {
                    return 2;
                }
                else
                {
                    if (x >= 24)
                    {
                        return 3;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        private void txtRPO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //private void txtRPO_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
        //    {
        //        e.Handled = true;
        //    }
        //    if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtRTO_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
        //    {
        //        e.Handled = true;
        //    }
        //    if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtRPO.Text) || String.IsNullOrEmpty(cmbDetRPO.Text)
                || String.IsNullOrEmpty(txtRTO.Text) || String.IsNullOrEmpty(cmbDetRTO.Text))
            {
                MessageBox.Show("No puede dejar campos vacios para el registro.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Tiempo máximo de tolerancia a la interrupción de este activo es: " + CalcularTMTI() +
                    " ¿es un periodo de tiempo correcto para este activo?", "¿TMTI correcto?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Registrar();
                    this.Hide();
                }
                else if (result == DialogResult.No)
                {
                    Registrar();
                    Sugerencia();
                    AgregarEstadoCritico();
                    this.Hide();
                }

            }
        }
    }
}
