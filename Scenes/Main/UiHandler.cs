using Godot;


namespace EasyKJSCrafter.Scenes.Main
{
    public partial class UIHandler : Node
    {
        public Control CurrentUI => GetChildOrNull<Control>(0);

        public void ChangeTo(Control scene)
        {
            RemoveChild(CurrentUI);
            AddChild(scene);
        }
    }
}