using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using EasyKJSCrafter.Singleton;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationTab
{
	public partial class DeclarationTab : ScrollContainer
	{
		[Export]
		public ItemCollection DeclarationCollection { get; set; }

		CollectionHolder CollHolder => GetNode<CollectionHolder>("CollectionHolder");

		public override void _Ready() {
			CollHolder.Collection = DeclarationCollection;
			CollHolder.BuildEntryTree();
		}
	}
}
