namespace TextCrypter.Crypto
{
    public class Vigenere
    {
        public static byte[] Encrypt(byte[] bytes, byte[] password)
        {
            byte[] encrypted = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
                encrypted[i] = Shr(bytes[i], password[i % password.Length]);

            return encrypted;
        }

        public static byte[] Decrypt(byte[] bytes, byte[] password)
        {
            byte[] encrypted = new byte[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
                encrypted[i] = Shl(bytes[i], password[i % password.Length]);

            return encrypted;
        }

        private static byte Shr(byte a, byte s) => (byte) ((a >> s % 8) | ((a << 8 - s % 8) & 0xFF));

        private static byte Shl(byte a, byte s) => (byte) ((a << s % 8) | ((a >> 8 - s % 8) & 0xFF));
    }
}