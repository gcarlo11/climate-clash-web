using Godot;

public partial class MonsterResource : Resource
{
	[Export] public string MonsterName;
	[Export] public int MaxHP;
	[Export] public int AttackDamage;
	[Export] public float MeterRate; // Kenaikan suhu per giliran
	[Export] public string Element; // Flood = Water, Heatwave = Thermal
}
