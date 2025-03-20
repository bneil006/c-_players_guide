using System;
using Challenges;
using PlayerHelpers;

Arrows myArrow = new Arrows("Steel", 85, "Goose");

myArrow.GetHeadType();
myArrow.GetFletchingType();
myArrow.GetShaftLength();
Console.WriteLine(myArrow.GetCost());
Console.WriteLine();

myArrow.SetHeadType("Wood");
myArrow.SetFletchingType("Turkey");
myArrow.SetShaftLength(65);

myArrow.GetHeadType();
myArrow.GetFletchingType();
myArrow.GetShaftLength();
Console.WriteLine(myArrow.GetCost());

Console.ReadLine();