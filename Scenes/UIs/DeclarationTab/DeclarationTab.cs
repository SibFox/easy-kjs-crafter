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

		ItemCollectionHolder CollectionHolder => GetNode<ItemCollectionHolder>("ItemCollectionHolder");

		public override void _Ready() {
			CollectionHolder.Holder = DeclarationCollection;
		}

		public bool SaveCollection()
		{
			if (CollectionHolder.ValidateCollection())
			{
				if (ResourceSaver.Save(DeclarationCollection) == Error.Ok)
				{
					GD.Print($"Коллекция \"{DeclarationCollection.ResourceName}\" успешно сохранена");
					return true;
				}
				else
					GD.Print($"При сохранении коллекции \"{DeclarationCollection.ResourceName}\" произошла ошибка");
			}
			return false;
		}
	}
}
