namespace RPG_system.Entitie
{
	/*
	 * @DOCTOR SOLO
	 * 
	 * In this code, 
	 * I work with a simple list to change the Bonus in the Atribute Dictionary in the {EntitieCreationAtribute} class.
	 * 
	 * All list will be RPG class only.
	 */
	internal class ClassSystem
	{
		/* 
		 * Correct order: 
		 * [Level, Weight, Life, Histamine, Mana, Inventor, Phisical Defense, Phisical Damage, Magical Damage, Magical Defense, Att Speed,
		 * Strenght, Critical Chance, Critical Damage, Mov Speed, Magic Proficience, Magical Att];
		 * 
		 * distribution:
		 * 120 pt
		*/

		public static decimal[] Warrior = [/*Level*/1.0M,/*Weight*/1.0M,/*Life*/1.3M,/*Histamine*/1.3M,/*Mana*/0.9M,/*Inventor*/1.0M,
			/*PhisicalDefense*/1.2M,/*PhisicalDamage*/1.0M,/*MagicalDamage*/1.0M,/*MagicalDefense*/0.9M,/*Att Speed*/1.0M,/*Strenght*/1.4M,
			/*CriticalChance*/1.0M,/*CriticalDamage*/1.4M,/*MovSpeed*/1.0M,/*MagicProficience*/0.9M,/*MagicalAtt*/0.9M];

		public static decimal[] Wizard = [/*Level*/1.0M,/*Weight*/1.0M,/*Life*/1.0M,/*Histamine*/0.9M,/*Mana*/1.3M,/*Inventor*/1.3M,
			/*PhisicalDefense*/0.1M,/*PhisicalDamage*/1.0M,/*MagicalDamage*/1.0M,/*MagicalDefense*/1.3M,/*Att Speed*/1.0M,/*Strenght*/0.8M,
			/*CriticalChance*/1.0M,/*CriticalDamage*/1.0M,/*MovSpeed*/1.0M,/*MagicProficience*/1.4M,/*MagicalAtt*/1.2M];

		public static decimal[] Assassin = [/*Level*/1.0M,/*Weight*/1.0M,/*Life*/0.8M,/*Histamine*/1.1M,/*Mana*/1.1M,/*Inventor*/1.1M,
			/*PhisicalDefense*/0.8M,/*PhisicalDamage*/1.0M,/*MagicalDamage*/1.0M,/*MagicalDefense*/0.8M,/*Att Speed*/1.5M,/*Strenght*/1.2M,
			/*CriticalChance*/1.0M,/*CriticalDamage*/1.4M,/*MovSpeed*/1.0M,/*MagicProficience*/1.2M,/*MagicalAtt*/1.2M];


		public static decimal[] ChoiseYourClass(byte choose)
		{
			switch(choose)
			{
				default:
					return Warrior;
				
				case 1:
					return Wizard;

				case 2:
					return Assassin;
			}
		}
	}
}
