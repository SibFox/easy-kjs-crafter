using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationTabUI
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

		public void SaveCollection()
		{
			if (CollHolder.ValidateCollection())
			{
				if (ResourceSaver.Save(DeclarationCollection) == Error.Ok)
				{
					GD.Print($"Коллекция \"{DeclarationCollection.ResourceName}\" успешно сохранена");
				}
				else
					GD.Print($"При сохранении коллекции \"{DeclarationCollection.ResourceName}\" произошла ошибка");
			}
			CollHolder.BuildEntryTree();
		}
	}
}
