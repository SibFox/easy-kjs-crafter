using EasyKJSCrafter.ResourceClasses.ItemEntities;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.DeclarationTab
{
    public partial class DeclarationTab : ScrollContainer
    {
        [Export]
        public ItemCollection DeclarationCollection { get; set; }

        VBoxContainer CollectionContainer => GetNode<VBoxContainer>("CollectionVContainer");

        
    }
}