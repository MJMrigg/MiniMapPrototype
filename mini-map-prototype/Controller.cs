using Godot;
using System;

public partial class Controller : StaticObject
{
	[Export] public float Speed = 5;
	[Export] public float JumpSpeed = 10;
	[Export] public float acceleration = 0.05f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Get player inputs
		Vector2 PlayerInput = Input.GetVector("Forward","Backward","Left","Right");
		float PlayerRotate = Input.GetAxis("Rotate_Left","Rotate_Right");
		//Rotate the object around its vertical axis
		Rotate(new Vector3(0,1,0), PlayerRotate*(MathF.PI/2.0f)*(float)delta*-1);
		//Set up velocity
		Vector2 NewVelocity = PlayerInput.Normalized()*Speed;
		Vector3 PredictedVelocity = (Transform.Basis.X*NewVelocity.Y)+(Transform.Basis.Z*NewVelocity.X);
		//Add gravity
		if(!IsOnFloor()){
			PredictedVelocity += GetGravity();
		}
		//Add acceleration
		Velocity = Velocity.Lerp(PredictedVelocity, acceleration);
		//Hangle jumping
		if(Input.IsActionPressed("Jump") && IsOnFloor()){
			Velocity += new Vector3(0,JumpSpeed,0);
		}
		//Move
		MoveAndSlide();
	}
}
