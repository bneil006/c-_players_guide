namespace Challenges
{
    public static class DefenseOfConsolas
    {
        public static void Run() // challenge on Page 68
        {
            Console.Write("Target Row: ");
            string userRow = Console.ReadLine();
            int row = int.Parse(userRow);

            Console.Write("Target Column: ");
            string userColumn = Console.ReadLine();
            int column = int.Parse(userColumn);

            Console.WriteLine();
            Console.WriteLine($"ATTACK INBOUND");
            Console.WriteLine($"ROW: {row}, COLUMN: {column}");
            Console.WriteLine();
            Console.WriteLine("DEFENSE DEPLOYED");

            List<(int, int)> defenders = new List<(int, int)> { (row, column - 1), (row, column + 1), (row - 1, column), (row + 1, column) };
            foreach ((int, int) item in defenders)
            {
                Console.WriteLine($"{(item.Item1, item.Item2)}");
            }

        }
    }
}
