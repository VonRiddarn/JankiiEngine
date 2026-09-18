using System;
using System.Collections.Generic;
using System.Threading;

namespace JankiiEngine;

static partial class Input
{
	static readonly HashSet<ConsoleKey> _keyCache = [];

	public static void ClearCacheInternal() => _keyCache.Clear();

	internal static void Initialize_Internal()
	{
		Thread inputThread = new(Loop);
		inputThread.Start();
	}

	static void Loop()
	{
		while (true)
		{
			_keyCache.Add(Console.ReadKey().Key);
		}
	}
}