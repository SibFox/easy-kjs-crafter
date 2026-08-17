using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.Interfaces
{
	// [GlobalClass]
	// [DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, Count = {Collection.Count}")]
	public interface ICollection<[MustBeVariant] T>
	{
		[Export]
		public Array<T> Collection { get; set; }

		public string ValidateCollection(int deep = 0) => string.Empty;
	}
}