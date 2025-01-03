namespace RPG_system.Entitie.Races
{
	using EntitieCreationAtribute;
	public class Race
	{
		public EntitieCreationAtribute GetHuman(string name, decimal weight) => new EntitieCreationAtribute(name, weight, 50, 50, 50, 40, 20, 20, 20, 20, 5, 5, 10, 10, 20);
	}
}
