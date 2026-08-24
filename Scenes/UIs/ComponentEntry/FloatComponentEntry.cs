using EasyKJSCrafter.ResourceClasses.ComponentEntities;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class FloatComponentEntry : IntegerComponentEntry
	{
		public override ComponentBase Component
		{
			get => base.Component;
			set
			{
				base.Component = value;
				ValueBox.Value = Godot.Mathf.Snapped(value.Value.AsDouble(), 0.0001);
			}
		}
	}
}