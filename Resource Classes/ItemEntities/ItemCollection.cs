using System.Diagnostics;
using System.Linq;
using System.Text;
using EasyKJSCrafter.Interfaces;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.ResourceClasses.ItemEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {Key}, Name = {EntryName}, Count = {Collection.Count}")]
	public partial class ItemCollection : ResourceEntry, ICollection<ResourceEntry>
	{
		[Export]
		public virtual Array<ResourceEntry> Collection { get; set; }

		public ItemCollection() { Collection = []; }
		public ItemCollection(string declarationKey, string collectionName = null) : base (declarationKey, collectionName) { Collection = []; }

		public override string StringView
		{
			get
			{
				StringBuilder builder = new();

				builder.Append($"{Key}: {{");
				System.Collections.Generic.LinkedList<string> entries = [];
				if (Collection.Count > 0)
				{
					foreach (var entry in Collection)
					{
						entries.AddLast($"\n\t{entry.StringView}");
					}
				}
				builder.AppendJoin(',', entries);
				builder.Append("\n}");

				return builder.ToString();
			}
		}

		public string ValidateCollection(int deep = 0)
		{
			StringBuilder allErrors = new();
			
			string collResId = DebuggerName;
			if (string.IsNullOrEmpty(Key))
			{
				allErrors.Append(new string('\t', deep-1) + $"У коллекции предметов \"{collResId}\" отсутсвует ключ" + '\n');
				HasErrors = true;
			}
			else
				collResId = Key;

			foreach (ResourceEntry entry in Collection)
			{
				entry.HasErrors = false;
				StringBuilder error = new();

				string entryResId = entry.DebuggerName + " типа " + entry.GetType().FullName.Split('.')[3];
				if (string.IsNullOrEmpty(entry.Key))
						error.Append(new string('\t', deep) + $"У ресурса отсутсвует ключ" + '\n');
				else
					entryResId = entry.Key + " типа " + entry.GetType().FullName.Split('.')[3];
				
				if (entry is ItemEntry item)
				{
					if (item.Id == null)
						error.Append(new string('\t', deep) + $"У предмета отсутсвует Id" + '\n');
					else
					{
						if (string.IsNullOrEmpty(item.Id.ModId))
							error.Append(new string('\t', deep) + $"У предмета отсутсвует ModId в Id" + '\n');
						if (string.IsNullOrEmpty(item.Id.Path))
							error.Append(new string('\t', deep) + $"У предмета отсутсвует Path в Id" + '\n');
					}
					item.Components.Id = item.Id;
					// string cErr = item.Components.ValidateCollection(++deep);
					// if (cErr.Length > 0)
					// {
					// 	item.HasErrors = true;
					// }
					error.Append(item.Components.ValidateCollection(++deep));
					--deep;
				}
				if (entry is ItemCollection coll)
				{
					error.Append(coll.ValidateCollection(++deep));
					--deep;
				}
;
				if (error.Length > 0)
				{
					if (allErrors.Length > 0)
						allErrors.Append(new string('-', 40 + deep * 4) + '\n');
					allErrors.Append(new string('\t', deep) + $"Ошибки валидации записи \"{entryResId}\" коллекции \"{collResId}\"" + '\n');
					allErrors.Append(new string('=', 40 + deep * 4) + '\n');
					allErrors.Append(error);

					HasErrors = true;
					Collection.First(e => e == entry).HasErrors = true;
				}
			}

			if (deep == 0 && allErrors.Length > 0)
				LogErr(nameof(ItemCollection), nameof(ValidateCollection), collResId).AddLine(allErrors.ToString()).Push();

			return allErrors.ToString();
		}
	}
}