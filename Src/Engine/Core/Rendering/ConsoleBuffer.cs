using System;

namespace JankiiEngine;

public class ConsoleBuffer
{
	int _width, _height;
	Cell[] _frontBuffer, _backBuffer;

	public ConsoleBuffer(int width = 120, int height = 30)
	{
		_width = width;
		_height = height;

		// Note, we're using a 1D array and offsetting by segments using Y as a muyltiplier.
		int bufferLength = width * height;

		_frontBuffer = new Cell[bufferLength];
		_backBuffer = new Cell[bufferLength];

		Clear();
	}

	public void Clear()
	{
		for (int i = 0; i < _backBuffer.Length; i++)
		{
			_backBuffer[i] = new Cell(' ', ConsoleColor.White, ConsoleColor.Black);
		}
	}
}