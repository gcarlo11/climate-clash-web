using Godot;
using System;

public partial class Card : Control
{
	[Export] public CardResource Data;

	private Label _nameLabel;
	private Label _costLabel;
	private TextureRect _icon;

	public override void _Ready()
	{
		_nameLabel = GetNode<Label>("CardName");
		_costLabel = GetNode<Label>("CostLabel");
		_icon = GetNode<TextureRect>("ElementIcon");

		if (Data != null) UpdateUI();

		// Sinyal untuk Hover dan Klik
		MouseEntered += OnHoverStart;
		MouseExited += OnHoverEnd;
		GuiInput += OnGuiInput;
	}

	public void UpdateUI()
	{
		_nameLabel.Text = Data.CardName;
		_costLabel.Text = Data.Cost.ToString();
		// Update icon atau warna background di sini berdasarkan Data.Element
	}

	private void OnHoverStart()
	{
		Tween tween = GetTree().CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(this, "scale", new Vector2(1.1f, 1.1f), 0.1f);
		tween.TweenProperty(this, "position:y", Position.Y - 20, 0.1f);
		ZIndex = 10;
	}

	private void OnHoverEnd()
	{
		Tween tween = GetTree().CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(this, "scale", new Vector2(1.0f, 1.0f), 0.1f);
		tween.TweenProperty(this, "position:y", Position.Y + 20, 0.1f);
		ZIndex = 0;
	}

	private void OnGuiInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mb && mb.Pressed && mb.ButtonIndex == MouseButton.Left)
		{
			// Beritahu BattleManager untuk memainkan kartu ini
			var battleManager = GetTree().Root.FindChild("BattleManager", true, false) as BattleManager;
			if (battleManager != null)
			{
				battleManager.PlayDefensiveCard(Data.BlockValue, Data.Cost, Data.HealValue);
				QueueFree(); // Hapus kartu dari tangan setelah dipakai
			}
		}
	}
}
