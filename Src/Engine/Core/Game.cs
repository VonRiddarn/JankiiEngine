using System;
using System.Threading;
using JankiiEngine.Internal;

namespace JankiiEngine;


abstract class Game(GameConfig config)
{
	protected readonly GameConfig _gameConfig = config;
	readonly int _tickMs = (int)MathF.Floor(1000f / config.TickRate);

	bool _isRunning = false;

	public void Run()
	{
		if (_isRunning) return;
		_isRunning = true;

		Console.Title = _gameConfig.Title;

		Renderer.CursorVisible = false;
		RunSplashScreen();


		Renderer.CursorVisible = _gameConfig.CursorVisible;
		Initialize();

		// Input thread
		Input.Initialize_Internal();

		// Update is on main thread.
		while (true)
		{
			Update();
			// TODO: Renderer

			Input.Clear_Cache_Internal();
			Thread.Sleep(_tickMs);
		}
	}

	/// <summary>
	/// Entry point of your game. Use this to initialize your entities / objects.
	/// </summary>
	protected abstract void Initialize();

	/// <summary>
	/// Global update of your project. Use this to make changes each frame.
	/// NOTE: GameObjects update automatically using the inner gameplay loop.
	/// </summary>
	protected abstract void Update();

	// ----- ----- -----
	//	   HELPERS
	// ----- ----- -----

	static void RunSplashScreen()
	{
		// TODO: Allow end user to add more stuff to the splash screen dynamically...
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.DarkYellow; // (ConsoleColor)Random.Shared.Next(1, 16);
		Console.Write(@"
      █████   █████████   ██████   █████ █████   ████ █████ █████      
      ▒▒███   ███▒▒▒▒▒███ ▒▒██████ ▒▒███ ▒▒███   ███▒ ▒▒███ ▒▒███      
       ▒███  ▒███    ▒███  ▒███▒███ ▒███  ▒███  ███    ▒███  ▒███      
       ▒███  ▒███████████  ▒███▒▒███▒███  ▒███████     ▒███  ▒███      
       ▒███  ▒███▒▒▒▒▒███  ▒███ ▒▒██████  ▒███▒▒███    ▒███  ▒███      
 ███   ▒███  ▒███    ▒███  ▒███  ▒▒█████  ▒███ ▒▒███   ▒███  ▒███      
▒▒████████   █████   █████ █████  ▒▒█████ █████ ▒▒████ █████ █████     
 ▒▒▒▒▒▒▒▒   ▒▒▒▒▒   ▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒ ▒▒▒▒▒   ▒▒▒▒ ▒▒▒▒▒ ▒▒▒▒▒      
                                                                       
                                                                       
                                                                       
 ██████████ ██████   █████   █████████  █████ ██████   █████ ██████████
▒▒███▒▒▒▒▒█▒▒██████ ▒▒███   ███▒▒▒▒▒███▒▒███ ▒▒██████ ▒▒███ ▒▒███▒▒▒▒▒█
 ▒███  █ ▒  ▒███▒███ ▒███  ███     ▒▒▒  ▒███  ▒███▒███ ▒███  ▒███  █ ▒ 
 ▒██████    ▒███▒▒███▒███ ▒███          ▒███  ▒███▒▒███▒███  ▒██████   
 ▒███▒▒█    ▒███ ▒▒██████ ▒███    █████ ▒███  ▒███ ▒▒██████  ▒███▒▒█   
 ▒███ ▒   █ ▒███  ▒▒█████ ▒▒███  ▒▒███  ▒███  ▒███  ▒▒█████  ▒███ ▒   █
 ██████████ █████  ▒▒█████ ▒▒█████████  █████ █████  ▒▒█████ ██████████
▒▒▒▒▒▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒ ▒▒▒▒▒    ▒▒▒▒▒ ▒▒▒▒▒▒▒▒▒▒ 
                                                                       ");

		Console.ResetColor();
		Console.WriteLine(@"
                                                                        
                            by VonRiddarn                             
                           EMBRACE THE JANK                             ");
		Thread.Sleep(2500);
		Console.Clear();
	}

}