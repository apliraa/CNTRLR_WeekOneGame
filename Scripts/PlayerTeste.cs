using Godot;
using System;


public partial class PlayerTeste : Entity
{
	
	[Export] 
	private PackedScene bullet;
	
	private bool shootCD = false;
	private double fireRate = 0.25;
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
				
				if (life <= 0){	QueueFree();}
				
				
		}
		
		
		
	}
}
