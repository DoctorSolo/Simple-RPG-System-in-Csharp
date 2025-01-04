namespace RPG_system.Entitie.Races
{
	using EntitieCreationAtribute;
	internal class Race
	{

		public EntitieCreationAtribute ChoiseRace(byte choise, decimal id, string name, decimal weight)
		{
			switch(choise)
			{
				default: // Human
					return new EntitieCreationAtribute(id, name, weight, 50, 50, 50, 40, 20, 20, 20, 20, 5, 5, 10, 10, 20);
			}
		}
	}
}
