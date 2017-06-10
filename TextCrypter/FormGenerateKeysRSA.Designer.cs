namespace TextCrypter
{
	partial class FormGenerateKeysRSA
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
			this.txtPublicKey = new System.Windows.Forms.TextBox();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnSavePublicKey = new System.Windows.Forms.Button();
			this.btnSavePrivateKey = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// txtPublicKey
			// 
			this.txtPublicKey.Location = new System.Drawing.Point(12, 12);
			this.txtPublicKey.Multiline = true;
			this.txtPublicKey.Name = "txtPublicKey";
			this.txtPublicKey.ReadOnly = true;
			this.txtPublicKey.Size = new System.Drawing.Size(333, 157);
			this.txtPublicKey.TabIndex = 1;
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(12, 175);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 2;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnSavePublicKey
			// 
			this.btnSavePublicKey.Enabled = false;
			this.btnSavePublicKey.Location = new System.Drawing.Point(131, 175);
			this.btnSavePublicKey.Name = "btnSavePublicKey";
			this.btnSavePublicKey.Size = new System.Drawing.Size(104, 23);
			this.btnSavePublicKey.TabIndex = 2;
			this.btnSavePublicKey.Text = "Save public key";
			this.btnSavePublicKey.UseVisualStyleBackColor = true;
			this.btnSavePublicKey.Click += new System.EventHandler(this.btnSavePublicKey_Click);
			// 
			// btnSavePrivateKey
			// 
			this.btnSavePrivateKey.Enabled = false;
			this.btnSavePrivateKey.Location = new System.Drawing.Point(241, 175);
			this.btnSavePrivateKey.Name = "btnSavePrivateKey";
			this.btnSavePrivateKey.Size = new System.Drawing.Size(104, 23);
			this.btnSavePrivateKey.TabIndex = 2;
			this.btnSavePrivateKey.Text = "Save private key";
			this.btnSavePrivateKey.UseVisualStyleBackColor = true;
			this.btnSavePrivateKey.Click += new System.EventHandler(this.btnSavePrivateKey_Click);
			// 
			// FormGenerateKeysRSA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 211);
			this.Controls.Add(this.btnSavePrivateKey);
			this.Controls.Add(this.btnSavePublicKey);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.txtPublicKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGenerateKeysRSA";
			this.Text = "Generate RSA Keys";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtPublicKey;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnSavePublicKey;
		private System.Windows.Forms.Button btnSavePrivateKey;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}