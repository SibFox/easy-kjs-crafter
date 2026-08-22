using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
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

		public StringDElement() { Value = string.Empty; }
		public StringDElement(string key) : base(key) {}
	}
}