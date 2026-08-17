using Godot;

namespace EasyKJSCrafter.Scenes.UIs.CollectionHolderUI
{
	/// <summary>
	/// Базовый класс для всех контейнеров коллекций.
	/// Наслледники должны реализовывать интерфейс ICollectionHolder<T, TElement>,
	/// </summary>
	public partial class CollectionHolder : VBoxContainer
	{
		/// <summary>
		/// Выстраивает элементы коллекции в дереве. Должен быть переопределён в наследниках.
		/// </summary>
		public virtual void BuildEntryTree() {}
	}
}
