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
			}
		}

		protected HBoxContainer NameContainer => GetNode<HBoxContainer>("HBoxContainer/NameHBoxContainer");
		protected Control DataContainer => GetNode<Control>("HBoxContainer/DataVBoxContainer");

		protected Button ShowDataButton => GetNode<Button>("ShowDataButton");

		protected LineEdit KeyLine => NameContainer.GetNode<LineEdit>("KeyLine");
		protected LineEdit EntryNameLine => NameContainer.GetNode<LineEdit>("EntryNameLine");

		void OnKeyLine_EditingToggled(bool toggledOn)
		{
			Resource.SetDeclarationKey(KeyLine.Text);
			KeyLine.Text = Resource.ResourceName;
		}

		void OnShowDataButton_Pressed()
		{
			DataContainer.Visible = !DataContainer.Visible;
			ShowDataButton.Text = DataContainer.Visible ? "X" : "O";
		}

		void OnItemNameLine_EditingToggled(bool toggledOn)
		{
			Resource.EntryName = EntryNameLine.Text;
		}
	}
}
