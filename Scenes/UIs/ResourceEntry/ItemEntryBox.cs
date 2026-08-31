using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemEntryBox : TagEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource as ItemEntry;
			set
			{
				if (value is ItemEntry item)
				{
					base.Resource = value;

					IdLabel.Id = item.Id;
					ItemIconRect.Texture = item.Icon;
					if (item.Icon == null)
						ItemIconRect.Texture = Manager.QuestionMarkTexture;
					ComponentsContainer.Holder = item.Components;
					UpdateCountLabel();

					ComponentsButton.ButtonPressed = ComponentsContainer.Visible = item.ComponentsExpanded;
				}
			}
		}

		protected ComponentCollectionHolder ComponentsContainer => GetNode<ComponentCollectionHolder>("%ComponentCollectionHolder");
		protected OptionButton AddComponentOption => GetNode<OptionButton>("%AddComponentOptionButton");
		protected Label ComponentsCountLabel => GetNode<Label>("%ComponentsCountLabel");
		protected Button ComponentsButton => GetNode<Button>("%ComponentsButton");

		void OnComponentsButton_Toggle(bool toggledOn)
		{
			(Resource as ItemEntry).ComponentsExpanded = toggledOn;
			ComponentsContainer.Visible = toggledOn;
		}

		protected override void OnKeyLine_EditingToggled(bool toggledOn)
		{
			base.OnKeyLine_EditingToggled(toggledOn);
			var item = Resource as ItemEntry;
			ComponentsContainer.Holder.Id.SetPathFromWholePath(item.Id.ModId + ":" + item.Id.Path);
		}

		void UpdateCountLabel()
		{
			ComponentsCountLabel.Text = (_resource as ItemEntry).Components.Collection.Count.ToString();
		}
	}
}