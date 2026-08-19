using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
    /* Пример:
        PathId        Value
        modid:path="somestring"
    */
    [GlobalClass]
    [DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
    public partial class StringComponent : ComponentBase
    {
        [Export]
        public override Variant Value
		{
			get => _value.AsString();
			set
			{
				_value = value.AsString();
			}
		}

        public StringComponent() {}
        public StringComponent(PathId pathId, string val) : base(pathId) { Value = val; }
        public StringComponent(string wholePath, string val) : base(wholePath) { Value = val; }
    }
}