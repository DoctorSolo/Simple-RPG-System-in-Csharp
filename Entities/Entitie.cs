using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ushort PhisicalDamage    { get -> PhisicalDamage + (AttSpeed * Strenght); }
        public ushort PhisicalDefense   { get -> (PhisicalDefense * (Weight / 10)); }

        public ushort MagicProficience  { get; }
        public ushort Inventor          { get; }
        public ushort Mana              { get; }

        public ushort MagicalDamage     { get -> (MagicalDamage + MagicProficience * (Inventor / 10)); }
        public ushort MagicalDefense    { get -> (MagicalDefense + MagicProficience * (Inventor / 10)); }

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
            this.PhisicalDefense    = PhisicalDefense;
            this.MagicProficience   = MagicProficience;
            this.Inventor           = Inventor;
            this.Mana               = Mana;
            this.MagicalDamage      = MagicalDamage;
            this.MagicalDefense     = MagicalDefense;
        }

        public void Show()
        {
            Console.WriteLine($"life: {Life}, Magical Damage: {MagicalDamage}");
        }
    }
}