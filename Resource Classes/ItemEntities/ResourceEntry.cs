using System.Diagnostics;
using System.Text.RegularExpressions;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}")]
	public partial class ResourceEntry : Entry
	{
		[Export]
		public string EntryName { get; set; }
		// Сохранение состояния раскрытия записи в редакторе
		public bool Expanded { get; set; }

		public ResourceEntry() {}
		public ResourceEntry(string declarationKey, string entryName = null) : base(declarationKey) => EntryName = entryName;
	}
}