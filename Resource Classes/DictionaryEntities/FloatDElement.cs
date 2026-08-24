using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}, Value={Value.AsDouble()}")]
	public partial class FloatDElement : DictionaryElementBase
	{
		[Export]
		public override Variant Value
		{
			get => _value.AsDouble();
			set
			{
				_value = Mathf.Snapped(value.AsDouble(), 0.0001);
			}
		}

		public override string StringView => (!InsideArray ? $"{Key}:" : string.Empty) + Mathf.Snapped(Value.AsDouble(), 0.0001).ToString().Replace(',','.');

		public FloatDElement() { Value = 0.0; }
		public FloatDElement(string key) : base(key) {}
	}
}