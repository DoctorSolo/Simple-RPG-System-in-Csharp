namespace RPG_system.Layout
{
	using System;
	internal class DisplayBox
	{
		private static int Heights = 0;

		public static string TextRead = "";
		public static int ChoiseRead = 0;

		// Get Position
		private static int left;
		private static int top;


		public static void Box(string message, ConsoleColor BorderColor, ConsoleColor TitleColor, bool NeedRead = false, 
			bool NeedChoise = false, ConsoleColor BackColor = ConsoleColor.Black, string specialMessage="", string[] caseIsChoise = null, 
			ConsoleColor specilaMessageColor=ConsoleColor.Red)
		{
			// Get Measurements
			int messageLenght = (specialMessage == "" || specialMessage == null) ? message.Length : message.Length + specialMessage.Length;
			int BoxWidth = messageLenght + 4;

			// Get Position
			int left = (Console.WindowWidth - BoxWidth) / 2;
			int top = (Console.WindowHeight / 2);

			do
			{
				Console.Clear();

				Console.BackgroundColor = BackColor;

				// Up border
				Border('+', '=', BoxWidth, BorderColor);

				BorderSpaceChar("| ", BoxWidth - 2, " |", BorderColor);

				BorderSpaceString("| ", BoxWidth, " |", BorderColor, message, messageLenght, TitleColor, specialMessage, specilaMessageColor);

				BorderSpaceChar("| ", BoxWidth - 2, " |", BorderColor);

				Border('+', '=', BoxWidth, BorderColor);

				if (NeedRead)
				{
					NeedRead = ReadBox();
				}
				if (NeedChoise)
				{
					NeedChoise = ChoiseBox(caseIsChoise[ChoiseRead], BoxWidth, caseIsChoise);
				}
			} while (NeedRead || NeedChoise);
		}


		private static void Border(Char Tip, Char Width, int BoxWidth, ConsoleColor BorderColor=ConsoleColor.White)
		{
			Console.ForegroundColor = BorderColor;
			Console.Write(Tip);
			Console.Write(new string(Width, BoxWidth));
			Console.WriteLine(Tip);
		}


		private static void BorderSpaceChar(string Tip1, int BoxWidth, string Tip2, ConsoleColor BorderC, char Width = ' ', ConsoleColor WidthC=ConsoleColor.Black)
		{
			Console.Write(Tip1);
			Console.ForegroundColor = BorderC;
			Console.Write(new string(Width, BoxWidth));
			Console.WriteLine(Tip2);
		}


		private static void BorderSpaceString(string Tip1, int BoxWidth, string Tip2, ConsoleColor BorderC, string message,
			int messageLenght, ConsoleColor messageColor = ConsoleColor.White, string specialMessage="", ConsoleColor specialMessageColor = ConsoleColor.Red)
		{
			if (specialMessage == "" || specialMessage == null)
			{
				Console.Write(Tip1);
				Console.ForegroundColor = messageColor;
				Console.Write(message.PadRight(messageLenght + 2));
				Console.ForegroundColor = BorderC;
				Console.WriteLine(Tip2);
			}
			else
			{
				Console.Write(Tip1);
				Console.ForegroundColor = messageColor;
				Console.Write(message.PadRight(messageLenght + 2 - specialMessage.Length + 2));
				Console.ForegroundColor = specialMessageColor;
				Console.Write(specialMessage.PadRight(messageLenght + 2 - message.Length + 2));
				Console.ForegroundColor = BorderC;
				Console.WriteLine(Tip2);
			}
		}


		private static bool ReadBox()
		{
			int BoxWidth = TextRead.Length + 4;
			Border('+', '=', BoxWidth, ConsoleColor.Red);
			BorderSpaceString("| ", BoxWidth, " |", ConsoleColor.Red, TextRead, TextRead.Length, ConsoleColor.Red);
			Border('+', '=', BoxWidth, ConsoleColor.Red);

			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			ConsoleKey key = keyInfo.Key;
			char keyChar = keyInfo.KeyChar;

			if (key == ConsoleKey.Enter && TextRead.Length > 0)
			{
				return false;
			}
			else if (char.IsLetterOrDigit(keyChar) || key == ConsoleKey.Spacebar)
			{
				TextRead += keyChar;
				
			}
			else if (key == ConsoleKey.Backspace && TextRead.Length > 0)
			{
				TextRead = TextRead.Substring(0, TextRead.Length - 1);
			}
			return true;
		}


		private static bool ChoiseBox(string Message, int BoxWidth, string[] Options)
		{
			int i = 4;
			Border('+', '=', BoxWidth, ConsoleColor.Red);
			foreach (string Option in Options)
			{
				Message = (Options[ChoiseRead] == Option)? $">> {Option}" : Option;
				
				BorderSpaceString("| ", BoxWidth, " |", ConsoleColor.Red, Message, BoxWidth - 4, ConsoleColor.Red);
				i++;
			}
			Border('+', '=', BoxWidth, ConsoleColor.Red);

			ConsoleKey Key = Console.ReadKey(true).Key;
			if (Key == ConsoleKey.UpArrow)
			{
				ChoiseRead --;
				if (ChoiseRead < 0) ChoiseRead = Options.Length - 1;
			}
			if (Key == ConsoleKey.DownArrow)
			{
				ChoiseRead ++;
				if (ChoiseRead > Options.Length - 1) ChoiseRead = 0;
			}
			if (Key == ConsoleKey.Enter) return false;
			return true;
		}
	}
}
