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


    public class EntitieCreationAtribute
    {
        #region Main Variables

        // This is all atributes name on RPG
        public static string[] _atributesName = ["Level", "Weight", "Life", "Histamine", "Mana", "Inventor", "Phisical Defense", "Phisical Damage", 
            "Magical Damage", "Magical Defense", "Att Speed", "Strenght", "Critical Chance", "Critical Damage", "Mov Speed", "Magic Proficience", "Magical Att"];
        
        // Here are layout name of atributes values
        public static string[] _infoAtributes = ["Total Value", "Bonus", "Base Value", "For Level"];

        // All variables used in atributes
        private string _nameLevel => _atributesName[0];
        private string _nameWeight => _atributesName[1];
        private string _nameLife => _atributesName[2];
        private string _nameHistamine => _atributesName[3];
        private string _nameMana => _atributesName[4];
        private string _nameInventor => _atributesName[5];
        private string _namePhisicalDe => _atributesName[6];
        private string _namePhisicalDa => _atributesName[7];
        private string _nameMagicalDa => _atributesName[8];
        private string _nameMagicalDe => _atributesName[9];
        private string _nameAttSpeed => _atributesName[10];
        private string _nameStrenght => _atributesName[11];
        private string _nameCriticalChance => _atributesName[12];
        private string _nameCriticalDa => _atributesName[13];
        private string _nameMovSpeed => _atributesName[14];
        private string _nameMagicP => _atributesName[15];
        private string _nameMagicalAtt => _atributesName[16];

        // All variables used in layout
        private string _InfoNameTotalValue => _infoAtributes[0];
        private string _InfoNameBonus => _infoAtributes[1];
        private string _infoNameBaseValue => _infoAtributes[2];
        private string _InfoNameForLevel => _infoAtributes[3];

        // VALUE BUFF/DEBUFF
        private double _debuff => 1.1;
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
			if (i < _atributesName.Length)
            {
                Atributes[_atributesName[i]] = new Dictionary<string, decimal>();
                Atributes[_atributesName[i]][_InfoNameTotalValue] = new decimal();
                Atributes[_atributesName[i]][_InfoNameBonus] = new decimal();
                Atributes[_atributesName[i]][_infoNameBaseValue] = new decimal();
                i ++;
                MakeAtributes(i);
            }
        }


        // ADD ALL VALUE IN ATRIBUTES...
        public EntitieCreationAtribute(decimal Weight, decimal Life, decimal Histamine, decimal Mana, decimal Inventor,
           decimal PhisicalDefense, decimal MagicalDefense, decimal AttSpeed, decimal Strenght, decimal CriticalChance, 
           decimal CriticalDamage, decimal MovSpeed, decimal MagicProficience, decimal MagicalAttk)
        {
            MakeAtributes();

			// Attributes...
			Atributes[_nameLevel]           [_infoNameBaseValue] = _level;
			Atributes[_nameWeight]          [_infoNameBaseValue] = Weight;
			Atributes[_nameLife]            [_infoNameBaseValue] = Life;
            Atributes[_nameHistamine]       [_infoNameBaseValue] = Histamine;
            Atributes[_nameMana]            [_infoNameBaseValue] = Mana;
            Atributes[_nameInventor]        [_infoNameBaseValue] = Inventor;
            Atributes[_namePhisicalDe]      [_infoNameBaseValue] = PhisicalDefense;
            Atributes[_nameMagicalDe]       [_infoNameBaseValue] = MagicalDefense;
            Atributes[_nameAttSpeed]        [_infoNameBaseValue] = AttSpeed;
            Atributes[_nameStrenght]        [_infoNameBaseValue] = Strenght;
            Atributes[_nameCriticalChance]  [_infoNameBaseValue] = CriticalChance;
            Atributes[_nameCriticalDa]      [_infoNameBaseValue] = CriticalDamage;
            Atributes[_nameMovSpeed]        [_infoNameBaseValue] = MovSpeed;
            Atributes[_nameMagicP]          [_infoNameBaseValue] = MagicProficience;
            Atributes[_nameMagicalAtt]      [_infoNameBaseValue] = MagicalAttk;

            // Set all bonus in value 1, so as not be empty...
            foreach (string atribute in _atributesName)
                Atributes[atribute][_InfoNameBonus] = 1;

            // Set Imutable attributes...
            foreach (string atribute in _atributesName)
            {
                if ((atribute != _nameLevel) && (atribute != _nameWeight) && (atribute != _namePhisicalDa) && 
                    (atribute != _nameMagicalDa))
                {
                    Atributes[atribute][_InfoNameForLevel] = 1;
                }
                else
                {
                    Atributes[atribute][_InfoNameForLevel] = 0;
                }
            }

            // Calculate others atributes...
            PhisicalDamageMethod(_infoNameBaseValue, _debuff);
            MagicalDamageMethod(_infoNameBaseValue, _debuff, _buff);
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
            decimal a = Atributes[_nameAttSpeed][Position];
            return a / (decimal)Math.Pow((double)a, Debuff);
        }

		private void PhisicalDamageMethod(string position, double DebuffValue) =>
		// Here will receive debuff in phisicalDamage for velAttk...
			Atributes[_namePhisicalDa][position] = decimal.Round(
                Atributes[_nameStrenght][position] * IncreacedAtributeDebuff(DebuffValue, position), 2);


        private void MagicalDamageMethod(string Position, double DebuffValue, decimal BuffValue) =>
        // Here will receive debuff in Magical Damage for velAttk and buff in Inteligence and Proficience...
            Atributes[_nameMagicalDa][Position] = decimal.Round(
                Atributes[_nameMagicalAtt][Position] * (Atributes[_nameAttSpeed][Position] * 
                IncreacedAtributeDebuff(_debuff, Position)) * 
                ((Atributes[_nameInventor][Position] + Atributes[_nameMagicP][Position]) * BuffValue), 2);


        private void PhisicalDefenseMethod(string Position, decimal BuffValue) =>
        // Here will receive buff for weight...
            Atributes[_namePhisicalDe][Position] *= decimal.Round(Atributes[_nameWeight][Position] * BuffValue, 2);


        private void MagicalDefenseMethod(string Position, decimal Buff) =>
        // Here will receive buff for inteligente and proficience
            Atributes[_nameMagicalDe][Position] *= decimal.Round(
                (Atributes[_nameInventor][Position] + Atributes[_nameMagicP][Position]) * Buff, 2);


        private void WeightMethod(decimal BuffOrDebuff) =>
        // Here will receive buff or debuff
            Atributes[_nameWeight][_InfoNameTotalValue] = decimal.Round(
                Atributes[_nameWeight][_infoNameBaseValue] * BuffOrDebuff, 2);


		#endregion


		private void CalculateAtribute()
		// This is a important method, he calculate all atributes...
		{
			foreach (string atrib in _atributesName)
            {
                if (Atributes[atrib][_InfoNameForLevel] == 1)
                {
                    decimal Bonus = Atributes[atrib][_InfoNameBonus];
                    Atributes[atrib][_InfoNameTotalValue] = decimal.Round(
                        Atributes[atrib][_infoNameBaseValue] * Bonus * CalculateLevel(_bonusLevel), 2);
                }
            }

            // Calculate others atributes...
            PhisicalDamageMethod(_InfoNameTotalValue, _debuff);
            MagicalDamageMethod(_InfoNameTotalValue, _debuff, _buff);
            PhisicalDefenseMethod(_InfoNameTotalValue, _buff);
            MagicalDefenseMethod(_InfoNameTotalValue, _buff);
        }


        public void NextLevel(byte level=1)
        // This method update all atributes for level
        {
            _level += level;
            Atributes[_nameLevel][_InfoNameTotalValue] = _level;

            CalculateAtribute();
        }


        public void ShowConsoleAtributes()
        // Show dictionary
        {
            Console.WriteLine("\n");
            
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
            for (byte i = 0; i < _atributesName.Length; i++)
            {
                Atributes[_atributesName[i]][_InfoNameBonus] *= Atribute[i];
            }
            CalculateAtribute();
        }
    }
}
