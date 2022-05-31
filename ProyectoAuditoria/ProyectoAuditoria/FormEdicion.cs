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
    public partial class FormEdicion : Form
    {
        public FormEdicion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtRPO.Text) || String.IsNullOrEmpty(cmbDetRPO.Text)
                || String.IsNullOrEmpty(txtRTO.Text) || String.IsNullOrEmpty(cmbDetRTO.Text))
            {
                MessageBox.Show("No puede dejar campos vacios para la edición.");
            }
            else
            {
                
                this.Hide();
                DialogResult result = MessageBox.Show("Tiempo máximo de tolerancia a la interrupción de este activo es: " + CalcularTMTI() +
                    ", ¿es un periodo de tiempo correcto para este activo?", "¿TMTI correcto?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {  
                    Editar();
                    this.Hide();
                }
                else if (result == DialogResult.No)
                {
                    Editar();
                    AgregarEstadoCritico();
                    this.Hide();
                }
            }
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

        private void Editar()
        {
            Matriz x = new Matriz();
            x.Nombre = txtNombre.Text;
            x.RPO = Double.Parse(txtRPO.Text);
            x.RTO = Double.Parse(txtRTO.Text);
            x.Detalle = cmbDetRPO.Text + "/" + cmbDetRTO.Text;
            x.LBC = double.Parse(txtRPO.Text) + double.Parse(txtRTO.Text);
            x.Prioridad = (int)Math.Ceiling(double.Parse(txtRPO.Text) + double.Parse(txtRTO.Text));
            x.TMTI = CalcularTMTI();

            try
            {
                if (Matriz.Modificar(x) > 0)
                {

                    MessageBox.Show("Edición exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (double.Parse(txtRPO.Text) == 0.01)
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
            max = " a " + ((int)Math.Ceiling(double.Parse(txtRPO.Text) + double.Parse(txtRTO.Text))) + " horas.";
            return min + max;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del aplicativo o servicio TI para poder editarlo.");
            }
            else
            {
                try
                {
                    DataTable tabla = Matriz.Buscar(txtNombre.Text);
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow fila = tabla.Rows[0];
                        txtNombre.Text = fila[0].ToString();
                        txtRPO.Text = fila[1].ToString();
                        txtRTO.Text = fila[2].ToString();

                        string split = fila[3].ToString();
                        List<string> list = new List<string>();
                        list = split.Split('/').ToList();

                        cmbDetRPO.Text = list[0];
                        cmbDetRTO.Text = list[1];
                    }
                    else
                    {
                        MessageBox.Show("Activo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormEdicion_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
