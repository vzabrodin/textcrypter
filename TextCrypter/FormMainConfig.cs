using Microsoft.Win32;
using System;
using System.Drawing;

namespace TextCrypter
{
    class FormMainConfig
    {
        private const string RegistrySubKey = @"SOFTWARE\TextCrypter";

        private bool wordWrap;
        private bool showEncryptedText;
        private Font font;

        public bool WordWrap
        {
            get => wordWrap;
            set
            {
                wordWrap = value;
                Save();
            }
        }

        public bool ShowEncryptedText
        {
            get => showEncryptedText;
            set
            {
                showEncryptedText = value;
                Save();
            }
        }

        public Font Font
        {
            get => font;
            set
            {
                font = value;
                Save();
            }
        }

        public FormMainConfig(bool wordWrap, bool showEncryptedText, Font font)
        {
            this.wordWrap = wordWrap;
            this.showEncryptedText = showEncryptedText;
            this.font = font;
        }

        public void Save()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistrySubKey))
            {
                key?.SetValue("WordWrap", wordWrap ? 1 : 0);
                key?.SetValue("ShowEncryptedText", showEncryptedText ? 1 : 0);
                key?.SetValue("Font",
                    new FontConverter().ConvertToString(font) ?? throw new InvalidOperationException());
            }
        }

        public static FormMainConfig Default() =>
            new FormMainConfig(false, false, new Font(FontFamily.GenericMonospace, 10));

        public static FormMainConfig FromRegistry()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistrySubKey))
            {
                bool wordWrap = (int) (key?.GetValue("WordWrap") ?? 0) != 0;
                bool showEncText = (int) (key?.GetValue("ShowEncryptedText") ?? 0) != 0;

                string fontString = key?.GetValue("Font")?.ToString();

                Font font = String.IsNullOrWhiteSpace(fontString)
                    ? new Font("Consolas", 10)
                    : new FontConverter().ConvertFromString(fontString) as Font;

                return new FormMainConfig(wordWrap, showEncText, font);
            }
        }
    }
}
