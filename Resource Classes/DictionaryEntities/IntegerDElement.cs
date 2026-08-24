using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}, Value={Value.AsInt32()}")]
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

		public override string StringView => (!InsideArray ? $"{Key}:" : string.Empty) + Value.AsInt32();

		public IntegerDElement() { Value = 0; }
		public IntegerDElement(string key) : base(key) {}
	}
}