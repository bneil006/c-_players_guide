using System;
using Challenges;

Console.Write("What day is it: ");
string day = Console.ReadLine();

switch (day.ToUpper())
{
    case "MONDAY":
    case "MON":
        Console.WriteLine("Today is Monday");
        break;
    case "TUESDAY":
    case "TUE":
        Console.WriteLine("Today is Tuesday");
        break;
    case "WEDNESDAY":
    case "WED":
        Console.WriteLine("Today is Wednesday");
        break;
    case "THURSDAY":
    case "THU":
        Console.WriteLine("Today is Thursday");
        break;
    case "FRIDAY":
    case "FRI":
        Console.WriteLine("Today is Friday");
        break;
    case "SATURDAY":
    case "SAT":
        Console.WriteLine("Today is Saturday");
        break;
    case "SUNDAY":
    case "SUN":
        Console.WriteLine("Today is Sunday");
        break;
    default:
        Console.WriteLine("Mmm, i'm not sure what day it is");
        break;
}

string[] myArray = { "banana", "orange", "apple" };
int count = 0;
for (int i = 0; i < myArray.Length; i++)
{
    count += 1;
    Console.WriteLine($"ITEM #{count}: {myArray[i]}");
}

Console.WriteLine(""); // splitting my loops on the console with some whitespace

count = 0;
foreach (string item in myArray)
{
    count += 1;
    Console.WriteLine($"ITEM #{count}: {item}");
}

Console.WriteLine("");

string[] newestArray = new string[200000];
newestArray[0] = "Dog";
newestArray[1] = "Cat";

foreach (string item in newestArray)
{
    if (item != null) // we are only executing if the arrays index in the loop isn't empty
    {
        Console.WriteLine($"ITEM: {item}");
    }
}
Console.ReadLine();