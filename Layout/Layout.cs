namespace RPG_system.Layout
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * 
	 * Here you have the base architecture for menus...
	 * 
	 */

	using System;
	using System.Threading;
	using RPG_system.Entitie;
	using RPG_system.World;
	using RPG_system.Translator;

	internal static class Layout
	{
		private static string? _playerName;


		public static void ChoiseYourPlayer()
		/*
		 * This method starts the methods for the user to create their character...
		 * 
		 */
		{
			EnterYourName();

			ChoiseYourRace();
		}


		public static void PressZtoContinue()
		/*
		 * If Z is pressed, the step will continue...
		 * 
		 */
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(Idioma._pressZText);
			
			ConsoleKeyInfo key;
			do
			{
				key = Console.ReadKey(true);
			}
			while (key.Key != ConsoleKey.Z);
			Console.Clear();
		}




		private static void EnterYourName()
		/*
		 * Read your name and show welcome message...
		 * 
		 */
		{
			DisplayBox.Box(Idioma._indYourName, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, true, false);

			_playerName = DisplayBox.TextRead;
			DisplayBox.Box($"{Idioma._welcomeMessage}{_playerName}", ConsoleColor.Green, ConsoleColor.DarkGreen);
			PressZtoContinue();
		}


		private static void ChoiseYourRace()
		/*
		 * Set race..
		 * 
		 */
		{
			DisplayBox.Box(Idioma._choiseYourRaceT, ConsoleColor.Green, ConsoleColor.Green, false, true, ConsoleColor.Black, "", Idioma._indChoiseRace);
			GameWorld.Entities.Add(00, Race.ChoiseRace((byte)DisplayBox.ChoiseRead, 0, _playerName, 60.00M));
			PressZtoContinue();
		}





		public static void Prohibited()
		/*
		 * This method adds an animation when starting...
		 * 
		 */
		{
			Console.Clear();

			string Message1 = "██████╗░██╗░░░██╗  ██████╗░░█████╗░░█████╗░████████╗░█████╗░██████╗░  ░██████╗░█████╗░██╗░░░░░░█████╗░";
			string Message2 = "██╔══██╗╚██╗░██╔╝  ██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗  ██╔════╝██╔══██╗██║░░░░░██╔══██╗";
			string Message3 = "██████╦╝░╚████╔╝░  ██║░░██║██║░░██║██║░░╚═╝░░░██║░░░██║░░██║██████╔╝  ╚█████╗░██║░░██║██║░░░░░██║░░██║";
			string Message4 = "██╔══██╗░░╚██╔╝░░  ██║░░██║██║░░██║██║░░██╗░░░██║░░░██║░░██║██╔══██╗  ░╚═══██╗██║░░██║██║░░░░░██║░░██║";
			string Message5 = "██████╦╝░░░██║░░░  ██████╔╝╚█████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║  ██████╔╝╚█████╔╝███████╗╚█████╔╝";
			string Message6 = "╚═════╝░░░░╚═╝░░░  ╚═════╝░░╚════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝  ╚═════╝░░╚════╝░╚══════╝░╚════╝░";

			int delay = 200; // Milissecond Animation Time
			byte loopAnimation = 2; // Loop Animation

			for (byte i = 0; i < loopAnimation; i++)
			{
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.DarkRed);
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.Red);
				Console.Clear();
				DisplayMessage(Message1, Message2, Message3, Message4, Message5, Message6, delay, ConsoleColor.Yellow);
				Thread.Sleep(delay);
			}
		}


		private static void DisplayMessage(string message1, string message2, string message3, string message4, string message5, string message6, int delay,
			ConsoleColor TextColor)
		/*
		 * This method has animation...
		 * 
		 */
		{
			// Exibe the Color
			Console.ForegroundColor = TextColor;

			// Exibe The Message
			CenterMessage(message1, -3);
			Thread.Sleep(delay);
			CenterMessage(message2, -2);
			Thread.Sleep(delay);
			CenterMessage(message3, -1);
			Thread.Sleep(delay);
			CenterMessage(message4, 0);
			Thread.Sleep(delay);
			CenterMessage(message5, 1);
			Thread.Sleep(delay);
			CenterMessage(message6, 2);

			Thread.Sleep(delay);
		}


		private static void CenterMessage(string message, int HowHeight = 0)
		/*
		 * responsible for centralizing the animation...
		 * 
		 */
		{
			// Calculate Cental message
			int left = (Console.WindowWidth - message.Length) / 2;
			int top = (Console.WindowHeight / 2) + HowHeight;

			// Center cursor
			Console.SetCursorPosition(left, top);

			// WriteTheTexto
			Console.WriteLine(message);
		}


		public static void HomeMenu()
		/*
		 * Draw home menu...
		 * 
		 */
		{
			DisplayBox.Box(Idioma.NameHomeMenu, ConsoleColor.Green, ConsoleColor.DarkGreen, false, true, ConsoleColor.Black, "", Idioma.Menus);

			switch (DisplayBox.ChoiseRead)
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
		/*
		 * Draw menu language...
		 * 
		 */
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
