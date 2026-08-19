using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ComponentEntryUI;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	public partial class ComponentCollectionHolder : CollectionHolder, ICollectionHolder<ComponentCollection, ComponentBase>
	{
		protected ComponentCollection _holder;
		[Export]
		public ComponentCollection Holder 
		{
			get => _holder;
			set
			{
				_holder = value;
				BuildEntryTree();
				EmitSignalElementAdded();
			}
		}
		public Array<ComponentBase> Collection => Holder.Collection;

		VBoxContainer CollectionContainer => GetNode<VBoxContainer>("BorderPanelContainer/CollectionVBoxContainer");
		public OptionButton AddComponentOption => CollectionContainer.GetNode<OptionButton>("AddComponentOptionButton");

		void OnAddComponentOption_Selected(int index)
		{
			AddComponentOption.Selected = 0;
			AddComponent((ComponentBase.ComponentType)index-1);
			EmitSignalElementAdded();
		}

		public override void BuildEntryTree()
		{
			foreach (Node entry in CollectionContainer.GetChildren(true))
			{
				if (entry.Name != "AddComponentOptionButton")
					entry.QueueFree();
			}

			if (Holder == null)
				return;
			
			// int c = 0;
			foreach (ComponentBase component in Collection)
			{
				switch (component)
				{
					case IntegerComponent i:
						AddComponent(ComponentBase.ComponentType.Integer, i);
						break;
					case FloatComponent i:
						AddComponent(ComponentBase.ComponentType.Float, i);
						break;
					case StringComponent i:
						AddComponent(ComponentBase.ComponentType.String, i);
						break;
					case BooleanComponent i:
						AddComponent(ComponentBase.ComponentType.Boolean, i);
						break;
					case ArrayComponent i:
						AddComponent(ComponentBase.ComponentType.Array, i);
						break;
					case DictionaryComponent i:
						AddComponent(ComponentBase.ComponentType.Dictionary, i);
						break;
				}

				// c++;
			}
			// LogInfo(nameof(ComponentCollectionHolder), nameof(BuildEntryTree)).AddLine($"Добавлено {c} компонентов для записи \"{_resource.ResourceName}\"");
		}

		void AddComponent(ComponentBase.ComponentType type, ComponentBase componentBase = null)
		{
			// ComponentEntry componentEntry = new();
			switch (type)
			{
				case ComponentBase.ComponentType.Integer:
					IntegerComponentEntry intComponentEntry = Manager.LoadedUIScenes.IntegerComponentEntryInstance();
					if (componentBase == null)
					{
						componentBase = new IntegerComponent();
						Collection.Add(componentBase);
					}
					intComponentEntry.Component = componentBase as IntegerComponent;
					intComponentEntry.Name = $"IntegerComponentEntry_{componentBase.Id.WholePath}";
					CollectionContainer.AddChild(intComponentEntry, false, InternalMode.Front);
					break;
				case ComponentBase.ComponentType.Float:
					FloatComponentEntry floatComponentEntry = Manager.LoadedUIScenes.FloatComponentEntryInstance();
					if (componentBase == null)
					{
						componentBase = new FloatComponent();
						Collection.Add(componentBase);
					}
					floatComponentEntry.Component = componentBase as FloatComponent;
					floatComponentEntry.Name = $"FloatComponentEntry_{componentBase.Id.WholePath}";
					CollectionContainer.AddChild(floatComponentEntry, false, InternalMode.Front);
					break;
				case ComponentBase.ComponentType.String:
					StringComponentEntry stringComponentEntry = Manager.LoadedUIScenes.StringComponentEntryInstance();
					if (componentBase == null)
					{
						componentBase = new StringComponent();
						Collection.Add(componentBase);
					}
					stringComponentEntry.Component = componentBase as StringComponent;
					stringComponentEntry.Name = $"StringComponentEntry_{componentBase.Id.WholePath}";
					CollectionContainer.AddChild(stringComponentEntry, false, InternalMode.Front);
					break;
				case ComponentBase.ComponentType.Boolean:
					BooleanComponentEntry booleanComponentEntry = Manager.LoadedUIScenes.BooleanComponentEntryInstance();
					if (componentBase == null)
					{
						componentBase = new BooleanComponent();
						Collection.Add(componentBase);
					}
					booleanComponentEntry.Component = componentBase as BooleanComponent;
					booleanComponentEntry.Name = $"BooleanComponentEntry_{componentBase.Id.WholePath}";
					CollectionContainer.AddChild(booleanComponentEntry, false, InternalMode.Front);
					break;
				case ComponentBase.ComponentType.Array:
					ArrayComponentEntry arrayComponentEntry = Manager.LoadedUIScenes.ArrayComponentEntryInstance();
					if (componentBase == null)
					{
						componentBase = new ArrayComponent();
						Collection.Add(componentBase);
					}
					arrayComponentEntry.Component = componentBase as ArrayComponent;
					arrayComponentEntry.Name = $"ArrayComponentEntry_{componentBase.Id.WholePath}";
					CollectionContainer.AddChild(arrayComponentEntry, false, InternalMode.Front);
					break;
				// case ComponentBase.ComponentType.Dictionary:
				// 	componentEntry = Manager.LoadedUIScenes.DictionaryComponentEntryInstance();
				// 	if (componentBase == null)
				// 	{
				// 		componentBase = new DictionaryComponent();
				// 		Collection.Add(componentBase);
				// 	}
				// componentEntry.Component = componentBase;
				// 	CollectionContainer.AddChild(componentEntry, false, InternalMode.Front);
				// 	break;
			}
		}

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}