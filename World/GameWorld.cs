namespace RPG_system.World
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * 
	 * This is the main class of shares in the world
	 * 
	 */

	using RPG_system.Entitie;
	using RPG_system.Layout;
	using RPG_system.Translator;
	using System;

	internal class GameWorld
	{
		private int OldID;
		private int NewID;
		public static Dictionary<decimal, EntitieCreationAtribute> Entities = new Dictionary<decimal, EntitieCreationAtribute>();


		public GameWorld()
		{
			OldID = 0;

			Mobs();

			GameWorldMain();
		}


		private int IDGenerator()
		{
			NewID = OldID + 1;
			OldID = NewID;
			
			return NewID;
		}


		private void Mobs()
		{
			int xID = IDGenerator();
			Entities.Add(xID, Race.ChoiseRace(1, xID, "Ogre", 150.00M));
		}


		public static void EntitieIsDie(int ID) => Entities.Remove(ID);


		public void ShowEntities()
		{
			foreach (var entity in Entities)
			{
				Console.WriteLine($"{entity.Key} = {entity.Value._cretureName}");
			}
		}


		//Scene
		private void GameWorldMain()
		{
			string namePlayer = Entities[00]._cretureName;

			Console.WriteLine($"{namePlayer} It's just a traveler wandering through a dense and heavy forest.");
			Console.WriteLine($"{namePlayer} hears a noise coming from the bushes, when suddenly he sees a rabbit,");
			Console.WriteLine($"at that instant his belly starts to growl.");
			Console.WriteLine($"you decide to go after the rabbit and suddenly you come across a huge and hungry Ogre");
			Console.WriteLine($"who grabs your prey and rips off its head with his mouth. But you are strong and decide to attack him.");

			Layout.PressZtoContinue();

			Battle();
		
		}


		private void Battle()
		{
			EntitieCreationAtribute player = Entities[0];
			EntitieCreationAtribute Monster = Entities[1];

			Entities[1].NextLevel(100);


			while (true)
			{
				if (Entities.ContainsKey(0))
				{
					Battle01(player, Monster);
				}
				else
				{
					DisplayBox.Box("You die", ConsoleColor.Red, ConsoleColor.Red);
					Layout.PressZtoContinue();
					Environment.Exit(0);
				}

				if (Entities.ContainsKey(1))
				{
					Battle01(Monster, player);
				}
				else
				{
					DisplayBox.Box("You have defeated the ogre and can now feed on the hunt.", ConsoleColor.Green, ConsoleColor.Green);
					Layout.PressZtoContinue();
					Environment.Exit(0);
				}
			}
		}

		private void Battle01(EntitieCreationAtribute entitie, EntitieCreationAtribute entitie2)
		{
			DisplayBox.Box($"{entitie._cretureName} attack", ConsoleColor.Red, ConsoleColor.Red);
			entitie2.ReceiveDamage(entitie);
			Layout.PressZtoContinue();

			entitie2.ShowConsoleAtributes();

			DisplayBox.Box($"{entitie2._cretureName} Life: {entitie2.Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue]}", ConsoleColor.Red, ConsoleColor.Red);
			Layout.PressZtoContinue();
		}
	}
}
