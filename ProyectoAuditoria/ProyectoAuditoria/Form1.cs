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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string detRPO = "", detRTO = "";
            if (Double.Parse(txtRPO1.Text) < 0.25 && Double.Parse(txtRPO1.Text) >= 0.01)
            {
                detRPO = "Alta disponibilidad";
            }
            if (Double.Parse(txtRPO1.Text) < 24 && Double.Parse(txtRPO1.Text) >= 0.25)
            {
                detRPO = "Replicación asíncrona";
            }
            if (Double.Parse(txtRPO1.Text) >= 24)
            {
                detRPO = "Respaldo";
            }
            if (Double.Parse(txtRTO1.Text) < 1 && Double.Parse(txtRTO1.Text) >= 0.01)
            {
                detRTO = "Hot Site";
            }
            if (Double.Parse(txtRTO1.Text) < 24 && Double.Parse(txtRTO1.Text) >= 2)
            {
                detRTO = "Sitio tibio";
            }
            if (Double.Parse(txtRTO1.Text) >= 24)
            {
                detRTO = "Sitio frio";
            }
            lblDetalle1.Text = detRPO + "/" + detRTO;


            double LBC = Double.Parse(txtRPO1.Text) + Double.Parse(txtRTO1.Text);
            lblLBC1.Text = LBC.ToString();


            double prioridad = 0;
            if (LBC < 1)
            {
                prioridad = 1;
            }
            if (LBC < 24 && LBC > 1)
            {
                prioridad = 2;
            }
            if (LBC >= 24)
            {
                prioridad = 3;
            }

            lblPrioridad1.Text = prioridad.ToString();
        }
    }
}
