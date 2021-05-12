using JeanCIty.Clases;
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
    public partial class frmCapturando : Form
    {
        public frmCapturando()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;

        }





        private void frmCapturando_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            timer1.Start();
        }





        private void frmCapturando_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(clsNeur.Cerrar == true)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
