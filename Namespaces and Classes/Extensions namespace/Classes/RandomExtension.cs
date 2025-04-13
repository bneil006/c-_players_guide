namespace Extensions
{
    public static class RandomClassExtension
    {
        public static void RandomDirection (this Random random)
        {
            List<string> directions = new List<string> { "Up", "Down", "Left", "Right" };
            int choice = random.Next(0, directions.Count);
            Console.WriteLine(directions.ElementAt(choice));
        }
    }
}
