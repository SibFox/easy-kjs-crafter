using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class BooleanComponentEntry : ComponentEntry
	{
		public override ComponentBase Component 
		{ 
			get => base.Component;
			set
			{
				base.Component = value;
				ValueCheck.ButtonPressed = value.Value.AsBool();
			}
		}

		protected CheckButton ValueCheck => GetNode<CheckButton>("%ValueCheck");

		void OnValueCheck_Toggled(bool toggledOn)
		{
			Component.Value = toggledOn;
		}
	}
}