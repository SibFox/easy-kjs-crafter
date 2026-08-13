using Godot;
using System;

[GlobalClass]
public partial class ComponentEntry : Resource
{
    [Export]
    public Variant Data { get; set; }
}
