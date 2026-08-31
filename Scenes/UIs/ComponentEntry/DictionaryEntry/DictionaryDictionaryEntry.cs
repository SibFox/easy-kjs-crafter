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
				CollectionHolder.Holder.InsideArray = value.InsideArray;
				CollectionHolder.Holder.DebuggerName = "InDictionaryDictionaryCollectionHolder_"+Name.ToString().Split('_')[1];
				CollectionHolder.Holder.Key = value.Key;
				HasErrorsLabel.Visible = value.HasErrors;
				UpdateCountLabel();

				CollectionHolder.Visible = ShowDictionaryButton.ButtonPressed = _element.Expanded;
				ShowDictionaryButton.Text = _element.Expanded ? "X" : "O";
			}
		}

		protected DictionaryCollectionHolder CollectionHolder => GetNode<DictionaryCollectionHolder>("%DictionaryCollectionHolder");
		protected Button ShowDictionaryButton => GetNode<Button>("%ShowDictionaryButton");
		protected Label ElementsCountLabel => GetNode<Label>("%ElementsCountLabel");

		void OnShowArrayButton_Toggled(bool toggledOn)
		{
			Element.Expanded = toggledOn;
			ShowDictionaryButton.Text = toggledOn ? "X" : "O";
			CollectionHolder.Visible = toggledOn;
		}

		void UpdateCountLabel() => ElementsCountLabel.Text = CollectionHolder.Collection.Count.ToString();

		protected override void OnKeyLine_EditingToggled(bool toggledOn)
		{
			base.OnKeyLine_EditingToggled(toggledOn);
			CollectionHolder.Holder.Key = Element.Key;
		}
	}
}