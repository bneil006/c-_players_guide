using System;
using Challenges;
using PlayerHelpers;

Arrows myArrow = new Arrows("Steel", 80, "Plastic");

Console.WriteLine(myArrow.Head);
Console.WriteLine(myArrow.Fletching);
Console.WriteLine(myArrow.ShaftLength);
Console.WriteLine(myArrow.Cost);
Console.WriteLine();

myArrow.Head = "Wood";
myArrow.Fletching = "Turkey";
myArrow.ShaftLength = 70;

Console.WriteLine(myArrow.Head);
Console.WriteLine(myArrow.Fletching);
Console.WriteLine(myArrow.ShaftLength);
Console.WriteLine(myArrow.Cost);
Console.WriteLine();

Arrows bestArrow = new Arrows { Fletching = "Goose", Head = "Steel", ShaftLength = 65 }; // object initializer syntax since we have properties
Console.WriteLine(bestArrow.Head);
Console.WriteLine(bestArrow.Fletching);
Console.WriteLine(bestArrow.ShaftLength);
Console.WriteLine(bestArrow.Cost);
Console.WriteLine();

Arrows defaultArrow = new Arrows();
Console.WriteLine(defaultArrow.Head);
Console.WriteLine(defaultArrow.Fletching);
Console.WriteLine(defaultArrow.ShaftLength);
Console.WriteLine(defaultArrow.Cost);

Console.ReadLine();