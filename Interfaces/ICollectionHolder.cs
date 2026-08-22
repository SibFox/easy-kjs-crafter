using Godot;
using Godot.Collections;

namespace EasyKJSCrafter.Interfaces
{
	/// <summary>
	/// Базовый интерфейс для всех контейнеров коллекций.
	/// </summary>
	/// <typeparam name="T">Тип коллекции</typeparam>
	/// <typeparam name="TElement">Тип элемента коллекции</typeparam>
	public interface ICollectionHolder<[MustBeVariant] T, [MustBeVariant] TElement> 
	where T : ICollection<TElement>
	{
		/// <summary>
		/// Коллекция, которая хранится в контейнере.
		/// </summary>
		[Export]
		public T Holder { get; set; }
		/// <summary>
		/// Возвращает коллекцию элементов, которая хранится в контейнере.
		/// </summary>
		public Array<TElement> Collection => Holder.Collection;
		
		/// <summary>
		/// Проверяет коллекцию на валидность. Релазуется через метод ValidateCollection() коллекции Holder.
		/// </summary>
		/// <returns></returns>
		public bool ValidateCollection(int deep = 0) => Holder.ValidateCollection(deep).Length == 0;
	}
}