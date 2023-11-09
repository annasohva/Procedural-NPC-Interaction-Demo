using Godot;
using LLama;
using LLama.Common;
using System;
using System.Collections.Generic;

public partial class LlamaSharp : Node
{
	static private string modelName = "llama-2-7b-guanaco-qlora.Q3_K_M.gguf";
	private string modelPath = "C:\\Users\\NikoNiemelä\\Documents\\Development\\Karelia\\Vuosi02\\TekoälyJaRobotiikka\\Projekti\\Procedural-NPC-Interaction-Demo\\Scripts\\model\\llama-2-7b-guanaco-qlora.Q3_K_M.gguf";
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
		var re = MasterBlacksmith(npcDescription, playerDialogue);
		return re;
	}

	private string MasterBlacksmith(string npcDescription, string playerDialogue)
	{
		LLamaWeights model;
		LLamaContext context;
		//string prompt = $"User:Could you talk like a master {npcDescription}\r\nGriswald: I am the crafty blacksmith how may i help you?\r\n";
		string asnwer = "";

		// Load a model
		var parameters = new ModelParams(modelPath)
		{
			ContextSize = 1024,
			Seed = 1337,
			GpuLayerCount = 5
		};
		model = LLamaWeights.LoadFromFile(parameters);
		context = model.CreateContext(parameters);
		var ex = new InteractiveExecutor(context);
		ChatSession session = new ChatSession(ex);

		// Ladataan chattibotille persoona tallennetuista profiileista
		session.LoadSession("C:\\Users\\NikoNiemelä\\Documents\\Development\\Karelia\\Vuosi02\\TekoälyJaRobotiikka\\Projekti\\Procedural-NPC-Interaction-Demo\\Scripts\\SavedSessionPath\\Blacksmith");

		foreach (var text in session.Chat(playerDialogue, new InferenceParams() { Temperature = 0.6f, AntiPrompts = new List<string> { "User:" } }))
		{
			asnwer += text;
		}

		// Tallennetaan sessio, että muistaa mitä ollana keskusteltu
		session.SaveSession("SavedSessionPath");
		string originalString = asnwer;

		// poistetaan user: syötöstä
		string modifiedString = originalString[..(asnwer.Length - 5)];
		return modifiedString;
	}
}
