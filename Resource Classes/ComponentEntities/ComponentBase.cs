using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
    [GlobalClass]
    public partial class ComponentBase : Resource
    {
        [Export]
        [DebuggerDisplay("Id = {Id.WholePath}, Value = {Value}")]
        public PathId Id { get; set; }

        public virtual Variant Value { get; set; }

        public ComponentBase() { Id = new(); }
        public ComponentBase(PathId pathId) { Id = pathId; }
        public ComponentBase(string wholePath) { Id.SetPathFromWholePath(wholePath); }
    }
}