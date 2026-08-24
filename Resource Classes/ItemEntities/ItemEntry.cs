using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;
using System.Diagnostics;
using System.Text;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, ItemId = {ItemId.WholePath}")]
	public partial class ItemEntry : ResourceEntry
	{
		[Signal]
		public delegate void EntryAddedEventHandler();
		[Signal]
		public delegate void EntryRemovedEventHandler();

		// Для отображения в редакторе
		[Export]
		public PathId Id { get; set; }
		[Export]
		public ComponentCollection Components { get; private set; }

		// Для отображения иконки для удобного отображения
		// TODO: Вставку через буфер обмена и сохранение внутри файлов проекта/приложения
		[Export]
		public Texture2D Icon { get; set; }

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

		public ItemEntry() { Components = new(); Id = new(); }

		public ItemEntry(string declarationKey, PathId itemId, string itemName = null) : base(declarationKey, itemName)
		{
			Id = itemId;
			Components = new();
		}

		public ItemEntry(string declarationKey, string itemIdString, string itemName = null) : base(declarationKey, itemName)
		{
			Id.SetPathFromWholePath(itemIdString);
			Components = new();
		}
	}
}
