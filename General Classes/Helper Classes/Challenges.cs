using System;
using System.Collections.Generic;
using PlayerHelpers;


namespace Challenges // Challenges from C# Players Guide
{
    public static class OC // Old Challenges
    {

        public static string DuckBear() // challenge on Page 54
        {
            Console.Write("How many Chocolate Eggs recovered today?: ");
            string answer = Console.ReadLine();
            int chocEggsRecovered = int.Parse(answer);

            int sisters = 4;
            int split = chocEggsRecovered % sisters;
            int sisterSplit = chocEggsRecovered / sisters;
            return $"DuckBear receives: {split}, Each sister receives: {sisterSplit}";
        }

        public static int DominionOfKings(int provinces, int duchies, int estates) // challenge on Page 55
        {
            int total = 0;
            total += estates;
            total += duchies * 3;
            total += provinces * 6;

            return total;
        }

        public static void DefenseOfConsolas() // challenge on Page 68
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

        public static void RepairingTheClocktower() // challenge on page 75
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

        public static void Watchtower() // challenge on page 78
        {

            Console.Write("Provide X: ");
            string userX = Console.ReadLine();
            int x = int.Parse(userX);

            Console.Write("Provide Y: ");
            string userY = Console.ReadLine();
            int y = int.Parse(userY);

            bool xLeftColumn = x < 0;
            bool xCenterColumn = x == 0;
            bool xRightColumn = x > 0;

            bool yLeftColumn = y > 0;
            bool yCenterColumn = y == 0;
            bool yRightColumn = y < 0;

            string direction = String.Empty;
            if (xLeftColumn && yLeftColumn) direction = "NW";
            if (xLeftColumn && yCenterColumn) direction = "W";
            if (xLeftColumn && yRightColumn) direction = "SW";
            if (xCenterColumn && yLeftColumn) direction = "N";
            if (xCenterColumn && yCenterColumn) direction = "HERE";
            if (xCenterColumn && yRightColumn) direction = "S";
            if (xRightColumn && yLeftColumn) direction = "NE";
            if (xRightColumn && yCenterColumn) direction = "E";
            if (xRightColumn && yRightColumn) direction = "SE";

            Console.WriteLine($"ENEMY COMING FROM THE: {direction}");
        }

        public static void BuyingInventory() // challenge on page 82
        {
            List<string> inventory = new List<string>
            {
                "Ropes",
                "Torches",
                "Climbing Equipment",
                "Clean Water",
                "Machete",
                "Canoe",
                "Food Supplies"
            };
            Console.WriteLine("The Following Items are available:");

            int count = 0;
            foreach (string item in inventory)
            {
                count++;
                Console.WriteLine($"{count} - {item}");
            }
            Console.Write("What number do you want to see the price of?: ");
            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                    Console.WriteLine("10 Gold for the Rope");
                    break;
                case 2:
                    Console.WriteLine("15 Gold for the Torches");
                    break;
                case 3:
                    Console.WriteLine("25 Gold for the Climbing Equipment");
                    break;
                case 4:
                    Console.WriteLine("1 Gold for the Clean Water");
                    break;
                case 5:
                    Console.WriteLine("20 Gold for the Machete");
                    break;
                case 6:
                    Console.WriteLine("200 Gold for the Canoe");
                    break;
                case 7:
                    Console.WriteLine("1 Gold for the Food Supplies");
                    break;
                default:
                    Console.WriteLine("That's not on the menu");
                    break;
            }

        }

        public static void DiscountedInventory() // challenge on page 83
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            name = name.ToUpper();

            Dictionary<string, float> discountedMembers = new Dictionary<string, float>()
            {
                { "BRANDON", 0.5f }, // 50% discount
                { "LUNA", 0.1f } // 90% discount
            };

            Dictionary<string, int> inventory = new Dictionary<string, int>()
            {
                { "Ropes", 10 },
                { "Torches", 15 },
                { "Climbing Equipment", 25 },
                { "Clean Water", 1 },
                { "Machete", 20 },
                { "Canoe", 200 },
                { "Food Supplies", 1 }
            };

            Console.WriteLine("The Following Items are available:");
            for (int i = 0; i < inventory.Count; i++)
            {
                KeyValuePair<string, int> item = inventory.ElementAt(i); // quicker to use var here over writing out KeyValuePair<string, int> item / var item same thing
                if (discountedMembers.ContainsKey(name))
                {
                    Console.WriteLine($"{i + 1} - {item.Key}: {(float)item.Value * discountedMembers[name]} Gold");
                }
                else
                {
                    Console.WriteLine($"{i + 1} - {item.Key}: {item.Value} Gold");
                }
            }
            Console.WriteLine("What would you like to purchase, Enter Number of item on the menu: ");
            int answer = int.Parse(Console.ReadLine());
            string choice;

            choice = answer switch
            {
                1 => "Ropes",
                2 => "Torches",
                3 => "Climbing Equipment",
                4 => "Clean Water",
                5 => "Machete",
                6 => "Canoe",
                7 => "Food Supplies",
                _ => String.Empty
            };

            if (inventory.ContainsKey(choice))
            {
                if (discountedMembers.ContainsKey(name))
                {
                    int cost = inventory[choice];
                    Console.WriteLine($"{choice} will cost ya: {(float)cost * discountedMembers[name]} Gold");
                }
                else
                {
                    Console.WriteLine($"{choice} will cost ya: {inventory[choice]}");
                }
            }
            else
            {
                Console.WriteLine("That's not on the menu, run the program and try again.");
            }
        }

        public static void ThePrototype() // challenge on page 88
        {
            Console.Write("Pilot choose a number for the hunters to guess: ");
            int pilotNumber = int.Parse(Console.ReadLine());

            Console.Clear();

            bool correctGuess = false;
            while (!correctGuess) // while false
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
                    break; // not super necassary since we would exit the while loop on the next iteration but is a little more efficient
                }
            }
        }

        public static void TheMagicCannon() // challenge on page 89
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

        public static void ReplicatorOfDto() // challenge on page 94
        {
            int[] numberArray = new int[5];

            int count = 0;
            while (count < 5)
            {
                Console.Write($"Provide a number: ");
                int response = int.Parse(Console.ReadLine());
                numberArray[count] = response;
                count++;
            }

            foreach (int number in numberArray)
            {
                Console.WriteLine($"{number}");
            }
        }

        public static void LawsOfFreach() // challenge on page 95
        {
            int[] numberArray = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int minNumber = int.MaxValue;
            int total = 0;
            foreach (int number in numberArray)
            {
                total += number;
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            int average = total / numberArray.Length;
            Console.WriteLine($"Min Number: {minNumber}, Average: {average}");
        }

        /// <summary>
        /// C# Players Guide using Methods and XML Documenation, like this.
        /// </summary>
        public static int AskForNumber(string text) // challenge on page 106
        {
            Console.Write(text);
            int userResponse = int.Parse(Console.ReadLine());
            return userResponse;
        }

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

        public static void SimulaSoup() // challenge on page 143
        {
            SpiceType spiceSelection;
            IngredientType ingredientSelection;
            FoodType foodSelection;

            Console.WriteLine("*** If you don't choose an item from the menu, we will choose for you ***");
            Console.WriteLine("MENU");
            Console.WriteLine("--------------------");
            Console.WriteLine($"SPICES: {SpiceType.Spicy}, {SpiceType.Salty}, {SpiceType.Sweet}");
            Console.WriteLine($"INGREDIENT: {IngredientType.Mushroom}, {IngredientType.Carrot}, {IngredientType.Potatoe}, {IngredientType.Chicken}");
            Console.WriteLine($"FOOD: {FoodType.Soup}, {FoodType.Stew}, {FoodType.Gumbo}");
            Console.WriteLine("--------------------");

            string userSelection = userChoice("SPICE");
            spiceSelection = userSelection switch
            {
                "SPICY" => SpiceType.Spicy,
                "SALTY" => SpiceType.Salty,
                "SWEET" => SpiceType.Sweet,
                _ => SpiceType.Spicy
            };

            userSelection = userChoice("INGREDIENT");
            ingredientSelection = userSelection switch
            {
                "MUSHROOM" => IngredientType.Mushroom,
                "CARROT" => IngredientType.Carrot,
                "POTATOE" => IngredientType.Potatoe,
                "CHICKEN" => IngredientType.Chicken,
                _ => IngredientType.Mushroom
            };

            userSelection = userChoice("FOOD");
            foodSelection = userSelection switch
            {
                "SOUP" => FoodType.Soup,
                "STEW" => FoodType.Stew,
                "GUMBO" => FoodType.Gumbo,
                _ => FoodType.Soup
            };

            string userChoice(string type)
            {
                string userSelection;
                Console.WriteLine("Choose a Spice, Ingredient, Food");
                Console.Write($"{type}: ");
                userSelection = Console.ReadLine().ToUpper();
                Console.WriteLine("--------------------");
                return userSelection;
            }

            Console.WriteLine($"{spiceSelection} {ingredientSelection} {foodSelection}");
        }

        public static void TestMethod()
        {

        }

    }
}
