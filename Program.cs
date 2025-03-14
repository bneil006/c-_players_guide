using System;
using Challenges;

List<(string, int, int)> highScores = new List<(string, int, int)>();

highScores.Add(OC.AddScore("Luna", 89, 8));
highScores.Add(OC.AddScore("Haley", 150, 15));
highScores.Add(OC.AddScore("Brandon", 5, 2));
highScores.Add(OC.AddScore("Sadie", 870, 25));

Console.WriteLine("UNSORTED LIST");
foreach (var score in highScores)
{
    Console.WriteLine($"Name: {score.Item1}, Score: {score.Item2}, Level: {score.Item3}");
}
Console.WriteLine("__________________________________________");
Console.WriteLine();

List<(string, int, int)> DisplayHighScores(List<(string, int, int)> scores)
{
    List<(string, int, int)> scoreList = new List<(string, int, int)>();

    while (scores.Count > 0)
    {
        (string, int, int) newTuple = ("default", 1, 1);
        int highestScore = int.MinValue;
        foreach (var score in scores)
        {
            if (score.Item2 > highestScore)
            {
                highestScore = score.Item2;
                newTuple = (score.Item1, score.Item2, score.Item3);
            }
        }
        scoreList.Add(newTuple);
        scores.Remove(newTuple);
    }
    return scoreList;
}

Console.WriteLine("SORTED LIST");
var newSortedList = DisplayHighScores(highScores);
foreach (var score in newSortedList)
{
    Console.WriteLine($"Name: {score.Item1}, Score: {score.Item2}, Level: {score.Item3}");
}
Console.WriteLine("__________________________________________");
Console.WriteLine();

Console.ReadLine();