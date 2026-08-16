using System.Diagnostics;
using System.Text.RegularExpressions;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
    [GlobalClass]
    [DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}")]
    public partial class ResourceEntry : Resource
    {
        [Export]
        public string EntryName { get; set; }


        public ResourceEntry() {}

        public ResourceEntry(string declarationKey, string entryName = null)
        {
            EntryName = entryName;
            SetDeclarationKey(declarationKey);
        }

        public void SetDeclarationKey(string declarationKey)
        {
            if (KeyRegex().IsMatch(declarationKey))
                ResourceName = declarationKey.ToLower();
        }


        [GeneratedRegex(@"^[a-z]+(?:[a-z_]+)*$", RegexOptions.IgnoreCase)]
        private static partial Regex KeyRegex();
    }
}