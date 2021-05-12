using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JeanCIty.Clases
{
    public class UserRecord
    {

        [XmlAttribute("id")]
        public int _id;

        [XmlAttribute("name")]
        public string _name;

        public UserRecord()
        {
            _id = 0;
            _name = string.Empty;
        }

        public UserRecord(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }




    }

    [XmlRoot("UserDatabase")]
    public class userDB : List<UserRecord>
    {

        public void WriteToFile(string path)
        {
            TextWriter w = null;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(userDB));
                w = new StreamWriter(path);
                s.Serialize(w, this);
                w.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                    w = null;
                }
            }


        }



        public static userDB ReadFromFile(string filename)
        {
            userDB newUserDb = null;
            TextReader r = null;
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(userDB));
                r = new StreamReader(filename);
                newUserDb = (userDB)s.Deserialize(r);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                r.Close();
            }

            return newUserDb;
        }

        public UserRecord Lookup(int id)
        {
            foreach (UserRecord userRec in this)
            {
                if (userRec.ID == id)
                    return userRec;
            }

            return null;
        }



    }
}
