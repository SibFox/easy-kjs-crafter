using System;
using System.Linq;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs
{
	public partial class CollectionHolder : VBoxContainer
	{
		[Export]
		public ItemCollection Collection { get; set; }

		OptionButton AddEntryOption => GetNode<OptionButton>("AddEntryOption");

		public void BuildEntryTree()
		{
			foreach (Node entry in GetChildren())
			{
				if (entry is not Button)
					entry.QueueFree();
			}

			if (Collection == null)
				return;

			foreach (ResourceEntry entry in Collection.Collection)
			{
				if (entry is ItemEntry item)
				{
					ItemEntryBox itemBox = Global.LoadedUIScenes.ItemEntryBoxInstance();
					itemBox.Resource = item;
					AddChild(itemBox, false, InternalMode.Front);
					GD.Print($"[CollectionHolder] Added item with name {entry.ResourceName} from {GetOwner().Name}");
				}
				if (entry is ItemCollection icoll)
				{
					ItemCollectionEntryBox collectionBox = Global.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
					collectionBox.Resource = icoll;
					AddChild(collectionBox, false, InternalMode.Front);
					GD.Print($"[CollectionHolder] Added collection with name {entry.ResourceName} from {GetOwner().Name}");
				}
			}
		}

		void OnAddEntryOption_Selected(int index)
		{
			AddEntryOption.Selected = 0;
			
			switch (index)
			{
				case 1:
					ItemEntry item = new();
					Collection.Collection.Add(item);
					ItemEntryBox itemBox = Global.LoadedUIScenes.ItemEntryBoxInstance();
					itemBox.Resource = item;
					AddChild(itemBox, false, InternalMode.Front);
					break;
				case 2:
					ItemCollection coll = new();
					Collection.Collection.Add(coll);
					ItemCollectionEntryBox collectionBox = Global.LoadedUIScenes.ItemCollectionEntryBoxBoxInstance();
					collectionBox.Resource = coll;
					AddChild(collectionBox, false, InternalMode.Front);
					break;
			}
		}
	}
}