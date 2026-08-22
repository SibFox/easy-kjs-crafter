using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class DictionaryDElement : DictionaryElementBase
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

		public DictionaryDElement() { Value = new DictionaryCollection(); }
		public DictionaryDElement(string key) : base(key) { Value = new DictionaryCollection(); }
	}
}