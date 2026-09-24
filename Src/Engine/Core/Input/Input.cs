using System;
using System.Collections.Generic;
using System.Threading;

namespace JankiiEngine;

static class Input
{

	static readonly HashSet<ConsoleKey> _keyCache = [];

	static readonly Lock _cacehLock = new();

	// ----- ***** ***** ***** -----
	//				API
	// ----- ----- ----- ----- -----

	public static bool GetKeyDown(ConsoleKey key)
	{
		lock (_cacehLock)
			return _keyCache.Contains(key);
	}


	// ----- ***** ***** ***** -----
	//			HELPERS
	// ----- ----- ----- ----- -----

	static void Loop()
	{
		while (true)
		{
			var keyInfo = Console.ReadKey(true);

			lock (_cacehLock)
				_keyCache.Add(keyInfo.Key);
		}
	}

	// ----- ***** ***** ***** -----
	//			INTERNAL
	// ----- ----- ----- ----- -----

	internal static void Clear_Cache_Internal()
	{
		lock (_cacehLock)
			_keyCache.Clear();
	}

	internal static void Initialize_Internal()
	{
		Thread inputThread = new(Loop);
		inputThread.Start();
	}

}