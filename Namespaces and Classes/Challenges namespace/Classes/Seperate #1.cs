using System;
using System.Collections.Generic;


namespace Challenges // Challenges from C# Players Guide
{
    public static class OC // Old Challenges
    {
        

        

        

        

        

        public static int CountDown(int number) // challenge on page 107
        {
            if (number == 0) return number;
            Console.WriteLine(number);
            return CountDown(number - 1);
        }

        /// <summary>
        /// Seperated into a different class OldChallenges, from the Battler so that I could keep track of this looking back
        /// Probably not the most efficent thing to do, but it works.
        /// PlayerHelpers.cs has the Battler Class
        /// </summary>
        /// <param name="manticore"></param>
        /// <param name="city"></param>
        public static void HuntingTheManticore(Battler manticore, Battler city) // challenge on page 124
        {
            Console.Clear();

            int cityStartingHealth = city.GetHealth();
            int manticoreStartingHealth = manticore.GetHealth();

            while (manticore.GetHealth() > 0 && city.GetHealth() > 0)
            {
                Console.WriteLine("-------------------------------------------------");
                Status(city.GetAttack(), manticore, city);
                city.FindTarget(manticore);
            }

            void Status(int round, Battler manticore, Battler city)
            {
                Console.WriteLine($"STATUS: Round: {city.GetAttack()} City: {city.GetHealth()}/{cityStartingHealth} Manticore: {manticore.GetHealth()}/{manticoreStartingHealth}");
            }

            if (manticore.GetHealth() <= 0)
            {
                Console.WriteLine($"The {manticore.GetName()} has been destoryed! The city of Consolas has been saved!");
            }
            else
            {
                Console.WriteLine($"The {city.GetName()} has been destoryed!");
            }
        }

        public static void SimulasChest() // challenge on page 135
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
}
