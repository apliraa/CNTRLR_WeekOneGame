using Godot;
using System;
public partial class Player : Entity
{
	[Export] 
	private PackedScene bullet;
	
	private bool shootCD = false;
	private double fireRate = 0.25;

	public override void _Ready()
	{
	}

	public override async void _PhysicsProcess(double delta)
	{
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero){
			Velocity = (direction.Normalized() * speed);
		} else{
			Velocity = Vector2.Zero;
		}
		MoveAndSlide();
		
		if(Input.IsActionPressed("shoot")){
			if(!shootCD){
				shootCD = true;
				var newBullet = bullet.Instantiate<Node2D>();
				newBullet.GlobalPosition = GlobalPosition;
				AddSibling(newBullet);
				await ToSignal(GetTree().CreateTimer(fireRate), SceneTreeTimer.SignalName.Timeout);
				shootCD = false;
			}
		}
		
		if (life <= 0){ QueueFree(); }
		
	}
}
