using System.IO;
using System.Security.Cryptography;

namespace TextCrypter.Classes.Crypto
{
	class AES
	{
		private static byte[] _salt = new byte[] { 250, 18, 32, 56, 232, 245, 69, 87 };

		public static byte[] Encrypt(byte[] bytes, byte[] password)
		{
			byte[] encryptedBytes = null;

			using (MemoryStream ms = new MemoryStream())
			{
				using (RijndaelManaged AES = new RijndaelManaged())
				{
					AES.KeySize = 256;
					AES.BlockSize = 128;

					var key = new Rfc2898DeriveBytes(password, _salt, 1000);
					AES.Key = key.GetBytes(AES.KeySize / 8);
					AES.IV = key.GetBytes(AES.BlockSize / 8);

					AES.Mode = CipherMode.CBC;

					using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cs.Write(bytes, 0, bytes.Length);
						cs.Close();
					}
					encryptedBytes = ms.ToArray();
				}
			}

			return encryptedBytes;
		}

		public static byte[] Decrypt(byte[] bytes, byte[] password)
		{
			byte[] decryptedBytes = null;

			using (MemoryStream ms = new MemoryStream())
			{
				using (RijndaelManaged AES = new RijndaelManaged())
				{
					AES.KeySize = 256;
					AES.BlockSize = 128;

					var key = new Rfc2898DeriveBytes(password, _salt, 1000);
					AES.Key = key.GetBytes(AES.KeySize / 8);
					AES.IV = key.GetBytes(AES.BlockSize / 8);

					AES.Mode = CipherMode.CBC;

					using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(bytes, 0, bytes.Length);
						cs.Close();
					}
					decryptedBytes = ms.ToArray();
				}
			}

			return decryptedBytes;
		}
	}
}