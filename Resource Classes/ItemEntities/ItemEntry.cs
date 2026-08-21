using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;
using System.Diagnostics;

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
