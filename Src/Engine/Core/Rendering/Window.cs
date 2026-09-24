using System;

internal class Window(int w, int h, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
{
	public readonly int Width = w;
	public readonly int Height = h;

	public readonly ConsoleColor DefaultForegroundColor = fg;
	public readonly ConsoleColor DefaultBackgroundColor = bg;
}