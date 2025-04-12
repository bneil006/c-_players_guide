namespace Challenges
{
    public static class RepairingTheClocktower
    {
        public static void Run() // challenge on page 75
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            if (number % 2 == 0)
            {
                Console.WriteLine($"TICK");
            }
            else
            {
                Console.WriteLine($"TOCK");
            }
        }
    }
}
