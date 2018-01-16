using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TextCrypter
{
	public partial class FormGenerateKeysRsa : Form
	{
		private int strength = 1024;
		private RSACryptoServiceProvider rsaProvider;

		public FormGenerateKeysRsa() => InitializeComponent();

	    private void btnGenerate_Click(object sender, EventArgs e)
		{
			rsaProvider = new RSACryptoServiceProvider(strength);
			txtPublicKey.Text = rsaProvider.ToXmlString(false);
			btnSavePrivateKey.Enabled = true;
			btnSavePublicKey.Enabled = true;
		}

		private void btnSavePublicKey_Click(object sender, EventArgs e)
		{
			string publicKey = rsaProvider.ToXmlString(false);
			saveFileDialog1.Filter = "Public key (*.pke)|*.pke";
			saveFileDialog1.FileName = "";

		    if (saveFileDialog1.ShowDialog() != DialogResult.OK)
		        return;

		    try
		    {
		        using (var fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
		        {
		            using (var streamWriter = new StreamWriter(fileStream))
		            {
		                streamWriter.WriteLine(publicKey);
		            }
		        }
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}

		private void btnSavePrivateKey_Click(object sender, EventArgs e)
		{
			string privateKeys = rsaProvider.ToXmlString(true);

			saveFileDialog1.Filter = "Private/Public keys (*.kez)|*.kez";
			saveFileDialog1.FileName = "";

		    if (saveFileDialog1.ShowDialog() != DialogResult.OK)
		        return;

		    try
		    {
		        using (var fileStream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
		        {
		            using (var streamWriter = new StreamWriter(fileStream))
		            {
		                streamWriter.WriteLine(privateKeys);
		            }
		        }
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
	}
}
