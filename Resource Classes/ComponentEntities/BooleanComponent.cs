using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
    /* Пример:
        PathId     Value
        modid:path=false
    */
    [GlobalClass]
    [DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
    public partial class BooleanComponent : ComponentBase
    {
        [Export]
        public new bool Value { get; set; }

        public BooleanComponent() {}
        public BooleanComponent(PathId pathId, bool val) : base(pathId) { Value = val; }
        public BooleanComponent(string wholePath, bool val) : base(wholePath) { Value = val; }
    }
}