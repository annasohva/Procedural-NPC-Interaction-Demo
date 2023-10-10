using Godot;
using System;

public partial class player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public Sprite2D playerSprite;
	public override void _Ready()
	{
		playerSprite = GetNode<Sprite2D>("Sprite2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
			velocity.X = direction.X * Speed;
			if(velocity.X < 0)
			{
				playerSprite.FlipH = true;
			}
			else if ( velocity.X > 0)
			{
				playerSprite.FlipH = false;
			}
		}
		else
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
