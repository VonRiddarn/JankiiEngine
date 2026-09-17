using System;

namespace JankiiEngine;

static partial class Renderer
{
	public static bool CursorVisible
	{
		get;
		set
		{
			field = value;
			Console.CursorVisible = value;
		}
	}
}