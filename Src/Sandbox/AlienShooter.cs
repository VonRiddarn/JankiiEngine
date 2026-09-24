using System;
using JankiiEngine;

class AlienShooter(GameConfig config) : Game(config)
{
	int _x = 0;
	int _dir = 1;

	protected override void Initialize()
	{
		Console.WriteLine("Ready to kill some alien scum?");
		Console.ReadLine();
	}

	protected override void Update()
	{
		if (Input.GetKeyDown(ConsoleKey.Spacebar))
		{
			Console.ForegroundColor = (ConsoleColor)Random.Shared.Next(9, 16);
			Console.WriteLine("SPACE");
		}
	}

	protected override void Draw(ConsoleBuffer buffer)
	{
		// Concern mixing, don't mind this :P
		if ((_x + _dir) is > 120 or < 0)
			_dir *= -1;

		buffer.Clear();
		buffer.SetCell(_x, 3, '@', _dir == 1 ? ConsoleColor.Blue : ConsoleColor.DarkYellow, ConsoleColor.Black);
		buffer.Draw();

		_x += _dir;
	}
}