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
				CollectionHolder.Holder.DebuggerName = "DictionaryCollectionHolder_"+Name.ToString().Split('_')[1];
				CollectionHolder.Holder.Key = value.Id.WholePath.Replace(':','_').Replace('/','_');
				HasErrorsLabel.Visible = value.HasErrors;
				UpdateCountLabel();

				CollectionHolder.Visible = ShowDictionaryButton.ButtonPressed = _component.Expanded;
				ShowDictionaryButton.Text = _component.Expanded ? "X" : "O";
			}
		}

		protected DictionaryCollectionHolder CollectionHolder => GetChild<DictionaryCollectionHolder>(1);
		protected Button ShowDictionaryButton => GetNode<Button>("%ShowDictionaryButton");
		protected Label ElementsCountLabel => GetNode<Label>("%ElementsCountLabel");

		void OnShowArrayButton_Toggled(bool toggledOn)
		{
			Component.Expanded = toggledOn;
			ShowDictionaryButton.Text = toggledOn ? "X" : "O";
			CollectionHolder.Visible = toggledOn;
		}

		void UpdateCountLabel() => ElementsCountLabel.Text = CollectionHolder.Collection.Count.ToString();

		void UpdateHolderKey(string wholePath) => CollectionHolder.Holder.Key = wholePath.Replace(':','_').Replace('/','_');
	}
}