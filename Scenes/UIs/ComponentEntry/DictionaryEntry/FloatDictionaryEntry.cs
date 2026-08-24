using EasyKJSCrafter.ResourceClasses.DictionaryEntities;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class FloatDictionaryEntry : IntegerDictionaryEntry
	{
		public override DictionaryElementBase Element
		{
			get => base.Element;
			set
			{
				base.Element = value;
				ValueBox.Value = Godot.Mathf.Snapped(value.Value.AsDouble(), 0.0001);
			}
		}
	}
}