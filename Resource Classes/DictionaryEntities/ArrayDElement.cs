using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class ArrayDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.As<DictionaryCollection>();
			set
			{
				_value = value.As<DictionaryCollection>();
			}
		}

		public ArrayDElement() { Value = new DictionaryCollection(); }
		public ArrayDElement(string key) : base(key) { Value = new DictionaryCollection(); }
	}
}