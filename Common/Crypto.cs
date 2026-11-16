using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Club1.Common
{
    public static class Crypto
    {
        public static String createSHA256Hash(String contrasena)
        {
            byte[] bytesEntrada = Encoding.UTF8.GetBytes(contrasena);
            byte[] bytesHash = SHA256.HashData(bytesEntrada);
            string hash = Convert.ToHexString(bytesHash).ToLower();
            return hash;
        }
    }
}
