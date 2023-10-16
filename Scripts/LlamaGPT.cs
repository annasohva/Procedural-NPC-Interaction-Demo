using Godot;
using System;

public partial class LlamaGPT : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	/// <summary>
	/// Generoi LlamaGPT:n kautta dialogue tekstin.
	/// </summary>
	/// <param name="npcDescription">NPC:n kuvaus string.</param>
	/// <param name="playerDialogue">Pelaajan kirjoittama viesti.</param>
	/// <returns></returns>
	public string GenerateText(string npcDescription, string playerDialogue)
	{
		// tällä metodilla voi generoida tekstit joka npcelle. generoinnissa hyödynnetään npcDescription-parametria määrittämään kuka npc on
		return $"This is a sample dialog text from {npcDescription}. You told me: {playerDialogue}.";
	}
}
