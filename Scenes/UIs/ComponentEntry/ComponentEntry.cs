using EasyKJSCrafter.ResourceClasses.ComponentEntities;
using EasyKJSCrafter.Scenes.UIs.CollectionHolderUI;
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
				IdLine.Id = value.Id;
				HasErrorsLabel.Visible = value.HasErrors;
			}
		}

		protected HBoxContainer DataContainer => GetNode<HBoxContainer>("DataHBoxContainer");
		protected PathIdLabel IdLine => GetNode<PathIdLabel>("%PathIdLabel");

		protected Label HasErrorsLabel => DataContainer.GetNode<Label>("HasErrorsLabel");
		protected Button DeleteButton => DataContainer.GetNode<Button>("DeleteButton");
		public Button ConfirmDeleteButton => DataContainer.GetNode<Button>("ConfirmDeleteButton");
		protected Button DeclineDeleteButton => DataContainer.GetNode<Button>("DeclineDeleteButton");

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
			var owner = FindParent("ComponentCollectionHolder") as ComponentCollectionHolder;
			if (owner.Collection.Remove(_component))
			{
				owner.EmitSignal(CollectionHolder.SignalName.ElementRemoved);
				QueueFree();
				LogInfo(nameof(ComponentEntry)).AddLine($"Удалён компонент \"{_component.Id.WholePath}\" типа \"{GetType().FullName[2]}\"").Push();
				return;
			}
			LogErr(nameof(ComponentEntry)).AddLine($"Ошибка при удалении компонента \"{_component.Id.WholePath}\" типа \"{GetType().FullName[2]}\"").Push();
		}
	}
}