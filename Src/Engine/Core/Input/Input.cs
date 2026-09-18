using System;
using System.Collections.Generic;
using System.Threading;
using JankiiEngine.Internal;

namespace JankiiEngine;

static partial class Input
{
	public static bool GetKeyDown(ConsoleKey key)
	=> _keyCache.Contains(key);

}