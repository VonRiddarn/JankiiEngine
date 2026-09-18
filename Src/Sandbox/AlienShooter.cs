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
		Console.WriteLine("Pew\t\t(Press ctrl + C to kill proccess)");
	}
}