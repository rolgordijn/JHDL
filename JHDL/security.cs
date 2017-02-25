using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JHDL
{
    /// <summary>
    /// This file contains a method to decrypt and one to encrypt strings, so one can't simply discover all the data stored in files on the pc, when (s)he doesn't have acces to the data where it's used in the software.
    /// Maybe it's not super safe, but good enough for it's purpose. 
    /// </summary>
    public static class Security
    {
        private static string Key = "dofkrfaosrdedofkrfaosrdedofkrfao";
        private static string IV = "zxcvbnmdfrasdfgh";

        /// <summary>
        /// This method takes a string as input and uses AES to decrypt it. 
        /// </summary>
        /// <param name="text">The string to be encrypted</param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            byte[] plaintextbytes = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintextbytes, 0, plaintextbytes.Length);
            crypto.Dispose();
            return Convert.ToBase64String(encrypted);
        }


        /// <summary>
        /// When a string is encrypted, we also need to decrypt it. This method will decrypt strings that were encrypted with the Encrypt method. 
        /// </summary>1
        /// <param name="encrypted">The string that needs to be decrypted</param>
        /// <returns></returns>
        public static string Decrypt(string encrypted)
        {
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);

        }
    }
}
