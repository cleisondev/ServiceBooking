using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.Services.Cryptography
{
    public class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA256.HashData(bytes);

            return Convert.ToBase64String(hashBytes);

        }


        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
