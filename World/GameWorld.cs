namespace RPG_system.World
{
	using EntitieCreationAtribute;
	using RPG_system.Entitie.Races;
	using RPG_system.Entitie.ClassSystem;

	internal class GameWorld
	{
		private decimal OldID;
		private decimal NewID;
		public static Dictionary<decimal, EntitieCreationAtribute> Entities = new Dictionary<decimal, EntitieCreationAtribute>();


		public GameWorld()
		{
			OldID = 0;

			Mobs();
		}


		private decimal IDGenerator()
		{
			NewID = OldID + 1;
			OldID = NewID;
			
			return NewID;
		}


		private void Mobs()
		{
			decimal xID = IDGenerator();
			Entities.Add(xID, new Race().ChoiseRace(1, xID, "Ogro", 150.00M));
		}


		public static void EntitieIsDie(decimal ID) => Entities.Remove(ID);


		public void ShowEntities()
		{
			foreach (var entity in Entities)
			{
				Console.WriteLine($"{entity.Key} = {entity.Value._cretureName}");
			}
		}
	}
}
