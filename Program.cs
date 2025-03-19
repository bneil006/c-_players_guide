using System;
using Challenges;
using PlayerHelpers;

Arrows myArrow = new Arrows();
Arrows mySecondArrow = new Arrows("WOOD", 85, "GOOSE");

Console.WriteLine(myArrow.GetCost());
Console.WriteLine(mySecondArrow.GetCost());

Console.ReadLine();