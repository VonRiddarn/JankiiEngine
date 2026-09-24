using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JankiiEngine;


abstract class Game(GameConfig config)
{
	protected readonly GameConfig _gameConfig = config;
	readonly int _tickMs = (int)MathF.Floor(1000f / config.TickRate);

	readonly ConsoleBuffer _consoleBuffer = new();

	bool _isRunning = false;

	readonly Dictionary<int, Entity> _entities = [];
	readonly Queue<Entity> _entitiesToInstantiate = [];
	readonly Queue<int> _entitiesToDestroy = [];

	// Lowkey, hashset might be overkill, but it ensures a "one, and only one" relationship for instances. 
	readonly HashSet<int> _enabledEntities = [];

	public void Run()
	{
		if (_isRunning) return;
		_isRunning = true;

		Console.Title = _gameConfig.Title;

		RunSplashScreen();
		SetupConsoleEnvironment(_gameConfig);

		// Setup Entity connection
		Entity.Set_Game_Internal(this);

		Initialize();

		// Input thread
		Input.Initialize_Internal();

		// Update is on main thread.

		try
		{
			while (true)
			{
				// Update main game loop
				Update();

				// Update, Enable and Destroy entities
				UpdateEntities();

				_consoleBuffer.Clear();
				Draw(_consoleBuffer);
				_consoleBuffer.Draw();

				Input.Clear_Cache_Internal();
				Thread.Sleep(_tickMs);
			}
		}
		catch (Exception e)
		{
			Console.Clear();
			Console.Write(e.Message);
			Console.WriteLine("Enter to continue...");
			Console.ReadLine();
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

	protected abstract void Draw(IRenderer renderer);

	// ----- ----- -----
	//	   	  API
	// ----- ----- -----
	internal void Instantiate_Entity_Internal(Entity entity)
		=> _entitiesToInstantiate.Enqueue(entity);

	internal void Destroy_Entity_Internal(Entity entity)
		=> _entitiesToDestroy.Enqueue(entity.InstanceId);

	public void DrawEntities(int layer = 0)
	{
		if (_entities.Count > 0)
		{
			foreach (var kvp in _entities)
			{
				Entity e = kvp.Value;
				if (e.Layer != layer || e.IsDestroyed || !e.IsEnabled)
					continue;

				e.Draw(_consoleBuffer);
			}
		}
	}

	// ----- ----- -----
	//	   HELPERS
	// ----- ----- -----

	void UpdateEntities()
	{
		// Instantiate entities
		while (_entitiesToInstantiate.Count > 0)
		{
			Entity e = _entitiesToInstantiate.Dequeue();
			if (_entities.TryAdd(e.InstanceId, e))
				e.OnInitialize();
		}

		// Update, enable or queue to destroy entities
		if (_entities.Count > 0)
		{
			foreach (var kvp in _entities)
			{
				Entity e = kvp.Value;

				if (e.IsDestroyed)
					continue;
				else if (e.IsEnabled)
				{
					if (!_enabledEntities.Contains(e.InstanceId))
					{
						e.OnEnable();
						_enabledEntities.Add(e.InstanceId);
					}
					e.Update();
				}
				else if (_enabledEntities.Contains(e.InstanceId))
				{
					e.OnDisable();
					_enabledEntities.Remove(e.InstanceId);
				}
			}
		}

		// Instantiate entities
		while (_entitiesToDestroy.Count > 0)
		{
			int id = _entitiesToDestroy.Dequeue();
			_entities.Remove(id);
			_enabledEntities.Remove(id);
		}
	}

	// ----- ----- -----
	//	STATIC HELPERS
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