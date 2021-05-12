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
    public partial class frminicio : Form
    {

        #region variableslocales
        Nffv _engine;
        string _userDatabaseFile;
        userDB _userDB;
        EnrollmentResult enrollmentResult;
        VerificationResult verificationResult;
        NffvUser usuario;

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

        #region Constructores
        public frminicio()
        {
          

            _engine = clsNeur.engine;

            string userDatabaseFile = "UserDB.VBNETSample.xml";
            _userDatabaseFile =  "UserDB.VBNETSample.xml";

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

        #endregion

        #region EventosDeFormulario

        private void frmInicio_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = true;
            btnEliminarTodos.BackColor = Color.FromArgb(28, 49, 68);
            btnHacerToma.BackColor = Color.FromArgb(28, 49, 68);
            btnVerificar.BackColor = Color.FromArgb(28, 49, 68);
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
        private void btnHacerToma_Click(object sender, EventArgs e)
        {
            clsNeur.Cerrar = false;
            picHuella.Image = Properties.Resources.huella;

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) == false && string.IsNullOrEmpty(txtApellidos.Text.Trim()) == false && string.IsNullOrEmpty(txtcedula.Text.Trim()) == false)
            {
                frmCapturando frm = new frmCapturando();

                ThreadStart delegado = new ThreadStart(timer1_Tick2);
                Thread _HiloToma = new Thread(delegado);
                _HiloToma.Start();

                frm.ShowDialog();
             
                if (enrollmentResult.engineStatus == NffvStatus.TemplateCreated)
                {
                    NffvUser engineUser = enrollmentResult.engineUser;
                    string strUsuario = txtcedula.Text.Trim();
                    if (strUsuario.Length <= 0)
                    {
                        strUsuario = engineUser.Id.ToString();
                    }

                    clsBasedeDatos clsBasedeDatos = new clsBasedeDatos();

                    if (clsBasedeDatos.RegistroPersona(txtcedula.Text.Trim(), txtNombre.Text.Trim(), txtApellidos.Text.Trim(), Clases.clsProcedimientos.Session["strUsuario"], engineUser.Id.ToString(),txttelefono.Text,txtSexo.Text,txtDireccion.Text) == true)
                    {
                        _userDB.Add(new UserRecord(engineUser.Id, strUsuario));

                        try
                        {
                            _userDB.WriteToFile(_userDatabaseFile);
                        }
                        catch
                        {
                            clsBasedeDatos = null;
                        }

                        picHuella.Image = engineUser.GetBitmap();
                        lbDatabase.Items.Add(new CData(engineUser, strUsuario));
                        MessageBox.Show("Persona Matriculada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtApellidos.Text = "";
                        txtcedula.Text = "";
                        txtDireccion.Text = "";
                        txtNombre.Text = "";
                        txtSexo.Text = "";
                        txttelefono.Text = "";
                        
                    }
                    else
                    {
                        _userDB.Remove(_userDB.Lookup(engineUser.Id));
                        _userDB.WriteToFile(_userDatabaseFile);
                        _engine.Users.RemoveAt(engineUser.Id);
                        picHuella.Image = Properties.Resources.huella;

                        MessageBox.Show("Ha Ocurrido un error, es posible que la persona ya exista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtApellidos.Text = "";
                        txtcedula.Text = "";
                        txtDireccion.Text = "";
                        txtNombre.Text = "";
                        txtSexo.Text = "";
                        txttelefono.Text = "";
                    }

                }
                else
                {
                    picHuella.Image = Properties.Resources.huella;
                    NffvStatus engineStatus = enrollmentResult.engineStatus;
                    MessageBox.Show(String.Format("el enrolamiento no pudo finalizar. motivo: {0}", engineStatus, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    txtApellidos.Text = "";
                    txtcedula.Text = "";
                    txtDireccion.Text = "";
                    txtNombre.Text = "";
                    txtSexo.Text = "";
                    txttelefono.Text = "";
                }

            }
            else
            {
                picHuella.Image = Properties.Resources.huella;

                MessageBox.Show("Debe llenar todos los campos requeridos para la matricula", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void timer2()
        {
            Capturarimagen(usuario);
            clsNeur.Cerrar = true;
        }

        private void timer1_Tick2()
        {
            enrollmentResult = Capturarimagen();
            clsNeur.Cerrar = true;
        }

        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Estas seguro de borrar Todas las personas matriculadas?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _engine.Users.Clear();
                _userDB.Clear();
                lbDatabase.Items.Clear();
                clsBasedeDatos clsBasedeDatos = new clsBasedeDatos();

                clsBasedeDatos.EliminarTodos();

                try
                {
                    _userDB.WriteToFile(_userDatabaseFile);
                }
                catch
                {

                }
                finally
                {
                    clsBasedeDatos = null;
                }
            }


        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.huella;
            clsNeur.Cerrar = false;

            if (string.IsNullOrEmpty(txtcedulaver.Text.Trim()) == false)
            {
                string ret = string.Empty;
                clsBasedeDatos clsBasedeDatos = new clsBasedeDatos();

                ret = clsBasedeDatos.ConsultarPersonaVerificacion(txtcedulaver.Text.Trim());

                if (ret != "")
                {
                    string[] datos = ret.Split('*');

                    txtNombrever.Text = datos[0];
                    txtapellidosver.Text = datos[1];
                    frmCapturando frm = new frmCapturando();
                    usuario = ((CData)lbDatabase.SelectedItem).EngineUser;
                    ThreadStart delegado = new ThreadStart(timer2);
                    Thread _HiloToma = new Thread(delegado);
                    _HiloToma.Start();


                    frm.ShowDialog();

                    if (verificationResult.engineStatus == NffvStatus.TemplateCreated)
                    {
                      

                        pictureBox1.Image = ((CData)lbDatabase.SelectedItem).EngineUser.GetBitmap();

                        if (verificationResult.score > 40)
                        {
                            MessageBox.Show("Verificacion Valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        else
                        {
                            pictureBox1.Image= Properties.Resources.huella;
                            MessageBox.Show("Verificacion No Valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNombrever.Text = "";
                            txtapellidosver.Text = "";
                            

                        }
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.huella;

                        MessageBox.Show("ha ocurrido un error al tomar la verificacion" + verificationResult.engineStatus, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    pictureBox1.Image = Properties.Resources.huella;

                    MessageBox.Show("No existe una persona registrada con el numero de cedula ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                pictureBox1.Image = Properties.Resources.huella;

                MessageBox.Show("Debe digitar un numero de Cedula ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        #endregion

        #region ProcedimientosLocales
        private EnrollmentResult Capturarimagen()
        {
            EnrollmentResult enrollmentResults = new EnrollmentResult();
            enrollmentResults.engineUser = _engine.Enroll(20000, out enrollmentResults.engineStatus);
            return enrollmentResults;
        }
        private bool Capturarimagen(NffvUser nffv)
        {

           
            //((CData)lbDatabase.SelectedItem).EngineUser;

            verificationResult = new VerificationResult();
            verificationResult.score = _engine.Verify(nffv, 20000, out verificationResult.engineStatus);
            return true;
        }
        #endregion

        #region Eventos
        private void lbDatabase_Click(object sender, EventArgs e)
        {
            txtcedulaver.Text = lbDatabase.SelectedItem.ToString();
            txtNombrever.Text = "";
            txtapellidosver.Text = "";
            pictureBox1.Image = Properties.Resources.huella;
        }
        #endregion

        private void lbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
