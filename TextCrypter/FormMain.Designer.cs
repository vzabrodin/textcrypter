namespace TextCrypter
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.miFileClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.miFileSetKey = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.miEditCut = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.miEditDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.miEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.miEditShowEncryptedText = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(584, 337);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox2
			// 
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox2.Location = new System.Drawing.Point(0, 0);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(96, 100);
			this.textBox2.TabIndex = 1;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Enabled = false;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.textBox2);
			this.splitContainer1.Panel2Collapsed = true;
			this.splitContainer1.Size = new System.Drawing.Size(584, 337);
			this.splitContainer1.SplitterDistance = 274;
			this.splitContainer1.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNew,
            this.miFileOpen,
            this.miFileSave,
            this.miFileSaveAs,
            this.miFileClose,
            this.toolStripSeparator1,
            this.miFileSetKey,
            this.toolStripSeparator2,
            this.miFileExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// miFileNew
			// 
			this.miFileNew.Name = "miFileNew";
			this.miFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.miFileNew.Size = new System.Drawing.Size(193, 22);
			this.miFileNew.Text = "New...";
			this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
			// 
			// miFileOpen
			// 
			this.miFileOpen.Name = "miFileOpen";
			this.miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.miFileOpen.Size = new System.Drawing.Size(193, 22);
			this.miFileOpen.Text = "Open...";
			this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
			// 
			// miFileSave
			// 
			this.miFileSave.Enabled = false;
			this.miFileSave.Name = "miFileSave";
			this.miFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.miFileSave.Size = new System.Drawing.Size(193, 22);
			this.miFileSave.Text = "Save";
			this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
			// 
			// miFileSaveAs
			// 
			this.miFileSaveAs.Enabled = false;
			this.miFileSaveAs.Name = "miFileSaveAs";
			this.miFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.miFileSaveAs.Size = new System.Drawing.Size(193, 22);
			this.miFileSaveAs.Text = "Save as...";
			this.miFileSaveAs.Click += new System.EventHandler(this.miFileSaveAs_Click);
			// 
			// miFileClose
			// 
			this.miFileClose.Enabled = false;
			this.miFileClose.Name = "miFileClose";
			this.miFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.miFileClose.Size = new System.Drawing.Size(193, 22);
			this.miFileClose.Text = "Close";
			this.miFileClose.Click += new System.EventHandler(this.miFileClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
			// 
			// miFileSetKey
			// 
			this.miFileSetKey.Enabled = false;
			this.miFileSetKey.Name = "miFileSetKey";
			this.miFileSetKey.Size = new System.Drawing.Size(193, 22);
			this.miFileSetKey.Text = "Set key...";
			this.miFileSetKey.Click += new System.EventHandler(this.miFileSetKey_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
			// 
			// miFileExit
			// 
			this.miFileExit.Name = "miFileExit";
			this.miFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.miFileExit.Size = new System.Drawing.Size(193, 22);
			this.miFileExit.Text = "Exit";
			this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditUndo,
            this.toolStripSeparator3,
            this.miEditCut,
            this.miEditCopy,
            this.miEditPaste,
            this.miEditDelete,
            this.toolStripSeparator4,
            this.miEditSelectAll,
            this.toolStripSeparator5,
            this.miEditShowEncryptedText});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// miEditUndo
			// 
			this.miEditUndo.Name = "miEditUndo";
			this.miEditUndo.Size = new System.Drawing.Size(181, 22);
			this.miEditUndo.Text = "Undo";
			this.miEditUndo.Click += new System.EventHandler(this.miEditUndo_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
			// 
			// miEditCut
			// 
			this.miEditCut.Name = "miEditCut";
			this.miEditCut.Size = new System.Drawing.Size(181, 22);
			this.miEditCut.Text = "Cut";
			this.miEditCut.Click += new System.EventHandler(this.miEditCut_Click);
			// 
			// miEditCopy
			// 
			this.miEditCopy.Name = "miEditCopy";
			this.miEditCopy.Size = new System.Drawing.Size(181, 22);
			this.miEditCopy.Text = "Copy";
			this.miEditCopy.Click += new System.EventHandler(this.miEditCopy_Click);
			// 
			// miEditPaste
			// 
			this.miEditPaste.Name = "miEditPaste";
			this.miEditPaste.Size = new System.Drawing.Size(181, 22);
			this.miEditPaste.Text = "Paste";
			this.miEditPaste.Click += new System.EventHandler(this.miEditPaste_Click);
			// 
			// miEditDelete
			// 
			this.miEditDelete.Name = "miEditDelete";
			this.miEditDelete.Size = new System.Drawing.Size(181, 22);
			this.miEditDelete.Text = "Delete";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
			// 
			// miEditSelectAll
			// 
			this.miEditSelectAll.Name = "miEditSelectAll";
			this.miEditSelectAll.Size = new System.Drawing.Size(181, 22);
			this.miEditSelectAll.Text = "Select all";
			this.miEditSelectAll.Click += new System.EventHandler(this.miEditSelectAll_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
			// 
			// miEditHideEncryptedText
			// 
			this.miEditShowEncryptedText.CheckOnClick = true;
			this.miEditShowEncryptedText.Name = "miEditHideEncryptedText";
			this.miEditShowEncryptedText.Size = new System.Drawing.Size(181, 22);
			this.miEditShowEncryptedText.Text = "Show encrypted text";
			this.miEditShowEncryptedText.Click += new System.EventHandler(this.miEditHideEncryptedText_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// miHelpAbout
			// 
			this.miHelpAbout.Name = "miHelpAbout";
			this.miHelpAbout.Size = new System.Drawing.Size(116, 22);
			this.miHelpAbout.Text = "About...";
			this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "TextCrypt file (*.textcrypt)|*.textcrypt|Text file (*.txt)|*.txt";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "TextCrypt file (*.textcrypt)|*.textcrypt|Text file (*.txt)|*.txt";
			// 
			// FormMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 361);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "FormMain";
			this.Text = "TextCrypter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miFileOpen;
		private System.Windows.Forms.ToolStripMenuItem miFileSave;
		private System.Windows.Forms.ToolStripMenuItem miFileClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem miFileExit;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
		private System.Windows.Forms.ToolStripMenuItem miFileSaveAs;
		private System.Windows.Forms.ToolStripMenuItem miFileSetKey;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem miFileNew;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miEditUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem miEditCut;
		private System.Windows.Forms.ToolStripMenuItem miEditCopy;
		private System.Windows.Forms.ToolStripMenuItem miEditPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem miEditSelectAll;
		private System.Windows.Forms.ToolStripMenuItem miEditDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem miEditShowEncryptedText;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}

