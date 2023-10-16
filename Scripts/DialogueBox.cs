using Godot;
using System;

public partial class DialogueBox : Control
{
	Button sayButton;
	TextEdit sayText;
	RichTextLabel dialogueText;

	[Signal]
	public delegate void PlayerDialogueSaidEventHandler(string text);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sayButton =  GetNode<Button>("SayButton");
		sayText = GetNode<TextEdit>("TextEdit");
		dialogueText =  GetNode<RichTextLabel>("ColorRect/RichTextLabel");

		sayButton.Pressed += SayButton_Pressed;
	}

	public void SayButton_Pressed() // kun "SayButton"-nappia painetaan tämä metodi lähettää signaalin jossa on mukana pelaajan kirjoittama teksti
	{
		this.EmitSignal("PlayerDialogueSaid", sayText.Text);
	}

	/// <summary>
	/// Asettaa DialogueBoxiin tekstin.
	/// </summary>
	/// <param name="text">Teksti string joka näytetään DialogueBoxissa.</param>
	public void SetText(string text)
	{
		dialogueText.Text = text;
	}
}
