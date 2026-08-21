using System.Diagnostics;
using System.Text.RegularExpressions;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}")]
	public partial class Entry : Resource
	{
		public string Key
		{
			get => ResourceName;
			set
			{
				if (KeyRegex().IsMatch(value))
					ResourceName = value.ToLower();
			}
		}
		public bool HasErrors { get; set; }
		public virtual string StringView { get => string.Empty; }

		public Entry() {}
		public Entry(string declarationKey) => Key = declarationKey;


		[GeneratedRegex(@"^[a-z]+(?:[a-z_]+)*$", RegexOptions.IgnoreCase)]
		private static partial Regex KeyRegex();
	}
}