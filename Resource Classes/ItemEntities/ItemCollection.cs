using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    public partial class ItemCollection : ResourceEntry
    {
        [Export]
        public Array<ResourceEntry> Collection { get; private set; }
        // Для отображения в редакторе
        public string CollectionName { get; set; }

        public ItemCollection() {}
        public ItemCollection(string declarationKey, string collectionName) : base (declarationKey) { CollectionName = collectionName; }
    }
}