using Godot;

public partial class PlayerUnit : Unit
{
	// Called when the node enters the scene tree for the first time.
	Sprite2D _selectionVisual;
	public override void _Ready(){
		_selectionVisual = GetNode<Sprite2D>("SelectionVisual");
	}
	public void ToggleSelectionVisual(bool toggle){
		_selectionVisual.Visible = toggle;
	}
}
