using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;
using System.Diagnostics;
using System.Text;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, ItemId = {ItemId.WholePath}")]
	public partial class ItemEntry : TagEntry
	{
		[Export]
		public ComponentCollection Components { get; private set; }

		public override string StringView
		{
			get
			{
				StringBuilder builder = new();
				if (!string.IsNullOrEmpty(EntryName))
					builder.Append(new string('\t', Level) + "// " + EntryName + '\n');
				builder.Append(new string('\t', Level) + $"{Key}: \'{Id.WholePath}");

				if (Components.Collection.Count > 0)
				{
					builder.Append('[');
					System.Collections.Generic.LinkedList<string> entries = [];
					foreach (var comp in Components.Collection)
					{
						entries.AddLast(comp.StringView);
					}
					builder.AppendJoin(',', entries);
					builder.Append(']');
				}
				builder.Append('\'');
				return builder.ToString();
			}
		}

		public bool ComponentsExpanded { get; set; }

		public ItemEntry() : base() { Components = new(); }
		public ItemEntry(string declarationKey, PathId itemId, string itemName = null) : base(declarationKey, itemId, itemName) { Components = new(); }
		public ItemEntry(string declarationKey, string itemId, string itemName = null) : base(declarationKey, itemId, itemName) { Components = new(); }
	}
}
