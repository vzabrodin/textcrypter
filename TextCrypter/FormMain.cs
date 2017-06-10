using System;
using System.IO;
using System.Windows.Forms;
using TextCrypter.Classes;

namespace TextCrypter
{
	public partial class FormMain : Form
	{
		private string textBoxTmp = string.Empty;
		private bool isFileSaved = true;

		private CryptFileMan fm;
		private FormMainConfig cfg;

		public FormMain()
		{
			fm = new CryptFileMan();
			cfg = FormMainConfig.FromRegistry();

			InitializeComponent();
			Text = Application.ProductName;

			textBox1.Font = textBox2.Font = cfg.Font;
			splitContainer1.Panel2Collapsed = !(miEditShowEncryptedText.Checked = cfg.ShowEncryptedText);
			textBox1.WordWrap = textBox2.WordWrap = miFormatWordWrap.Checked = cfg.WordWrap;
		}

		public FormMain(string filename) : this()
		{
			FileOpen_Helper(filename);
		}

		#region TextBox Edit Actions

		private void miEditUndo_Click(object sender, EventArgs e)
		{
			textBox1.Undo();
		}

		private void miEditCut_Click(object sender, EventArgs e)
		{
			textBox1.Cut();
		}

		private void miEditCopy_Click(object sender, EventArgs e)
		{
			textBox1.Copy();
		}

		private void miEditPaste_Click(object sender, EventArgs e)
		{
			textBox1.Paste();
		}

		private void miEditSelectAll_Click(object sender, EventArgs e)
		{
			textBox1.SelectAll();
		}



		#endregion

		private void miHelpAbout_Click(object sender, EventArgs e)
		{
			new FormAbout().ShowDialog();
		}

		private void miEditHideEncryptedText_Click(object sender, EventArgs e)
		{
			splitContainer1.Panel2Collapsed = !(cfg.ShowEncryptedText = miEditShowEncryptedText.Checked);
		}

		private void miFileNew_Click(object sender, EventArgs e)
		{
			miFileClose_Click(null, EventArgs.Empty);
			FormSetKey formKey = new FormSetKey();
			if (formKey.ShowDialog() != DialogResult.OK) return;

			fm.New(formKey.Key, formKey.Algorithm);
			isFileSaved = true;
			Text = $"Untitled - {Application.ProductName}";

			splitContainer1.Enabled = true;
			miFileSave.Enabled = true;
			miFileSaveAs.Enabled = true;
			miFileSetKey.Enabled = true;
			miFileClose.Enabled = true;
		}

		private void FileOpen_Helper(string filename)
		{
			FormSetKey formKey = new FormSetKey();
			if (formKey.ShowDialog() != DialogResult.OK) return;
			try
			{
				fm.Open(filename, formKey.Key, formKey.Algorithm);
				textBox1.Text = fm.Text;
				textBox2.Text = Convert.ToBase64String(fm.TextEncrypted);

				isFileSaved = true;
				Text = $"{Path.GetFileName(fm.FilePath) ?? "Untitled"} - {Application.ProductName}";

				splitContainer1.Enabled = true;
				miFileSave.Enabled = true;
				miFileSaveAs.Enabled = true;
				miFileSetKey.Enabled = true;
				miFileClose.Enabled = true;
			}
			catch (Exception ex)
			{
				fm.Close();
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void miFileOpen_Click(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
			FileOpen_Helper(openFileDialog1.FileName);
		}

		private void miFileSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(fm.FilePath))
			{
				saveFileDialog1.FileName = Path.GetFileName(fm.FilePath);
				miFileSaveAs_Click(sender, e);
			}
			else
			{
				fm.Save();
				isFileSaved = true;
				Text = $"{Path.GetFileName(fm.FilePath) ?? "Untitled"} - {Application.ProductName}";
			}
		}

		private void miFileSaveAs_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(fm.FilePath)) saveFileDialog1.FileName = new FileInfo(fm.FilePath).Name;
			if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
			fm.FilePath = saveFileDialog1.FileName;
			fm.Save();
			isFileSaved = true;
			Text = $"{Path.GetFileName(fm.FilePath) ?? "Untitled"} - {Application.ProductName}";
		}

		private void miFileClose_Click(object sender, EventArgs e)
		{
			if (!isFileSaved)
			{
				var question = MessageBox.Show("Do you want to save changes?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (question == DialogResult.Yes)
				{
					if (string.IsNullOrEmpty(fm.FilePath))
					{
						if (saveFileDialog1.ShowDialog() == DialogResult.OK)
						{
							fm.Save(saveFileDialog1.FileName);
						}
					}
					else
					{
						fm.Save();
					}
				}
			}

			textBox1.Clear();
			textBox2.Clear();
			isFileSaved = true;
			Text = Application.ProductName;
			fm.Close();

			splitContainer1.Enabled = false;
			miFileSave.Enabled = false;
			miFileSaveAs.Enabled = false;
			miFileSetKey.Enabled = false;
			miFileClose.Enabled = false;
		}

		private void miFileSetKey_Click(object sender, EventArgs e)
		{
			var oldKey = fm.Key;
			var oldKeyPath = fm.KeyFilePath;
			var oldAlgorithm = fm.Algorithm;

			try
			{
				FormSetKey dbsetts = new FormSetKey(fm.Key, fm.KeyFilePath, fm.Algorithm);
				if (dbsetts.ShowDialog() != DialogResult.OK) return;
				fm.Key = dbsetts.Key;
				fm.Algorithm = dbsetts.Algorithm;

				fm.Text = textBox1.Text;
				textBox2.Text = Convert.ToBase64String(fm.TextEncrypted);

				isFileSaved = false;
				Text = $"{Path.GetFileName(fm.FilePath) ?? "Untitled"} * {Application.ProductName}";
			}
			catch (Exception ex)
			{
				fm.Key = oldKey;
				fm.KeyFilePath = oldKeyPath;
				fm.Algorithm = oldAlgorithm;
				MessageBox.Show(ex.Message, Application.ProductName);
			}
		}

		private void miFileExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isFileSaved)
			{
				var question = MessageBox.Show("Do you want to save changes?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (question == DialogResult.Cancel)
				{
					e.Cancel = true;
					return;
				}
				if (question == DialogResult.Yes)
				{
					if (string.IsNullOrEmpty(fm.FilePath))
					{
						if (saveFileDialog1.ShowDialog() != DialogResult.OK)
						{
							e.Cancel = true;
							return;
						}
						fm.Save(saveFileDialog1.FileName);
					}
					else
					{
						fm.Save();
					}
				}
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				isFileSaved = false;
				fm.Text = textBox1.Text;
				textBox2.Text = Convert.ToBase64String(fm.TextEncrypted);
				textBoxTmp = textBox1.Text;
				Text = $"{Path.GetFileName(fm.FilePath) ?? "Untitled"} * {Application.ProductName}";
			}
			catch (ArgumentException ex)
			{
				textBox1.Text = textBoxTmp;
				MessageBox.Show(ex.Message, Application.ProductName);
			}
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A) (sender as TextBox).SelectAll();
		}

		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			string[] dragDropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (dragDropFiles.Length != 1) return;
			FileOpen_Helper(dragDropFiles[0]);
		}

		private void miFormatWordWrap_Click(object sender, EventArgs e)
		{
			cfg.WordWrap = textBox1.WordWrap = textBox2.WordWrap = (sender as ToolStripMenuItem).Checked;
		}

		private void miFormatFont_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			fd.Font = cfg.Font;
			if (fd.ShowDialog() == DialogResult.OK)
			{
				cfg.Font = textBox1.Font = textBox2.Font = fd.Font;
			}
		}
	}
}