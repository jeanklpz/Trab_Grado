using JeanCIty.Clases;
using Neurotec.Biometrics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeanCIty.Formas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnInicirSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) == true || string.IsNullOrEmpty(txtContraseña.Text.Trim()) == true)
            {
                MessageBox.Show("Debe llenar todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Clases.clsBasedeDatos objBaseDeDatos;
                Dictionary<string, string> Dic;
                frmMenu frmini;

                try
                {
                    objBaseDeDatos = new Clases.clsBasedeDatos();


                    Dic = objBaseDeDatos.IniciarSesion(txtUsuario.Text.Trim());

                    if (Dic == null)
                    {
                        MessageBox.Show("El usuario no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Dic["strContraseña"] == Clases.clsProcedimientos.hashPass(txtContraseña.Text))
                        {
                            Clases.clsProcedimientos.Session = Dic;

                            limpiar();
                            if (clsNeur.engine == null)
                            {
                                clsNeur.iniciar();

                            }
                            frmini = new frmMenu();
                            this.Hide();
                            frmini.ShowDialog();
                            this.Show();



                        }
                        else
                        {
                            MessageBox.Show("La contraseña ingresada es incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Dic = null;
                    frmini = null;
                }

            }


        }
        private void limpiar()
        {
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            frmRegistro frmReg;
            try
            {
                limpiar();
                this.Hide();
                frmReg = new frmRegistro();
                frmReg.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frmReg = null;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\ftrScanAPI.dll") == false)
            {
                byte[] bytArchivo;
                bytArchivo = JeanCIty.Properties.Resources.ftrScanAPI;
                File.WriteAllBytes(Application.StartupPath + @"\ftrScanAPI.dll", bytArchivo);
            }
            txtUsuario.Focus();
            toolTip1.SetToolTip(BtnRegistro, "Presione Clic aqui para registrarse");
            toolTip1.SetToolTip(BtnInicirSesion, "Presione Clic aqui para iniciar session");
            toolTip1.SetToolTip(txtUsuario, "Ingrese su Usuario");
            toolTip1.SetToolTip(txtContraseña, "Ingrese su Contraseña");
            BtnInicirSesion.BackColor = Color.FromArgb(28, 49, 68);
            BtnRegistro.BackColor = Color.FromArgb(28, 49, 68);


        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
