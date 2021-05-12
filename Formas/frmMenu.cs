using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeanCIty.Formas
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCheckin frm = new frmCheckin();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frminicio frm = new frminicio();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "Bienvenido: " + Clases.clsProcedimientos.Session["strUsuario"];

            timer1.Start();
            toolTip1.SetToolTip(button4, "Haga clic aqui para registrar un vuelo");
            toolTip1.SetToolTip(button2, "Haga clic Para confirmar un vuelo");
            toolTip1.SetToolTip(button3, "Haga clic para guardar la informacion de una persona");


            button4.BackColor = Color.FromArgb(28, 49, 68);
            button2.BackColor = Color.FromArgb(28, 49, 68);
            button3.BackColor = Color.FromArgb(28, 49, 68);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmGuardarReserva frm = new frmGuardarReserva();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            label2.Text= "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            label3.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
