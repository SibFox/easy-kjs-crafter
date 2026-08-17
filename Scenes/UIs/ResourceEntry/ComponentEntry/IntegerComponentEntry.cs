using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class IntegerComponentEntry : ComponentEntry
	{
		[Export]
		public override ComponentBase Component
		{
			get => _component;
			set
			{
				base.Component = value;
				ValueBox.Value = value.Value.AsInt32();
			}
		}

		SpinBox ValueBox => GetNode<SpinBox>("%ValueSpinBox");

		void OnValueBox_ValueChanged(float val)
		{
			_component.Value = val;
		}
	}
}