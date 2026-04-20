using Godot;

[GlobalClass] // Tambahkan baris ini!
public partial class CardResource : Resource
{
	[Export] public string CardName;
	[Export] public int Cost;
	[Export] public int BlockValue;
	[Export] public int HealValue;
	[Export] public string Element; 
}
