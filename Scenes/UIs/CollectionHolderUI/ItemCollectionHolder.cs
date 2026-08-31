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
				ResourceEntryBox entryBox = new();
				if (entry is TagEntry tag)
				{
					if (Holder.Type == ItemCollection.CollectionType.Items)
					{
						entryBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
						entryBox.Resource = tag as ItemEntry;
						entryBox.Name = "ItemEntry_"+(GetChildCount()-1);
					}
					if (Holder.Type == ItemCollection.CollectionType.Tags)
					{
						entryBox = Manager.LoadedUIScenes.TagEntryBoxInstance();
						entryBox.Resource = tag;
						entryBox.Name = "TagEntry_"+(GetChildCount()-1);
					}
					if (Holder.Type == ItemCollection.CollectionType.Fluids)
					{
						entryBox = Manager.LoadedUIScenes.TagEntryBoxInstance();
						tag.SetMeta("IsFluid", true);
						entryBox.Resource = tag;
						entryBox.Name = "FluidEntry_"+(GetChildCount()-1);
					}
				}
				if (entry is ItemCollection icoll)
				{
					icoll.Type = Holder.Type;
					entryBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
					entryBox.Name = "ItemCollectionEntry_"+(GetChildCount()-1);
					entryBox.Resource = icoll;
				}
				addedEntries++;
				AddChild(entryBox, false, InternalMode.Front);
			}

			LogInfo(nameof(ItemCollectionHolder), Holder.Key).AddLine($"Added {addedEntries} entries from collection {Holder.Key}").Push();
		}

		void OnAddEntryButton_Pressed()
		{
			ResourceEntryBox entryBox = new();
			TagEntry entry = new();
			if (Holder.Type == ItemCollection.CollectionType.Items)
			{
				entry = new ItemEntry() { DebuggerName = "ItemEntry_" + (GetChildCount() - 1) };
				entryBox = Manager.LoadedUIScenes.ItemEntryBoxInstance();
			}
			if (Holder.Type == ItemCollection.CollectionType.Tags)
			{
				entry = new() { DebuggerName = "TagEntry_" + (GetChildCount() - 1) };
				entryBox = Manager.LoadedUIScenes.TagEntryBoxInstance();
			}
			if (Holder.Type == ItemCollection.CollectionType.Fluids)
			{
				entry = new() { DebuggerName = "FluidEntry_" + (GetChildCount() - 1) };
				entry.SetMeta("IsFluid", true);
			}

			Holder.Collection.Add(entry);
			AddChild(entryBox, false, InternalMode.Front);
			entryBox.Name = entry.DebuggerName;
			entryBox.Resource = entry;
			EmitSignalElementAdded();
		}

		void OnAddCollectionButton_Pressed()
		{
			ItemCollection coll = new() { DebuggerName = "ItemCollectionEntry_" + (GetChildCount() - 1) };
			Holder.Collection.Add(coll);
			ItemCollectionEntryBox collectionBox = Manager.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
			AddChild(collectionBox, false, InternalMode.Front);
			coll.Type = Holder.Type;
			collectionBox.Name = coll.DebuggerName;
			collectionBox.Resource = coll;
			EmitSignalElementAdded();
		}

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}