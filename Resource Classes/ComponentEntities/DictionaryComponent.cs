using System.Diagnostics;
using Godot;
using Godot.Collections;

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
		[Export]
		public override Variant Value
		{
			get => _value.AsGodotDictionary<string, Variant>();
			set
			{
				_value = value.AsGodotDictionary<string, Variant>();
			}
		}

		public DictionaryComponent() {}
		public DictionaryComponent(PathId pathId) : base(pathId) {}
		public DictionaryComponent(string wholePath) : base(wholePath) {}
	}
}