using System;

namespace JankiiEngine;

class Program
{
	static void Main()
	{
		Console.WriteLine("Hello, World!");

		var game = new AlienShooter(new GameConfig { Title = "AlienShooter" });
		game.Run();
	}
}
