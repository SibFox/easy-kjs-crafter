using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	public partial class ItemCollectionHolder : CollectionHolder, ICollectionHolder<ItemCollection, ResourceEntry>
	{
		protected ItemCollection _holder;
		[Export]
		public ItemCollection Holder 
		{
			get => _holder;
			set
			{
				_holder = value;
				BuildEntryTree();
			}
		}
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
					AddChild(itemBox, false, InternalMode.Front);
					itemBox.Resource = item;
					itemBox.Name = "ItemEntry_"+(GetChildCount()-1);
					addedEntries++;
				}
				if (entry is ItemCollection icoll)
				{
					ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
					AddChild(collectionBox, false, InternalMode.Front);
					collectionBox.Name = "ItemCollectionEntry_"+(GetChildCount()-1);
					collectionBox.Resource = icoll;
					addedEntries++;
				}
			}

			LogInfo(nameof(ItemCollectionHolder), Holder.Key).AddLine($"Added {addedEntries} entries from collection {Holder.ResourceName}").Push();
		}

		void OnAddEntryButton_Pressed()
		{
			ItemEntry item = new() { DebuggerName = "ItemEntry_" + (GetChildCount() - 1) };
			Holder.Collection.Add(item);
			ItemEntryBox itemBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
			AddChild(itemBox, false, InternalMode.Front);
			itemBox.Name = item.DebuggerName;
			itemBox.Resource = item;
			EmitSignalElementAdded();
		}

		void OnAddCollectionButton_Pressed()
		{
			ItemCollection coll = new() { DebuggerName = "ItemCollectionEntry_" + (GetChildCount() - 1) };
			Holder.Collection.Add(coll);
			ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
			AddChild(collectionBox, false, InternalMode.Front);
			collectionBox.Name = coll.DebuggerName;
			collectionBox.Resource = coll;
			EmitSignalElementAdded();
		}

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}