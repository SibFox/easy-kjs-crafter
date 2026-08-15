using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntry
{
	public partial class ItemEntryBox : VBoxContainer
	{
        private ItemEntry _item;
		[Export]
		public ItemEntry Item
        {
            get => _item;
            set
            {
                _item = value;
                
                KeyLine.Text = value.ResourceName;
                ItemNameLine.Text = value.ItemName;
                IdLabel.Id = value.ItemId;
                ItemIconRect.Texture = value.Icon;
                if (value.Icon == null)
                    ItemIconRect.Texture = Global.QuestionMarkTexture;
            }
        }

        HBoxContainer NameContainer => GetNode<HBoxContainer>("NameHBoxContainer");
        VBoxContainer DataContainer => GetNode<VBoxContainer>("DataVBoxContainer");

        LineEdit KeyLine => NameContainer.GetNode<LineEdit>("KeyLine");
        LineEdit ItemNameLine => NameContainer.GetNode<LineEdit>("ItemNameLine");
        TextureRect ItemIconRect => NameContainer.GetNode<TextureRect>("ItemIconRect");
        Button ShowDataButton => NameContainer.GetNode<Button>("ShowDataButton");

        PathIdLabel IdLabel => DataContainer.GetNode<PathIdLabel>("PathIdLabel");

        public override void _Ready() {
            Item = new()
            {
                ResourceName = "kke",
                ItemName = "Балаб",
                ItemId = new("Calac:Malac")
            };
        }

        void OnShowDataButton_Pressed()
        {
            DataContainer.Visible = !DataContainer.Visible;
            ShowDataButton.Text = DataContainer.Visible ? "X" : "O";
        }
	}
}
