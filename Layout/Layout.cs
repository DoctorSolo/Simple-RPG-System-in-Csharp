namespace RPG_system.Layout
{
	using RPG_system.EntitieCreationAtribute;
	using RPG_system.Entitie.Races;
	using RPG_system.World;
	using RPG_system.Translator;
	using RPG_system.Layout;
	using System.Xml.Linq;

	internal class Layout
	{
		private static string Name;


		public static void ChoiseYourPlayer()
		// MAIN HERE		
		{

			EnterYourName();

			ChoiseYourRace();
		}


		private static void PressZtoContinue()
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
		{
			DisplayBox.Box(Idioma._indYourName, ConsoleColor.Green, ConsoleColor.Magenta, true, false);
			Name = DisplayBox.TextRead;

			DisplayBox.Box(Idioma._welcomeMessage, ConsoleColor.Green, ConsoleColor.DarkYellow, false, false, ConsoleColor.Black, Name, null, ConsoleColor.Blue);
			PressZtoContinue();
		}


		private static void ChoiseYourRace()
		{
			DisplayBox.Box(Idioma._choiseYourRaceT, ConsoleColor.Green, ConsoleColor.Green, false, true, ConsoleColor.Black, "", Idioma._indChoiseRace);
			GameWorld.Entities.Add(00, new Race().ChoiseRace((byte)DisplayBox.ChoiseRead, 00, Name, 60.00M));
			PressZtoContinue();
		}
	
	}
}
