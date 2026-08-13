using Godot;
using Godot.Collections;

[GlobalClass]
public partial class ItemCollection : ResourceEntry
{
    [Export]
    public Array<ResourceEntry> ItemName { get; private set; }

    public ItemCollection(string declarationKey) : base (declarationKey)
    {
        
    }

    public void AddEntry(ResourceEntry entry)
    {
        
    }

    public void RemoveEntry(ResourceEntry entry)
    {
        
    }
}