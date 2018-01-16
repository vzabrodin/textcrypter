using System;
using System.IO;
using System.Text;
using TextCrypter.Crypto;
using TextCrypter.Exceptions;

namespace TextCrypter
{
    public class CryptFileMan
    {
        public CipherAlgorithm Algorithm { get; set; }

        public string FilePath { get; set; }

        public bool IsSaved { get; set; }

        public string KeyFilePath { get; set; }

        public string Key { get; set; }

        public byte[] TextEncrypted { get; set; }

        public string Text
        {
            get
            {
                string text = String.Empty;
                switch (Algorithm)
                {
                    case CipherAlgorithm.Aes:
                        text = Encoding.Unicode.GetString(Aes.Decrypt(TextEncrypted, Encoding.Unicode.GetBytes(Key)));
                        break;
                    case CipherAlgorithm.Rsa:
                        text = Encoding.Unicode.GetString(Rsa.Decrypt(TextEncrypted, 1024, Key));
                        break;
                    case CipherAlgorithm.OneTimePad:
                        text = Encoding.Unicode.GetString(OneTimePad.Decrypt(TextEncrypted,
                            Encoding.Unicode.GetBytes(Key)));
                        break;
                    case CipherAlgorithm.Vigenere:
                        text = Encoding.Unicode.GetString(Vigenere.Decrypt(TextEncrypted,
                            Encoding.Unicode.GetBytes(Key)));
                        break;

                }

                return text;
            }
            set
            {
                switch (Algorithm)
                {
                    case CipherAlgorithm.Aes:
                        TextEncrypted = Aes.Encrypt(Encoding.Unicode.GetBytes(value), Encoding.Unicode.GetBytes(Key));
                        break;
                    case CipherAlgorithm.Rsa:
                        TextEncrypted = Rsa.Encrypt(Encoding.Unicode.GetBytes(value), 1024, Key);
                        break;
                    case CipherAlgorithm.OneTimePad:
                        TextEncrypted = OneTimePad.Encrypt(Encoding.Unicode.GetBytes(value),
                            Encoding.Unicode.GetBytes(Key));
                        break;
                    case CipherAlgorithm.Vigenere:
                        TextEncrypted = Vigenere.Encrypt(Encoding.Unicode.GetBytes(value),
                            Encoding.Unicode.GetBytes(Key));
                        break;
                }
            }
        }

        public CryptFileMan()
        {
            KeyFilePath = null;
            FilePath = null;
        }

        public void New(string key, CipherAlgorithm algorithm)
        {
            Close();
            Key = key;
            Algorithm = algorithm;
        }

        public void Open(string filepath, string key, CipherAlgorithm algorithm)
        {
            New(key, algorithm);
            FilePath = filepath;

            using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                switch (new FileInfo(filepath).Extension)
                {
                    case ".textcrypt":
                        using (var binaryReader = new BinaryReader(fileStream))
                        {
                            try
                            {
                                TextEncrypted = binaryReader.ReadAllBytes();
                            }
                            catch (System.Security.Cryptography.CryptographicException)
                            {
                                throw new WrongKeyException();
                            }
                        }

                        break;
                    case ".txt":
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            Text = streamReader.ReadToEnd();
                        }

                        FilePath = null;
                        break;
                    default:
                        throw new Exception("File type is not supported");
                }
            }
        }

        public void Save() => Save(FilePath);

        public void Save(string filepath)
        {
            if (filepath == null)
                throw new ArgumentNullException(nameof(filepath));

            using (var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                switch (new FileInfo(filepath).Extension)
                {
                    case ".textcrypt":
                        using (var binaryWriter = new BinaryWriter(fileStream))
                        {
                            if (TextEncrypted != null)
                                binaryWriter.Write(TextEncrypted);
                        }

                        break;
                    case ".txt":
                        using (var streamWriter = new StreamWriter(fileStream))
                        {
                            streamWriter.Write(Text);
                        }

                        break;
                    default:
                        throw new Exception("File type is not supported");
                }
            }
        }

        public void Close()
        {
            FilePath = null;
        }
    }
}
