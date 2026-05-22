using Godot;
using System;


public partial class PlayerTeste : Entity
{
	private PackedScene bullet = GD.Load<PackedScene>("res://bullet.tscn");
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero){
			 Velocity = (direction.Normalized() * speed);
		} else{
			Velocity = Vector2.Zero;
		}
		MoveAndSlide();
		
		if(Input.IsActionJustPressed("shoot")){
			var newBullet = bullet.Instantiate<Node2D>();
				newBullet.GlobalPosition = GlobalPosition;
				AddSibling(newBullet);
		}
		
		
		
	}
}
