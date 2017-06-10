using System;
using System.Text;
using System.IO;
using TextCrypter.Classes.Crypto;
using TextCrypter.Classes.Exceptions;

namespace TextCrypter.Classes
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
				string text = null;
				switch (Algorithm)
				{
					case CipherAlgorithm.AES:
						text = Encoding.Unicode.GetString(AES.Decrypt(TextEncrypted, Encoding.Unicode.GetBytes(Key)));
						break;
					case CipherAlgorithm.RSA:
						text = Encoding.Unicode.GetString(RSA.Decrypt(TextEncrypted, 1024, Key));
						break;
					case CipherAlgorithm.OneTimePad:
						text = Encoding.Unicode.GetString(OneTimePad.Decrypt(TextEncrypted, Encoding.Unicode.GetBytes(Key)));
						break;
					case CipherAlgorithm.Vigenere:
						text = Encoding.Unicode.GetString(Vigenere.Decrypt(TextEncrypted, Encoding.Unicode.GetBytes(Key)));
						break;

				}
				return text;
			}
			set
			{
				switch (Algorithm)
				{
					case CipherAlgorithm.AES:
						TextEncrypted = AES.Encrypt(Encoding.Unicode.GetBytes(value), Encoding.Unicode.GetBytes(Key));
						break;
					case CipherAlgorithm.RSA:
						TextEncrypted = RSA.Encrypt(Encoding.Unicode.GetBytes(value), 1024, Key);
						break;
					case CipherAlgorithm.OneTimePad:
						TextEncrypted = OneTimePad.Encrypt(Encoding.Unicode.GetBytes(value), Encoding.Unicode.GetBytes(Key));
						break;
					case CipherAlgorithm.Vigenere:
						TextEncrypted = Vigenere.Encrypt(Encoding.Unicode.GetBytes(value), Encoding.Unicode.GetBytes(Key));
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

			using (Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite))
			{
				switch (new FileInfo(filepath).Extension)
				{
					case ".textcrypt":
						using (var binread = new BinaryReader(stream))
						{
							try
							{
								TextEncrypted = binread.ReadAllBytes();
							}
							catch (System.Security.Cryptography.CryptographicException)
							{
								throw new WrongKeyException();
							}
						}
						break;
					case ".txt":
						using (var rd = new StreamReader(stream))
						{
							Text = rd.ReadToEnd();
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
		    if (filepath == null) throw new ArgumentNullException(nameof(filepath));
		    using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
			{
				switch (new FileInfo(filepath).Extension)
				{
					case ".textcrypt":
						using (var binwr = new BinaryWriter(stream))
						{
							if (TextEncrypted != null) binwr.Write(TextEncrypted);
						}
						break;
					case ".txt":
						using (var wr = new StreamWriter(stream))
						{
							wr.Write(Text);
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
