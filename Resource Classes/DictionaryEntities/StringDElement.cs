using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class StringDElement : DictionaryElementBase
	{
		public override Variant Value
		{
			get => _value.AsString();
			set
			{
				_value = value.AsString();
			}
		}

		public StringDElement() {}
		public StringDElement(string key) : base(key) {}
	}
}