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

        private void txtRPO1_TextChanged(object sender, EventArgs e)
        {
            string detRPO, detRTO;
            if(Int32.Parse(txtRPO1.Text)<0.25 && Int32.Parse(txtRPO1.Text) >= 0.01)
            {
                detRPO = "Alta disponibilidad";
            }
            if (Int32.Parse(txtRPO1.Text) < 24 && Int32.Parse(txtRPO1.Text) >= 0.25)
            {
                detRPO = "Replicación asíncrona";
            }
            if (Int32.Parse(txtRPO1.Text) >= 24)
            {
                detRPO = "Respaldo";
            }
        }
    }
}
