namespace Extensions
{
    public static class RandomClassExtension
    {
        public static string RandomDirection (this Random random) // challenge on page 278 of C# Players Guide
        {
            List<string> directions = new List<string> { "Up", "Down", "Left", "Right" };

            return directions.ElementAt(random.Next(0, directions.Count));
        }
    }
}
