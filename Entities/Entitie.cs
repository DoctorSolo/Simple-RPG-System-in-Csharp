namespace RPG_system.Entities
{
    public abstract class Entitie
    {

        public ushort Life      { get; }
        public ushort MovSpeed  { get; }
        public ushort AttSpeed  { get; }
        public ushort Strenght  { get; }
        public decimal Weight   { get; }
        public ushort Histamine { get; }


        private ushort _phisicalDamage;
        public ushort PhisicalDamage
        {
            get => _phisicalDamage;
            set => _phisicalDamage = (ushort)(PhisicalDamage + (AttSpeed * Strenght));
        }


        public ushort PhisicalDefense { get; }



        public ushort MagicProficience  { get; }
        public ushort Inventor          { get; }
        public ushort Mana              { get; }


        private ushort _magicalDamage;
        public ushort MagicalDamage
        {
            get => _magicalDamage;
            set => _magicalDamage = (ushort)(MagicalDamage + (MagicProficience * (Inventor / 10)));
        }


        private ushort _magicalDefense;
        public ushort MagicalDefense
        {
            get => _magicalDefense;
            set => _magicalDefense = (ushort)(MagicalDefense + (MagicProficience * (Inventor / 10)));
        }


        public Entitie(ushort Life, ushort MovSpeed, ushort AttSpeed, ushort Strenght, decimal Weight, ushort Histamine,
            ushort PhisicalDamage, ushort PhisicalDefense, ushort MagicProficience, ushort Inventor, ushort Mana, 
            ushort MagicalDamage, ushort MagicalDefense)
        {
            this.Life               = Life;
            this.MovSpeed           = MovSpeed;
            this.AttSpeed           = AttSpeed;
            this.Strenght           = Strenght;
            this.Weight             = Weight;
            this.Histamine          = Histamine;
            this.PhisicalDamage     = PhisicalDamage;
            this.PhisicalDefense    = (ushort)(PhisicalDefense * (Weight * 0.2M));
            this.MagicProficience   = MagicProficience;
            this.Inventor           = Inventor;
            this.Mana               = Mana;
            this.MagicalDamage      = MagicalDamage;
            this.MagicalDefense     = MagicalDefense;
        }


        public Entitie(ushort Life, ushort MovSpeed, ushort AttSpeed, ushort Strenght, decimal Weight, ushort Histamine,
            ushort PhisicalDamage, ushort PhisicalDefense, ushort Inventor)
        {
            this.Life = Life;
            this.MovSpeed = MovSpeed;
            this.AttSpeed = AttSpeed;
            this.Strenght = Strenght;
            this.Weight = Weight;
            this.Histamine = Histamine;
            this.PhisicalDamage = PhisicalDamage;
            this.PhisicalDefense = PhisicalDefense;
            this.Inventor = Inventor;
        }


        public void Show()
        {
            Console.WriteLine($"life: {Life}, PhisicalDefense: {PhisicalDefense}");
        }
    }
}