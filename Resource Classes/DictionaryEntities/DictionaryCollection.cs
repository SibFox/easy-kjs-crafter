using System.Diagnostics;
using System.Linq;
using System.Text;
using EasyKJSCrafter.Interfaces;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.ResourceClasses.DictionaryEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {Key}, Name = {DebuggerName}, Count = {Collection.Count}, InArray={InsideArray}")]
	public partial class DictionaryCollection : DictionaryElementBase, ICollection<DictionaryElementBase>
	{
		[Export]
		public virtual Array<DictionaryElementBase> Collection { get; set; }

		public DictionaryCollection() { Collection = []; }

		public string ValidateCollection(int deep = 0)
		{
			StringBuilder allErrors = new();
			
			string collResId = DebuggerName;
			if (!InsideArray)
			{
				if (string.IsNullOrEmpty(Key))
				{
					allErrors.Append(new string('\t', deep-1) + $"У словаря элементов \"{collResId}\" отсутсвует ключ" + '\n');
					HasErrors = true;
				}
				else
					collResId = Key;
			}

			foreach (DictionaryElementBase element in Collection)
			{
				element.HasErrors = false;
				StringBuilder error = new();

				string entryResId = element.DebuggerName;
				if (!element.InsideArray)
				{
					if (string.IsNullOrEmpty(element.Key))
							error.Append(new string('\t', deep) + $"У элемента \"{entryResId}\" отсутсвует ключ" + '\n');
					else
						entryResId = element.Key + " типа " + element.GetType().FullName.Split('.')[3];
				}

				if (element is ArrayDElement arrC)
				{
					error.Append(arrC.Value.As<DictionaryCollection>().ValidateCollection(++deep));
					--deep;
				}
				if (element is DictionaryDElement dictC)
				{
					error.Append(dictC.Value.As<DictionaryCollection>().ValidateCollection(++deep));
					--deep;
				}
				
				if (error.Length > 0)
				{
					if (allErrors.Length > 0)
						allErrors.Append(new string('-', 40 + deep * 4) + '\n');
					allErrors.Append(new string('\t', deep) + $"Ошибки валидации элемента \"{entryResId}\" " +
					(element.InsideArray ? "внутри массива" : $"коллекции \"{collResId}\"") + '\n');
					allErrors.Append(new string('=', 40 + deep * 4) + '\n');
					allErrors.Append(error);

					HasErrors = true;
					Collection.First(e => e == element).HasErrors = true;
				}
			}

			if (deep == 0 && allErrors.Length > 0)
				LogErr(nameof(DictionaryCollection), nameof(ValidateCollection), DebuggerName).AddLine(allErrors.ToString()).Push();

			return allErrors.ToString();
		}
	}
}
