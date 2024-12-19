
namespace RPG_system.Entities.EntitieCreationAtribute
{
    internal class EntitieCreationAtribute
    {
        // This is all atributes name on RPG
        private string[] _atributesName = ["Level", "Weight", "Life", "Histamine", "Mana", "Inventor", "Phisical Defense", "Phisical Damage", 
            "Magical Damage", "Magical Defense", "Att Speed", "Strenght", "Critical Chance", "Critical Damage", "Mov Speed", "Magic Proficience", "Magical Att"];
        
        // Here are layout name of atributes values
        private string[] _infoAtributes = ["Total Value", "Bonus"];

        // All variables used
        private string _nameLevel;
        private string _nameWeight;
        private string _nameLife;
        private string _nameHistamine;
        private string _nameMana;
        private string _nameInventor;
        private string _namePhisicalDe;
        private string _namePhisicalDa;
        private string _nameMagicalDa;
        private string _nameMagicalDe;
        private string _nameAttSpeed;
        private string _nameStrenght;
        private string _nameCriticalChance;
        private string _nameCriticalDa;
        private string _nameMovSpeed;
        private string _nameMagicP;
        private string _nameMagicalAtt;

        private int _level = 0;
        private Dictionary<string, decimal> oldAtributes = new Dictionary<string, decimal>();
        private Dictionary<string, Dictionary<string, decimal>> Atributes = new Dictionary<string, Dictionary<string, decimal>>();


        private void MakeAtributes(byte i=0)
        {
            if (i < _atributesName.Length)
            {
                Atributes[_atributesName[i]] = new Dictionary<string, decimal>();
                Atributes[_atributesName[i]][_infoAtributes[0]] = new decimal();
                Atributes[_atributesName[i]][_infoAtributes[1]] = new decimal();
                i ++;
                MakeAtributes(i);
            }
        }


        public EntitieCreationAtribute(decimal Weight, decimal Life, decimal Histamine, decimal Mana, decimal Inventor,
           decimal PhisicalDefense, decimal MagicalDefense, decimal AttSpeed, decimal Strenght, decimal CriticalChance, 
           decimal CriticalDamage, decimal MovSpeed, decimal MagicProficience, decimal MagicalAttk)
        {
            MakeAtributes();
            Atributes[_atributesName[0]][_infoAtributes[0]] = _level;
            Atributes[_atributesName[1]][_infoAtributes[0]] = Weight;

            oldAtributes.Add(_atributesName[2], Life);
            oldAtributes.Add(_atributesName[3], Histamine);
            oldAtributes.Add(_atributesName[4], Mana);
            oldAtributes.Add(_atributesName[5], Inventor);
            oldAtributes.Add(_atributesName[6], PhisicalDefense);
            oldAtributes.Add(_atributesName[9], MagicalDefense);
            oldAtributes.Add(_atributesName[10], AttSpeed);
            oldAtributes.Add(_atributesName[11], Strenght);
            oldAtributes.Add(_atributesName[12], CriticalChance);
            oldAtributes.Add(_atributesName[13], CriticalDamage);
            oldAtributes.Add(_atributesName[14], MovSpeed);
            oldAtributes.Add(_atributesName[15], MagicProficience);
            oldAtributes.Add(_atributesName[16], MagicalAttk);

            foreach (string atribute in _atributesName)
                Atributes[atribute][_infoAtributes[1]] = 1;

            CalculateAtribute();
        }


        private decimal CalculateLevel()
        {
            return (decimal)Math.Pow(1.1, _level);
        }


        private decimal IncreacedAtributeDebuff(double Debuff)
        {
            decimal a = Atributes[_atributesName[10]][_infoAtributes[0]];
            return a / (decimal)Math.Pow((double)a, Debuff);
        }


        private void CalculateAtribute()
        {
            string TotalV = _infoAtributes[0];
            foreach (string atrib in _atributesName)
            {
                try
                {
                    decimal Bonus = Atributes[atrib][_infoAtributes[1]];
                    Atributes[atrib][TotalV] = decimal.Round(oldAtributes[atrib] * Bonus * CalculateLevel(), 2);
                }
                catch
                {
                    continue;
                }
            }
            //Atributes
            decimal s = Atributes[_atributesName[11]][TotalV];
            decimal a = Atributes[_atributesName[10]][TotalV];
            decimal Inventor = Atributes[_atributesName[5]][TotalV];
            decimal MagProf = Atributes[_atributesName[15]][TotalV];
            decimal MagAtt = Atributes[_atributesName[16]][TotalV];
            decimal Weight = Atributes[_atributesName[1]][TotalV];

            //Phisical Damage
            string atribute = _atributesName[7];
            Atributes[atribute][TotalV] = decimal.Round(s * IncreacedAtributeDebuff(1.1), 2);

            //Magical Damage
            atribute = _atributesName[8];
            Atributes[atribute][TotalV] = decimal.Round(
                MagAtt * (a * IncreacedAtributeDebuff(1.1)) * ((Inventor + MagProf) * 0.02M),
                2);

            // Phisical Defense
            atribute = _atributesName[6];
            Atributes[atribute][TotalV] *= decimal.Round(Weight * 0.02M, 2);

            // Magical Defense
            atribute = _atributesName[9];
            Atributes[atribute][TotalV] *= decimal.Round((Inventor + MagProf) * 0.02M, 2);


        }


        public void NextLevel(byte level=1)
        {
            _level = level;
            Atributes[_atributesName[0]][_infoAtributes[0]] = _level;

            CalculateAtribute();
        }


        public void ShowConsoleAtributes()
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

    }
}
