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
		
		//limites da tela
		Vector2 tamanhoTela = GetViewport().GetVisibleRect().Size;
		float margem = 20f;

		Position = new Vector2(
		Mathf.Clamp(Position.X, margem, tamanhoTela.X - margem),
		Mathf.Clamp(Position.Y, margem, tamanhoTela.Y - margem) );
		
		if(Input.IsActionPressed("shoot")){
			if(!shootCD){
				shootCD = true;
				var newBullet = bullet.Instantiate<Node2D>();
				newBullet.GlobalPosition = GlobalPosition;
				AddSibling(newBullet);
				GetNode<AudioStreamPlayer2D>("shootSound").Play();
				await ToSignal(GetTree().CreateTimer(fireRate), SceneTreeTimer.SignalName.Timeout);
				shootCD = false;
			}
		}
		
		if (life <= 0){ 
			
			GetTree().ChangeSceneToFile("res://Cenas/game_over_tela.tscn");
			}

		
	}
}
