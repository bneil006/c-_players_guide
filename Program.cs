using System;
using Challenges;
using PlayerHelpers;

Score newScore = new Score();
Score betterNewScore = new Score("Haley", 5000, 5);

newScore.name = "Brandon";
newScore.points = 4000;
newScore.level = 5;

Dictionary<string, Dictionary<string, (int, int, bool)>> myDict = new Dictionary<string, Dictionary<string, (int, int, bool)>>
{
    {"name", new Dictionary<string, (int, int, bool)>
        {
            {newScore.name, (newScore.points, newScore.level, newScore.EarnedStar())},
            {betterNewScore.name, (betterNewScore.points, betterNewScore.level, betterNewScore.EarnedStar())}
        }
    }
};

foreach (var item in myDict["name"])
{
    string name = item.Key;
    (int points, int level, bool earnedStar) = item.Value;
    Console.WriteLine($"Name: {name}, Points: {points}, Level: {level}, EarnedStar: {earnedStar}");
}
Console.ReadLine();