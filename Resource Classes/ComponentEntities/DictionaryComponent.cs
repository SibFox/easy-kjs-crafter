using System.Diagnostics;
using System.Text;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
	/* Пример:
					PathId                       key : Variant, key : Variant
		geneticsresequenced:plasmid_progress={dna_points:50,gene:"geneticsresequenced:regeneration_4"}
	*/
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Count = {Value.Count}")]
	public partial class DictionaryComponent : ComponentBase
	{
		/// <summary>
		/// Словарь вхождений
		/// Возвращает <see cref="DictionaryCollection"/>
		/// </summary>
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

				builder.Append($"{Id.WholePath}={{");

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

		public DictionaryComponent() { Value = new DictionaryCollection(); }
		public DictionaryComponent(PathId pathId) : base(pathId) { Value = new DictionaryCollection(); }
		public DictionaryComponent(string wholePath) : base(wholePath) { Value = new DictionaryCollection(); }
	}
}