using Godot;
using System;

public partial class MenuInicial : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/Play").Pressed += OnPlayPressed;
		GetNode<Button>("VBoxContainer/Quit").Pressed += OnQuitPressed;
	}
	
	private void OnPlayPressed()
	{
		
		GetTree().ChangeSceneToFile("res://Cenas/game.tscn"); 
	}
	
	private void OnQuitPressed()
	{
		GetNode<AudioStreamPlayer2D>("buttonSelection").Play();
		GetTree().Quit();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
