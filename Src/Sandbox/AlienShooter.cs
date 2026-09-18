using System;
using JankiiEngine;

class AlienShooter(GameConfig config) : Game(config)
{
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
}