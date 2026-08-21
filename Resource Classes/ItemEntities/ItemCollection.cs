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
    [DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, Count = {Collection.Count}")]
    public partial class ItemCollection : ResourceEntry, ICollection<ResourceEntry>
    {
        [Export]
        public virtual Array<ResourceEntry> Collection { get; set; }

        public ItemCollection() { Collection = []; }
        public ItemCollection(string declarationKey, string collectionName = null) : base (declarationKey, collectionName) { Collection = []; }

        public string ValidateCollection(int deep = 0)
        {
            StringBuilder allErrors = new();

			string collResId = ToString();
			if (string.IsNullOrEmpty(ResourceName))
				allErrors.Append(new string('\t', deep-1) + $"У коллекции \"{collResId}\" отсутсвует ключ" + '\n');
			else
				collResId = ResourceName;

			foreach (ResourceEntry entry in Collection)
			{
				entry.HasErrors = false;
				StringBuilder error = new();

				string entryResId = entry.ToString() + " типа " + entry.GetType().FullName.Split('.')[3];
				if (string.IsNullOrEmpty(entry.ResourceName))
						error.Append(new string('\t', deep) + $"У ресурса отсутсвует ключ" + '\n');
				else
					entryResId = entry.ResourceName + " типа " + entry.GetType().FullName.Split('.')[3];
				
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
					error.Append(item.Components?.ValidateCollection() ?? string.Empty);
					// foreach (ComponentBase component in item.Components)
					// {
					// 	string componentResId = entry.ToString();
					// 	if (component.Id == null)
					// 		error.Append(new string('\t', deep) + $"У компонента \"{componentResId}\" предмета \"{entryResId}\" коллекции \"{collResId}\" отсутсвует Id" + '\n');
					// 	else
					// 	{
					// 		if (string.IsNullOrEmpty(component.Id.ModId))
					// 			error.Append(new string('\t', deep) + $"У компонента \"{componentResId}\" отсутсвует ModId в Id" + '\n');
					// 		if (string.IsNullOrEmpty(component.Id.Path))
					// 			error.Append(new string('\t', deep) + $"У компонента \"{componentResId}\" отсутсвует Path в Id" + '\n');
					// 	}
					// }
				}
				if (entry is ItemCollection coll)
				{
					string collErrors = coll.ValidateCollection(++deep);
					--deep;
					if (collErrors.Length > 0)
						error.Append(collErrors);
				}
;
				if (error.Length > 0)
				{
					if (allErrors.Length > 0)
						allErrors.Append(new string('-', 40 + deep * 4) + '\n');
					allErrors.Append(new string('\t', deep) + $"Ошибки валидации записи \"{entryResId}\" коллекции \"{collResId}\"" + '\n');
					allErrors.Append(new string('=', 40 + deep * 4) + '\n');
					allErrors.Append(error.ToString());

					HasErrors = true;
					Collection.First(e => e.ToString() == entry.ToString()).HasErrors = true;
				}
			}

			if (deep == 0 && allErrors.Length > 0)
				LogErr(nameof(ItemCollection), nameof(ValidateCollection)).AddLine(allErrors.ToString()).Push();

			return allErrors.ToString();
        }
    }
}