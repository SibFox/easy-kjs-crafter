using System;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

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

					BuildEntryTree();
				}
			}
		}

		Label CountLabel => NameContainer.GetNode<Label>("CountLabel");
		CollectionHolder CollHolder => DataContainer.GetNode<CollectionHolder>("CollectionHolder");

		void BuildEntryTree()
		{
			CollHolder.Collection = _resource as ItemCollection;
			CollHolder.BuildEntryTree();
		}

        void OnResized()
        {
            CountLabel.Text = (_resource as ItemCollection).Collection.Count.ToString();
        }
	}
}