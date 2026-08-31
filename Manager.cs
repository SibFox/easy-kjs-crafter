using EasyKJSCrafter.Scenes.Main;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using EasyKJSCrafter.Scenes.UIs.ComponentEntryUI;
using EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI;
using EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor;
using EasyKJSCrafter.Scenes.UIs.MainMenu;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter
{
	[GlobalClass]
	public partial class Manager : Node
	{
		private static Main _main;
		public static Main Main
		{
			get => _main;
			set
			{
				if (value is Main)
				{
					_main = value;
				}
			}
		}

		public static readonly Texture2D QuestionMarkTexture = GD.Load<Texture2D>("res://Assets/Images/question_mark.svg");

	public override void _Ready()
	{
		if (!DirAccess.DirExistsAbsolute(Paths.LogsPath[..^1]))
		{
			DirAccess.MakeDirAbsolute(Paths.LogsPath[..^1]);
		}

		FileAccess.Open(Paths.LogsPath + "latest.log", FileAccess.ModeFlags.Write).Close();
		FileAccess.Open(Paths.LogsPath + "debug.log", FileAccess.ModeFlags.Write).Close();

		LogInfo(nameof(Manager)).AddLine("Easy KubeJS crafter initialized").Push();
	}

		public static class LoadedUIScenes
		{
			public static readonly MainMenu MainMenu = ResourceLoader.Load<PackedScene>("uid://1ei3gtjf3xpc").Instantiate<MainMenu>();
			public static readonly DeclarationsRedactor DeclarationsRedactor = ResourceLoader.Load<PackedScene>("uid://dc8srvin27rtg").Instantiate<DeclarationsRedactor>();

			public static TagEntryBox TagEntryBoxInstance() => ResourceLoader.Load<PackedScene>("uid://dtfooyp35xidp").Instantiate<TagEntryBox>();
			public static ItemEntryBox ItemEntryBoxInstance() => ResourceLoader.Load<PackedScene>("uid://bfu7lsul3ckth").Instantiate<ItemEntryBox>();
			public static ItemCollectionEntryBox ItemCollectionEntryBoxBoxInstance() => ResourceLoader.Load<PackedScene>("uid://cpn7rta0p7lhy").Instantiate<ItemCollectionEntryBox>();

			public static IntegerComponentEntry IntegerComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://c4ofav60g2ggu").Instantiate<IntegerComponentEntry>();
			public static FloatComponentEntry FloatComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://gi4aukixawbl").Instantiate<FloatComponentEntry>();
			public static StringComponentEntry StringComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://bblxbg30e2mdc").Instantiate<StringComponentEntry>();
			public static BooleanComponentEntry BooleanComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://dlyqw1e0yte5c").Instantiate<BooleanComponentEntry>();
			public static ArrayComponentEntry ArrayComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://cnrnjqsblejj6").Instantiate<ArrayComponentEntry>();
			public static DictionaryComponentEntry DictionaryComponentEntryInstance() => ResourceLoader.Load<PackedScene>("uid://d1f3g2b0b2nyu").Instantiate<DictionaryComponentEntry>();

			public static IntegerDictionaryEntry IntegerDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://dmh4tyoebj6uf").Instantiate<IntegerDictionaryEntry>();
			public static FloatDictionaryEntry FloatDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://uejourcourwy").Instantiate<FloatDictionaryEntry>();
			public static StringDictionaryEntry StringDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://dv2i72sisegeo").Instantiate<StringDictionaryEntry>();
			public static BooleanDictionaryEntry BooleanDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://ddugy4hotwmcv").Instantiate<BooleanDictionaryEntry>();
			public static ArrayDictionaryEntry ArrayDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://cv621uelaa5g6").Instantiate<ArrayDictionaryEntry>();
			public static DictionaryDictionaryEntry DictionaryDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("uid://br1ruubpywdgo").Instantiate<DictionaryDictionaryEntry>();
		}

		public static class Paths
	{
		public const string LogsPath = "user://Logs/";
		// public const string GlobalConfigPath = "user://GlobalConfig.cfg";

		// public const string Scenes = "res://Scenes/";
		// public const string UI = Scenes + "UI/";
	}
	}
}
