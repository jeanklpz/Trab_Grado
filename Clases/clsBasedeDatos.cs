using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanCIty.Clases
{
    public class clsBasedeDatos
    {

        public Dictionary<string, string> IniciarSesion(string User)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            Dictionary<string, string> DicRet;
            try
            {
                strConsultaSQL = "Select strUsuario,strContraseña,strCorreo,strNombre,strApellido,intEstado from tblUsuarios where strUsuario=@strUsuario ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strUsuario", User);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (ds.Rows.Count > 0)
                {
                    DicRet = new Dictionary<string, string>();
                    DicRet.Add("strUsuario", ds.Rows[0]["strUsuario"].ToString());
                    DicRet.Add("strContraseña", ds.Rows[0]["strContraseña"].ToString());
                    DicRet.Add("strCorreo", ds.Rows[0]["strCorreo"].ToString());
                    DicRet.Add("strNombre", ds.Rows[0]["strNombre"].ToString());
                    DicRet.Add("strApellido", ds.Rows[0]["strApellido"].ToString());
                    DicRet.Add("intEstado", ds.Rows[0]["intEstado"].ToString());

                    return DicRet;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }

        public bool Registro(string strUser, string strhash, string strcorreo, string strNombre, string strApellido)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
                if (ExisteUsuario(strUser) == true)
                {
                    return false;
                }

                strConsultaSQL = "Insert Into tblUsuarios (strUsuario,strContraseña,strCorreo,strNombre,strApellido,intEstado,FechaRegistro) Values (@strUsuario,@strContraseña,@strCorreo,@strNombre,@strApellido,@intEstado,@FechaRegistro) ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strUsuario", strUser);
                cmd.Parameters.AddWithValue("@strContraseña", strhash);
                cmd.Parameters.AddWithValue("@strCorreo", strcorreo);
                cmd.Parameters.AddWithValue("@strNombre", strNombre);
                cmd.Parameters.AddWithValue("@strApellido", strApellido);
                cmd.Parameters.AddWithValue("@intEstado", 1);
                cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                return true;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }

        public bool RegistroPersona(string strcedula, string strNombre, string strApellido, string strUsuario, string bolTieneHuella,string strTelefono,string strSexo,string strDireccion)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
                if (ExistePersona(strcedula) == true)
                {
                    return false;
                }

                strConsultaSQL = "Insert Into tblPersonas (strcedula,strNombre,strApellido,strUsuario,bolTieneHuella,strTelefono,strSexo,strDireccion) Values (@strcedula,@strNombre,@strApellido,@strUsuario,@bolTieneHuella,@strTelefono,@strSexo,@strDireccion) ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strcedula", strcedula);
                cmd.Parameters.AddWithValue("@strNombre", strNombre);
                cmd.Parameters.AddWithValue("@strApellido", strApellido);
                cmd.Parameters.AddWithValue("@strUsuario", strUsuario);
                cmd.Parameters.AddWithValue("@bolTieneHuella", bolTieneHuella);
                cmd.Parameters.AddWithValue("@strTelefono", strTelefono);
                cmd.Parameters.AddWithValue("@strSexo", strSexo);
                cmd.Parameters.AddWithValue("@strDireccion", strDireccion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                return true;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }

        public bool EliminarTodos()
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
              

                strConsultaSQL = "Delete From tblPersonas";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                return true;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }


        public bool ConfirmarReserva(string codigoReserva)
        {
            SqlCommand cmd;
            SqlCommand cmd2;
            SqlCommand cmd3;
            string strConsultaSQL = string.Empty;
            try
            {


                strConsultaSQL = "insert into tblreservasConfirmadas  (strCodigoReserva,strDestino ,strFechaDestino,strHora,strOrigen,strCedulaPersona,strReservaConfirmada)select strCodigoReserva,strDestino ,strFechaDestino,strHora,strOrigen,strCedulaPersona,strReservaConfirmada from tblreservas where  strCodigoReserva = '"+ codigoReserva + "' ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);

                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                string consulta2 = "update tblreservasConfirmadas set strReservaConfirmada = 'True' where  strCodigoReserva = '"+ codigoReserva +"' ";
                cmd2 = new SqlCommand(consulta2);
                cmd2.Connection = conectar();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable ds1 = new DataTable();
                da1.Fill(ds1);
                if (cmd2.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd2.Connection.Close();
                }


                string consulta3 = "Delete From tblreservas where  strCodigoReserva = '" + codigoReserva + "' ";
                cmd3 = new SqlCommand(consulta3);
                cmd3.Connection = conectar();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                DataTable ds2 = new DataTable();
                da2.Fill(ds2);
                if (cmd3.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd3.Connection.Close();
                }

                return true;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }




        public string ConsultarPersonaVerificacion(string strCedula)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
           
            try
            {
                strConsultaSQL = "Select strNombre,strApellido,bolTieneHuella,strTelefono,strSexo,strDireccion from tblPersonas where strCedula=@strCedula ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strCedula", strCedula);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (ds.Rows.Count > 0)
                {

                    return  ds.Rows[0]["strNombre"].ToString() + "*" + ds.Rows[0]["strApellido"].ToString() + "*" + ds.Rows[0]["bolTieneHuella"].ToString() + "*" + ds.Rows[0]["strTelefono"].ToString() + "*" + ds.Rows[0]["strSexo"].ToString() + "*" + ds.Rows[0]["strDireccion"].ToString();
                }
                else
                {
                    return "";
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }

        public DataTable ConsultarReserva(string strCedula)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;

            try
            {
                strConsultaSQL = "Select strCodigoReserva as Reserva,strCedulaPersona as Cedula,strOrigen as Origen , strDestino as Destino,strFechaDestino as Fecha,strHora as Hora, strReservaConfirmada as Confirmada from  tblreservas where strCedulaPersona=@strCedula ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strCedula", strCedula);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (ds.Rows.Count > 0)
                {
                    if (ds.Rows[0]["Confirmada"].ToString() == "False")
                    {
                        return ds;

                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }
        }

        private bool ExisteUsuario(string strUsuario)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
                strConsultaSQL = "Select strUsuario from tblUsuarios where strUsuario=@strUsuario ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strUsuario", strUsuario);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (ds.Rows.Count > 0)
                {
                    ds = null;
                    da = null;

                    return true;
                }
                else
                {
                    ds = null;
                    da = null;
                    return false;
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }



        }


        public bool registrarCheckin(string strCodigoReserva, string strDestino, string strFechaDestino, string strHora, string strOrigen,string strCedula)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
                strConsultaSQL = "Insert into tblreservas (strCodigoReserva,strDestino,strFechaDestino,strHora,strOrigen,strReservaConfirmada,strCedulaPersona) Values(@strCodigoReserva,@strDestino,@strFechaDestino,@strHora,@strOrigen,'False',@strCedula) ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strCodigoReserva", strCodigoReserva);
                cmd.Parameters.AddWithValue("@strDestino", strDestino);
                cmd.Parameters.AddWithValue("@strFechaDestino", strFechaDestino);
                cmd.Parameters.AddWithValue("@strHora", strHora);
                cmd.Parameters.AddWithValue("@strOrigen", strOrigen);
                cmd.Parameters.AddWithValue("@strCedula", strCedula);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
             
                    return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }



        }

        private bool ExistePersona(string strCedula)
        {
            SqlCommand cmd;
            string strConsultaSQL = string.Empty;
            try
            {
                strConsultaSQL = "Select strCedula from tblPersonas where strCedula=@strCedula ";
                cmd = new SqlCommand(strConsultaSQL);
                cmd.Connection = conectar();
                cmd.Parameters.AddWithValue("@strCedula", strCedula);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (cmd.Connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

                if (ds.Rows.Count > 0)
                {
                    ds = null;
                    da = null;

                    return true;
                }
                else
                {
                    ds = null;
                    da = null;
                    return false;
                }

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                strConsultaSQL = string.Empty;
                cmd = null;
            }



        }

        private SqlConnection conectar()
        {
            try
            {
                SqlConnection oconectar = new SqlConnection(ConfigurationManager.AppSettings["Bd"].ToString());
                oconectar.Open();
                return oconectar;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }


        }

    }
}
