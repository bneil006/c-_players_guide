using System;
using Challenges;
using PlayerHelpers;


Card card = new Card("Blue King");
Console.WriteLine($"Players selected card: {card.CardSelection}. FACE CARD? {card.FaceCard}");

Console.ReadLine();