using Godot;
using System;

public partial class BattleManager : Node
{
	[Export] public PackedScene CardTemplate;
	[Export] public Godot.Collections.Array<CardResource> Deck;

	private ProgressBar _tempBar;
	private Label _energyLabel;
	private ProgressBar _enemyHPBar;
	private TextureRect _enemySprite;
	private Label _hpLabel;
	private Label _blockLabel;

	private int _currentEnergy = 3;
	private float _currentTemp = 0;
	private int _playerHP = 100;
	private int _enemyHP = 40;
	private int _currentBlock = 0;

	public override void _Ready()
	{
		_tempBar = GetNode<ProgressBar>("ClimateMeter/TempBar");
		_energyLabel = GetNode<Label>("PlayerUI/EnergyLabel");
		_hpLabel = GetNode<Label>("PlayerUI/HPLabel");
		_blockLabel = GetNodeOrNull<Label>("PlayerUI/BlockLabel");

		_enemyHPBar = GetNode<ProgressBar>("EnemyInfo/EnemyHP");
		_enemySprite = GetNode<TextureRect>("EnemyInfo/EnemySprite");
		
		Button myButton = GetNode<Button>("EndTurnBtn");
		if (myButton != null)
			myButton.Pressed += OnEndTurnPressed;
		
		// GUNAKAN CARA INI: Mencari node Hand secara rekursif agar lebih aman
		var handNode = FindChild("Hand", true, false) as HBoxContainer;

		if (handNode != null && CardTemplate != null && Deck != null)
		{
			foreach (CardResource data in Deck)
			{
				var newCard = CardTemplate.Instantiate<Card>();
				newCard.Data = data; 
				
				// Paksa ukuran kartu jika di Card.tscn masih 0x0
				newCard.CustomMinimumSize = new Vector2(150, 220);
				
				handNode.AddChild(newCard);
			}
			GD.Print($"Berhasil memunculkan {Deck.Count} kartu.");
		}
		else
		{
			GD.PrintErr("Gagal! Pastikan: 1. Node 'Hand' ada di Scene. 2. CardTemplate diisi. 3. Deck diisi.");
		}

		UpdateUI();
	}

	// ... (Sisa fungsi PlayDefensiveCard, UpdateUI, dan OnEndTurnPressed tetap sama)
	// Pastikan tidak ada karakter aneh/tag [cite] saat copy paste bagian bawahnya
	private void UpdateUI()
	{
		if (_energyLabel != null) _energyLabel.Text = $"Energy: {_currentEnergy}/3";
		if (_tempBar != null) _tempBar.Value = _currentTemp;
		if (_enemyHPBar != null) _enemyHPBar.Value = _enemyHP;
		if (_hpLabel != null) _hpLabel.Text = $"HP: {_playerHP}";
		if (_blockLabel != null) _blockLabel.Text = $"Block: {_currentBlock}";
	}

	public void PlayDefensiveCard(int blockValue, int cost, int healValue)
	{
		if (_currentEnergy >= cost)
		{
			_currentEnergy -= cost;
			_currentBlock += blockValue;
			
			if (healValue > 0)
			{
				_playerHP = Mathf.Min(100, _playerHP + healValue);
			}

			GD.Print($"Play Defensive: Block +{blockValue}, Heal +{healValue}");
			UpdateUI();
		}
		else
		{
			GD.Print("Energi tidak cukup!");
		}
	}

	public void OnEndTurnPressed()
	{
		int monsterDamage = 10;
		int damageTaken = Mathf.Max(0, monsterDamage - _currentBlock);
		
		_currentBlock = Mathf.Max(0, _currentBlock - monsterDamage);
		_playerHP -= damageTaken;

		_currentTemp += 1.5f;
		_currentEnergy = 3;
		_currentBlock = 0;

		UpdateUI();

		if (_currentTemp >= 10 || _playerHP <= 0)
		{
			GD.Print("Climate Collapse! Game Over.");
		}
	}
}
