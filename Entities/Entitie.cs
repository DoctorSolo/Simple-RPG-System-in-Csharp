using System.Reflection.Emit;

namespace RPG_system.Entities
{
    public abstract class Entitie
    {
        // All atributes
        public ushort Level { get; set; }
        public int Life {  get; set; }
        public int Histamine { get; set; }
        public decimal Weight { get; set; }


        public int MovSpeed  { get; set; }
        public decimal AttSpeed  { get; set; }
        public decimal CriticalDamage { get; set; }
        public decimal Strenght  { get; set; }
        public int PhisicalDamage { get; private set; }
        public decimal PhisicalDefense { get; set; }


        public int Mana { get; set; }
        public int MagicProficience { get; set; }
        public int Inventor { get; set; }
        public int MagicalAttk { get; set; }

        public decimal MagicalDamage { get; set; }
        public int MagicalDefense { get; set; }

        public bool ThereIsClass { get; set; }

        public Entitie(ushort Level, decimal Weight, int Life, int Histamine, decimal PhisicalDefense, 
            int MovSpeed, decimal AttSpeed, decimal Strenght, decimal CriticalDamage, int Mana, int MagicProficience,
            int Inventor, int MagicalAttk, int MagicalDefense)
        {
            this.Level = Level;
            this.Weight = Weight;

            this.Life = Life;
            this.Histamine = Histamine;

            this.MovSpeed = MovSpeed;
            this.AttSpeed = AttSpeed;
            this.Strenght = Strenght;
            this.CriticalDamage = CriticalDamage;

            this.PhisicalDefense = PhisicalDefense;

            this.MagicProficience = MagicProficience;
            this.Inventor = Inventor;
            this.Mana = Mana;
            this.MagicalAttk = MagicalAttk;
            this.MagicalDefense = MagicalDefense;

            ThereIsClass = false;
            UpdateAtributes(Level, Weight, Life, Histamine, PhisicalDefense,
            MovSpeed, AttSpeed, Strenght, CriticalDamage, Mana, MagicProficience,
            Inventor, MagicalAttk, MagicalDefense);
        }


        private decimal _bl;
        private decimal _bh;
        private decimal _bpd;
        private decimal _bms;
        private decimal _bas;
        private decimal _bs;
        private decimal _bcd;
        private decimal _bm;
        private decimal _bmp;
        private decimal _bi;
        private decimal _bma;
        private decimal _bmd;

        public void GrowthBonus(decimal Bl, decimal Bh, decimal Bpd, decimal BMs, decimal BAs,
            decimal Bs, decimal Bcd, decimal Bm, decimal BMp, decimal Bi, decimal BMa, decimal BMd, bool Class=false)
        {
            _bl += Bl;
            _bh += Bh;
            _bpd += Bpd;
            _bms += BMs;
            _bas += BAs;
            _bs += Bs;
            _bcd += Bcd;
            _bm += Bm;
            _bmp += BMp;
            _bi += Bi;
            _bma += BMa;
            _bmd += BMd;

            if (Class)
            {
                ThereIsClass = true;
            }
        }


        public decimal BonusCalculation(decimal V)
        {
            return Decimal.Round((decimal)Math.Pow((double)(1 + V), Level), 2);
        }


        public void NextLevel(ushort Level)
        {
            this.Level += Level;
            UpdateAtributes(this.Level, Weight, Life, Histamine, PhisicalDefense,
            MovSpeed, AttSpeed, Strenght, CriticalDamage, Mana, MagicProficience,
            Inventor, MagicalAttk, MagicalDefense);
        }


        public void UpdateAtributes(ushort Level, decimal Weight, int Life, int Histamine, decimal PhisicalDefense,
            int MovSpeed, decimal AttSpeed, decimal Strenght, decimal CriticalDamage, int Mana, int MagicProficience,
            int Inventor, int MagicalAttk, int MagicalDefense)
        {
            this.Life = (int)(Life * BonusCalculation(_bl));
            this.Histamine = (int)(Histamine * BonusCalculation(_bh));

            this.MovSpeed = (int)(MovSpeed * BonusCalculation(_bms));
            this.AttSpeed = Decimal.Round(AttSpeed * BonusCalculation(_bas), 2);
            this.Strenght = Strenght * BonusCalculation(_bs);

            this.PhisicalDamage = (int)(Strenght * (AttSpeed / (decimal)Math.Pow((double)AttSpeed, 1.2)));
            this.PhisicalDefense = Decimal.Round((PhisicalDefense * Weight * 0.02M) * (decimal)Math.Pow(1.05, Level), 2);
            this.CriticalDamage = Decimal.Round(CriticalDamage, 2);

            this.MagicProficience = (int)(MagicProficience * Math.Pow(1.05, Level));
            this.Inventor = (int)(Inventor * Math.Pow(1.05, Level));
            this.Mana = (int)(Mana * Math.Pow(1.05, Level));
            this.MagicalAttk = (int)(MagicalAttk * Math.Pow(1.05, Level));
            this.MagicalDamage = Decimal.Round((decimal)MagicalAttk * (decimal)AttSpeed * (decimal)(Inventor + MagicProficience) * 0.02M, 2);
            this.MagicalDefense = (int)(MagicalDefense * (Inventor + MagicProficience) * 0.02M * (int)Math.Pow(1.05, Level));
        }


        public void Show()
        {
            Console.WriteLine($"level: {Level}, life: {Life}, PhisicalDefense: {PhisicalDefense}, Strenght: {Strenght}, AttSpeed: {AttSpeed}, PhisicalDamage: {PhisicalDamage}");
        }
    }
}