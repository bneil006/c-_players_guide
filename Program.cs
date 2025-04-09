using System;
using iField;
using McDonald;

Sheep sheep = new Sheep();
Cow cow = new Cow();

iField.Pig iPig = new iField.Pig();
McDonald.Pig mcPig = new McDonald.Pig();

Console.WriteLine($"{sheep.ToString()}, {cow.ToString()}, {iPig.ToString()}, {mcPig.ToString()}");

Console.ReadLine();