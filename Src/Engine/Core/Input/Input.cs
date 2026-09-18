using System;
using System.Collections.Generic;
using System.Threading;

namespace JankiiEngine;

static class Input
{

	static readonly HashSet<ConsoleKey> _keyCache = [];

	// ----- ***** ***** ***** -----
	//				API
	// ----- ----- ----- ----- -----

	public static bool GetKeyDown(ConsoleKey key)
	=> _keyCache.Contains(key);


	// ----- ***** ***** ***** -----
	//			HELPERS
	// ----- ----- ----- ----- -----

	static void Loop()
	{
		while (true)
		{
			_keyCache.Add(Console.ReadKey(true).Key);
		}
	}

	// ----- ***** ***** ***** -----
	//			INTERNAL
	// ----- ----- ----- ----- -----

	internal static void Clear_Cache_Internal() => _keyCache.Clear();

	internal static void Initialize_Internal()
	{
		Thread inputThread = new(Loop);
		inputThread.Start();
	}

}