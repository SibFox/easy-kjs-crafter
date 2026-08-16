using Godot;
using Godot.Collections;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using System.Diagnostics;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    [DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, ItemId = {ItemId.WholePath}")]
    public partial class ItemEntry : ResourceEntry
    {
        // Для отображения в редакторе
        [Export]
        public PathId Id { get; set; }
        [Export]
        public Array<ComponentBase> Components { get; private set; }

        // Для отображения иконки для удобного отображения
        // TODO: Вставку через буфер обмена и сохранение внутри файлов проекта/приложения
        [Export]
        public Texture2D Icon { get; set; }

        public ItemEntry() { Components = []; Id = new(); }

        public ItemEntry(string declarationKey, PathId itemId, string itemName = null) : base(declarationKey, itemName)
        {
            Id = itemId;
            Components = [];
        }

        public ItemEntry(string declarationKey, string itemIdString, string itemName = null) : base(declarationKey, itemName)
        {
            Id.SetPathFromWholePath(itemIdString);
            Components = [];
        }
    }
}
