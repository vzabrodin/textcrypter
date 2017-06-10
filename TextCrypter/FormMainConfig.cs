using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TextCrypter
{
	class FormMainConfig
	{
		private static string _registrySubKey = "SOFTWARE\\TextCrypter";

		private bool _wordWrap;
		private bool _showEncryptedText;
		private Font _font;

		public bool WordWrap
		{
			get
			{
				return _wordWrap;
			}
			set
			{
				_wordWrap = value;
				Save();
			}
		}

		public bool ShowEncryptedText
		{
			get
			{
				return _showEncryptedText;
			}
			set
			{
				_showEncryptedText = value;
				Save();
			}
		}

		public Font Font
		{
			get
			{
				return _font;
			}
			set
			{
				_font = value;
				Save();
			}
		}

		public FormMainConfig() : this(false, false, new Font(FontFamily.GenericMonospace, 10))
		{
		}

		public FormMainConfig(bool wordWrap, bool showEncryptedText, Font font)
		{
			_wordWrap = wordWrap;
			_showEncryptedText = showEncryptedText;
			_font = font;
		}

		public void Save()
		{
			var key = Registry.CurrentUser.CreateSubKey(_registrySubKey);
			key.SetValue("WordWrap", _wordWrap ? 1 : 0);
			key.SetValue("ShowEncryptedText", _wordWrap ? 1 : 0);
			key.SetValue("Font", new FontConverter().ConvertToString(_font));
			key.Close();
		}

		public static FormMainConfig FromRegistry()
		{
			var key = Registry.CurrentUser.CreateSubKey(_registrySubKey);

			bool wordWrap = (int)key.GetValue("WordWrap", 0) != 0;
			bool showEncText = (int)key.GetValue("ShowEncryptedText", 0) != 0;

			var tmp = key.GetValue("Font");
			Font font;
			if (tmp == null)
			{
				font = new Font(FontFamily.GenericMonospace, 10);
			}
			else
			{
				font = (Font)(new FontConverter().ConvertFromString((string)tmp));
			}
			return new FormMainConfig(wordWrap, showEncText, font);
		}
	}
}