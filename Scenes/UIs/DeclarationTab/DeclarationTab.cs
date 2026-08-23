using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationTabUI
{
	public partial class DeclarationTab : ScrollContainer
	{
		[Export]
		ItemCollection DeclarationCollection { get; set; }

		ItemCollectionHolder CollectionHolder => GetChild<ItemCollectionHolder>(0);

		public override void _Ready()
		{
			CollectionHolder.Holder = DeclarationCollection;
		}

		public void BuildCollection() => CollectionHolder.BuildEntryTree();

		public bool SaveCollection()
		{
			if (CollectionHolder.ValidateCollection())
			{
				if (ResourceSaver.Save(DeclarationCollection) == Error.Ok)
				{
					GD.Print($"Коллекция \"{DeclarationCollection.Key}\" успешно сохранена");
					return true;
				}
				else
					GD.Print($"При сохранении коллекции \"{DeclarationCollection.Key}\" произошла ошибка");
			}
			return false;
		}

		public string GetStringView() => DeclarationCollection.StringView;
	}
}