using Godot;
using System;

public partial class GameManager : Node2D
{
	
	private Node2D playerSpawn;
	private Node2D player;
	[Export] private PackedScene enemyScene;
	
	//UI
	private Label scoreLabel;
	private int score = 0;
	private TextureRect vida1;
	private TextureRect vida2;
	private TextureRect vida3;
	private TextureRect vida4;
	
	//Spawner
	private double timerSpawn = 0;
	private double intervaloSpawn = 2;
	
	public override void _Ready()
	{	
		playerSpawn = GetNode<Node2D>("PlayerSpawnPoint");
		player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		player.GlobalPosition = playerSpawn.GlobalPosition;
		scoreLabel = GetNode<Label>("UI/VBoxContainer/ScoreLabel");
		vida1 = GetNode<TextureRect>("UI/VBoxContainer/HBoxContainer/vida1");
		vida2 = GetNode<TextureRect>("UI/VBoxContainer/HBoxContainer/vida2");
		vida3 = GetNode<TextureRect>("UI/VBoxContainer/HBoxContainer/vida3");
		vida4 = GetNode<TextureRect>("UI/VBoxContainer/HBoxContainer/vida4");
		 var playerEntity = player as Entity;
   		 AtualizarVida(playerEntity.life);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("quit")){
			GetTree().Quit();
		}else if( Input.IsActionJustPressed("reset")){
			GetTree().ReloadCurrentScene();
		}
		
		//timer do jogo
		timerSpawn -= delta;
		if (timerSpawn <= 0){
			SpawnarInimigo();
			timerSpawn = intervaloSpawn; 
			}
		//spawner
		
	}
	
	public void AddScore(){
		score += (int)(10);
		scoreLabel.Text = "Score: " + score;
	}
	
	public void AtualizarVida(int vidaAtual)
{
	vida1.Visible = vidaAtual >= 1;
	vida2.Visible = vidaAtual >= 2;
	vida3.Visible = vidaAtual >= 3;
	vida4.Visible = vidaAtual >= 4;
}

private void SpawnarInimigo()
{
	var inimigo = enemyScene.Instantiate<Node2D>();
	
	float larguraTela = GetViewport().GetVisibleRect().Size.X;
	float xAleatorio = (float)GD.RandRange(50, larguraTela - 50);
	
	inimigo.GlobalPosition = new Vector2(xAleatorio, -50);
	AddChild(inimigo);
}
	
}
