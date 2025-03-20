using System;
using Challenges;
using PlayerHelpers;

List<Arrows> arrows = new List<Arrows> { Arrows.CreateEliteArrow(), Arrows.CreateMarksmanArrow(), Arrows.CreateBeginnerArrow() };
Arrows myArrow = new Arrows("Wood", 69, "Goose");

Arrows.SoldArrowLedger();
Console.ReadLine();