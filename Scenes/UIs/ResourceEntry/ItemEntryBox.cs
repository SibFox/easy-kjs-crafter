using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemEntryBox : ResourceEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource as ItemEntry;
			set
			{
				if (value is ItemEntry item)
				{
					_resource = value;

					KeyLine.Text = item.ResourceName;
					EntryNameLine.Text = item.EntryName;
					IdLabel.Id = item.Id;
					ItemIconRect.Texture = item.Icon;
					if (item.Icon == null)
						ItemIconRect.Texture = Manager.QuestionMarkTexture;
					ComponentsContainer.Holder = item.Components;
					UpdateCountLabel();
				}
			}
		}

		protected TextureRect ItemIconRect => NameContainer.GetNode<TextureRect>("ItemIconRect");

		protected PathIdLabel IdLabel => DataContainer.GetNode<PathIdLabel>("PathIdLabel");

		protected ComponentCollectionHolder ComponentsContainer => GetNode<ComponentCollectionHolder>("%ComponentCollectionHolder");
		protected OptionButton AddComponentOption => GetNode<OptionButton>("%AddComponentOptionButton");
		protected Label ComponentsCountLabel => NameContainer.GetNode<Label>("%ComponentsCountLabel");

		void OnComponentsButton_Toggle(bool toggledOn)
		{
			ComponentsContainer.Visible = toggledOn;
		}

		void UpdateCountLabel()
		{
			ComponentsCountLabel.Text = (_resource as ItemEntry).Components.Collection.Count.ToString();
			DebugInfo(nameof(ItemEntryBox), nameof(UpdateCountLabel)).AddLine($"Вызвано в {_resource.ResourceName} " +
			$"с количеством элементов {(_resource as ItemEntry).Components.Collection.Count}").Push();
		}
	}
}