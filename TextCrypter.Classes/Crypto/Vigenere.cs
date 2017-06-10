using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCrypter.Classes.Crypto
{
	class Vigenere
	{
		public static byte[] Encrypt(byte[] bytes, byte[] password)
		{
			byte[] encrypted = new byte[bytes.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				encrypted[i] = (shr(bytes[i], password[(i % password.Length)]));
			}
			return encrypted;
		}

		public static byte[] Decrypt(byte[] bytes, byte[] password)
		{
			byte[] encrypted = new byte[bytes.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				encrypted[i] = shl(bytes[i], password[(i % password.Length)]);
			}
			return encrypted;
		}

		private static byte shr(byte a, byte s)
		{
			return (byte)((a >> s % 8) | ((a << 8 - s % 8) & 0xFF));
		}

		private static byte shl(byte a, byte s)
		{
			return (byte)((a << s % 8) | ((a >> 8 - s % 8) & 0xFF));
		}
	}
}