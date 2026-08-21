using System.Linq;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class ArrayDictionaryEntry : DictionaryEntry
	{
		[Export]
		public override DictionaryElementBase Element
		{
			get => base.Element as ArrayDElement;
			set
			{
				base.Element = value;

				CollectionHolder.Holder = (value as ArrayDElement).Value.As<DictionaryCollection>();
				UpdateCountLabel();
			}
		}

		protected DictionaryCollectionHolder CollectionHolder => GetNode<DictionaryCollectionHolder>("DictionaryCollectionHolder");
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