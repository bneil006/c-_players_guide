using System;
using System.Collections.Generic;
using PlayerHelpers;

Player player = new Player("Brandon");
Dungeon dungeon = new Dungeon("Small");
DungeonGame game = new DungeonGame(player, dungeon);

game.RunGame();

Console.ReadLine();