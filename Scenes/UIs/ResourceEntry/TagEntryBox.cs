using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class TagEntryBox : ResourceEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource as TagEntry;
			set
			{
				if (value is TagEntry tag)
				{
					base.Resource = value;

					IdLabel.Id = tag.Id;
					ItemIconRect.Texture = tag.Icon;
					if (tag.Icon == null)
						ItemIconRect.Texture = Manager.QuestionMarkTexture;
				}
			}
		}

		protected TextureRect ItemIconRect => NameContainer.GetNode<TextureRect>("ItemIconRect");

		protected PathIdLabel IdLabel => DataContainer.GetNode<PathIdLabel>("PathIdLabel");
	}
}