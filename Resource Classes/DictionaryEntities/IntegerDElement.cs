using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class IntegerDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.AsInt32();
			set
			{
				_value = value.AsInt32();
			}
		}

		public IntegerDElement() { Value = 0; }
		public IntegerDElement(string key) : base(key) {}
	}
}