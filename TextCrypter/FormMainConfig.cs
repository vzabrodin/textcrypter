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

		public FormMainConfig()
		{
			_wordWrap = false;
			_font = new Font(FontFamily.GenericMonospace, 10);
		}

		public void Save()
		{
			string q = _font.ToString();
			var w = _font.ToHfont();
			/*
			var key = Registry.CurrentUser.CreateSubKey(_registrySubKey);
			key.SetValue("WordWrap", _wordWrap ? 1 : 0);
			key.SetValue("FontName", _font);
			key.Close();
			*/
		}

		public static FormMainConfig FromRegistry()
		{
			return new FormMainConfig();
		}
	}
}
