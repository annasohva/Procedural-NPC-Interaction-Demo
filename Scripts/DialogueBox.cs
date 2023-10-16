using Godot;
using System;

public partial class DialogueBox : Control
{
	Button sayButton;
	Button closeDialogueButton;
	TextEdit sayText;
	RichTextLabel dialogueText;

	[Signal]
	public delegate void PlayerDialogueSaidEventHandler(string text);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sayButton =  GetNode<Button>("SayButton");
		closeDialogueButton = GetNode<Button>("CloseDialogueButton");
		sayText = GetNode<TextEdit>("TextEdit");
		dialogueText =  GetNode<RichTextLabel>("ColorRect/RichTextLabel");

		sayButton.Pressed += SayButton_Pressed;
		closeDialogueButton.Pressed += CloseDialogueButton_Pressed;
	}

	public void SayButton_Pressed() // kun "SayButton"-nappia painetaan tämä metodi lähettää signaalin jossa on mukana pelaajan kirjoittama teksti
	{
		this.EmitSignal("PlayerDialogueSaid", sayText.Text);
	}

	public void CloseDialogueButton_Pressed() // kun "CloseDialogueButton"-nappia painetaan piilottaa dialogueboxin ja tyhjentää tekstit
	{
		this.Hide();
		sayText.Text = "";
		dialogueText.Text = "";
	}

	/// <summary>
	/// Avaa DialogueBoxin näkyviin.
	/// </summary>
	/// <param name="openingLine">Teksti mikä DialogueBoxissa näytetään aluksi.</param>
	public void OpenDialogue(string openingLine)
	{
		this.Show();
		dialogueText.Text = openingLine;
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
