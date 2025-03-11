using System;
using System.Collections.Generic;

namespace Challenges // Challenges from C# Players Guide
{
    public class OldChallenges
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


    }
}
