using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class BooleanDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.AsBool();
			set
			{
				_value = value.AsBool();
			}
		}

		public BooleanDElement() { Value = false; }
		public BooleanDElement(string key) : base(key) {}
	}
}