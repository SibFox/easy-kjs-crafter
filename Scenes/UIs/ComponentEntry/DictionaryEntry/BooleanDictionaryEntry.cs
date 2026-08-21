using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class BooleanDictionaryEntry : DictionaryEntry
	{
		public override DictionaryElementBase Element 
		{ 
			get => base.Element;
			set
			{
				base.Element = value;
				ValueCheck.ButtonPressed = value.Value.AsBool();
			}
		}

		protected CheckButton ValueCheck => GetNode<CheckButton>("%ValueCheck");

		void OnValueCheck_Toggled(bool toggledOn)
		{
			Element.Value = toggledOn;
		}
	}
}