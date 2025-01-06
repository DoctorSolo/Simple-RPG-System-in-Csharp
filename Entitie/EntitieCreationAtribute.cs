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
		// This is a name for creature
		public string _cretureName { get; }
        public decimal _id { get; }

        // VALUE BUFF/DEBUFF
        private double _debuff => 0.1;
        private decimal _buff => 0.02M;
        private double _bonusLevel => 1.1;

        // Dictionary Instance ////////////////////////////
        public int _level = 0;
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
            MakeAtributes();

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
            foreach (string atribute in Idioma._atributesName)
                Atributes[atribute][Idioma._InfoNameBonus] = 1;

            // Set Imutable attributes...
            foreach (string atribute in Idioma._atributesName)
            {
                if ((atribute != Idioma._nameLevel) && (atribute != Idioma._nameWeight) && (atribute != Idioma._namePhisicalDa) && 
                    (atribute != Idioma._nameMagicalDa))
                {
                    Atributes[atribute][Idioma._InfoNameForLevel] = 1;
                }
                else
                {
                    Atributes[atribute][Idioma._InfoNameForLevel] = 0;
                }
            }

            // Calculate others atributes...
            PhisicalDamageMethod(Idioma._infoNameBaseValue, _debuff);
            MagicalDamageMethod(Idioma._infoNameBaseValue, _debuff, _buff);
            WeightMethod(1);

            // Update Atributes...
            CalculateAtribute();
        }


        private decimal CalculateLevel(double BonusLevel)
        // Here all atributes increase with level...
        {
            return (decimal)Math.Pow(BonusLevel, _level);
        }


		#region CALCULATE OTHERS ATTRIBUTES


		private decimal IncreacedAtributeDebuff(double Debuff, string Position)
        // Here some attributes will receive debuff...
        {
            decimal a = Atributes[Idioma._nameAttSpeed][Position];
            return a / (decimal)Math.Pow((double)a, Debuff);
        }

		private void PhisicalDamageMethod(string position, double DebuffValue) =>
		// Here will receive debuff in phisicalDamage for velAttk...
			Atributes[Idioma._namePhisicalDa][position] = decimal.Round(
                Atributes[Idioma._nameStrenght][position] * IncreacedAtributeDebuff(DebuffValue, position), 2);


        private void MagicalDamageMethod(string Position, double DebuffValue, decimal BuffValue) =>
        // Here will receive debuff in Magical Damage for velAttk and buff in Inteligence and Proficience...
            Atributes[Idioma._nameMagicalDa][Position] = decimal.Round(
                Atributes[Idioma._nameMagicalAtt][Position] * (Atributes[Idioma._nameAttSpeed][Position] * 
                IncreacedAtributeDebuff(_debuff, Position)) * 
                ((Atributes[Idioma._nameInventor][Position] + Atributes[Idioma._nameMagicP][Position]) * BuffValue), 2);


        private void PhisicalDefenseMethod(string Position, decimal BuffValue) =>
        // Here will receive buff for weight...
            Atributes[Idioma._namePhisicalDe][Position] *= decimal.Round(Atributes[Idioma._nameWeight][Position] * BuffValue, 2);


        private void MagicalDefenseMethod(string Position, decimal Buff) =>
        // Here will receive buff for inteligente and proficience
            Atributes[Idioma._nameMagicalDe][Position] *= decimal.Round(
                (Atributes[Idioma._nameInventor][Position] + Atributes[Idioma._nameMagicP][Position]) * Buff, 2);


        private void WeightMethod(decimal BuffOrDebuff) =>
        // Here will receive buff or debuff
            Atributes[Idioma._nameWeight][Idioma._InfoNameTotalValue] = decimal.Round(
                Atributes[Idioma._nameWeight][Idioma._infoNameBaseValue] * BuffOrDebuff, 2);


		#endregion


		private void CalculateAtribute()
		// This is a important method, he calculate all atributes...
		{
			foreach (string atrib in Idioma._atributesName)
            {
                if (Atributes[atrib][Idioma._InfoNameForLevel] == 1)
                {
                    decimal Bonus = Atributes[atrib][Idioma._InfoNameBonus];
                    Atributes[atrib][Idioma._InfoNameTotalValue] = decimal.Round(
                        Atributes[atrib][Idioma._infoNameBaseValue] * Bonus * CalculateLevel(_bonusLevel), 2);
                }
            }

            // Calculate others atributes...
            PhisicalDamageMethod(Idioma._InfoNameTotalValue, _debuff);
            MagicalDamageMethod(Idioma._InfoNameTotalValue, _debuff, _buff);
            PhisicalDefenseMethod(Idioma._InfoNameTotalValue, _buff);
            MagicalDefenseMethod(Idioma._InfoNameTotalValue, _buff);
        }


        public void NextLevel(byte level=1)
        // This method update all atributes for level
        {
            _level += level;
            Atributes[Idioma._nameLevel][Idioma._InfoNameTotalValue] = _level;

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
        // Here is the system class
        {
            for (byte i = 0; i < Idioma._atributesName.Length; i++)
            {
                Atributes[Idioma._atributesName[i]][Idioma._InfoNameBonus] *= Atribute[i];
            }
            CalculateAtribute();
        }


        public EntitieCreationAtribute ReceiveDamage(EntitieCreationAtribute Mobx)
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

				Mobx.Atributes[Idioma._nameHistamine][Idioma._InfoNameTotalValue] -=
				(Atributes[Idioma._namePhisicalDe][Idioma._InfoNameTotalValue] * 0.1M);
			}

            if (Atributes[Idioma._nameMagicalDe][Idioma._InfoNameTotalValue] < Mobx.Atributes[Idioma._nameMagicalDa][Idioma._InfoNameTotalValue] &&
                Mobx.Atributes[Idioma._nameMana][Idioma._InfoNameTotalValue] >= _manaComption)
            {
				Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue] -=
					(Mobx.Atributes[Idioma._nameMagicalDa][Idioma._InfoNameTotalValue] - Atributes[Idioma._nameMagicalDe][Idioma._InfoNameTotalValue]);
			}

            if (Atributes[Idioma._nameLife][Idioma._InfoNameTotalValue] <= 0) GameWorld.EntitieIsDie(_id);


            return Mobx;
		}
	}
}
