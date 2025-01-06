namespace RPG_system.Entitie
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * this class will define the race of the entity...
	 * 
	 * 515 points must be distributed!!!
	 * 
	 */


	internal class Race
	{

		public EntitieCreationAtribute ChoiseRace(byte choise, decimal id, string name, decimal weight)
		{
			switch(choise)
			{
				default: // Human
					return new EntitieCreationAtribute(id, name, weight, 100, 100, 100, 050, 020, 020, 020, 020, 005, 020, 020, 020, 020);

				case 1: // Ogro
					return new EntitieCreationAtribute(id, name, weight, 150, 100, 005, 005, 100, 015, 010, 050, 010, 050, 010, 005, 005);

				case 2: // Spectral Knight
					return new EntitieCreationAtribute(id, name, weight, 100, 000, 100, 050, 010, 050, 025, 000, 010, 040, 030, 050, 050);
			}
		}
	}
}
