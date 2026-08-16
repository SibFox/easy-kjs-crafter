using System.Diagnostics;
using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    [DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, Count = {Collection.Count}")]
    public partial class ItemCollection : ResourceEntry
    {
        [Export]
        public Array<ResourceEntry> Collection { get; private set; }

        public ItemCollection() { Collection = []; }
        public ItemCollection(string declarationKey, string collectionName = null) : base (declarationKey, collectionName) { Collection = []; }
    }
}