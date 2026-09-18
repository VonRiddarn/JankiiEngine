using System;
using System.Threading;

namespace JankiiEngine;


abstract class Game
{
	protected readonly GameConfig _gameConfig;
	readonly int _tickMs;

	bool _isRunning = false;

	public Game(GameConfig config)
	{
		_gameConfig = config;
		_tickMs = (int)MathF.Floor(1000f / config.TickRate);
	}

	public void Run()
	{
		if (_isRunning) return;
		_isRunning = true;

		Console.Title = _gameConfig.Title;

		Renderer.CursorVisible = false;
		RunSplashScreen();


		Renderer.CursorVisible = _gameConfig.CursorVisible;
		Initialize();
		// TODO: Make sure to pass GameConfig to the engine backend so we can use width / height for viewport rendering.
		// TODO: Setup input thread
		// TODO: Setup update thread
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