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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Clases.clsBasedeDatos objBaseDeDatos;

            try
            {

                if (string.IsNullOrEmpty(txtusuario.Text.Trim()) == true || string.IsNullOrEmpty(txtContraseña.Text.Trim()) == true || string.IsNullOrEmpty(txtCcotraseña.Text.Trim()) == true || string.IsNullOrEmpty(txtnombre.Text.Trim()) == true || string.IsNullOrEmpty(txtapellido.Text.Trim()) == true || string.IsNullOrEmpty(txtemail.Text.Trim()) == true)
                {
                    MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtCcotraseña.Text.Trim() == txtContraseña.Text.Trim())
                    {
                        objBaseDeDatos = new Clases.clsBasedeDatos();

                        if (objBaseDeDatos.Registro(txtusuario.Text.Trim(), Clases.clsProcedimientos.hashPass(txtContraseña.Text.Trim()), txtemail.Text.Trim(), txtnombre.Text.Trim(), txtapellido.Text.Trim()) == true)
                        {
                            MessageBox.Show("Registro realizado Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El usuario ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objBaseDeDatos = null;
            }


        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(28, 49, 68);
            btnRegistrar.BackColor = Color.FromArgb(28, 49, 68);
            toolTip1.SetToolTip(btnRegistrar, "Presion Clic aqui para Registrar");
            toolTip1.SetToolTip(btnCancelar, "Presion Clic aqui para Cancelar");

        }
    }
}
