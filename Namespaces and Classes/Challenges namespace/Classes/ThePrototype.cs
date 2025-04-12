namespace Challenges
{
    public static class ThePrototype
    {
        public static void Run() // challenge on page 88
        {
            Console.Write("Pilot choose a number for the hunters to guess: ");
            int pilotNumber = int.Parse(Console.ReadLine());

            Console.Clear();

            bool correctGuess = false;
            while (!correctGuess)
            {
                Console.Write("Hunter guess the pilots number: ");
                int hunterGuess = int.Parse(Console.ReadLine());
                if (hunterGuess < pilotNumber)
                {
                    Console.WriteLine($"{hunterGuess} is to low");
                }
                else if (hunterGuess > pilotNumber)
                {
                    Console.WriteLine($"{hunterGuess} is to high");
                }
                else
                {
                    Console.WriteLine("You guess the number!");
                    correctGuess = true;
                }
            }
        }
    }
}
