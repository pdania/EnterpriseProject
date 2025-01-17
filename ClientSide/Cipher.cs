﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ClientSide
{
    public class Cipher
    {
        private static string _key;

        public static string Key
        {
            get => _key;
            set => _key = value;
        }

        private static string GenerateEncryptionKey()
        {
            string encryptionKey = "XYZ" + "verylongmessagethatimpossibletohack";

            return encryptionKey;
        }

        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                // ReSharper disable once PossibleNullReferenceException
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        static Cipher()
        {
            Key = GenerateEncryptionKey();
        }
    }
}