using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.ResourceClasses.ItemEntities;
using EasyKJSCrafter.Scenes.UIs.ResourceEntryUI;
using Godot;
using static EasyKJSCrafter.Common.Logger.Logger;

namespace EasyKJSCrafter.Scenes.UIs.ComponentEntryUI
{
	public partial class ComponentEntry : VBoxContainer
	{
		protected ComponentBase _component = new();
		public virtual ComponentBase Component
		{
			get => _component;
			set
			{
				_component = value;

				IdLabel.Id = _component.Id;
			}
		}

		protected HBoxContainer DataContainer => GetNode<HBoxContainer>("DataHBoxContainer");
		protected PathIdLabel IdLabel => GetNode<PathIdLabel>("%PathIdLabel");

		protected Label HasErrorsLabel => DataContainer.GetNode<Label>("HasErrorsLabel");
		protected Button DeleteButton => DataContainer.GetNode<Button>("DeleteButton");
		protected Button ConfirmDeleteButton => DataContainer.GetNode<Button>("ConfirmDeleteButton");
		protected Button DeclineDeleteButton => DataContainer.GetNode<Button>("DeclineDeleteButton");

		public override void _Ready()
		{
			HasErrorsLabel.Visible = _component.HasErrors;
		}

		void OnDeleteButton_Pressed()
		{
			DeleteButton.Visible = false;
			ConfirmDeleteButton.Visible = DeclineDeleteButton.Visible = true;
		}

		void OnDeclineDeleteButton_Pressed()
		{
			DeleteButton.Visible = true;
			ConfirmDeleteButton.Visible = DeclineDeleteButton.Visible = false;
		}

		void OnConfirmDeleteButton_Pressed()
		{
			// Owner не работает, потому что он сам по себе null
			var owner = GetOwner<ItemEntry>();
			if (owner.Components.Remove(_component))
			{
				LogInfo(nameof(ComponentEntry), owner.ResourceName).AddLine($"Удалён компонент типа \"{GetType().FullName[2]}\"").Push();
				QueueFree();
				return;
			}
			LogErr(nameof(ComponentEntry), owner.ResourceName).AddLine($"Ошибка при удалении компонента типа \"{GetType().FullName[2]}\"").Push();
		}
	}
}