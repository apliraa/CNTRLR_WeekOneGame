using Godot;
using System;

public partial class Bullet : Entity
{
	
	public override void _Ready(){
	GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += QueueFree;
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("bullet");
			GetNode<Area2D>("Hitbox").BodyEntered += OnHitboxBodyEntered;

	}

	public override void _PhysicsProcess(double delta)
	{
		Position += Vector2.Up * speed * (float)delta;
		
		if (life <= 0){	QueueFree();}
		
	}
	
	private void OnHitboxBodyEntered(Node2D body)
{
	if (body is Entity entity)
	{
		entity.life -= 1;
		QueueFree();
		
		 var gm = GetTree().GetFirstNodeInGroup("GameManager") as GameManager;
		gm?.AddScore();
	}
}
	
}
