namespace RPG_system.EntitieCreationAtribute
{
	/*
     *  @DOCTOR SOLO
     *
     *  This code will work with a dictionary with, base value (it's a initial value of atributes), 
     *  bonus (it's add a percentage of the initial value) and total value (it's a result of "bonus" in "base value").
     *
     *  Each race has unique value, and each class has unique bonus. Usable items has bonus too, the bonus is what 
     *  will make you strong.
     *
     *  The level increases all atributes.
    */

	using RPG_system.World;
    using RPG_system.Translator;


	internal class EntitieCreationAtribute
    {

		#region Main Variables
		public string _cretureName { get; } // Name of the creature
        public decimal _id { get; } // ID of the creature

		private int _level = 0; // Level of the creature

		// VALUE BUFF/DEBUFF
		private decimal _debuff => 0.10M;
        private decimal _buff => 1.10M;
        private decimal _bonusLevel => 1.10M;

        // Main Dictionary Instance
        public Dictionary<string, Dictionary<string, decimal>> Atributes = new Dictionary<string, Dictionary<string, decimal>>();
		#endregion


		private void MakeAtributes(byte i=0)
	    /*
         * CREATING ATRIBUTE METHOD
         *
         *
         * This method need loand a extext for a internal dictionary...
         *
         */
		{
			if (i < Idioma._atributesName.Length)
            {
				Atributes[Idioma._atributesName[i]] = new Dictionary<string, decimal>();
                Atributes[Idioma._atributesName[i]][Idioma._InfoNameTotalValue] = new decimal();
                Atributes[Idioma._atributesName[i]][Idioma._InfoNameBonus] = new decimal();
                Atributes[Idioma._atributesName[i]][Idioma._infoNameBaseValue] = new decimal();
                i ++;
                MakeAtributes(i);
            }
        }


        // ADD ALL VALUE IN ATRIBUTES...
        public EntitieCreationAtribute(decimal id, string Name, decimal Weight, decimal Life, decimal Histamine, decimal Mana, decimal Inventor,
           decimal PhisicalDefense, decimal MagicalDefense, decimal AttSpeed, decimal Strenght, decimal CriticalChance, 
           decimal CriticalDamage, decimal MovSpeed, decimal MagicProficience, decimal MagicalAttk)
        {
            MakeAtributes(); // Create main dictionary...

            // Creature Name and ID...
            _cretureName = Name;
            _id = id;

            // Attributes...
			Atributes[Idioma._nameLevel]           [Idioma._infoNameBaseValue] = _level;
			Atributes[Idioma._nameWeight]          [Idioma._infoNameBaseValue] = Weight;
			Atributes[Idioma._nameLife]            [Idioma._infoNameBaseValue] = Life;
            Atributes[Idioma._nameHistamine]       [Idioma._infoNameBaseValue] = Histamine;
            Atributes[Idioma._nameMana]            [Idioma._infoNameBaseValue] = Mana;
            Atributes[Idioma._nameInventor]        [Idioma._infoNameBaseValue] = Inventor;
            Atributes[Idioma._namePhisicalDe]      [Idioma._infoNameBaseValue] = PhisicalDefense;
            Atributes[Idioma._nameMagicalDe]       [Idioma._infoNameBaseValue] = MagicalDefense;
            Atributes[Idioma._nameAttSpeed]        [Idioma._infoNameBaseValue] = AttSpeed;
            Atributes[Idioma._nameStrenght]        [Idioma._infoNameBaseValue] = Strenght;
            Atributes[Idioma._nameCriticalChance]  [Idioma._infoNameBaseValue] = CriticalChance;
            Atributes[Idioma._nameCriticalDa]      [Idioma._infoNameBaseValue] = CriticalDamage;
            Atributes[Idioma._nameMovSpeed]        [Idioma._infoNameBaseValue] = MovSpeed;
            Atributes[Idioma._nameMagicP]          [Idioma._infoNameBaseValue] = MagicProficience;
            Atributes[Idioma._nameMagicalAtt]      [Idioma._infoNameBaseValue] = MagicalAttk;

            // Set all bonus in value 1, so as not be empty...
            foreach (string atribute in Idioma._atributesName) Atributes[atribute][Idioma._InfoNameBonus] = 1;

            // Set Imutable attributes...
            foreach (string atribute in Idioma._atributesName) 
                Atributes[atribute][Idioma._InfoNameForLevel] = ((atribute != Idioma._nameLevel) && (atribute != Idioma._nameWeight) && 
                    (atribute != Idioma._namePhisicalDa) && (atribute != Idioma._nameMagicalDa)) ? 1 : 0;

            // Calculate others atributes...
            PhisicalDamageMethod(Idioma._infoNameBaseValue, _debuff);
            MagicalDamageMethod(Idioma._infoNameBaseValue, _debuff, _buff);
            WeightMethod(1);

            // Update Atributes...
            CalculateAtribute();
        }

		#region CALCULATE OTHERS ATTRIBUTES


		private decimal CalculateLevel(decimal BonusLevel) => (decimal)Math.Pow((double)BonusLevel, _level);
		// Here all atributes increase with level...


		private decimal IncreacedAtributeDamageDebuff(decimal Debuff, string Position) =>
		// Here some damage attributes will receive debuff...
			Atributes[Idioma._nameAttSpeed][Position] / (decimal)Math.Pow((double)Atributes[Idioma._nameAttSpeed][Position], (double)Debuff);


        private decimal IncreacedAtributeMagicaDamageBuff(decimal Buff, string Position) =>
        // Here some damage attribute will receive buff...
			(Buff - 1) * (Atributes[Idioma._nameInventor][Position] + Atributes[Idioma._nameMagicP][Position]);


        private decimal IncreacedAtributeDefeseBuff(decimal Buff, string Position) => (Buff - 1) * Atributes[Idioma._nameWeight][Position];
		// Here the phisical defense will receive buff for height...


		private void PhisicalDamageMethod(string position, decimal DebuffValue) =>
		// Here will receive debuff in phisicalDamage for velAttk...
			Atributes[Idioma._namePhisicalDa][position] = decimal.Round(
                Atributes[Idioma._nameStrenght][position] * IncreacedAtributeDamageDebuff(DebuffValue, position), 2);


		private void MagicalDamageMethod(string Position, decimal DebuffValue, decimal BuffValue) =>
        // Here will receive debuff in Magical Damage for velAttk and buff in Inteligence and Proficience...
            Atributes[Idioma._nameMagicalDa][Position] = decimal.Round(
                Atributes[Idioma._nameMagicalAtt][Position] * IncreacedAtributeDamageDebuff(_debuff, Position) *
                IncreacedAtributeMagicaDamageBuff(BuffValue, Position), 2);


        private void PhisicalDefenseMethod(string Position, decimal BuffValue) =>
        // Here will receive buff for weight...
            Atributes[Idioma._namePhisicalDe][Position] *= decimal.Round(IncreacedAtributeDefeseBuff(BuffValue, Position), 2);


        private void MagicalDefenseMethod(string Position, decimal Buff) =>
        // Here will receive buff for inteligente and proficience
            Atributes[Idioma._nameMagicalDe][Position] *= decimal.Round(IncreacedAtributeMagicaDamageBuff(Buff, Position), 2);


        private void WeightMethod(decimal BuffOrDebuff) =>
        // Here will receive buff or debuff
            Atributes[Idioma._nameWeight][Idioma._InfoNameTotalValue] = decimal.Round(
                Atributes[Idioma._nameWeight][Idioma._infoNameBaseValue] * BuffOrDebuff, 2);

		#endregion


		private void CalculateAtribute()
		/*
         * This is a important method, he calculate all atributes...
         * 
         */
		{
			foreach (string atrib in Idioma._atributesName) 
                if (Atributes[atrib][Idioma._InfoNameForLevel] == 1)
                    Atributes[atrib][Idioma._InfoNameTotalValue] = decimal.Round(
                        Atributes[atrib][Idioma._infoNameBaseValue] * Atributes[atrib][Idioma._InfoNameBonus] * CalculateLevel(_bonusLevel), 2);

            // Calculate others atributes...
            PhisicalDamageMethod(Idioma._InfoNameTotalValue, _debuff);
            MagicalDamageMethod(Idioma._InfoNameTotalValue, _debuff, _buff);
            PhisicalDefenseMethod(Idioma._InfoNameTotalValue, _buff);
            MagicalDefenseMethod(Idioma._InfoNameTotalValue, _buff);
        }


        public void NextLevel(byte level=1)
        // This method update all atributes for level
        {
            Atributes[Idioma._nameLevel][Idioma._InfoNameTotalValue] += level;
            CalculateAtribute();
        }


        public void ShowConsoleAtributes()
        // Show dictionary
        {
            Console.WriteLine($"\n{_cretureName}");
            
            foreach(string atribute in Atributes.Keys.ToList())
            {
                Console.WriteLine($"{atribute}:");
                foreach(var info in Atributes[atribute])
                {
                    Console.WriteLine($"{info.Key}: {info.Value}");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");
        }


        public void ClassForEntitie(decimal[] Atribute)
        /*
         * This method will add class to entity...
         * 
         */
        {
            for (byte i = 0; i < Idioma._atributesName.Length; i++)
            {
                Atributes[Idioma._atributesName[i]][Idioma._InfoNameBonus] *= Atribute[i];
            }
            CalculateAtribute();
        }


        public EntitieCreationAtribute ReceiveDamage(EntitieCreationAtribute Mobx)
        /*
         * This method is very important then it calculate damages, histamina and mana...
         * 
         */
		{
            decimal _histamineComption = (Atributes[Idioma._namePhisicalDe][Idioma._InfoNameTotalValue] + Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue])/
                Mobx.Atributes[Idioma._namePhisicalDa][Idioma._InfoNameTotalValue];
			decimal _manaComption = (Atributes[Idioma._nameMagicalDe][Idioma._InfoNameTotalValue] + Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue]) /
				Mobx.Atributes[Idioma._nameMagicalDa][Idioma._InfoNameTotalValue];

			if (Atributes[Idioma._namePhisicalDe][Idioma._InfoNameTotalValue] < Mobx.Atributes[Idioma._namePhisicalDa][Idioma._InfoNameTotalValue] &&
				Mobx.Atributes[Idioma._nameHistamine][Idioma._InfoNameTotalValue] >= _histamineComption)
			{
			    Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue] -= 
                    (Mobx.Atributes[Idioma._namePhisicalDa][Idioma._InfoNameTotalValue] - Atributes[Idioma._namePhisicalDe][Idioma._InfoNameTotalValue]);

				Mobx.Atributes[Idioma._nameHistamine][Idioma._InfoNameTotalValue] -= _histamineComption;
			}

            if (Atributes[Idioma._nameMagicalDe][Idioma._InfoNameTotalValue] < Mobx.Atributes[Idioma._nameMagicalDa][Idioma._InfoNameTotalValue] &&
                Mobx.Atributes[Idioma._nameMana][Idioma._InfoNameTotalValue] >= _manaComption)
            {
				Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue] -=
					(Mobx.Atributes[Idioma._nameMagicalDa][Idioma._InfoNameTotalValue] - Atributes[Idioma._nameMagicalDe][Idioma._InfoNameTotalValue]);

                Mobx.Atributes[Idioma._nameMana][Idioma._InfoNameTotalValue] -= _histamineComption;
			}

            if (Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue] <= 0) GameWorld.EntitieIsDie(_id);


            return Mobx;
		}


        public void RecoversHistamine() =>
            Atributes[Idioma._nameHistamine][Idioma._InfoNameTotalValue] *= (Atributes[Idioma._nameHistamine][Idioma._InfoNameTotalValue] < 
            Atributes[Idioma._nameHistamine][Idioma._infoNameBaseValue] * Atributes[Idioma._InfoNameBonus][Idioma._InfoNameTotalValue] * 
            CalculateLevel(_bonusLevel)) ? _buff : Atributes[Idioma._nameHistamine][Idioma._infoNameBaseValue] * Atributes[Idioma._InfoNameBonus][Idioma._InfoNameTotalValue] *
			CalculateLevel(_bonusLevel);


        public void RecoversMana() =>
			Atributes[Idioma._nameMana][Idioma._InfoNameTotalValue] *= (Atributes[Idioma._nameMana][Idioma._InfoNameTotalValue] <
			Atributes[Idioma._nameMana][Idioma._infoNameBaseValue] * Atributes[Idioma._InfoNameBonus][Idioma._InfoNameTotalValue] *
			CalculateLevel(_bonusLevel)) ? _buff : Atributes[Idioma._nameMana][Idioma._infoNameBaseValue] * Atributes[Idioma._InfoNameBonus][Idioma._InfoNameTotalValue] *
			CalculateLevel(_bonusLevel);
	}
}
