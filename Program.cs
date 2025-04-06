using System;
using System.Collections.Generic;
using PlayerHelpers;

Dungeon dungeon = new Dungeon("Medium");

dungeon.SetDungeonRooms();
dungeon.ShowDungeonRooms();

Console.ReadLine();