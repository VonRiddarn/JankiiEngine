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

	// ----- ***** ***** ***** -----
	//			HELPERS
	// ----- ----- ----- ----- -----

	// ----- ***** ***** ***** -----
	//			INTERNAL
	// ----- ----- ----- ----- -----
}