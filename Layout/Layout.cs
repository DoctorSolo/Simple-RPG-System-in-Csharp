namespace RPG_system.Layout
{
	using RPG_system.EntitieCreationAtribute;
	using RPG_system.Entitie.Races;
	using RPG_system.World;
	using System.Xml.Linq;

	internal class Layout
	{
		public static string[] _indiomaLayout = ["Enter your name: ", "WELCOME to the game ", "\nPRESS 'Z' TO CONTINUE", "Choise your race: ", "0. Human"];
		private static string _indYourName = _indiomaLayout[0];
		private static string _welcomeMessage = _indiomaLayout[1];
		private static string _pressZText = _indiomaLayout[2];
		private static string _choiseYourRaceT = _indiomaLayout[3];
		private static string _choiseYourRaceHumanT = _indiomaLayout[4];


		private static string? Name;

		private static void EnterYourName()
		{
			Console.BackgroundColor = ConsoleColor.Cyan;

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(_indYourName);
			Name = Console.ReadLine();
			Console.Clear();
			Console.Write(_welcomeMessage);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write($"{Name}\n");

			PressZtoContinue();
		}


		public static void ChoiseYourPlayer()
		{
			EnterYourName();

			ChoiseYourRace();
		}

		private static void PressZtoContinue()
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(_pressZText);
			
			ConsoleKeyInfo key;
			do
			{
				key = Console.ReadKey(true);
			}
			while (key.Key != ConsoleKey.Z);
			Console.Clear();
		}


		private static void ChoiseYourRace()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(_choiseYourRaceT);
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(_choiseYourRaceHumanT);

			ConsoleKeyInfo key;
			byte number;

			do
			{
				key = Console.ReadKey(true);
				number = (byte)char.GetNumericValue(key.KeyChar);

			}
			while(number != 0);

			GameWorld.Entities.Add(00, new Race().ChoiseRace(number, 00, Name, 60.00M));

			Console.Clear();
		}
	
	}
}
