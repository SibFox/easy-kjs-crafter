using System.Diagnostics;
using System.Linq;
using System.Text;
using EasyKJSCrafter.Interfaces;
using EasyKJSCrafter.ResourceClasses.DictionaryEntities;
using Godot;
using Godot.Collections;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.ResourceClasses.ComponentEntities
{
	[GlobalClass]
	[DebuggerDisplay("Key = {ResourceName}, Name = {EntryName}, Count = {Collection.Count}")]
	public partial class ComponentCollection : ComponentBase, ICollection<ComponentBase>
	{
		[Export]
		public virtual Array<ComponentBase> Collection { get; set; }

		public ComponentCollection() { Collection = []; }

		public string ValidateCollection(int deep = 0)
		{
			StringBuilder allErrors = new();

			string collResId = DebuggerName;
			if (Id == null)
			{
				allErrors.Append(new string('\t', deep-1) + $"У коллекции компонентов \"{collResId}\" отсутсвует Id" + '\n');
				HasErrors = true;
			}
			else
			{
				if (string.IsNullOrEmpty(Id.ModId))
				{
					allErrors.Append(new string('\t', deep-1) + $"У коллекции компонентов \"{collResId}\" отсутсвует ModId" + '\n');
					HasErrors = true;
				}
				if (string.IsNullOrEmpty(Id.Path))
				{
					allErrors.Append(new string('\t', deep-1) + $"У коллекции компонентов \"{collResId}\" отсутсвует Path" + '\n');
					HasErrors = true;
				}
			}
			if (allErrors.Length == 0)
				collResId = Id.WholePath;

			foreach (ComponentBase component in Collection)
			{
				component.HasErrors = false;
				StringBuilder error = new();

				string componentResId = component.DebuggerName;
				if (component.Id == null)
					error.Append(new string('\t', deep) + $"У компонента отсутсвует Id" + '\n');
				else
				{
					if (string.IsNullOrEmpty(component.Id.ModId))
						error.Append(new string('\t', deep) + $"У компонента отсутсвует ModId" + '\n');
					if (string.IsNullOrEmpty(component.Id.Path))
						error.Append(new string('\t', deep) + $"У компонента отсутсвует Path" + '\n');
				}
				if (error.Length == 0)
					componentResId = Id.WholePath + " типа " + component.GetType().FullName.Split('.')[3];

				if (component is ArrayComponent arrC)
				{
					error.Append(arrC.Value.As<ComponentCollection>().ValidateCollection(++deep));
					--deep;
				}
				if (component is DictionaryComponent dictC)
				{
					error.Append(dictC.Value.As<DictionaryCollection>().ValidateCollection(++deep));
					--deep;
				}

				if (error.Length > 0)
				{
					if (allErrors.Length > 0)
						allErrors.Append(new string('-', 40 + deep * 4) + '\n');
					allErrors.Append(new string('\t', deep) + $"Ошибки валидации компонента \"{componentResId}\"" + '\n');
					allErrors.Append(new string('=', 40 + deep * 4) + '\n');
					allErrors.Append(error);

					HasErrors = true;
					Collection.First(c => c == component).HasErrors = true;
				}
			}

			if (deep == 0 && allErrors.Length > 0)
				LogErr(nameof(ComponentCollection), nameof(ValidateCollection), DebuggerName).AddLine(allErrors.ToString()).Push();

			return allErrors.ToString();
		}
	}
}