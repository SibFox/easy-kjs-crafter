using System.Diagnostics;
using System.Text;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}, Value={Value.Collection.Count}")]
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

		public override string StringView
		{
			get
			{
				StringBuilder builder = new();

				if (!InsideArray)
					builder.Append($"{Key}:");
				builder.Append('{');

				System.Collections.Generic.LinkedList<string> entries = [];
				foreach (var element in Value.As<DictionaryCollection>().Collection)
				{
					entries.AddLast(element.StringView);
				}

				builder.AppendJoin(',', entries);
				builder.Append('}');

				return builder.ToString();
			}
		}

		public DictionaryDElement() { Value = new DictionaryCollection(); }
		public DictionaryDElement(string key) : base(key) { Value = new DictionaryCollection(); }
	}
}