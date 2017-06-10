using TextCrypter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextCrypter
{
	public partial class FormSetKey : Form
	{
		public CipherAlgorithm Algorithm { get; set; }

		public string Key { get; set; }

		public string KeyFilePath { get; set; }

		public FormSetKey()
		{
			InitializeComponent();
			cmbCipherAlgorithm.DataSource = Enum.GetValues(typeof(CipherAlgorithm));
		}

		public FormSetKey(string key, string keyFilePath, CipherAlgorithm algorithm) : this()
		{
			cmbCipherAlgorithm.SelectedItem = algorithm;
			switch (algorithm)
			{
				case CipherAlgorithm.AES:
				case CipherAlgorithm.OneTimePad:
				case CipherAlgorithm.Vigenere:
					txtKeyAES.Text = key;
					break;
				case CipherAlgorithm.RSA:
					txtKeyRSA.Text = keyFilePath;
					break;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
			txtKeyRSA.Text = openFileDialog1.FileName;
		}

		private void btnCreateKeyFile_Click(object sender, EventArgs e)
		{
			FormGenerateKeysRSA gen = new FormGenerateKeysRSA();
			gen.ShowDialog();
		}

		private void FormSetKeyRSA_FormClosing(object sender, FormClosingEventArgs e)
		{
			CipherAlgorithm c;
			Enum.TryParse<CipherAlgorithm>(cmbCipherAlgorithm.SelectedValue.ToString(), out c);
			Algorithm = c;

			if (DialogResult == DialogResult.OK)
			{
				switch (Algorithm)
				{
					case CipherAlgorithm.AES:
					case CipherAlgorithm.OneTimePad:
					case CipherAlgorithm.Vigenere:
						Key = txtKeyAES.Text;
						break;
					case CipherAlgorithm.RSA:
						using (StreamReader rd = new StreamReader(txtKeyRSA.Text))
						{
							Key = rd.ReadToEnd();
						}
						KeyFilePath = txtKeyRSA.Text;
						break;
				}
			}
		}

		private void cmbCipherAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
		{
			CipherAlgorithm c;
			Enum.TryParse<CipherAlgorithm>(cmbCipherAlgorithm.SelectedValue.ToString(), out c);

			switch (c)
			{
				case CipherAlgorithm.AES:
				case CipherAlgorithm.OneTimePad:
				case CipherAlgorithm.Vigenere:
					lblKeyAES.Show();
					txtKeyAES.Show();
					lblKeyRSA.Hide();
					txtKeyRSA.Hide();
					btnBrowse.Hide();
					btnCreateKeyFile.Hide();
					break;
				case CipherAlgorithm.RSA:
					lblKeyRSA.Show();
					txtKeyRSA.Show();
					btnBrowse.Show();
					btnCreateKeyFile.Show();
					lblKeyAES.Hide();
					txtKeyAES.Hide();
					break;
			}
		}
	}
}