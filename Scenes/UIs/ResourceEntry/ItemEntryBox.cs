using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemEntryBox : ResourceEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource;
			set
			{
                if (value is ItemEntry item)
                {
                	_resource = value;

                    KeyLine.Text = item.ResourceName;
                    EntryNameLine.Text = item.EntryName;
                    IdLabel.Id = item.ItemId;
                    ItemIconRect.Texture = item.Icon;
                    if (item.Icon == null)
                        ItemIconRect.Texture = Global.QuestionMarkTexture;
                }
            }
		}

		protected TextureRect ItemIconRect => NameContainer.GetNode<TextureRect>("ItemIconRect");
		protected PathIdLabel IdLabel => DataContainer.GetNode<PathIdLabel>("PathIdLabel");
		protected Button ComponentsButton => DataContainer.GetNode<Button>("ComponentsButton");
		
		void OnComponentsButton_Toggle(bool toggledOn)
		{
			
		}
	}
}