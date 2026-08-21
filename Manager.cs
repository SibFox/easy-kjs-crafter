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
			public static readonly MainMenu MainMenu = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/MainMenu/MainMenu.tscn").Instantiate<MainMenu>();
			public static readonly DeclarationsRedactor DeclarationsRedactor = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/DeclarationsRedactor/DeclarationsRedactor.tscn").Instantiate<DeclarationsRedactor>();

			public static ItemEntryBox ItemEntryBoxInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ResourceEntry/ItemEntryBox.tscn").Instantiate<ItemEntryBox>();
			public static ItemCollectionEntryBox ItemCollectionEntryBoxBoxInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ResourceEntry/ItemCollectionEntryBox.tscn").Instantiate<ItemCollectionEntryBox>();

			public static IntegerComponentEntry IntegerComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/IntegerComponentEntry.tscn").Instantiate<IntegerComponentEntry>();
			public static FloatComponentEntry FloatComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/FloatComponentEntry.tscn").Instantiate<FloatComponentEntry>();
			public static StringComponentEntry StringComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/StringComponentEntry.tscn").Instantiate<StringComponentEntry>();
			public static BooleanComponentEntry BooleanComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/BooleanComponentEntry.tscn").Instantiate<BooleanComponentEntry>();
			public static ArrayComponentEntry ArrayComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/ArrayComponentEntry.tscn").Instantiate<ArrayComponentEntry>();
			public static DictionaryComponentEntry DictionaryComponentEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryComponentEntry.tscn").Instantiate<DictionaryComponentEntry>();

			public static IntegerDictionaryEntry IntegerDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/IntegerDictionaryEntry.tscn").Instantiate<IntegerDictionaryEntry>();
			public static FloatDictionaryEntry FloatDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/FloatDictionaryEntry.tscn").Instantiate<FloatDictionaryEntry>();
			public static StringDictionaryEntry StringDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/StringDictionaryEntry.tscn").Instantiate<StringDictionaryEntry>();
			public static BooleanDictionaryEntry BooleanDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/BooleanDictionaryEntry.tscn").Instantiate<BooleanDictionaryEntry>();
			public static ArrayDictionaryEntry ArrayDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/ArrayDictionaryEntry.tscn").Instantiate<ArrayDictionaryEntry>();
			public static DictionaryDictionaryEntry DictionaryDictionaryEntryInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ComponentEntry/DictionaryEntry/DictionaryDictionaryEntry.tscn").Instantiate<DictionaryDictionaryEntry>();
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
