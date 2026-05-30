using Godot;
using System;

public partial class GameManager : Node2D
{
	
	private Node2D playerSpawn;
	private Node2D player;
	
	public override void _Ready()
	{	
		playerSpawn = GetNode<Node2D>("PlayerSpawnPoint");
		player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		player.GlobalPosition = playerSpawn.GlobalPosition;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("quit")){
			GetTree().Quit();
		}else if( Input.IsActionJustPressed("reset")){
			GetTree().ReloadCurrentScene();
		}
		
		//spawner
		
		
	}
}
