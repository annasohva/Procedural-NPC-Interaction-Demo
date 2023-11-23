using Godot;
using System;

public partial class commoner_girl : CharacterBody2D
{
private int speed = 5;
private int mode = 1;

public void MoveUp()
{ 
	Vector2 velocity = Velocity;
	velocity.Y = -speed*2;
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
	velocity.X = speed*2;
	Velocity = velocity;
}

public override void _PhysicsProcess(double delta) 
	{ 
			
		if (mode==1) 
		{
			MoveRight(); 
			MoveAndSlide(); 
		}
		if (mode==2) 
		{
			MoveLeft(); 
			MoveAndSlide(); 
		}
		if (mode==3) 
		{
			MoveUp(); 
			MoveAndSlide();
		}
		if (mode==4) 
		{
			MoveDown(); 
			MoveAndSlide();
		}
		
		
	}

private void OnTimerTimeout()
{
	if (mode == 9)
	{
		mode = 1;
	}
	else
	{
		mode ++;
	}
}

} //CommonerGirl end
