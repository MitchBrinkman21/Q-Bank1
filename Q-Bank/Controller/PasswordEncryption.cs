using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Q_Bank.Controller
{
    class PasswordEncryption
    {
        public string encodedSalt { get; set; }
        public string encodedKey { get; set; }
        
        public void createEncryptedPassword(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 20)) // 20-byte salt
            {
                byte[] salt = deriveBytes.Salt;
                byte[] key = deriveBytes.GetBytes(20); // 20-byte key

                encodedSalt = Convert.ToBase64String(salt);
                encodedKey = Convert.ToBase64String(key);
            }
        }

        public bool authenticate(string password, string encodedSalt, string encodedKey)
        {
            try
            {
                // load encodedSalt and encodedKey from database for the given username
                byte[] salt = Convert.FromBase64String(encodedSalt);
                byte[] key = Convert.FromBase64String(encodedKey);


                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
                {
                    byte[] testKey = deriveBytes.GetBytes(20); // 20-byte key

                    if (!testKey.SequenceEqual(key))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
