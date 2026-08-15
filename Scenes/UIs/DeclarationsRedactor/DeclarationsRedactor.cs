using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor
{
    public partial class DeclarationsRedactor : Control
    {
        

        public void OnMainMenuButton_Click()
        {
            Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.MainMenu);
        }
    }
}