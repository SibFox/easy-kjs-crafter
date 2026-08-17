using Godot;
using EasyKJSCrafter;

namespace EasyKJSCrafter.Scenes.Main
{
    public partial class Main : Node
    {
        public UIHandler UIHandler => GetChild<UIHandler>(0);

        public override void _Ready()
        {
            Manager.Main = this;

            // Корректно выдаёт false
            // string t = "44t";
            // GD.Print(int.TryParse(t, out int ti));
            // GD.Print(float.TryParse(t, out float tf));
            // GD.Print(ti);
            // GD.Print(tf);
        }
    }
}