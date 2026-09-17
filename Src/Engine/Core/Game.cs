using System;
using System.Threading;

namespace JankiiEngine;

// TODO: Add a GameSettings object instead. 
// It'll contain lots of default settings that can be overridden.
// This makes it easier to customize as see fit.
// EG: {TickRate: 60, SizeX: 120, SizeY: 120}
abstract class Game(int tickRate, bool cursorVisible = false)
{
	readonly int _tickMs = (int)MathF.Floor(1000f / tickRate);
	bool _isRunning = false;

	async public void Run()
	{
		if (_isRunning) return;
		_isRunning = true;

		Renderer.CursorVisible = false;
		RunSplashScreen();


		Renderer.CursorVisible = cursorVisible;
		Initialize();
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

                            by VonRiddarn                             
                           EMBRACE THE JANK                             ");

		Thread.Sleep(2500);
		Console.Clear();
	}

}