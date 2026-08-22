using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ResourceEntryBox : HBoxContainer
	{
		protected  ResourceEntry _resource;
		public virtual ResourceEntry Resource
		{
			get => _resource;
			set
			{
				_resource = value;

				KeyLine.Text = value.ResourceName;
				EntryNameLine.Text = value.EntryName;
				HasErrorsLabel.Visible = value.HasErrors;

				ShowDataButton.ButtonPressed = Resource.Expanded;
				DataContainer.Visible = Resource.Expanded;
				ShowDataButton.Text = Resource.Expanded ? "X" : "O";
			}
		}

		protected PanelContainer InfoContainer => GetNode<PanelContainer>("InfoPanelContainer");

		protected HBoxContainer NameContainer => InfoContainer.GetNode<HBoxContainer>("HBoxContainer/NameHBoxContainer");
		protected Control DataContainer => InfoContainer.GetNode<Control>("HBoxContainer/DataVBoxContainer");

		protected Button ShowDataButton => GetNode<Button>("ShowDataButton");

		protected LineEdit KeyLine => NameContainer.GetNode<LineEdit>("KeyLine");
		protected LineEdit EntryNameLine => NameContainer.GetNode<LineEdit>("EntryNameLine");
		protected Button DeleteButton => NameContainer.GetNode<Button>("DeleteButton");
		protected Button ConfirmDeleteButton => NameContainer.GetNode<Button>("ConfirmDeleteButton");
		protected Button DeclineDeleteButton => NameContainer.GetNode<Button>("DeclineDeleteButton");
		protected Label HasErrorsLabel => NameContainer.GetNode<Label>("HasErrorsLabel");

		public override void _Ready()
		{
			HasErrorsLabel.Visible = Resource.HasErrors;

			ShowDataButton.ButtonPressed = Resource.Expanded;
			DataContainer.Visible = Resource.Expanded;
			ShowDataButton.Text = Resource.Expanded ? "X" : "O";
		}

		void OnShowDataButton_Toggled(bool toggledOn)
		{
			Resource.Expanded = toggledOn;
			DataContainer.Visible = toggledOn;
			ShowDataButton.Text = toggledOn ? "X" : "O";
		}

		protected virtual void OnKeyLine_EditingToggled(bool toggledOn)
		{
			Resource.Key = KeyLine.Text;
			KeyLine.Text = Resource.Key;
		}

		void OnItemNameLine_EditingToggled(bool toggledOn)
		{
			Resource.EntryName = EntryNameLine.Text;
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
			var owner = FindParent("ItemCollectionHolder") as ItemCollectionHolder;
			string resId = string.IsNullOrEmpty(Resource.Key) ? Resource.DebuggerName : Resource.Key;
			string ownerId = string.IsNullOrEmpty(owner.Holder.Key) ? owner.Holder.DebuggerName : owner.Holder.Key;

			if (owner.Holder.Collection.Remove(Resource))
			{
				owner.EmitSignal(CollectionHolder.SignalName.ElementRemoved);
				LogInfo(nameof(ResourceEntryBox), Name).AddLine($"Ресурс \"{resId}\" удалён из коллекции \"{ownerId}\"").Push();
				QueueFree();
				return;
			}
			LogErr(nameof(ResourceEntryBox), Name).AddLine($"Ошибка при удалении ресурса \"{resId}\" из коллекции \"{ownerId}\"").Push();
		}
	}
}
