using System.Diagnostics;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class ComponentBase : Entry
	{
		public enum ComponentType
		{
			Integer,
			Float,
			String,
			Boolean,
			Array,
			Dictionary
		}

		[Export]
		public PathId Id { get; set; }

		protected Variant _value;
		public virtual Variant Value
		{
			get => _value;
			set
			{
				_value = value;
			}
		}

		public ComponentBase() { Id = new(); }
		public ComponentBase(PathId pathId) { Id = pathId; }
		public ComponentBase(string wholePath) { Id.SetPathFromWholePath(wholePath); }
	}
}