using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class FloatDElement : DictionaryElementBase
	{
		public override Variant Value
		{
			get => (float)_value.AsDouble();
			set
			{
				_value = (float)value.AsDouble();
			}
		}

		public FloatDElement() {}
		public FloatDElement(string key) : base(key) {}
	}
}