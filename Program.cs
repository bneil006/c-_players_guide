using System;

static string DuckBear() // challenge on Page 54 on C# Players Guide
{
    Console.Write("How many Chocolate Eggs recovered today?: ");
    string answer = Console.ReadLine();
    int chocEggsRecovered = int.Parse(answer);

    int sisters = 4;
    int split = chocEggsRecovered % sisters;
    int sisterSplit = chocEggsRecovered / sisters;
    return $"DuckBear receives: {split}, Each sister receives: {sisterSplit}";
}

static int DominionOfKings(int provinces, int duchies, int estates) // challenge on Page 55
{
    int total = 0;
    total += estates;
    total += duchies * 3;
    total += provinces * 6;

    return total;
}

static void DefenseOfConsolas() // challenge on Page 68
{
    Console.Write("Target Row: ");
    string userRow = Console.ReadLine();
    int row = int.Parse(userRow);

    Console.Write("Target Column: ");
    string userColumn = Console.ReadLine();
    int column = int.Parse(userColumn);

    Console.WriteLine("");
    Console.WriteLine($"ATTACK INBOUND");
    Console.WriteLine($"ROW: {row}, COLUMN: {column}");
    Console.WriteLine("");
    Console.WriteLine("DEFENSE DEPLOYED");

    List<(int, int)> defenders = new List<(int, int)> { (row, column - 1), (row, column + 1), (row - 1, column), (row + 1, column) };
    foreach ((int, int) item in defenders)
    {
        Console.WriteLine($"{(item.Item1, item.Item2)}");
    }

}

DefenseOfConsolas();
Console.ReadLine();