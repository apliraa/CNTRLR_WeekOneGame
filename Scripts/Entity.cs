using Godot;
using System;
public abstract partial class Entity : CharacterBody2D
{
	
	[Export] public int life;
	[Export] public float speed;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (life <= 0){	QueueFree();}
	}
	
	
		
	
}
