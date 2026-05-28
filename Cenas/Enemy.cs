using Godot;
using System;

public partial class Enemy : Entity
{
	
	public override void _Ready(){
		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += QueueFree;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Vector2.Down * speed;
		MoveAndSlide();
		
	if (life <= 0){	QueueFree();}
		
	}
}
