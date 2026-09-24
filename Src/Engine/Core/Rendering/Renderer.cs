using System;

namespace JankiiEngine;

static class Renderer
{
	// ----- ***** ***** ***** -----
	//				API
	// ----- ----- ----- ----- -----

	public static bool CursorVisible
	{
		get;
		set
		{
			field = value;
			Console.CursorVisible = value;
		}
	}

	public static Window Window { get; private set; } = new(0, 0);

	// ----- ***** ***** ***** -----
	//			HELPERS
	// ----- ----- ----- ----- -----

	// ----- ***** ***** ***** -----
	//			INTERNAL
	// ----- ----- ----- ----- -----

	internal static void Setup_Internal(GameConfig cfg)
	{
		Window = new(cfg.Width, cfg.Height);
	}
}