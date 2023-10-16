using Godot;
using System;
using System.Diagnostics;

public partial class Main : Node
{
	DialogueBox dialogueBox;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// kytketään dialogueBoxin visibility event
		dialogueBox = this.GetNode<DialogueBox>("UI/DialogueBox");
		dialogueBox.VisibilityChanged += OnDialogueBoxVisibilityChanged;

		// käydään läpi jokainen npc joka on npc ryhmässä
		foreach(var npc in GetTree().GetNodesInGroup("NPC")) 
		{
			// haetaan npc:n dialoguenode
			var npcDialogueNode = npc.GetNode<DialogueNode>("DialogueNode");

			// lisätään jokaisen npc:n dialoguenodeen referenssi dialoguebox ui:hin
			npcDialogueNode.dialogueBox = dialogueBox;

			// lisätään myös referenssi LlamaGPT:een
			npcDialogueNode.llamaGPT = this.GetNode<LlamaGPT>("LlamaGPT");

			// yhdistetään dialogueboxista signaali dialoguenodeen. näyttää erroria mutta se on bugi ja ohjelma silti toimii
			dialogueBox.PlayerDialogueSaid += npcDialogueNode.OnPlayerDialogueSaid;
		}
		
	}

	public void OnDialogueBoxVisibilityChanged() // kun dialogueBox on näkyvissä poistaa playeriltä liikkumiskyvyn
	{
		var player = this.GetNode<player>("Town/Player");

		if(dialogueBox.Visible == true)
		{
			player.SetPhysicsProcess(false);
		}
		else
		{
			player.SetPhysicsProcess(true);
		}
	}
}
