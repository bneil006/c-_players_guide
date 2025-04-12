namespace Challenges
{
    public static class Watchtower
    {
        public static void Run() // challenge on page 78
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
