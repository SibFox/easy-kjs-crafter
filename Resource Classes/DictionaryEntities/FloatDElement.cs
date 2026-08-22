using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class FloatDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.AsDouble();
			set
			{
				_value = value.AsDouble();
			}
		}

		public FloatDElement() { Value = 0.0; }
		public FloatDElement(string key) : base(key) {}
	}
}