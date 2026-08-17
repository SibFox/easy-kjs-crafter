using System.Text;
using EasyKJSCrafter.Scenes.UIs.DeclarationTabUI;
using EasyKJSCrafter;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationsRedactor
{
	public partial class DeclarationsRedactor : Control
	{
		TabContainer DeclarationContainer => GetNode<TabContainer>("PanelContainer/VBoxContainer/HBoxContainer/DeclarationTabContainer");
		HBoxContainer SaveContainer => GetNode<HBoxContainer>("PanelContainer/VBoxContainer/SaveHBoxContainer");

		DeclarationTab ItemsTab => DeclarationContainer.GetNode<DeclarationTab>("ItemsTab");
		DeclarationTab TagsTab => DeclarationContainer.GetNode<DeclarationTab>("TagsTab");
		DeclarationTab FluidsTab => DeclarationContainer.GetNode<DeclarationTab>("FluidsTab");

		Label SaveInfoLabel => SaveContainer.GetNode<Label>("SaveInfoLabel");
		
		void OnBackButton_Pressed()
		{
			Manager.Main.UIHandler.ChangeTo(Manager.LoadedUIScenes.MainMenu);
		}

		void OnSaveButton_Pressed()
		{
			StringBuilder errors = new("При сохранении ");
			int l = errors.Length;
			bool itemsSaved = ItemsTab.SaveCollection();
			bool tagsSaved = TagsTab.SaveCollection();
			bool fluidsSaved = FluidsTab.SaveCollection();
			if (!itemsSaved)
			{
				if (errors.Length > l)
					errors.Append(", ");
				errors.Append("Предметов");
			}
			if (!tagsSaved)
			{
				if (errors.Length > l)
					errors.Append(", ");
				errors.Append("Тегов");
			}
			if (!fluidsSaved)
			{
				if (errors.Length > l)
					errors.Append(", ");
				errors.Append("Жидкостей");
			}
			errors.Append(" произошли ошибки");

			if (!itemsSaved || !tagsSaved || !fluidsSaved)
				SaveInfoLabel.Text = errors.ToString();
			else
				SaveInfoLabel.Text = "Определения успешно сохранены";
		}
	}
}