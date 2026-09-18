using System;
using System.Collections.Generic;
using System.Threading;

namespace JankiiEngine;

static partial class Input
{
	static readonly HashSet<ConsoleKey> _keyCache = [];

	internal static void Clear_Cache_Internal() => _keyCache.Clear();

	internal static void Initialize_Internal()
	{
		Thread inputThread = new(Loop);
		inputThread.Start();
	}

	static void Loop()
	{
		while (true)
		{
			_keyCache.Add(Console.ReadKey(true).Key);
		}
	}
}