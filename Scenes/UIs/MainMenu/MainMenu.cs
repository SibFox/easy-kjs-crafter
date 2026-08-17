using EasyKJSCrafter;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.MainMenu
{
	public partial class MainMenu : Control
	{
		public override void _Ready()
		{
			GetNode<Label>("VBoxContainer/InfoHBoxContainer/BuildLabel").Text = "By SibFox. Version " + ProjectSettings.GetSetting("application/config/version");
		}
		
		void OnDeclRedButton_Click()
		{
			Manager.Main.UIHandler.ChangeTo(Manager.LoadedUIScenes.DeclarationsRedactor);
		}

		void OnCraftRedButton_Click()
		{
			// Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.CraftRedactor);
		}

		void OnExitButton_Pressed()
		{
			GetTree().Quit();
		}
	}
}