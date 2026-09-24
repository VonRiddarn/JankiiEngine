using System;

namespace JankiiEngine;

public record struct Cell(char Char, ConsoleColor FgColor, ConsoleColor BgColor)
{
	public void Update(char c, ConsoleColor fgColor, ConsoleColor bgColor)
	{
		Char = c;
		FgColor = fgColor;
		BgColor = bgColor;
	}
}