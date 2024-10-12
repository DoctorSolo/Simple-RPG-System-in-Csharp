using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG_system.Entities.Entitie;

namespace RPG_system.Models.Class
{
    public class Wizard
    {
        public Wizard(Entitie entitie)
        {
            entitie.Life += 5;
            entitie.Inventor += 10;
            entitie.MagicProficience += 100;
            entitie.MagicalDefense += 80;
            entitie.Mana += 100;
        }
    }
}