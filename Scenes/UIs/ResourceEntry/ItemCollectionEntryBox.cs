using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemCollectionEntryBox : ResourceEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource;
			set
			{
				if (value is ItemCollection coll)
				{
					_resource = coll;

					KeyLine.Text = coll.ResourceName;
					EntryNameLine.Text = coll.EntryName;

					ItemHolder.Holder = coll;
					UpdateCountLabel();
				}
			}
		}

		Label CountLabel => NameContainer.GetNode<Label>("CountLabel");
		ItemCollectionHolder ItemHolder => DataContainer.GetNode<ItemCollectionHolder>("ItemCollectionHolder");

		void UpdateCountLabel()
		{ 
			CountLabel.Text = (_resource as ItemCollection).Collection.Count.ToString();
			DebugInfo(nameof(ItemCollectionEntryBox), nameof(UpdateCountLabel)).AddLine($"Вызвано в {_resource.ResourceName} " +
			$"с количеством элементов {(_resource as ItemCollection).Collection.Count}").Push();
		}
	}
}