using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class StringDictionaryEntry : DictionaryEntry
	{
		public override DictionaryElementBase Element 
		{ 
			get => base.Element;
			set
			{
				base.Element = value;
				ValueLine.Text = value.Value.AsString();
			}
		}

		protected LineEdit ValueLine => GetNode<LineEdit>("%ValueLine");

		void OnValueLine_Toggled(bool toggledOn)
		{
			Element.Value = ValueLine.Text;
		}
	}
}