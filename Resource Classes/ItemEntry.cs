using Godot;
using Godot.Collections;
using System;

[GlobalClass]
public partial class ItemEntry : ResourceEntry
{
	// Для отображения в редакторе
	[Export]
	public string ItemName { get; private set; }
	[Export]
	public PathId ItemId { get; private set; }
    [Export]
    public Array<ComponentEntry> Components { get; private set; }

	// Для отображения иконки для удобного отображения
	// TODO: Вставку через буфер обмена и сохранение внутри файлов проекта/приложения
	[Export]
	public Texture2D Icon { get; private set; }

    public ItemEntry(string declarationKey, string itemName, PathId itemId) : base(declarationKey)
    {
        ItemName = itemName;
        ItemId = itemId;
    }

    public ItemEntry(string declarationKey, string itemName, string itemIdString) : base(declarationKey)
    {
        ItemName = itemName;
        ItemId.SetPathFromWholePath(itemIdString);
    }
}
