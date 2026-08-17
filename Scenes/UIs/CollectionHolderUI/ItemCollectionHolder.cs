using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	public partial class ItemCollectionHolder : CollectionHolder, ICollectionHolder<ItemCollection, ResourceEntry>
	{
		public ItemCollection Holder { get; set; }
		public Array<ResourceEntry> Collection => Holder.Collection;

		OptionButton AddEntryOption => GetNode<OptionButton>("AddEntryOption");


        public override void BuildEntryTree()
		{
			int addedEntries = 0;

			foreach (Node entry in GetChildren(true))
			{
				if (entry.Name != "AddButtonHBoxContainer")
					entry.QueueFree();
			}

			if (Holder == null)
				return;

			foreach (ResourceEntry entry in Holder.Collection)
			{
				if (entry is ItemEntry item)
				{
					ItemEntryBox itemBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
					itemBox.Resource = item;
					AddChild(itemBox, false, InternalMode.Front);
					addedEntries++;
				}
				if (entry is ItemCollection icoll)
				{
					ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
					collectionBox.Resource = icoll;
					AddChild(collectionBox, false, InternalMode.Front);
					addedEntries++;
				}
			}

			GD.Print($"[CollectionHolder] Added {addedEntries} entries from collection {Holder.ResourceName}");
		}

		void OnAddEntryButton_Pressed()
		{
			ItemEntry item = new();
			Holder.Collection.Add(item);
			ItemEntryBox itemBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
			itemBox.Resource = item;
			AddChild(itemBox, false, InternalMode.Front);
		}

		void OnAddCollectionButton_Pressed()
		{
			ItemCollection coll = new();
			Holder.Collection.Add(coll);
			ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
			collectionBox.Resource = coll;
			AddChild(collectionBox, false, InternalMode.Front);
		}

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}