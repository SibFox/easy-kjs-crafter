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
				CollectionHolder.Holder.InsideArray = value.InsideArray;
				CollectionHolder.Holder.DebuggerName = "InArrayDictionaryCollectionHolder_"+Name.ToString().Split('_')[1];
				CollectionHolder.Holder.Key = value.Key;
				CollectionHolder.Holder.InsideArray = true;
				HasErrorsLabel.Visible = value.HasErrors;
				UpdateCountLabel();

				CollectionHolder.Visible = ShowArrayButton.ButtonPressed = _element.Expanded;
				ShowArrayButton.Text = _element.Expanded ? "X" : "O";
			}
		}


		protected DictionaryCollectionHolder CollectionHolder => GetChild<DictionaryCollectionHolder>(1);
		protected Button ShowArrayButton => GetNode<Button>("%ShowArrayButton");
		protected Label ComponentsCountLabel => GetNode<Label>("%ComponentsCountLabel");

		void OnShowArrayButton_Toggled(bool toggledOn)
		{
			Element.Expanded = toggledOn;
			ShowArrayButton.Text = toggledOn ? "X" : "O";
			CollectionHolder.Visible = toggledOn;
		}

		void UpdateCountLabel() => ComponentsCountLabel.Text = CollectionHolder.Collection.Count.ToString();

		protected override void OnKeyLine_EditingToggled(bool toggledOn)
		{
			base.OnKeyLine_EditingToggled(toggledOn);
			CollectionHolder.Holder.Key = Element.Key;
		}

	}
}