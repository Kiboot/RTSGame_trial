using Godot;
using System;

public partial class CharacterBody : CharacterBody2D
{


}

	//code for testing navigation agent. nagivation server required for obstacle avoidance
	// [Export] NavigationRegion2D navReg;
	// [Export] NavigationAgent2D nav;

	// double speed = 100;

	// public override void _Ready()
	// {
	// 	navReg = GetNode<NavigationRegion2D>("../NavigationRegion2D");
	// 	nav = GetNode<NavigationAgent2D>("NavigationAgent2D");
	// }

	// public override void _Process(double delta)
	// {
	// 	if (nav.IsTargetReachable()){
	// 		if (nav.DistanceToTarget()> 1){
	// 					Vector2 nextLocation = nav.GetNextPathPosition();
	// 	var direction = GlobalPosition.DirectionTo(nextLocation).Normalized();
	// 	GlobalPosition += direction * (float)speed * (float)delta;		
	// 		}

	// 	}

	// 	if(Input.IsActionPressed("m1")){
	// 		nav.TargetPosition = GetGlobalMousePosition();
	// 	}

	// }


	// [Export] NavigationRegion2D navReg;
	// [Export] NavigationAgent2D nav;

	// double speed = 100;
	// Rid Map;
	// List<Vector2[]> Path;
	// Vector2 target;
	

	// public override void _Ready()
	// {
	// 	navReg = GetNode<NavigationRegion2D>("../NavigationRegion2D");
	// 	nav = GetNode<NavigationAgent2D>("NavigationAgent2D");
	// 	CallDeferred("Setup_NavServer");
	// }

	// public override void _UnhandledInput(InputEvent @event)
	// {
	// 	if(!@event.IsActionPressed("m1")){return;}
	// 	UpdateNavigationPath(this.Position,GetGlobalMousePosition());
	// }


	// public override void _Process(double delta)
	// {


	// }
	// public void Setup_NavServer(){
	// 	//creating a new navigation map
	// 	Map = NavigationServer2D.MapCreate();
	// 	NavigationServer2D.MapSetActive(Map, true);

	// 	//sets navigation region and adds it top the map
	// 	var Region = NavigationServer2D.
	// 	NavigationServer2D.RegionSetTransform(Region,new Transform2D());
	// 	NavigationServer2D.RegionSetMap(Region, Map);

	// 	//sets navigation mesh for the region

	// 	NavigationMesh nav_mesh = GetNode<NavigationMesh>("../NavigationRegion2D");
		
	// 	Godot.NavigationAgent2D GDScript = new NavigationAgent2D();
	// 	var MeshPoly = new NavigationPolygon();
	// 	GDScript.Call("nav_mesh.navigation_polygon",MeshPoly);
		
	// 	NavigationServer2D.RegionSetNavigationPolygon(Region,MeshPoly);
	// 	var path = NavigationServer2D.r

	// public void UpdateNavigationPath (Vector2 StartPos, Vector2 EndPos){

	// 	Path.Add(NavigationServer2D.MapGetPath(Map,StartPos,EndPos, true));
	// 	Path.RemoveAt(0);
	// 	SetProcess(true);
	// }
