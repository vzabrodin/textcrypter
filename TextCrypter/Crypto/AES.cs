using System.IO;
using System.Security.Cryptography;

namespace TextCrypter.Crypto
{
    public class Aes
    {
        private static readonly byte[] Salt = {250, 18, 32, 56, 232, 245, 69, 87};

        public static byte[] Encrypt(byte[] bytes, byte[] password)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var rijndael = new RijndaelManaged())
                {
                    rijndael.KeySize = 256;
                    rijndael.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(password, Salt, 1000);
                    rijndael.Key = key.GetBytes(rijndael.KeySize / 8);
                    rijndael.IV = key.GetBytes(rijndael.BlockSize / 8);

                    rijndael.Mode = CipherMode.CBC;

                    using (var cryptoStream =
                        new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] bytes, byte[] password)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var rijndael = new RijndaelManaged())
                {
                    rijndael.KeySize = 256;
                    rijndael.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(password, Salt, 1000);
                    rijndael.Key = key.GetBytes(rijndael.KeySize / 8);
                    rijndael.IV = key.GetBytes(rijndael.BlockSize / 8);

                    rijndael.Mode = CipherMode.CBC;

                    using (var cryptoStream =
                        new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                    }

                    return memoryStream.ToArray();
                }
            }
        }
    }
}
