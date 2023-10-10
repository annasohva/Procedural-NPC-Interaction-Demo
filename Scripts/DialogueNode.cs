using Godot;
using System;
using System.Diagnostics;

public partial class DialogueNode : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// yhdistetään signaalit AreaEntered ja AreaExited DialogueAreasta metodeihin jotta tiedetään milloin player on lähellä 
		var detectionArea = GetNode<Area2D>("DialogueArea");
		detectionArea.AreaEntered += PlayerEntered;
		detectionArea.AreaExited += PlayerExited;
	}

	public void PlayerEntered(Area2D area)
	{
		Debug.Print("moi");
	}

	public void PlayerExited(Area2D area)
	{
		Debug.Print("hei");
	}
}
