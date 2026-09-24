using System;

interface IRenderer
{
	public void SetCell(int x, int y, char c, ConsoleColor fg, ConsoleColor bg);
}