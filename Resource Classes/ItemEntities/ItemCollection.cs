using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    public partial class ItemCollection : ResourceEntry
    {
        [Export]
        public Array<ResourceEntry> Collection { get; private set; }

        public ItemCollection() {}
        public ItemCollection(string declarationKey) : base (declarationKey) {}
    }
}