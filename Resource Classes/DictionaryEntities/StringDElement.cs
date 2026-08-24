using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}, Value={Value.ToString()}")]
	public partial class StringDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.AsString();
			set
			{
				_value = value.AsString();
			}
		}

		public override string StringView => (!InsideArray ? $"{Key}:" : string.Empty) + $"\"{Value}\"";

		public StringDElement() { Value = string.Empty; }
		public StringDElement(string key) : base(key) {}
	}
}