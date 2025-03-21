using System;
using Challenges;
using PlayerHelpers;


Point pointA = new Point();
Point pointB = new Point(2, 3);
Point pointC = new Point(-4, 0);

Point.ShowPoints();

Color colorA = Color.Purple();
Color colorB = Color.Red();
Color colorC = new Color(128, 68, 192);

colorA.DisplayRGB();
colorB.DisplayRGB();
colorC.DisplayRGB();

Console.ReadLine();