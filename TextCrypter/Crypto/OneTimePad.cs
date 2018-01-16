using System;

namespace TextCrypter.Crypto
{
    public class OneTimePad
	{
	    public static byte[] Encrypt(byte[] bytes, byte[] password)
	    {
	        if (bytes.Length > password.Length)
	            throw new ArgumentException("Key must be the same size, or longer, as the message");

	        byte[] encrypted = new byte[bytes.Length];

	        for (int i = 0; i < bytes.Length; i++)
	            encrypted[i] = (byte) (bytes[i] ^ password[i]);

	        return encrypted;
	    }

	    public static byte[] Decrypt(byte[] bytes, byte[] password)
		{
		    if (bytes.Length > password.Length)
		        throw new ArgumentException("Key must be the same size, or longer, as the message");

		    byte[] encrypted = new byte[bytes.Length];

		    for (int i = 0; i < bytes.Length; i++)
		        encrypted[i] = (byte) (bytes[i] ^ password[i]);

		    return encrypted;
		}
	}
}
