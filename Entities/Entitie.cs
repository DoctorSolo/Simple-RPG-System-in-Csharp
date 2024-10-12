using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG_system.Entities.Entitie
{
    public abstract class Entitie
    {
        public int Life { get; set; }
        public int PhisicalDamage { get; set; }
        public int PhisicalDefense { get; set; }
        public int MovSpeed { get; set; }
        public int AttSpeed { get; set; }
        public int Strenght { get; set; }
        public int Weight { get; set; }
        public int Histamine { get; set; }

        public int MagicProficience { get; set; }
        public int Inventor { get; set; }
        public int MagicalDamage{ get; set; }
        public int MagicalDefense { get; set; }
        public int Mana { get; set; }
 
        public Entitie(int Weight, int Life=100, int MovSpeed=1, int AttSpeed=1, int Histamine=10, int Strenght=5, int Inventor=5, int MagicProficience=0, int MagicDefense=0, int Mana=0)
        {
            this.Weight = Weight;
            this.Life = Life;
            this.MovSpeed = MovSpeed;
            this.AttSpeed = AttSpeed;
            this.Histamine = Histamine;
            this.Strenght = Strenght;
            this.MagicalDamage = (this.MagicProficience * this.Inventor);
            this.MagicalDefense = (MagicDefense * this.Inventor);
            this.Mana = Mana;
            this.PhisicalDamage = (Strenght * AttSpeed);
            this.PhisicalDefense = 1 + (Weight/10);
        }
        public Entitie(int Weight, int Life=100, int MovSpeed=1, int AttSpeed=1, int Histamine=10, int Strenght=5, int Inventor=5)
        {
            this.Weight = Weight;
            this.Life = Life;
            this.MovSpeed = MovSpeed;
            this.AttSpeed = AttSpeed;
            this.Histamine = Histamine;
            this.Strenght = Strenght;
            this.PhisicalDamage = (Strenght * AttSpeed);
            this.PhisicalDefense = 1 + (Weight/10);
        }

        public void Show()
        {
            Console.WriteLine($"life: {Life}, Magical Damage: {MagicalDamage}");
        }
    }
}