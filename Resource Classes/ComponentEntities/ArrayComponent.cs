using System.Diagnostics;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;
using Godot.Collections;

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

		public ArrayComponent() { Value = new ComponentCollection(); }
		public ArrayComponent(PathId pathId) : base(pathId) { Value = new ComponentCollection(); }
		public ArrayComponent(string wholePath) : base(wholePath) { Value = new ComponentCollection(); }
	}
}