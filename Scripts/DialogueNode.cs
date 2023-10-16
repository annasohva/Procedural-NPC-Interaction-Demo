using Godot;
using System;
using System.Diagnostics;

public partial class DialogueNode : Node2D
{
	public LlamaGPT llamaGPT;
	public DialogueBox dialogueBox;

	[Export]
	string openingLine = "";
	[Export]
	string npcDescription = "";

	[Signal]
	public delegate void DialogueInitiatedEventHandler();

	Sprite2D keyPressTip;

	bool playerInArea = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		keyPressTip = GetNode<Sprite2D>("KeyPressTip");

		// yhdistetään signaalit AreaEntered ja AreaExited DialogueAreasta metodeihin jotta tiedetään milloin player on lähellä 
		var detectionArea = GetNode<Area2D>("DialogueArea");
		detectionArea.AreaEntered += PlayerEntered;
		detectionArea.AreaExited += PlayerExited;
	}

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("interact") && playerInArea){
			dialogueBox.OpenDialogue(openingLine);
			EmitSignal("DialogueInitiated");
		}
    }

    public void PlayerEntered(Area2D area)
	{
		playerInArea = true;
		keyPressTip.Show();
	}

	public void PlayerExited(Area2D area)
	{
		playerInArea = false;
		keyPressTip.Hide();
	}

	public void OnPlayerDialogueSaid(string playerDialogue) // yhdistetty dialogueboxin OnPlayerDialogueSaid signaaliin
	{
		if(playerInArea) {
			string generatedText = llamaGPT.GenerateText(npcDescription, playerDialogue); // pyytää llamaa generoimaan tekstin
			dialogueBox.SetText(generatedText);
		}
	}
}
