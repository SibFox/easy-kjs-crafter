using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}")]
	public partial class ResourceEntry : Entry
	{
		[Export]
		public string EntryName { get; set; }

		public ResourceEntry() {}
		public ResourceEntry(string declarationKey, string entryName = null) : base(declarationKey) => EntryName = entryName;
	}
}