using Godot;
using System;

public partial class FollowCam : Camera3D
{
	[Export] public Node3D Target;
	[Export] public float FollowX = 0;
	[Export] public float FollowY = 0;
	[Export] public float FollowZ = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Target == null){
			return;
		}
		//Follow the target
		Position = Target.Position + (Target.Basis.X*FollowX) + (Target.Basis.Y*FollowY) + (Target.Basis.Z*FollowZ);
		LookAt(Target.Position);
	}
}
