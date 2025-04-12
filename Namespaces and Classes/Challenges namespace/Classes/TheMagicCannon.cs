namespace Challenges
{
    public static class TheMagicCannon
    {
        public static void Run() // challenge on page 89
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"{i}: Fire & Electric");
                }
                else if (i % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i}: Fire");
                }
                else if (i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i}: Electric");
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"{i}: Normal");
                }
            }
        }
    }
}
