using Godot;

public partial class EntryBox : HBoxContainer
{
	protected PanelContainer ContentContainer => GetNode<PanelContainer>("ContentContainer");
	protected VBoxContainer ContentVBoxContainer => ContentContainer.GetNode<VBoxContainer>("ContentVBoxContainer");
}
