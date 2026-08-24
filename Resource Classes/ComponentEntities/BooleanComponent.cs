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
		/// <summary>
		/// Булевый компонент
		/// Возвращает <see cref="bool"/>
		/// </summary>
		[Export]
		public override Variant Value
		{
			get => _value.AsBool();
			set
			{
				_value = value.AsBool();
			}
		}

		public override string StringView => $"{Id.WholePath}={Value.AsBool().ToString().ToLower()}";

		public BooleanComponent() { Value = false; }
		public BooleanComponent(PathId pathId, bool val) : base(pathId) { Value = val; }
		public BooleanComponent(string wholePath, bool val) : base(wholePath) { Value = val; }
	}
}