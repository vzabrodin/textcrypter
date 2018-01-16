using System;
using System.Windows.Forms;

namespace TextCrypter
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			switch (args.Length)
			{
				case 1:
					Application.Run(new FormMain(args[0]));
					break;
				default:
					Application.Run(new FormMain());
					break;
			}
		}
	}
}
