using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class StringComponentEntry : ComponentEntry
	{
		public override ComponentBase Component 
		{ 
			get => base.Component;
			set
			{
				base.Component = value;
				ValueLine.Text = value.Value.AsString();
			}
		}

		protected LineEdit ValueLine => GetNode<LineEdit>("%ValueLine");

		void OnValueLine_Toggled(bool toggledOn)
		{
			_component.Value = ValueLine.Text;
		}
	}
}