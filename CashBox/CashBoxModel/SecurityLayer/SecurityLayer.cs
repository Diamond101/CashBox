using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBoxModel.SecurityLayer
{
    public class SecurityLayer
    {
        public string SecuredConnection()
        {
            string server = GetConfigValue("Server");
            string database = GetConfigValue("Database");

            return "Data Source=" + server + "; Initial Catalog=" + database + "; Integrated Security=SSPI;";
        }

        public string TrackerConnection()
        {
            string server = GetConfigValue("TrackingServer");
            string database = GetConfigValue("TrackingDatabase");
            string uid = Decrypt(GetConfigValue("TrackingUser"));
            string password = Decrypt(GetConfigValue("TrackingPassword"));

            return "Data Source=" + server + "; Initial Catalog=" + database + "; UID=" +
                   uid + "; Password=" + password + "; Integrated Security=false;";
        }

        string key = "12345";
        public string Encrypt(string value)
        {
            return new CrytoLibrary.SymmetricEncryption(CrytoLibrary.SymmetricEncryption.EncryptionType.DES)
                .Encrypt(value, key);
        }

        public string Decrypt(string value)
        {
            return new CrytoLibrary.SymmetricEncryption(CrytoLibrary.SymmetricEncryption.EncryptionType.DES)
                .Decrypt(value, key);
        }

        string GetConfigValue(string _key)
        {
            return ConfigurationManager.AppSettings[_key];
        }
    }
}
