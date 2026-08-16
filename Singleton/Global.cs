using EasyKJSCrafter.Scenes.Main;
using EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor;
using EasyKJSCrafter.Scenes.UIs.MainMenu;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using Godot;

namespace EasyKJSCrafter.Singleton
{
    [GlobalClass]
    public partial class Global : Node
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

        public static class LoadedUIScenes
        {
            public static readonly MainMenu MainMenu = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/MainMenu/MainMenu.tscn").Instantiate<MainMenu>();
            public static readonly DeclarationsRedactor DeclarationsRedactor = ResourceLoader.Load<PackedScene>("res://Scenes/UIs/DeclarationsRedactor/DeclarationsRedactor.tscn").Instantiate<DeclarationsRedactor>();

            public static ItemEntryBox ItemEntryBoxInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ResourceEntry/ItemEntryBox.tscn").Instantiate<ItemEntryBox>();
            public static ItemCollectionEntryBox ItemCollectionEntryBoxBoxInstance() => ResourceLoader.Load<PackedScene>("res://Scenes/UIs/ResourceEntry/ItemCollectionEntryBox.tscn").Instantiate<ItemCollectionEntryBox>();
        }
    }
}
