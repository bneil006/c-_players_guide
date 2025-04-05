using System;
using System.Collections.Generic;
using PlayerHelpers;

Dungeon dungeon = new Dungeon("Small");

dungeon.SetDungeonRooms();
dungeon.ShowDungeonRooms();

Console.ReadLine();