using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ES.Helpers
{
    public class LoginHelper
    {
        public static string HashGen(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + "electronicSystem");
            var encodeBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodeBytes).Replace("-", "").ToLower();
        }
    }
}
