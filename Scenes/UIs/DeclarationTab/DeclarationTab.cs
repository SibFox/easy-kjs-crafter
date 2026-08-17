using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationTabUI
{
	public partial class DeclarationTab : ScrollContainer
	{
		[Export]
		public ItemCollection DeclarationCollection { get; set; }

		ItemCollectionHolder CollHolder => GetNode<ItemCollectionHolder>("ItemCollectionHolder");

		public override void _Ready() {
			CollHolder.Holder = DeclarationCollection;
			CollHolder.BuildEntryTree();
		}

		public bool SaveCollection()
		{
			bool res = false;
			if (CollHolder.ValidateCollection())
			{
				if (ResourceSaver.Save(DeclarationCollection) == Error.Ok)
				{
					GD.Print($"Коллекция \"{DeclarationCollection.ResourceName}\" успешно сохранена");
					res = true;
				}
				else
					GD.Print($"При сохранении коллекции \"{DeclarationCollection.ResourceName}\" произошла ошибка");
			}
			CollHolder.BuildEntryTree();
			return res;
		}
	}
}
