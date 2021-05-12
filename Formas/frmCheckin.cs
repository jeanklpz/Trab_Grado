using JeanCIty.Clases;
using Neurotec.Biometrics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeanCIty.Formas
{
    public partial class frmCheckin : Form
    {

        #region variableslocales
        Nffv _engine;
        string _userDatabaseFile;
        userDB _userDB;
        ListBox lbDatabase;
        bool ret = false;
        string Huella = "0";
        frmCapturando frm;
        string codigoReserva = string.Empty;

        #endregion
        #region clasesInternas
        internal class EnrollmentResult
        {
            public NffvStatus engineStatus;
            public NffvUser engineUser;
        }
        internal class VerificationResult
        {
            public NffvStatus engineStatus;
            public int score;
        }

        public class CData
        {
            private NffvUser _engineUser;
            private Bitmap _image;
            private string _name;

            public CData(NffvUser engineUser, string name)
            {
                _engineUser = engineUser;
                _image = engineUser.GetBitmap();
                _name = name;
            }

            public NffvUser EngineUser
            {
                get
                {
                    return _engineUser;
                }
            }

            public Bitmap Image
            {
                get
                {
                    return _image;
                }
            }

            public int ID
            {
                get
                {
                    return _engineUser.Id;
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            public override string ToString()
            {
                return Name;
            }
        }

        #endregion


        public frmCheckin()
        {
            //Nffv engine = null;
            //engine = new Nffv("FingerprintDB.VBNETSample.dat", "", "Futronic;FutronicEthernetFam");

            _engine = clsNeur.engine;

            string userDatabaseFile = "UserDB.VBNETSample.xml";
            _userDatabaseFile = "UserDB.VBNETSample.xml";

            try
            {
                _userDB = userDB.ReadFromFile(userDatabaseFile);
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
                _userDB = new userDB();
            }
            InitializeComponent();
        }

        private void frmCheckin_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            btnBuscar.BackColor = Color.FromArgb(28, 49, 68);
            button1.BackColor = Color.FromArgb(28, 49, 68);
            toolTip1.SetToolTip(btnBuscar, "Presione Clic aqui para Iniciar la captura de huella");
            toolTip1.SetToolTip(button1, "Presione Clic aqui para Confirmar el Check-In");
            lbDatabase = new ListBox();

            foreach (NffvUser engineUser in _engine.Users)
            {
                string _id = engineUser.Id.ToString();
                UserRecord _userRec = _userDB.Lookup(engineUser.Id);

                if (_userRec != null)
                {
                    _id = _userRec.Name;
                }
                lbDatabase.Items.Add(new CData(engineUser, _id));
            }

            if (lbDatabase.Items.Count > 0)
            {
                lbDatabase.SelectedIndex = 0;
            }




        }

        private bool Capturarimagen()
        {
            bool ret = false;

            for (int i = 0; i <= lbDatabase.Items.Count - 1; i++)
            {
                lbDatabase.SelectedIndex = i;

                NffvUser nffv = ((CData)lbDatabase.SelectedItem).EngineUser;


                VerificationResult verificationResult = new VerificationResult();
                verificationResult.score = _engine.Verify(nffv, 20000, out verificationResult.engineStatus);

                if (verificationResult.score > 60)
                {
                    ret = true;

                    goto retornar;
                }
                else
                {
                    Huella = "2";
                }

            }
        retornar:
            return ret;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            picHuella.Image = Properties.Resources.huella;
            gridreserva.DataSource = null;
            codigoReserva = string.Empty;
            txtNombre.Text = "";
            txtcedula.Text = "";
            txtapellido.Text = "";
            txtdireccion.Text = "";
            txtsexo.Text = "";
            txttelefono.Text = "";

            try
            {

                string strDatos = string.Empty;
                clsBasedeDatos clsBasedeDatos = null;
                clsNeur.Cerrar = false;
                frm = new frmCapturando();

                ThreadStart delegado = new ThreadStart(timer1_Tick);
                Thread _HiloToma = new Thread(delegado);
                _HiloToma.Start();




                frm.ShowDialog();

                if (ret == true)
                {
                    clsBasedeDatos = new clsBasedeDatos();

                    strDatos = clsBasedeDatos.ConsultarPersonaVerificacion(lbDatabase.SelectedItem.ToString());
                    if (strDatos != "")
                    {
                        string[] datos = strDatos.Split('*');
                        txtcedula.Text = lbDatabase.SelectedItem.ToString();
                        txtNombre.Text = datos[0];
                        txtapellido.Text = datos[1];
                        txttelefono.Text = datos[3];
                        txtsexo.Text = datos[4];
                        txtdireccion.Text = datos[5];
                        picHuella.Image = ((CData)lbDatabase.SelectedItem).EngineUser.GetBitmap();

                        DataTable ds = clsBasedeDatos.ConsultarReserva(txtcedula.Text);
                        if (ds != null)
                        {
                            codigoReserva = ds.Rows[0]["Reserva"].ToString();
                            gridreserva.DataSource = ds;
                            MessageBox.Show("Validacion realizada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        else
                        {
                            gridreserva.DataSource = null;
                            MessageBox.Show("la Persona no tiene reservas Activas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        gridreserva.DataSource = null;

                        MessageBox.Show("la huella colocada no se encuentra registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    if (Huella == "0")
                    {
                        gridreserva.DataSource = null;

                        MessageBox.Show("Se ha vencido el tiempo de espera de la huella o el scanner esta desconectado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        gridreserva.DataSource = null;

                        MessageBox.Show("la huella colocada no se encuentra registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    picHuella.Image = Properties.Resources.huella;
                    txtNombre.Text = "";
                    txtcedula.Text = "";
                    txtapellido.Text = "";
                    txtdireccion.Text = "";
                    txtsexo.Text = "";
                    txttelefono.Text = "";
                    gridreserva.DataSource = null;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void timer1_Tick()
        {
            ret = Capturarimagen();

            if (ret == true)
            {
                // frm.Close();
                Huella = "1";
                clsNeur.Cerrar = ret;

            }
            else
            {
                //  frm.Close();

                if (Huella != "2")
                {
                    Huella = "0";

                }

                clsNeur.Cerrar = true;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsBasedeDatos clsbase;
            try
            {
                clsbase = new clsBasedeDatos();
               bool ret= clsbase.ConfirmarReserva(codigoReserva);

                if(ret == true)
                {
                    MessageBox.Show("Confirmacion Exitosa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    picHuella.Image = Properties.Resources.huella;
                    txtNombre.Text = "";
                    txtcedula.Text = "";
                    txtapellido.Text = "";
                    txtdireccion.Text = "";
                    txtsexo.Text = "";
                    txttelefono.Text = "";
                    gridreserva.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con la confirmacion porfavor intente de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picHuella.Image = Properties.Resources.huella;
                    txtNombre.Text = "";
                    txtcedula.Text = "";
                    txtapellido.Text = "";
                    txtdireccion.Text = "";
                    txtsexo.Text = "";
                    txttelefono.Text = "";
                    gridreserva.DataSource = null;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                picHuella.Image = Properties.Resources.huella;
                txtNombre.Text = "";
                txtcedula.Text = "";
                txtapellido.Text = "";
                txtdireccion.Text = "";
                txtsexo.Text = "";
                txttelefono.Text = "";
                gridreserva.DataSource = null;
            }

        }
    }
}


