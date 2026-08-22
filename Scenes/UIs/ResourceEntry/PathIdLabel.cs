using EasyKJSCrafter.ResourceClasses;
using Godot;

namespace EasyKJSCrafter.Scenes.UIs.ResourceEntryUI
{
	public partial class PathIdLabel : HBoxContainer
	{
		[Signal]
		public delegate void IdChangedEventHandler(string wholePath);

		private PathId _id = new();

		[Export]
		public PathId Id
		{
			get => _id;
			set
			{
				_id = value;
				ModIdLine.Text = value.ModId;
				PathLine.Text = value.Path;
				WholePathLine.Text = value.WholePath;
			}
		}

		HBoxContainer DividedLineContainer => GetNode<HBoxContainer>("DividedLineHBoxContainer");
		HBoxContainer WholeLineContainer => GetNode<HBoxContainer>("WholeLineHBoxContainer");
		Button ChangeButton => GetNode<Button>("ChangeButton");

		LineEdit ModIdLine => DividedLineContainer.GetNode<LineEdit>("ModIdLine");
		LineEdit PathLine => DividedLineContainer.GetNode<LineEdit>("PathLine");
		LineEdit WholePathLine => WholeLineContainer.GetNode<LineEdit>("WholePathLine");

		void OnChangeButton_Pressed()
		{
			DividedLineContainer.Visible = !DividedLineContainer.Visible;
			WholeLineContainer.Visible = !WholeLineContainer.Visible;
		}

		void OnModIdLine_EditingToggled(bool toggled_on)
		{
			Id.ModId = ModIdLine.Text;
			UpdateTextLines();
		}

		void OnPathLine_EditingToggled(bool toggled_on)
		{
			Id.Path = PathLine.Text;
			UpdateTextLines();
		}

		void OnWholePathLine_EditingToggled(bool toggled_on)
		{
			Id.WholePath = WholePathLine.Text;
			UpdateTextLines();
		}

		void UpdateTextLines()
		{
			ModIdLine.Text = Id.ModId;
			PathLine.Text = Id.Path;
			WholePathLine.Text = Id.WholePath;
			EmitSignalIdChanged(Id.WholePath);
		}
	}
}