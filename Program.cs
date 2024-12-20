using RPG_system.Entities.EntitieCreationAtribute;


EntitieCreationAtribute Alice = new EntitieCreationAtribute(60.00M, 120, 80, 10, 5, 40, 10, 10, 60, 0.8M, 10, 30, 10, 10);

Alice.ShowConsoleAtributes();

Alice.NextLevel(100);

Alice.ShowConsoleAtributes();

Alice.NextLevel(0);

Alice.ShowConsoleAtributes();