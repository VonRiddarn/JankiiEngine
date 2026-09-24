using System;
using JankiiEngine;

class AlienShooter(GameConfig config) : Game(config)
{

	readonly string[] _layerZeroMap = [
		"################################################################################",
	"#,.,,,,,,.,,,,,,.,,#.........................#.................................#",
	"#,,... .,,,.,......+..........O...O..........+.................................#",
	"#,,, O ,,,........:#..........O...O..........#...#######+#######...#########...#",
	"#,,,,,,,.........::#.........................#...#.............#...#.......#...#",
	"#,.,,,.,........:::#..........O...O..........#...#...:::::::...#...+.......#...#",
	"########+###########..........O...O..........#...#...:::::::...#...#.......#...#",
	"#..................#.........................#...#.............#...#########...#",
	"#......::::........#..........O...O..........#...###############...............#",
	"#......:::.........+..........O...O..........+.................................#",
	"#..................######################+###########################+##########",
	"#......O...O.......#.........................#.................................#",
	"#..................+...::::..................#.....%................%..........#",
	"#..................#...::::..................#.................................#",
	"#......O...O.......#...::::....O.......O.....#...........%.....................#",
	"#..................#.........................#.................................#",
	"#..................#.........................+..........................%......#",
	"################################################################################"
	];

	protected override void Initialize()
	{
		Console.WriteLine("Ready to kill some alien scum?");
		Console.ReadLine();

		Player player = new(5, 5, '@', ConsoleColor.Green, ConsoleColor.Black)
		{
			Layer = 1
		};
		Entity.Instantiate(player);
	}

	protected override void Update()
	{
		if (Input.GetKeyDown(ConsoleKey.Spacebar))
		{
			Console.ForegroundColor = (ConsoleColor)Random.Shared.Next(9, 16);
			Console.WriteLine("SPACE");
		}
	}

	protected override void Draw(IRenderer renderer)
	{
		DrawMap(renderer);
		DrawEntities(1);
	}

	void DrawMap(IRenderer renderer)
	{
		for (int y = 0; y < _layerZeroMap.Length; y++)
		{
			for (int x = 0; x < _layerZeroMap[y].Length; x++)
			{
				char tile = _layerZeroMap[y][x];

				if (tile == ' ')
					continue;

				// Default to black background
				ConsoleColor fgColor = ConsoleColor.White;

				switch (tile)
				{
					case '#': fgColor = ConsoleColor.Gray; break;       // Walls
					case '.': fgColor = ConsoleColor.DarkGray; break;   // Floor
					case '+': fgColor = ConsoleColor.DarkYellow; break; // Doors
					case 'O': fgColor = ConsoleColor.White; break;      // Statues
					case ':': fgColor = ConsoleColor.DarkRed; break;    // Rubble
					case ',': fgColor = ConsoleColor.DarkGreen; break;  // Moss
					case '"': fgColor = ConsoleColor.Green; break;      // Grass
					case '%': fgColor = ConsoleColor.Magenta; break;    // Spores
				}

				renderer.SetCell(x, y, tile, fgColor, ConsoleColor.Black);
			}
		}
	}
}