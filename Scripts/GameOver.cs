using Godot;
using System;

public partial class GameOver : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 GetNode<Button>("VBoxContainer/Restart").Pressed += OnRestartPressed;
		 GetNode<Button>("VBoxContainer/Quit").Pressed += OnQuitPressed;
	}
	
	private void OnRestartPressed()
	{
		GetTree().ChangeSceneToFile("res://Cenas/game.tscn");
	}
	
	 private void OnQuitPressed()
	{
		GetTree().Quit();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
