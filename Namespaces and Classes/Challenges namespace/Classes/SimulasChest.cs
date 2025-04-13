namespace Challenges
{
    public static class SimulasChest
    {
        public static void Run() // challenge on page 135
        {
            ChestStates currentState = ChestStates.Locked;

            Console.WriteLine("Exit program with Q or Quit");
            Console.WriteLine("-------------------------------------------");

            string userResponse;
            while (true)
            {

                Console.Write($"The chest is {currentState}. What do you want to do [open, close, lock, unlock]: ");
                userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "OPEN" && currentState == ChestStates.Unlocked)
                {
                    currentState = ChestStates.Open;
                }
                else if (userResponse == "CLOSE" && currentState == ChestStates.Open)
                {
                    currentState = ChestStates.Closed;
                }
                else if (userResponse == "LOCK" && currentState == ChestStates.Closed || currentState == ChestStates.Unlocked)
                {
                    currentState = ChestStates.Locked;
                }
                else if (userResponse == "UNLOCK" && currentState == ChestStates.Locked)
                {
                    currentState = ChestStates.Unlocked;
                }
                else if (userResponse == "QUIT" || userResponse == "Q")
                {
                    break;
                }

            }
        }
    }

    internal enum ChestStates // challenge on page 135 SimulaChest()
    {
        Open,
        Closed,
        Locked,
        Unlocked
    }
}
