namespace TextCrypter.Crypto
{
    public interface ICryptoAlgorithm
    {
        byte[] Encrypt(byte[] bytes, byte[] password);

        byte[] Decrypt(byte[] bytes, byte[] password);
    }
}
