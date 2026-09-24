using System;

namespace JankiiEngine;

public interface IConsoleBuffer
{
	public void SetCell(int x, int y, char c, ConsoleColor fg, ConsoleColor? bg);
}