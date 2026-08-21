using System.Diagnostics;
using System.Linq;
using System.Text;
using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, Count = {Collection.Count}")]
	public partial class DictionaryCollection : ComponentBase, ICollection<DictionaryElementBase>
	{
		[Export]
		public virtual Array<DictionaryElementBase> Collection { get; set; }

		public DictionaryCollection() { Collection = []; }

		public string ValidateCollection(int deep = 0)
		{
			StringBuilder allErrors = new();

			string collResId = ToString();
			if (string.IsNullOrEmpty(ResourceName))
				allErrors.Append(new string('\t', deep-1) + $"У коллекции \"{collResId}\" отсутсвует ключ" + '\n');
			else
				collResId = ResourceName;

			foreach (DictionaryElementBase entry in Collection)
			{
				entry.HasErrors = false;
				StringBuilder error = new();

				string entryResId = entry.ToString() + " типа " + entry.GetType().FullName.Split('.')[3];
				if (string.IsNullOrEmpty(entry.ResourceName))
						error.Append(new string('\t', deep) + $"У ресурса отсутсвует ключ" + '\n');
				else
					entryResId = entry.ResourceName + " типа " + entry.GetType().FullName.Split('.')[3];
				
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
				LogErr(nameof(DictionaryCollection), nameof(ValidateCollection)).AddLine(allErrors.ToString()).Push();

			return allErrors.ToString();
		}
	}
}