using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.MainMenu
{
    public partial class MainMenu : Control
    {
        public void OnDeclRedButton_Click()
        {
            Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.DeclarationsRedactor);
        }

        public void OnCraftRedButton_Click()
        {
            // Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.CraftRedactor);
        }
    }
}