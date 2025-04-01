using Godot;
using System;

public partial class Unit : CharacterBody2D
{
	[Export] int _hp		= 100;
	[Export] int _dmg		= 20;
	[Export] float _spd		= 300f;
	[Export] float _atkSpd	= 0.5f;
	[Export] float _atkRng	= 10f;

	private float _lastAtkTime;
	private CharacterBody2D _target = new();
	private NavigationAgent2D _agent;
	private Sprite2D _sprite;
	

	[Export] bool _isPlayer;
	

	public override void _Ready(){
		_agent		= GetNode<NavigationAgent2D>("NavigationAgent2D");
		_sprite		= GetNode<Sprite2D>("Sprite");
	}
	public void TakeDamage(int dmgToTake){
		_hp -= dmgToTake;
		if (_hp <= 0) QueueFree(); //similar to if if (_hp <= 0){ QueueFree() };
	}
	public void SetTarget(CharacterBody2D NewTarget){
		_target = NewTarget;
	}

	public void TargetCheck(){
		
		if (_target != null){
			float dist = GlobalPosition.DistanceTo(_target.GlobalPosition);
			if (dist <= _atkRng){
				_agent.TargetPosition = GlobalPosition;
				TryAttackTarget();
			}
			else{
				_agent.TargetPosition = _target.GlobalPosition;
				//MoveToLocation(_target.GlobalPosition);
			}
		}
	}
		
	public void TryAttackTarget()
	{
		Unit _targetUnit = _target as Unit; //may cause crash please check later

		if (_target == null) return; // Null check for _target

		double CurTime = Time.GetUnixTimeFromSystem();
		if ((CurTime - _lastAtkTime) > _atkSpd)
		{
			_targetUnit = (Unit)_target ;
			_targetUnit.TakeDamage(_dmg);
			_target = _targetUnit;
			_lastAtkTime = (float)CurTime;
		}
	}

	public override void _Input(InputEvent @event){
		if (
			@event is InputEventMouseButton mouseEvent &&
			!mouseEvent.Pressed && 
			mouseEvent.ButtonIndex == MouseButton.Right
			) 
			{
				MoveToLocation();
			}
	}
	//public void Setup_NavServer(){
			//creating a new navigation map
			//Map = NavigationServer2D.MapCreate();
			//NavigationServer2D.MapSetActive(Map, true);
	//}

	public void MoveToLocation(){
		//_target = null;
		//_agent.TargetPosition = Location;

		var mousePos = GetGlobalMousePosition();
		var map = GetWorld2D().NavigationMap;
		var p = NavigationServer2D.MapGetClosestPoint(map, mousePos / GlobalScale);
		//Use GetGlobalMousePosition()/GlobalScale when in windowed mode.
		_agent.TargetPosition = p;
	}
		public void MoveToLocation(Vector2 targetLoc){
		//_target = null;
		//_agent.TargetPosition = Location;

		var mousePos = GetGlobalMousePosition();
		var map = GetWorld2D().NavigationMap;
		var p = NavigationServer2D.MapGetClosestPoint(map,targetLoc);
		//Use GetGlobalMousePosition()/GlobalScale when in windowed mode.
		_agent.TargetPosition = p;
	}

	public override void _PhysicsProcess(double delta){
		if (_agent.IsNavigationFinished()) return;
		//LookAt(_agent.GetNextPathPosition()); model rotation
		var diff = _agent.GetNextPathPosition() - GlobalPosition;
		var dir = diff.Normalized();
		Velocity = dir * _spd;
		MoveAndSlide();
	}

}
