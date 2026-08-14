using Godot;


namespace EasyKJSCrafter.Scenes.Main
{
    public partial class UiHandler : Node
    {
        public Control CurrentUI => GetChildOrNull<Control>(0);

        public Control MainMenu = GD.Load<PackedScene>("res://Scenes/UIs/MainMenu/MainMenu.tscn").Instantiate<Control>();
        public Control DeclarationsRedactor = GD.Load<PackedScene>("res://Scenes/UIs/DeclarationsRedactor/DeclarationsRedactor.tscn").Instantiate<Control>();

        public void ChangeTo(Control scene)
        {
            RemoveChild(CurrentUI);
            AddChild(scene);
        }
    }
}