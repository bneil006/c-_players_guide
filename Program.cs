using System;
using System.Collections.Generic;
using PlayerHelpers;
using AdvancedPlayerHelper;

DungeonGame dungeonGame = new DungeonGame(new Player("Brandon"), new Dungeon(""));
dungeonGame.RunGame();

Console.ReadLine();