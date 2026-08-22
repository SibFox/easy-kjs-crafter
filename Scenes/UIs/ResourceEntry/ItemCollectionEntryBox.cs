using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemCollectionEntryBox : ResourceEntryBox
	{
		Label CountLabel => NameContainer.GetNode<Label>("CountLabel");
		ItemCollectionHolder CollectionHolder => DataContainer.GetChild<ItemCollectionHolder>(0);

		[Export]
		public override ResourceEntry Resource
		{
			get => _resource;
			set
			{
				base.Resource = value;
				CollectionHolder.Holder = value as ItemCollection;
				CollectionHolder.Holder.DebuggerName = "ItemCollectionHolder_"+Name.ToString().Split('_')[1];
				UpdateCountLabel();
			}
		}

		void UpdateCountLabel()
		{
			var c = Resource as ItemCollection;
			CountLabel.Text = c.Collection.Count.ToString();
		}
	}
}