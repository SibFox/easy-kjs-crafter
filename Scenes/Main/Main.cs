using Godot;
using EasyKJSCrafter.ResourceClasses.ItemEntities;

namespace EasyKJSCrafter.Scenes.Main
{
    public partial class Main : Node
    {
        ItemCollection Items = GD.Load<ItemCollection>("res://Resources/Items.tres");
        ItemCollection Tags = GD.Load<ItemCollection>("res://Resources/Tags.tres");
        ItemCollection Fluids = GD.Load<ItemCollection>("res://Resources/Fluids.tres");

        public override void _Ready() {
            GD.Print(Items.Collection.Count);
        }
    }
}