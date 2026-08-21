using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI.DictionaryEntryUI
{
	public partial class IntegerDictionaryEntry : DictionaryEntry
	{
		[Export]
		public override DictionaryElementBase Element
		{
			get => base.Element;
			set
			{
				base.Element = value;
				ValueBox.Value = value.Value.AsInt32();
			}
		}

		protected SpinBox ValueBox => GetNode<SpinBox>("%ValueSpinBox");

		void OnValueBox_ValueChanged(float val)
		{
			Element.Value = val;
		}
	}
}