using RPG_system.Entitie.Races;
using RPG_system.Entitie.ClassSystem;
using RPG_system.EntitieCreationAtribute;


EntitieCreationAtribute Alice = new Race().GetHuman("Alice", 60.00M);
EntitieCreationAtribute Ciber = new Race().GetHuman("Ciber", 40.00M);

Alice.ClassForEntitie(ClassSystem.Warrior);
Ciber.ClassForEntitie(ClassSystem.Assassin);


Alice = Ciber.ReceiveDamage(Alice);

Alice.ShowConsoleAtributes();
Ciber.ShowConsoleAtributes();