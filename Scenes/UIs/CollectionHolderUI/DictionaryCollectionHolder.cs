using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	public partial class DictionaryCollectionHolder : CollectionHolder, ICollectionHolder<DictionaryCollection, DictionaryElementBase>
	{
		protected DictionaryCollection _holder;
		[Export]
		public DictionaryCollection Holder 
		{
			get => _holder;
			set
			{
				_holder = value;
				BuildEntryTree();
				EmitSignalElementAdded();
			}
		}
		public Array<DictionaryElementBase> Collection => Holder.Collection;

		VBoxContainer CollectionContainer => GetNode<VBoxContainer>("BorderPanelContainer/CollectionVBoxContainer");
		public OptionButton AddElementOption => CollectionContainer.GetNode<OptionButton>("%AddElementOptionButton");

		void OnAddElementOption_Selected(int index)
		{
			AddElementOption.Selected = 0;
			AddElement((ComponentBase.ComponentType)index-1);
			EmitSignalElementAdded();
		}

		public override void BuildEntryTree()
		{
			foreach (Node entry in CollectionContainer.GetChildren(true))
			{
				if (entry.Name != "AddElementOptionButton")
					entry.QueueFree();
			}

			if (Holder == null)
				return;
			
			// int c = 0;
			foreach (DictionaryElementBase component in Collection)
			{
				switch (component)
				{
					case IntegerDElement i:
						AddElement(ComponentBase.ComponentType.Integer, i);
						break;
					case FloatDElement i:
						AddElement(ComponentBase.ComponentType.Float, i);
						break;
					case StringDElement i:
						AddElement(ComponentBase.ComponentType.String, i);
						break;
					case BooleanDElement i:
						AddElement(ComponentBase.ComponentType.Boolean, i);
						break;
					case ArrayDElement i:
						AddElement(ComponentBase.ComponentType.Array, i);
						break;
					case DictionaryDElement i:
						AddElement(ComponentBase.ComponentType.Dictionary, i);
						break;
				}

				// c++;
			}
			// LogInfo(nameof(ComponentCollectionHolder), nameof(BuildEntryTree)).AddLine($"Добавлено {c} компонентов для записи \"{_resource.ResourceName}\"");
		}

		void AddElement(ComponentBase.ComponentType type, DictionaryElementBase elementBase = null)
		{
			DictionaryEntry dictionaryEntry = new();
			switch (type)
			{
				case ComponentBase.ComponentType.Integer:
					dictionaryEntry = Manager.LoadedUIScenes.IntegerDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new IntegerDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"IntegerDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
				case ComponentBase.ComponentType.Float:
					dictionaryEntry = Manager.LoadedUIScenes.FloatDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new FloatDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"FloatDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
				case ComponentBase.ComponentType.String:
					dictionaryEntry = Manager.LoadedUIScenes.StringDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new StringDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"StringDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
				case ComponentBase.ComponentType.Boolean:
					dictionaryEntry = Manager.LoadedUIScenes.BooleanDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new BooleanDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"BooleanDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
				case ComponentBase.ComponentType.Array:
					dictionaryEntry = Manager.LoadedUIScenes.ArrayDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new ArrayDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"ArrayDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
				case ComponentBase.ComponentType.Dictionary:
					dictionaryEntry = Manager.LoadedUIScenes.DictionaryDictionaryEntryInstance();
					if (elementBase == null)
					{
						elementBase = new DictionaryDElement();
						Collection.Add(elementBase);
					}
					elementBase.DebuggerName = $"DictionaryDictionaryEntry_"+(CollectionContainer.GetChildCount()-1);
					break;
			}
			elementBase.InsideArray = GetMeta("IsInArray", false).AsBool();
			if (elementBase.InsideArray)
				elementBase.ResourceName = $"arr_{Holder.Key}_{Collection.Count}";
			dictionaryEntry.Name = elementBase.DebuggerName;
			dictionaryEntry.Element = elementBase;
			CollectionContainer.AddChild(dictionaryEntry, false, InternalMode.Front);
		}

		public bool ValidateCollection() => Holder.ValidateCollection().Length == 0;
	}
}