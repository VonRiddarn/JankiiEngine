namespace JankiiEngine;

class GameConfig
{
	public string Title { get; set; } = "JankiiEngine Game";
	public int TickRate { get; set; } = 60;

	public int Width { get; set; } = 200;
	public int Height { get; set; } = 30;

	public bool CursorVisible { get; set; } = false;
}