using Godot;
using System;

public partial class Enemy : Entity
{
	
	public override void _Ready(){
		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += QueueFree;
			GetNode<Area2D>("Hitbox").BodyEntered += OnHitboxBodyEntered;

	}

	public override void _PhysicsProcess(double delta)
	{
		//Position += Vector2.Down * speed * (float)delta;
		
	if (life <= 0){	QueueFree();}
		
	}
	
	private void OnHitboxBodyEntered(Node2D body)
{
	if (body is Entity entity)
	{
		entity.life -= 1;
		
		
	}
}
	
}
