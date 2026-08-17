using System.Diagnostics;
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
        [Export]
        public override Variant Value
		{
			get => _value.AsGodotArray<ComponentBase>();
			set
			{
				_value = (Array<ComponentBase>)value;
			}
		}

        public ArrayComponent() {}
        public ArrayComponent(PathId pathId) : base(pathId) {}
        public ArrayComponent(string wholePath) : base(wholePath) {}
    }    
}