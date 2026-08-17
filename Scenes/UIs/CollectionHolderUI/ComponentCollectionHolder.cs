using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	public partial class ComponentCollectionHolder : CollectionHolder, ICollectionHolder<ComponentsCollection, ComponentBase>
	{
		[Export]
		public ComponentsCollection Holder { get; set; }
		public Array<ComponentBase> Collection => Holder.Collection;

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

			// foreach (ComponentBase component in Holder.Collection)
			// {
			// 	if (entry is ItemEntry item)
			// 	{
			// 		ItemEntryBox itemBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
			// 		itemBox.Resource = item;
			// 		AddChild(itemBox, false, InternalMode.Front);
			// 		addedEntries++;
			// 	}
			// 	if (entry is ItemCollection icoll)
			// 	{
			// 		ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
			// 		collectionBox.Resource = icoll;
			// 		AddChild(collectionBox, false, InternalMode.Front);
			// 		addedEntries++;
			// 	}
			// }

			// GD.Print($"[CollectionHolder] Added {addedEntries} entries from collection {Holder.ResourceName}");
		}

		// void OnAddEntryButton_Pressed()
		// {
		// 	ItemEntry item = new();
		// 	Holder.Collection.Add(item);
		// 	ItemEntryBox itemBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
		// 	itemBox.Resource = item;
		// 	AddChild(itemBox, false, InternalMode.Front);
		// }

		// void OnAddCollectionButton_Pressed()
		// {
		// 	ItemCollection coll = new();
		// 	Holder.Collection.Add(coll);
		// 	ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
		// 	collectionBox.Resource = coll;
		// 	AddChild(collectionBox, false, InternalMode.Front);
		// }

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}