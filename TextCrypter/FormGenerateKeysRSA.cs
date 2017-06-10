using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextCrypter
{
	public partial class FormGenerateKeysRSA : Form
	{
		private int strength = 1024;
		private RSACryptoServiceProvider RSAProvider;

		public FormGenerateKeysRSA()
		{
			InitializeComponent();
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			RSAProvider = new RSACryptoServiceProvider(strength);
			txtPublicKey.Text = RSAProvider.ToXmlString(false);
			btnSavePrivateKey.Enabled = true;
			btnSavePublicKey.Enabled = true;
		}

		private void btnSavePublicKey_Click(object sender, EventArgs e)
		{
			string publicKey = RSAProvider.ToXmlString(false);
			saveFileDialog1.Filter = "Public key (*.pke)|*.pke";
			saveFileDialog1.FileName = "";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					using (var stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
					{
						using (var wr = new StreamWriter(stream))
						{
							wr.WriteLine(publicKey);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnSavePrivateKey_Click(object sender, EventArgs e)
		{
			string privateKeys = RSAProvider.ToXmlString(true);

			saveFileDialog1.Filter = "Private/Public keys (*.kez)|*.kez";
			saveFileDialog1.FileName = "";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					using (var stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
					{
						using (var wr = new StreamWriter(stream))
						{
							wr.WriteLine(privateKeys);
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
}