using Godot;
using System;

[GlobalClass]
public partial class ResourceEntry : Resource
{
    public ResourceEntry(string declarationKey)
    {
        this.ResourceName = declarationKey.ToLower();
    }
}
