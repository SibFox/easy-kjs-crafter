using System.Diagnostics;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
	public partial class DictionaryElementBase : Entry
	{
		public bool InsideArray { get; set; } = false;

		protected Variant _value;
		public virtual Variant Value
		{
			get => _value;
			set
			{
				_value = value;
			}
		}

		public DictionaryElementBase() {}
		public DictionaryElementBase(string key) : base(key) {}
	}
}