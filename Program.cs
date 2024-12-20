using RPG_system.Entities.EntitieCreationAtribute;

//Races.Human Alice = new Races.Human(60, 0);
//new Clase().Warrior(Alice);

//Alice.Show();

//Alice.NextLevel(1);

//Alice.Show();

EntitieCreationAtribute Alice = new EntitieCreationAtribute(60.00M, 100, 80, 10, 5, 40, 10, 10, 60, 0.8M, 10, 30, 10, 10);

Alice.ShowConsoleAtributes();

Alice.NextLevel(100);

Alice.ShowConsoleAtributes();

Alice.NextLevel(0);

Alice.ShowConsoleAtributes();