using EasyKJSCrafter.Scenes.UIs.DeclarationTabUI;
using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor
{
	public partial class DeclarationsRedactor : Control
	{
		TabContainer DeclarationContainer => GetNode<TabContainer>("VBoxContainer/HBoxContainer/DeclarationTabContainer");

		DeclarationTab ItemsTab => DeclarationContainer.GetNode<DeclarationTab>("ItemsTab");
		DeclarationTab TagsTab => DeclarationContainer.GetNode<DeclarationTab>("TagsTab");
		DeclarationTab FluidsTab => DeclarationContainer.GetNode<DeclarationTab>("FluidsTab");
		
		void OnBackButton_Pressed()
		{
			Global.Main.UIHandler.ChangeTo(Global.LoadedUIScenes.MainMenu);
		}

		void OnSaveButton_Pressed()
		{
			ItemsTab.SaveCollection();
			TagsTab.SaveCollection();
			FluidsTab.SaveCollection();
		}
	}
}