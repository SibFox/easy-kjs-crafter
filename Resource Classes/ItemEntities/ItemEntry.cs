using Godot;
using Godot.Collections;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using System.Diagnostics;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    [DebuggerDisplay("Key = {ResourceName}, Name = {ItemName}, ItemId = {ItemId.WholePath}")]
    public partial class ItemEntry : ResourceEntry
    {
        // Для отображения в редакторе
        [Export]
        public string ItemName { get; set; }
        [Export]
        public PathId ItemId { get; set; } = new();
        [Export]
        public Array<ComponentBase> Components { get; set; }

        // Для отображения иконки для удобного отображения
        // TODO: Вставку через буфер обмена и сохранение внутри файлов проекта/приложения
        [Export]
        public Texture2D Icon { get; set; }

        public ItemEntry() {}

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
}
