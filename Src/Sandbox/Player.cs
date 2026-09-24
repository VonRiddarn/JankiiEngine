using System;
using JankiiEngine;

class Player(int x, int y, char c, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black) : Entity2D(x, y, c, fg, bg)
{
	public override void OnDisable()
	{
	}

	public override void OnEnable()
	{
	}

	public override void Update()
	{
		if (Input.GetKeyDown(ConsoleKey.UpArrow))
			Y -= 1;
		if (Input.GetKeyDown(ConsoleKey.DownArrow))
			Y += 1;
		if (Input.GetKeyDown(ConsoleKey.LeftArrow))
			X -= 1;
		if (Input.GetKeyDown(ConsoleKey.RightArrow))
			X += 1;
	}
}