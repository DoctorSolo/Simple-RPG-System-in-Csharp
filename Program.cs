using RPG_system.Entitie.Races;
using RPG_system.Entitie.ClassSystem;
using RPG_system.EntitieCreationAtribute;


EntitieCreationAtribute Alice = new Race().GetHuman(60.00M);

Alice.ShowConsoleAtributes();

Alice.NextLevel(100);

Alice.ShowConsoleAtributes();

Alice.ClassForEntitie(ClassSystem.Warrior);

Alice.ShowConsoleAtributes();