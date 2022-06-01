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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int lparam);

        private void button1_Click(object sender, EventArgs e)
        {
            Form formRegistro = new FormRegistro();
            formRegistro.Show();
        }
        private void LlenarTabla()
        {
            try
            {
                DataTable tabla = Matriz.Listado();
                dataGridView1.DataSource = tabla;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarTablaEnObservacion()
        {
            try
            {
                DataTable tabla = EstadoCritico.Listado();
                dataGridView2.DataSource = tabla;
                dataGridView2.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarTabla();
            LlenarTablaEnObservacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Form formEdicion = new FormEdicion();
            formEdicion.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form inicioSesion = new InicioSesion();
            this.Hide();
            inicioSesion.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LlenarTabla();
            LlenarTablaEnObservacion();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            LlenarTabla();
            LlenarTablaEnObservacion();
        }

        private void imgSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imgMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
