using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class DictionaryEntry : EntryBox
	{
		protected DictionaryElementBase _element = new();
		public virtual DictionaryElementBase Element
		{
			get => _element;
			set
			{
				_element = value;
				HasErrorsLabel.Visible = value.HasErrors;

				KeyLine.Text = value.InsideArray ? string.Empty : value.Key;
				KeyLine.Visible = DataContainer.GetNode<Separator>("VSeparator").Visible = !value.InsideArray;
			}
		}

		protected HBoxContainer DataContainer => ContentContainer.GetNode<HBoxContainer>("DataHBoxContainer");
		protected LineEdit KeyLine => GetNode<LineEdit>("%KeyLine");

		protected Label HasErrorsLabel => DataContainer.GetNode<Label>("HasErrorsLabel");
		protected Button DeleteButton => DataContainer.GetNode<Button>("DeleteButton");
		public Button ConfirmDeleteButton => DataContainer.GetNode<Button>("ConfirmDeleteButton");
		protected Button DeclineDeleteButton => DataContainer.GetNode<Button>("DeclineDeleteButton");

		protected virtual void OnKeyLine_EditingToggled(bool toggledOn)
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
			string elmId = string.IsNullOrEmpty(Element.Key) ? Element.DebuggerName : Element.Key;
			string ownerId = string.IsNullOrEmpty(owner.Holder.Key) ? owner.Holder.DebuggerName : owner.Holder.Key;
			if (owner.Collection.Remove(_element))
			{
				owner.EmitSignal(CollectionHolder.SignalName.ElementRemoved);
				QueueFree();
				LogInfo(nameof(ComponentEntry)).AddLine($"Удалён элемент \"{elmId}\" типа \"{GetType().FullName.Split('.')[4]}\""+
				$" из словаря {ownerId}").Push();
				return;
			}
			LogErr(nameof(ComponentEntry)).AddLine($"Ошибка при удалении элемента \"{elmId}\" типа \"{GetType().FullName.Split('.')[4]}\""+
				$" из словаря {ownerId}").Push();
		}
	}
}