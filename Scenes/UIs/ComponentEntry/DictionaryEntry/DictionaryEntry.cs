using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class DictionaryEntry : VBoxContainer
	{
		protected DictionaryElementBase _element = new();
		public virtual DictionaryElementBase Element
		{
			get => _element;
			set
			{
				_element = value;
				KeyLine.Text = value.Key;
				HasErrorsLabel.Visible = value.HasErrors;

				KeyLine.Visible = DataContainer.GetNode<Separator>("VSeparator").Visible = !value.InsideArray;
			}
		}

		protected HBoxContainer DataContainer => GetNode<HBoxContainer>("DataHBoxContainer");
		protected LineEdit KeyLine => GetNode<LineEdit>("%KeyLine");

		protected Label HasErrorsLabel => DataContainer.GetNode<Label>("HasErrorsLabel");
		protected Button DeleteButton => DataContainer.GetNode<Button>("DeleteButton");
		public Button ConfirmDeleteButton => DataContainer.GetNode<Button>("ConfirmDeleteButton");
		protected Button DeclineDeleteButton => DataContainer.GetNode<Button>("DeclineDeleteButton");

		void OnKeyLine_EditingToggled(bool toggledOn)
		{
			_element.Key = KeyLine.Text;
			KeyLine.Text = _element.Key;
		}

		void OnDeleteButton_Pressed()
		{
			DeleteButton.Visible = false;
			ConfirmDeleteButton.Visible = DeclineDeleteButton.Visible = true;
		}

		void OnDeclineDeleteButton_Pressed()
		{
			DeleteButton.Visible = true;
			ConfirmDeleteButton.Visible = DeclineDeleteButton.Visible = false;
		}

		void OnConfirmDeleteButton_Pressed()
		{
			var owner = FindParent("DictionaryCollectionHolder") as DictionaryCollectionHolder;
			if (owner.Collection.Remove(_element))
			{
				owner.EmitSignal(CollectionHolder.SignalName.ElementRemoved);
				QueueFree();
				LogInfo(nameof(ComponentEntry)).AddLine($"Удалён элемент \"{_element.Key}\" типа \"{GetType().FullName[2]}\"" +
				$"из словаря {owner.Holder.Key}").Push();
				return;
			}
			LogErr(nameof(ComponentEntry)).AddLine($"Ошибка при удалении элемент \"{_element.Key}\" типа \"{GetType().FullName[2]}\"" +
				$"из словаря {owner.Holder.Key}").Push();
		}
	}
}