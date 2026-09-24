using System;
using JankiiEngine;

class Ball(int x, int y, char c, ConsoleColor fg = ConsoleColor.White, ConsoleColor? bg = null) : Entity2D(x, y, c, fg, bg)
{
	int _speedX = 1;
	int _speedY = 1;

	const int FRAME_DELAY = 3;
	int _frames = FRAME_DELAY;

	public override void OnDisable()
	{
	}

	public override void OnEnable()
	{
	}

	public override void Update()
	{
		if (--_frames > 0)
			return;

		int dX = X + _speedX;
		int dY = Y + _speedY;

		if (dX < 0 || dX >= Renderer.Window.Width)
			_speedX *= -1;
		if (dY < 0 || dY >= Renderer.Window.Height)
			_speedY *= -1;

		X += _speedX;
		Y += _speedY;

		_frames = FRAME_DELAY;
	}
}

