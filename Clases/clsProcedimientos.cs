using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JeanCIty.Clases
{
   public static class clsProcedimientos
    {

        public static Dictionary<string,string> Session { get; set; }

        public static string hashPass(string parameters)
        {
            string resultado;
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] dato = sha.ComputeHash(Encoding.UTF8.GetBytes(parameters));
            StringBuilder ConstruirString = new StringBuilder();
            int i = 1;
            while (i < dato.Length)
            {
                ConstruirString.Append(dato[i].ToString("x2"));
                i = i + 1;
            }
            resultado = ConstruirString.ToString();
            return resultado;
        }



    }
}
