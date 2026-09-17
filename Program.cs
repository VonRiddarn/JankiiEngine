using System;

namespace JankiiEngine;

class Program
{
	static void Main()
	{
		Console.WriteLine("Hello, World!");

		var game = new AlienShooter(60);
		game.Run();
	}
}
