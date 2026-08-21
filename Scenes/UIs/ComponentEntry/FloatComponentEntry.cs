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
				ValueBox.Value = value.Value.AsDouble();
			}
		}
	}
}