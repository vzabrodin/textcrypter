namespace TextCrypter
{
	partial class FormSetKey
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCreateKeyFile = new System.Windows.Forms.Button();
			this.lblKeyRSA = new System.Windows.Forms.Label();
			this.txtKeyRSA = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.lblKeyAES = new System.Windows.Forms.Label();
			this.txtKeyAES = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.cmbCipherAlgorithm = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCreateKeyFile
			// 
			this.btnCreateKeyFile.Location = new System.Drawing.Point(12, 118);
			this.btnCreateKeyFile.Name = "btnCreateKeyFile";
			this.btnCreateKeyFile.Size = new System.Drawing.Size(93, 23);
			this.btnCreateKeyFile.TabIndex = 9;
			this.btnCreateKeyFile.Text = "Create key file";
			this.btnCreateKeyFile.UseVisualStyleBackColor = true;
			this.btnCreateKeyFile.Click += new System.EventHandler(this.btnCreateKeyFile_Click);
			// 
			// lblKeyRSA
			// 
			this.lblKeyRSA.AutoSize = true;
			this.lblKeyRSA.Location = new System.Drawing.Point(12, 55);
			this.lblKeyRSA.Name = "lblKeyRSA";
			this.lblKeyRSA.Size = new System.Drawing.Size(44, 13);
			this.lblKeyRSA.TabIndex = 8;
			this.lblKeyRSA.Text = "Key file:";
			// 
			// txtKeyRSA
			// 
			this.txtKeyRSA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeyRSA.Location = new System.Drawing.Point(12, 71);
			this.txtKeyRSA.Name = "txtKeyRSA";
			this.txtKeyRSA.Size = new System.Drawing.Size(213, 20);
			this.txtKeyRSA.TabIndex = 7;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(231, 69);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 5;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// lblKeyAES
			// 
			this.lblKeyAES.AutoSize = true;
			this.lblKeyAES.Location = new System.Drawing.Point(12, 55);
			this.lblKeyAES.Name = "lblKeyAES";
			this.lblKeyAES.Size = new System.Drawing.Size(28, 13);
			this.lblKeyAES.TabIndex = 8;
			this.lblKeyAES.Text = "Key:";
			// 
			// txtKeyAES
			// 
			this.txtKeyAES.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeyAES.Location = new System.Drawing.Point(12, 71);
			this.txtKeyAES.Name = "txtKeyAES";
			this.txtKeyAES.Size = new System.Drawing.Size(294, 20);
			this.txtKeyAES.TabIndex = 7;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Private/public keys (*.kez)|*.kez|Public key (*.pke)|*.pke";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(237, 118);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(156, 118);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// cmbCipherAlgorithm
			// 
			this.cmbCipherAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCipherAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCipherAlgorithm.FormattingEnabled = true;
			this.cmbCipherAlgorithm.Location = new System.Drawing.Point(12, 25);
			this.cmbCipherAlgorithm.Name = "cmbCipherAlgorithm";
			this.cmbCipherAlgorithm.Size = new System.Drawing.Size(294, 21);
			this.cmbCipherAlgorithm.TabIndex = 9;
			this.cmbCipherAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbCipherAlgorithm_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Algorighm:";
			// 
			// FormSetKey
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(324, 153);
			this.Controls.Add(this.btnCreateKeyFile);
			this.Controls.Add(this.lblKeyAES);
			this.Controls.Add(this.lblKeyRSA);
			this.Controls.Add(this.txtKeyRSA);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtKeyAES);
			this.Controls.Add(this.cmbCipherAlgorithm);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSetKey";
			this.Text = "Encryption settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetKeyRSA_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCreateKeyFile;
		private System.Windows.Forms.Label lblKeyRSA;
		private System.Windows.Forms.TextBox txtKeyRSA;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ComboBox cmbCipherAlgorithm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblKeyAES;
		private System.Windows.Forms.TextBox txtKeyAES;
	}
}