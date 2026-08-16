using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Singleton;
using Godot;

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

				ShowDataButton.ButtonPressed = _resource.Expanded;
				DataContainer.Visible = _resource.Expanded;
				ShowDataButton.Text = _resource.Expanded ? "X" : "O";
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

		public override void _Ready() {
			HasErrorsLabel.Visible = _resource.HasErrors;

			ShowDataButton.ButtonPressed = _resource.Expanded;
			DataContainer.Visible = _resource.Expanded;
			ShowDataButton.Text = _resource.Expanded ? "X" : "O";
		}

		void OnKeyLine_EditingToggled(bool toggledOn)
		{
			Resource.SetDeclarationKey(KeyLine.Text);
			KeyLine.Text = Resource.ResourceName;
		}

		void OnShowDataButton_Toggled(bool toggledOn)
		{
			_resource.Expanded = toggledOn;
			DataContainer.Visible = toggledOn;
			ShowDataButton.Text = toggledOn ? "X" : "O";
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
			var holder = GetParent<CollectionHolder>();
			if (holder.Collection.Collection.Remove(_resource))
			{
				GD.Print($"Ресурс \"{_resource.ResourceName}\" удалён из коллекции \"{holder.Collection.ResourceName}\"");
				QueueFree();
				return;
			}
			GD.Print($"Ошибка при удалении ресурса \"{_resource.ResourceName}\" из коллекции \"{holder.Collection.ResourceName}\"");
		}
	}
}
