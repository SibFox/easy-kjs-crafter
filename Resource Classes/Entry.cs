using System.Diagnostics;
using System.Text.RegularExpressions;
using Godot;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key={Key}, Name={DebuggerName}")]
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
		/// <summary>
		/// Уровень глубины для StringView
		/// </summary>
		public int Level { get; set; }
		// Сохранение состояния раскрытия записи в редакторе
		[Export(PropertyHint.None)]
		public bool Expanded { get; set; }

		public string DebuggerName { get; set; }

		public Entry() {}
		public Entry(string declarationKey) => Key = declarationKey;


		[GeneratedRegex(@"^[a-z]+(?:[a-z_]+)*$", RegexOptions.IgnoreCase)]
		private static partial Regex KeyRegex();
	}
}