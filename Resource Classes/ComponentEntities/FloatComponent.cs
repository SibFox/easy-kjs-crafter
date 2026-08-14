using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
    /* Пример:
        PathId     Value
        modid:path=15.8
    */
    [GlobalClass]
    [DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
    public partial class FloatComponent : ComponentBase
    {
        [Export]
        public new float Value { get; set; }

        public FloatComponent() {}
        public FloatComponent(PathId pathId, float val) : base(pathId) { Value = val; }
        public FloatComponent(string wholePath, float val) : base(wholePath) { Value = val; }
    }
}