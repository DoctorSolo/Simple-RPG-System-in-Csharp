using RPG_system.Entities;

namespace RPG_system.Entities
{
    public class Races(ushort Level, decimal Weight, int Life, int Histamine, decimal PhisicalDefense, int MovSpeed, decimal AttSpeed, decimal Strenght, decimal CriticalDamage, int Mana, int MagicProficience, int Inventor, int MagicalAttk, int MagicalDefense)
        : Entitie(Level, Weight, Life, Histamine, PhisicalDefense, MovSpeed, AttSpeed, Strenght, CriticalDamage, Mana, MagicProficience, Inventor, MagicalAttk, MagicalDefense)
    {

        public class Human(decimal Weight, ushort Level=1) : Races(Level, Weight, 100, 50, 10, 5, 5, 5, 2, 5, 2, 10, 5, 5) { }
        //public class Goblin() : Races(100, 2, 2, 2, 40, 50, 10, 10, 4) { }
        //public class MagicWolf() : Races(80, 5, 3, 30, 30, 80, 10, 20, 7, 1, 20, 3, 10) { }
    }
}