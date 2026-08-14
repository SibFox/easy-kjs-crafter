using System.Diagnostics;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    [DebuggerDisplay("Key = {ResourceName}")]
    public partial class ResourceEntry : Resource
    {
        public ResourceEntry() {}

        public ResourceEntry(string declarationKey)
        {
            SetDeclarationKey(declarationKey);
        }

        public void SetDeclarationKey(string declarationKey)
        {
            if (declarationKey.Contains(':') || declarationKey.Contains('/'))

            this.ResourceName = declarationKey.ToLower();
        }
    }
}