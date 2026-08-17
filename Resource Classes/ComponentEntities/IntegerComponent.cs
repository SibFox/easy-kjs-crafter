using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
    /* Пример:
                PathId                  Value
        industrialupgrade:level_microchip=10
    */
    [GlobalClass]
    [DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
    public partial class IntegerComponent : ComponentBase
    {
        [Export]
        public override Variant Value
		{
			get => _value.AsInt32();
			set
			{
				_value = (int)value;
			}
		}

        public IntegerComponent() {}
        public IntegerComponent(PathId pathId, int val) : base(pathId) { Value = val; }
        public IntegerComponent(string wholePath, int val) : base(wholePath) { Value = val; }
    }
}