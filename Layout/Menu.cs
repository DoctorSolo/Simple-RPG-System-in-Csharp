namespace RPG_system.Layout
{
	using System;
	using System.Threading;
	using RPG_system.Layout;
	using RPG_system.Translator;


	internal class Menu
	{
		private static int Selection = 0;

		public static void InterfacePlay()
		{

			Prohibited();

			while(true)
			{
				HomeMenu();
			}
		}


		private static void Prohibited()
		{
			Console.Clear();

			string Message1 = "██████╗░░█████╗░░█████╗░████████╗░█████╗░██████╗░  ░██████╗░█████╗░██╗░░░░░░█████╗░";
			string Message2 = "██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗  ██╔════╝██╔══██╗██║░░░░░██╔══██╗";
			string Message3 = "██║░░██║██║░░██║██║░░╚═╝░░░██║░░░██║░░██║██████╔╝  ╚█████╗░██║░░██║██║░░░░░██║░░██║";
			string Message4 = "██║░░██║██║░░██║██║░░██╗░░░██║░░░██║░░██║██╔══██╗  ░╚═══██╗██║░░██║██║░░░░░██║░░██║";
			string Message5 = "██████╔╝╚█████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║  ██████╔╝╚█████╔╝███████╗╚█████╔╝";
			string Message6 = "╚═════╝░░╚════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝  ╚═════╝░░╚════╝░╚══════╝░╚════╝░";

			int delay = 200; // Milissecond Animation Time
			byte loopAnimation = 1; // Loop Animation

			for (byte i = 0; i < loopAnimation; i++)
			{
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.DarkRed);
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.Cyan);
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.DarkYellow);
				Thread.Sleep(delay);
			}
		}


		private static void DisplayMessage(string message1, string message2, string message3, string message4, string message5, string message6, int delay,
			ConsoleColor TextColor)
		{
			// Exibe the Color
			Console.ForegroundColor = TextColor;

			// Exibe The Message
			CenterMessage(message1, -3);
			CenterMessage(message2, -2);
			CenterMessage(message3, -1);
			CenterMessage(message4, 0);
			CenterMessage(message5, 1);
			CenterMessage(message6, 2);

			Thread.Sleep( delay );
		}


		private static void CenterMessage(string message, int HowHeight=0)
		{
			// Calculate Cental message
			int left = (Console.WindowWidth - message.Length) / 2;
			int top = (Console.WindowHeight / 2) + HowHeight;

			// Center cursor
			Console.SetCursorPosition(left, top);

			// WriteTheTexto
			Console.WriteLine(message);
		}


		private static void HomeMenu()
		{
			DisplayBox.Box(Idioma.NameHomeMenu, ConsoleColor.Green, ConsoleColor.DarkGreen, false, true, ConsoleColor.Black, "", Idioma.Menus);
			Selection = DisplayBox.ChoiseRead;

			switch (Selection)
			{
				case 0:
					HomeMenuPlay();
					break;
				case 1:
					HomeMenuLanguage();
					break;
				default:
					HomeMenuExit();
					break;
			}
		}


		private static void HomeMenuLanguage()
		{
			DisplayBox.Box(Idioma.ChoiseYourLanguage, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, false, true, ConsoleColor.Black, "", Idioma.ChoiseIndioma);
			Idioma.SetLanguage((byte)DisplayBox.ChoiseRead);
		}


		private static void HomeMenuExit()
		{
			Environment.Exit(0);
		}


		private static void HomeMenuPlay()
		{
			Layout.ChoiseYourPlayer();
		}
	}
}
