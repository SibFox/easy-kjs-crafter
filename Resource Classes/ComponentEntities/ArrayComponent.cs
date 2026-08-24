using System.Diagnostics;
using System.Text;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
	/* Пример:
					PathId                  Value is [StringComponent(PathId="string")]
		geneticsresequenced:dna_helix[geneticsresequenced:gene="geneticsresequenced:step_assist"]
	*/
	[GlobalClass]
	[DebuggerDisplay("Id = {Id.WholePath}, Count = {Value.Count}")]
	public partial class ArrayComponent : ComponentBase
	{
		/// <summary>
		/// Массив компонентов
		/// Возвращает <see cref="ComponentCollection"/>
		/// </summary>
		[Export]
		public override Variant Value
		{
			get => _value.As<ComponentCollection>();
			set
			{
				_value = value.As<ComponentCollection>();
			}
		}

		public override string StringView
		{
			get
			{
				StringBuilder builder = new();

				builder.Append($"{Id.WholePath}[");

				System.Collections.Generic.LinkedList<string> entries = [];
				foreach (var comp in Value.As<ComponentCollection>().Collection)
				{
					entries.AddLast(comp.StringView);
				}
				
				builder.AppendJoin(',', entries);
				builder.Append(']');

				return builder.ToString();
			}
		}

		public ArrayComponent() { Value = new ComponentCollection(); }
		public ArrayComponent(PathId pathId) : base(pathId) { Value = new ComponentCollection(); }
		public ArrayComponent(string wholePath) : base(wholePath) { Value = new ComponentCollection(); }
	}
}