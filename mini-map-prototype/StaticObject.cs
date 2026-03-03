using Godot;
using System;

public partial class StaticObject : CharacterBody3D
{
	[Export] public Sprite3D MiniMapIcon;
	[Export] public float IconScale;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Scale up the map icon
		if(MiniMapIcon != null){
			MiniMapIcon.Scale = new Vector3(IconScale, IconScale, IconScale);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
