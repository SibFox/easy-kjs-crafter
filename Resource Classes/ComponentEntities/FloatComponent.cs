using System.Diagnostics;
using System.Text;
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
		public override Variant Value
		{
			get => _value.AsDouble();
			set
			{
				_value = Mathf.Snapped(value.AsDouble(), 0.0001);
			}
		}

		public override string StringView => $"{Id.WholePath}={Mathf.Snapped(Value.AsDouble(), 0.0001).ToString().Replace(',','.')}";

		public FloatComponent() { Value = 0.0; }
		public FloatComponent(PathId pathId, float val) : base(pathId) { Value = val; }
		public FloatComponent(string wholePath, float val) : base(wholePath) { Value = val; }
	}
}