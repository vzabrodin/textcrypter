using System;
using System.IO;
using System.Windows.Forms;

namespace TextCrypter
{
	public partial class FormMain : Form
	{
		private string textBoxTmp = string.Empty;
		private bool isFileSaved = true;

		private readonly CryptFileMan cryptFileMan;
		private readonly FormMainConfig formMainConfig;

		public FormMain()
		{
			cryptFileMan = new CryptFileMan();
			formMainConfig = FormMainConfig.FromRegistry();

			InitializeComponent();
			Text = Application.ProductName;

			textBox1.Font = textBox2.Font = formMainConfig.Font;
			splitContainer1.Panel2Collapsed = !(miEditShowEncryptedText.Checked = formMainConfig.ShowEncryptedText);
			textBox1.WordWrap = textBox2.WordWrap = miFormatWordWrap.Checked = formMainConfig.WordWrap;
		}

	    public sealed override string Text
	    {
	        get => base.Text;
	        set => base.Text = value;
	    }

	    public FormMain(string filename) : this() => FileOpen_Helper(filename);

	    #region TextBox Edit Actions

		private void miEditUndo_Click(object sender, EventArgs e) => textBox1.Undo();

	    private void miEditCut_Click(object sender, EventArgs e) => textBox1.Cut();

	    private void miEditCopy_Click(object sender, EventArgs e) => textBox1.Copy();

	    private void miEditPaste_Click(object sender, EventArgs e) => textBox1.Paste();

	    private void miEditSelectAll_Click(object sender, EventArgs e) => textBox1.SelectAll();

	    #endregion

		private void miHelpAbout_Click(object sender, EventArgs e) => new FormAbout().ShowDialog();

	    private void miEditHideEncryptedText_Click(object sender, EventArgs e) =>
	        splitContainer1.Panel2Collapsed = !(formMainConfig.ShowEncryptedText = miEditShowEncryptedText.Checked);

	    private void miFileNew_Click(object sender, EventArgs e)
		{
			miFileClose_Click(null, EventArgs.Empty);

			FormSetKey formKey = new FormSetKey();

			if (formKey.ShowDialog() != DialogResult.OK)
			    return;

			cryptFileMan.New(formKey.Key, formKey.Algorithm);
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
			if (formKey.ShowDialog() != DialogResult.OK)
			    return;

			try
			{
				cryptFileMan.Open(filename, formKey.Key, formKey.Algorithm);
				textBox1.Text = cryptFileMan.Text;
				textBox2.Text = Convert.ToBase64String(cryptFileMan.TextEncrypted);

				isFileSaved = true;
				Text = $"{Path.GetFileName(cryptFileMan.FilePath) ?? "Untitled"} - {Application.ProductName}";

				splitContainer1.Enabled = true;
				miFileSave.Enabled = true;
				miFileSaveAs.Enabled = true;
				miFileSetKey.Enabled = true;
				miFileClose.Enabled = true;
			}
			catch (Exception ex)
			{
				cryptFileMan.Close();
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void miFileOpen_Click(object sender, EventArgs e)
		{
			openFileDialog1.FileName = "";

			if (openFileDialog1.ShowDialog() != DialogResult.OK)
			    return;

			FileOpen_Helper(openFileDialog1.FileName);
		}

		private void miFileSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(cryptFileMan.FilePath))
			{
				saveFileDialog1.FileName = Path.GetFileName(cryptFileMan.FilePath);
				miFileSaveAs_Click(sender, e);
			}
			else
			{
				cryptFileMan.Save();
				isFileSaved = true;
				Text = $"{Path.GetFileName(cryptFileMan.FilePath) ?? "Untitled"} - {Application.ProductName}";
			}
		}

		private void miFileSaveAs_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(cryptFileMan.FilePath))
			    saveFileDialog1.FileName = new FileInfo(cryptFileMan.FilePath).Name;

			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
			    return;

			cryptFileMan.FilePath = saveFileDialog1.FileName;
			cryptFileMan.Save();

			isFileSaved = true;

			Text = $"{Path.GetFileName(cryptFileMan.FilePath) ?? "Untitled"} - {Application.ProductName}";
		}

		private void miFileClose_Click(object sender, EventArgs e)
		{
			if (!isFileSaved)
			{
			    DialogResult question = MessageBox.Show("Do you want to save changes?", Application.ProductName,
			        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			    if (question == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(cryptFileMan.FilePath) && saveFileDialog1.ShowDialog() == DialogResult.OK)
			            cryptFileMan.Save(saveFileDialog1.FileName);
			        else
			            cryptFileMan.Save();
                }
            }

			textBox1.Clear();
			textBox2.Clear();
			isFileSaved = true;
			Text = Application.ProductName;
			cryptFileMan.Close();

			splitContainer1.Enabled = false;
			miFileSave.Enabled = false;
			miFileSaveAs.Enabled = false;
			miFileSetKey.Enabled = false;
			miFileClose.Enabled = false;
		}

		private void miFileSetKey_Click(object sender, EventArgs e)
		{
			string oldKey = cryptFileMan.Key;
			string oldKeyPath = cryptFileMan.KeyFilePath;
			CipherAlgorithm oldAlgorithm = cryptFileMan.Algorithm;

			try
			{
				FormSetKey dbsetts = new FormSetKey(cryptFileMan.Key, cryptFileMan.KeyFilePath, cryptFileMan.Algorithm);
				if (dbsetts.ShowDialog() != DialogResult.OK)
				    return;

				cryptFileMan.Key = dbsetts.Key;
				cryptFileMan.Algorithm = dbsetts.Algorithm;

				cryptFileMan.Text = textBox1.Text;
				textBox2.Text = Convert.ToBase64String(cryptFileMan.TextEncrypted);

				isFileSaved = false;
				Text = $"{Path.GetFileName(cryptFileMan.FilePath) ?? "Untitled"} * {Application.ProductName}";
			}
			catch (Exception ex)
			{
				cryptFileMan.Key = oldKey;
				cryptFileMan.KeyFilePath = oldKeyPath;
				cryptFileMan.Algorithm = oldAlgorithm;
				MessageBox.Show(ex.Message, Application.ProductName);
			}
		}

		private void miFileExit_Click(object sender, EventArgs e) => Close();

	    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
	    {
	        if (isFileSaved)
	            return;

	        var question = MessageBox.Show("Do you want to save changes?", Application.ProductName,
	            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

	        switch (question)
	        {
	            case DialogResult.Cancel:
	                e.Cancel = true;
	                return;
	            case DialogResult.Yes:
	                if (string.IsNullOrEmpty(cryptFileMan.FilePath))
	                {
	                    if (saveFileDialog1.ShowDialog() != DialogResult.OK)
	                    {
	                        e.Cancel = true;
	                        return;
	                    }

	                    cryptFileMan.Save(saveFileDialog1.FileName);
	                }
	                else
	                {
	                    cryptFileMan.Save();
	                }

	                break;
	        }
	    }

	    private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				isFileSaved = false;
				cryptFileMan.Text = textBox1.Text;
				textBox2.Text = Convert.ToBase64String(cryptFileMan.TextEncrypted);
				textBoxTmp = textBox1.Text;
				Text = $"{Path.GetFileName(cryptFileMan.FilePath) ?? "Untitled"} * {Application.ProductName}";
			}
			catch (ArgumentException ex)
			{
				textBox1.Text = textBoxTmp;
				MessageBox.Show(ex.Message, Application.ProductName);
			}
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			    (sender as TextBox)?.SelectAll();
		}

		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
		    if (e.Data.GetDataPresent(DataFormats.FileDrop))
		        e.Effect = DragDropEffects.Copy;
		}

		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			string[] dragDropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (dragDropFiles.Length != 1) return;
			FileOpen_Helper(dragDropFiles[0]);
		}

	    private void miFormatWordWrap_Click(object sender, EventArgs e) =>
	        formMainConfig.WordWrap = textBox1.WordWrap = textBox2.WordWrap = ((ToolStripMenuItem) sender).Checked;

	    private void miFormatFont_Click(object sender, EventArgs e)
	    {
	        FontDialog fd = new FontDialog {Font = formMainConfig.Font};
	        if (fd.ShowDialog() == DialogResult.OK)
	            formMainConfig.Font = textBox1.Font = textBox2.Font = fd.Font;
	    }
	}
}
