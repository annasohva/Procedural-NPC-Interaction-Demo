using Godot;
using System;

public partial class old_commoner : CharacterBody2D
{
private int speed = 10;
private int mode = 1;

public void MoveUp()
{ 
	Vector2 velocity = Velocity;
	velocity.Y = -speed;
	Velocity = velocity;
}

public void MoveDown()
{ 
	Vector2 velocity = Velocity;
	velocity.Y = speed;
	Velocity = velocity;
}

public void MoveLeft()
{ 
	Vector2 velocity = Velocity;
	velocity.X = -speed;
	Velocity = velocity;
}

public void MoveRight() 
{ 
	Vector2 velocity = Velocity;
	velocity.X = speed;
	Velocity = velocity;
}

public override void _PhysicsProcess(double delta) 
	{ 
		if (mode == 1)
		{
			MoveDown(); 
			MoveAndSlide(); 
		}
		else
		{
			MoveUp(); 
			MoveAndSlide(); 
		}
	}

private void OnTimerTimeout()
{
	if (mode == 1)
	{
		mode = 2;
	}
	else
	{
		mode = 1;
	}
}

} //OldCommoner end
