using RPG_system.Entities;

namespace RPG_system.Entities;

public class Warrior : Entitie
{
    public Warrior(ushort Life = 3500, ushort MovSpeed = 4, ushort AttSpeed = 2, ushort Strenght = 1000, decimal Weight = 60.0M, ushort Histamine = 2000, ushort PhisicalDamage = 1000, ushort PhisicalDefense = 2000, ushort MagicProficience = 500, ushort Inventor = 90, ushort Mana = 0, ushort MagicalDamage = 0, ushort MagicalDefense = 0) : base(Life, MovSpeed, AttSpeed, Strenght, Weight, Histamine, PhisicalDamage, PhisicalDefense, MagicProficience, Inventor, Mana, MagicalDamage, MagicalDefense)
    {
    }
}