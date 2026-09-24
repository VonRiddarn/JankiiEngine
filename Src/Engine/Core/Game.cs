using System;
using System.Threading;

namespace JankiiEngine;


abstract class Game(GameConfig config)
{
	protected readonly GameConfig _gameConfig = config;
	readonly int _tickMs = (int)MathF.Floor(1000f / config.TickRate);

	readonly ConsoleBuffer _consoleBuffer = new();

	bool _isRunning = false;

	public void Run()
	{
		if (_isRunning) return;
		_isRunning = true;

		Console.Title = _gameConfig.Title;

		RunSplashScreen();
		SetupConsoleEnvironment(_gameConfig);

		Initialize();

		// Input thread

		Input.Initialize_Internal();

		// Update is on main thread.

		while (true)
		{
			Update();
			Draw(_consoleBuffer);

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

	protected abstract void Draw(ConsoleBuffer buffer);

	// ----- ----- -----
	//	   HELPERS
	// ----- ----- -----


	static void SetupConsoleEnvironment(GameConfig config)
	{
		Console.ForegroundColor = config.FgColor;
		Console.BackgroundColor = config.BgColor;

		Renderer.CursorVisible = config.CursorVisible;
	}

	static void RunSplashScreen()
	{
		// TODO: Allow end user to add more stuff to the splash screen dynamically...

		Renderer.CursorVisible = false;
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.DarkYellow; // (ConsoleColor)Random.Shared.Next(1, 16);

		Console.WriteLine(Graphics.ENGINE_LOGO);

		Console.ForegroundColor = ConsoleColor.White; // (ConsoleColor)Random.Shared.Next(1, 16);

		Console.WriteLine(Graphics.ENGINGE_CREDITS);
		Thread.Sleep(2500);
		Console.Clear();
	}

}