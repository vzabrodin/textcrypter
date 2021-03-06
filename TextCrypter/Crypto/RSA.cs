using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TextCrypter.Crypto
{
    public class Rsa
    {
        public static byte[] Encrypt(byte[] bytes, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(dwKeySize);
            rsa.FromXmlString(xmlString);

            int blockSize = dwKeySize / 16;

            List<byte> arrayList = new List<byte>();
            for (int i = 0; i * blockSize < bytes.Length; i++)
            {
                byte[] buffer = new byte[blockSize];

                for (int j = 0; j < buffer.Length && i * blockSize + j < bytes.Length; j++)
                    buffer[j] = bytes[i * blockSize + j];

                byte[] newBytes = rsa.Encrypt(buffer, true);
                Array.Reverse(newBytes);

                arrayList.AddRange(newBytes);
            }

            return arrayList.ToArray();
        }

        public static byte[] Decrypt(byte[] bytes, int keySize, string xmlString)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize);
            rsa.FromXmlString(xmlString);

            int blockSize = keySize / 8;

            List<byte> arrayList = new List<byte>();
            for (int i = 0; i * blockSize < bytes.Length; i++)
            {
                byte[] buffer = new byte[blockSize];

                for (int j = 0; j < buffer.Length && i * blockSize + j < bytes.Length; j++)
                    buffer[j] = bytes[i * blockSize + j];

                Array.Reverse(buffer);
                byte[] newBytes = rsa.Decrypt(buffer, true);

                arrayList.AddRange(newBytes);
            }

            return arrayList.ToArray();
        }
    }
}
