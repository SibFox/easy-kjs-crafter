using Godot;
using System.Diagnostics;
using System.Text;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, ItemId = {ItemId.WholePath}")]
	public partial class TagEntry : ResourceEntry
	{
		[Signal]
		public delegate void EntryAddedEventHandler();
		[Signal]
		public delegate void EntryRemovedEventHandler();

		// Для отображения в редакторе
		[Export]
		public PathId Id { get; set; }

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
				builder.Append(new string('\t', Level) + $"{Key}: \'{(GetMeta("IsFluid", false).AsBool() ? "" : '#')}{Id.WholePath}");

				builder.Append('\'');
				return builder.ToString();
			}
		}

		public TagEntry() { Id = new(); }
		public TagEntry(string declarationKey, PathId itemId, string itemName = null) : base(declarationKey, itemName) { Id = itemId; }
		public TagEntry(string declarationKey, string itemIdString, string itemName = null) : base(declarationKey, itemName) { Id.SetPathFromWholePath(itemIdString); }
	}
}
