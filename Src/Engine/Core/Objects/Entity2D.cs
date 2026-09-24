using System;

namespace JankiiEngine;

public abstract class Entity2D(int x, int y, char c, ConsoleColor fg = ConsoleColor.White, ConsoleColor? bg = null) : Entity
{
	public int X { get; set; } = x;
	public int Y { get; set; } = y;
	public ConsoleColor FgColor = fg;
	public ConsoleColor? BgColor = bg;

	public char Char = c;


	public override abstract void Update();
	public override void Draw(IConsoleBuffer renderer) => renderer.SetCell(X, Y, Char, FgColor, BgColor);
}