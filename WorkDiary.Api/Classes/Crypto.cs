using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ServiceDotNet.Api.Classes
{
    public class Crypto
    {
        #region :: CONSTRUCTORS ::

        public Crypto()
        {
            this.EncryptionKey = "!#$a54?3!@##snQBE59A"; // Setting a default key which can be changed by property anytime.
        }

        #endregion

        #region :: PUBLIC PROPERTIES ::

        public string EncryptionKey
        {
            get;
            set;
        }

        #endregion

        #region :: PUBLIC CLASS METHODS ::

        /// <MethodName>Encrypt</MethodName>
        /// <WrittenBy>Ghazanfar</WrittenBy>
        /// <WrittenOn>Dec 21, 2011</WrittenOn>
        /// <summary>
        /// This function is to encrypt any given string. You can also use your own EncryptionKey by setting that property.
        /// </summary>
        /// <param name="stringValue">String which you want to encrypt</param>
        /// <returns>Encrypted value of given string.</returns>
        public string Encrypt(string stringValue)
        {
            return this.EncryptString(stringValue, this.EncryptionKey);
        }

        /// <MethodName>Decrypt</MethodName>
        /// <WrittenBy>Ghazanfar</WrittenBy>
        /// <WrittenOn>Dec 21, 2011</WrittenOn>
        /// <summary>
        /// This function is to decrypty any given string
        /// </summary>
        /// <param name="stringValue">String which you want to decrypt. Must be generated from the same system. Otherwise, it can throw an exception.</param>
        /// <returns>Decrypted value of given encrypted string.</returns>
        public string Decrypt(string stringValue)
        {
            return this.DecryptString(stringValue, this.EncryptionKey);
        }

        #endregion

        #region :: Private Encrypt / Decrypt Functions ::
        /// <MethodName>DecryptString</MethodName>
        /// <WrittenBy>Ghazanfar</WrittenBy>
        /// <WrittenOn>Dec 21, 2011</WrittenOn>
        /// <summary>
        /// This function is to decrypts any given string using the encryption key.
        /// </summary>
        /// <param name="stringValue">String which you want to decrypt. Must be generated from the same system. Otherwise, it can throw an exception.</param>
        /// <param name="sEncryptionKey">Key which was used to encrypt the string</param>
        /// <returns>Decrypted value of given encrypted string.</returns>
        private string DecryptString(string stringToDecrypt, string sEncryptionKey)
        {

            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];

            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (System.FormatException fex)
            {
                throw fex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <MethodName>EncryptString</MethodName>
        /// <WrittenBy>Ghazanfar</WrittenBy>
        /// <WrittenOn>Dec 21, 2011</WrittenOn>
        /// <summary>
        /// This function is to encrypt any given string using the encryption key.
        /// </summary>
        /// <param name="stringValue">String which you want to encrypt.</param>
        /// <param name="sEncryptionKey">Key which you want to use for encryption.</param>
        /// <returns>Encrypted value of given string.</returns>
        private string EncryptString(string stringToEncrypt, string sEncryptionKey)
        {

            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length)

            try
            {
                key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}