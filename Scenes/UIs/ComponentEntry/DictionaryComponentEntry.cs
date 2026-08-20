using EasyKJSCrafter.ResourceClasses.ComponentEntities;
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

				// CollectionHolder.Holder = (value as DictionaryComponent).Value.As<ComponentCollection>();
				UpdateCountLabel();
			}
		}

		protected ComponentCollectionHolder CollectionHolder => GetNode<ComponentCollectionHolder>("ComponentCollectionHolder");
		protected Button ShowArrayButton => GetNode<Button>("%ShowArrayButton");
		protected Label ComponentsCountLabel => GetNode<Label>("%ComponentsCountLabel");
		
		void OnShowArrayButton_Toggled(bool toggledOn)
		{
			ShowArrayButton.Text = toggledOn ? "X" : "O";
			CollectionHolder.Visible = toggledOn;
		}

		void UpdateCountLabel() => ComponentsCountLabel.Text = CollectionHolder.Collection.Count.ToString();
	}
}