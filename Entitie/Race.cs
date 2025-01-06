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
					return new EntitieCreationAtribute(id, name, weight, 050, 050, 050, 040, 020, 020, 020, 020, 005, 005, 010, 010, 020);

				case 1: // Ogro
					return new EntitieCreationAtribute(id, name, weight, 100, 100, 005, 005, 050, 010, 010, 050, 010, 010, 005, 005, 005);
			}
		}
	}
}
