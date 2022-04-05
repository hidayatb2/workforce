using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AppEncryption
    {
        public static string CreateSalt()
        {
            byte[] rng = RandomNumberGenerator.GetBytes(20);
            return Convert.ToBase64String(rng);
        }

        public static string CreatePasswordHash(string password, string salt)
        {
            string saltandpass = string.Concat(password, salt);
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltandpass));
            return Convert.ToBase64String(hash);
        }
    }
}
