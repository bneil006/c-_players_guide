namespace Challenges
{
    public static class Inventory
    {
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
    }
}
