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
    public partial class frmGuardarReserva : Form
    {
        public frmGuardarReserva()
        {
            InitializeComponent();
        }

        private void frmGuardarReserva_Load(object sender, EventArgs e)
        {
           btnGuardar.BackColor = Color.FromArgb(28, 49, 68);
        }

    

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text.Trim() == "" || txtHora.Text.Trim() == "" || txtDestino.Text.Trim() == "" || txtorigen.Text.Trim() == "" )
                {
                    MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    clsBasedeDatos clsBasedeDatos = new clsBasedeDatos();
           
                    string codigoreserva = Guid.NewGuid().ToString();
                    if (clsBasedeDatos.registrarCheckin(codigoreserva, txtDestino.Text, dateTimePicker1.Value.ToString(), txtHora.Text, txtorigen.Text,txtCedula.Text) == true)
                    {
                        MessageBox.Show("se guardo la reserva correctamente con el #" + codigoreserva, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        MessageBox.Show("no se pudo realizar el registro de la reserva", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }
    }
}
