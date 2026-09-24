using System;

namespace JankiiEngine;

// TODO: Look into WriteConsoleOutput (windows only)
// Maybe have the gamesetting require a render-enginge of choice.
// To streamline the API both renderers (Buffer and Block) can use something like IRenderEngine
// 
// Another alternative: ANSI codes and buffer. I've never gotten ANSI to work as I want it to though.
// Might be a good cross-platform performance project

public class ConsoleBuffer : IRenderer
{
	readonly int _width, _height;
	readonly Cell[] _frontBuffer, _backBuffer;

	public ConsoleBuffer(int width = 120, int height = 30)
	{
		_width = width;
		_height = height;

		// Note, we're using a 1D array and offsetting by segments using Y as a muyltiplier.
		int bufferLength = width * height;

		_frontBuffer = new Cell[bufferLength];
		_backBuffer = new Cell[bufferLength];

		Initialize();
	}

	void Initialize()
	{
		for (int i = 0; i < _backBuffer.Length; i++)
		{
			_backBuffer[i] = new Cell(' ', ConsoleColor.White, ConsoleColor.Black);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < _backBuffer.Length; i++)
		{
			_backBuffer[i].Update(' ', ConsoleColor.White, ConsoleColor.Black);
		}
	}

	public void SetCell(int x, int y, char c, ConsoleColor fg, ConsoleColor bg)
	{
		if (x < 0 || x >= _width || y < 0 || y >= _height)
			return;

		int index = y * _width + x;

		_backBuffer[index].Update(c, fg, bg);
	}

	public void Draw()
	{
		int index;

		for (int y = 0; y < _height; y++)
		{
			for (int x = 0; x < _width; x++)
			{
				index = y * _width + x;

				if (_backBuffer[index] == _frontBuffer[index])
					continue;

				Console.SetCursorPosition(x, y);
				if (Console.ForegroundColor != _backBuffer[index].FgColor)
					Console.ForegroundColor = _backBuffer[index].FgColor;

				if (Console.BackgroundColor != _backBuffer[index].BgColor)
					Console.BackgroundColor = _backBuffer[index].BgColor;

				Console.Write(_backBuffer[index].Char);

				// Sync front buffer to what is currently drawn
				_frontBuffer[index] = _backBuffer[index];
			}
		}
	}
}