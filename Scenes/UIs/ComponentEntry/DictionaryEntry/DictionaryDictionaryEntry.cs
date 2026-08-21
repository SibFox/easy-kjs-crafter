using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class DictionaryDictionaryEntry : DictionaryEntry
	{
		[Export]
		public override DictionaryElementBase Element
		{
			get => base.Element as DictionaryDElement;
			set
			{
				base.Element = value;

				CollectionHolder.Holder = (value as DictionaryDElement).Value.As<DictionaryCollection>();
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