using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Helper.Hasher
{
    public static class PasswordHasher
    {
        public static string Hasher(string password)
        {
            if(!string.IsNullOrEmpty(password))
            {
                var sha = SHA256.Create();  
                var asByteArray = Encoding.UTF8.GetBytes(password); 

                var hasherPassword = sha.ComputeHash(asByteArray); 

                return Convert.ToBase64String(hasherPassword);
            }
            return null;
        }
    }
}
