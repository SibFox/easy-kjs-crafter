using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class DictionaryComponentEntry : ComponentEntry
	{
		[Export]
		public override ComponentBase Component
		{
			get => base.Component as DictionaryComponent;
			set
			{
				base.Component = value;

				CollectionHolder.Holder = (value as DictionaryComponent).Value.As<DictionaryCollection>();
				UpdateCountLabel();
			}
		}

		protected DictionaryCollectionHolder CollectionHolder => GetNode<DictionaryCollectionHolder>("DictionaryCollectionHolder");
		protected Button ShowDictionaryButton => GetNode<Button>("%ShowDictionaryButton");
		protected Label ElementsCountLabel => GetNode<Label>("%ElementsCountLabel");
		
		void OnShowArrayButton_Toggled(bool toggledOn)
		{
			ShowDictionaryButton.Text = toggledOn ? "X" : "O";
			CollectionHolder.Visible = toggledOn;
		}

		void UpdateCountLabel() => ElementsCountLabel.Text = CollectionHolder.Collection.Count.ToString();
	}
}