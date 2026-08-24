using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}, Value={Value.AsBool()}")]
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

		public override string StringView => (!InsideArray ? $"{Key}:" : string.Empty) + Value.AsBool().ToString().ToLower();

		public BooleanDElement() { Value = false; }
		public BooleanDElement(string key) : base(key) {}
	}
}