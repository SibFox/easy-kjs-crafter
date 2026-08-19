using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class IntegerComponentEntry : ComponentEntry
	{
		[Export]
		public override ComponentBase Component
		{
			get => base.Component;
			set
			{
				base.Component = value;
				ValueBox.Value = value.Value.AsInt32();
			}
		}

		protected SpinBox ValueBox => GetNode<SpinBox>("%ValueSpinBox");

		void OnValueBox_ValueChanged(float val)
		{
			_component.Value = val;
		}
	}
}