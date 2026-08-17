using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ComponentEntryUI;
using EasyKJSCrafter;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class ItemEntryBox : ResourceEntryBox
	{
		[Export]
		public override ResourceEntry Resource
		{
			get => _resource;
			set
			{
				if (value is ItemEntry item)
				{
					_resource = value;

					KeyLine.Text = item.ResourceName;
					EntryNameLine.Text = item.EntryName;
					IdLabel.Id = item.Id;
					ItemIconRect.Texture = item.Icon;
					if (item.Icon == null)
						ItemIconRect.Texture = Manager.QuestionMarkTexture;
					ComponentsButton.Text = $"Компоненты ({item.Components.Count})";
					BuildComponentsTree();
				}
			}
		}

		protected TextureRect ItemIconRect => NameContainer.GetNode<TextureRect>("ItemIconRect");

		protected PathIdLabel IdLabel => DataContainer.GetNode<PathIdLabel>("PathIdLabel");
		protected Button ComponentsButton => DataContainer.GetNode<Button>("ComponentsButton");

		protected VBoxContainer ComponentsContainer => GetNode<VBoxContainer>("%ComponentsHolder");
		protected OptionButton AddComponentOption => GetNode<OptionButton>("%AddComponentOptionButton");

		void OnComponentsButton_Toggle(bool toggledOn)
		{
			ComponentsContainer.Visible = toggledOn;
		}

		void OnAddComponentOption_Selected(int index)
		{
			AddComponentOption.Selected = 0;
			AddComponentScene((ComponentBase.ComponentType)index-1);
		}

		void BuildComponentsTree()
		{
			int c = 0;
			foreach (ComponentBase component in (_resource as ItemEntry).Components)
			{
				switch (component)
				{
					case IntegerComponent i:
						AddComponentScene(ComponentBase.ComponentType.Integer, i);
						break;
					case FloatComponent i:
						AddComponentScene(ComponentBase.ComponentType.Float, i);
						break;
					case StringComponent i:
						AddComponentScene(ComponentBase.ComponentType.String, i);
						break;
					case BooleanComponent i:
						AddComponentScene(ComponentBase.ComponentType.Boolean, i);
						break;
					case ArrayComponent i:
						AddComponentScene(ComponentBase.ComponentType.Array, i);
						break;
					case DictionaryComponent i:
						AddComponentScene(ComponentBase.ComponentType.Dictionary, i);
						break;
				}
				c++;
			}
			LogInfo(nameof(ItemEntryBox), nameof(BuildComponentsTree)).AddLine($"Добавлено {c} компонентов для записи \"{_resource.ResourceName}\"");
		}

		void AddComponentScene(ComponentBase.ComponentType type, ComponentBase componentBase = null)
		{
			ComponentEntry componentEntry = new();
			switch (type)
			{
				case ComponentBase.ComponentType.Integer:
					componentEntry = Manager.LoadedUIScenes.IntegerComponentEntryInstance();
					if (componentBase == null)
					{
						var c = new IntegerComponent();
						componentBase = c;
						(_resource as ItemEntry).Components.Add(c);
					}
					break;
				case ComponentBase.ComponentType.Float:
					componentEntry = Manager.LoadedUIScenes.FloatComponentEntryInstance();
					if (componentBase == null)
					{
						var c = new FloatComponent();
						componentBase = c;
						(_resource as ItemEntry).Components.Add(c);
					}
					break;
				case ComponentBase.ComponentType.String:
					componentEntry = Manager.LoadedUIScenes.StringComponentEntryInstance();
					if (componentBase == null)
					{
						var c = new StringComponent();
						componentBase = c;
						(_resource as ItemEntry).Components.Add(c);
					}
					break;
				case ComponentBase.ComponentType.Boolean:
					componentEntry = Manager.LoadedUIScenes.BooleanComponentEntryInstance();
					if (componentBase == null)
					{
						var c = new BooleanComponent();
						componentBase = c;
						(_resource as ItemEntry).Components.Add(c);
					}
					break;
				// case ComponentBase.ComponentType.Array:
				// 	component = Global.LoadedUIScenes.IntegerComponentInstance();
				// 	break;
				// case ComponentBase.ComponentType.Dictionary:
				// 	component = Global.LoadedUIScenes.IntegerComponentInstance();
				// 	break;
			}
			componentEntry.Component = componentBase;
			ComponentsContainer.AddChild(componentEntry, false, InternalMode.Front);
		}
	}
}