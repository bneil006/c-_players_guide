using System;
using PlayerHelpers;

Sword firstSword = new Sword { GemstoneMaterial = GemstoneType.Sapphire, SwordMaterial = SwordType.Iron, Length = 32, Width = 4};
Sword secondSword = firstSword with { GemstoneMaterial = GemstoneType.Amber , Length = 28, Width = 2};
Sword thirdSword = new Sword(GemstoneType.Emerald, SwordType.Iron, 35, 3);

Console.WriteLine(firstSword.ToString());
Console.WriteLine(secondSword.ToString());
Console.WriteLine(thirdSword.ToString());

Console.ReadLine();