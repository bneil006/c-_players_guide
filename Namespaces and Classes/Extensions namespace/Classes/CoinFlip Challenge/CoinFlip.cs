namespace Extensions
{
    public class CoinFlip
    {
        public string CoinFlipSpecial(bool fixedGame = false) // challenge on page 278 of C# Players Guide
        {
            Random random = new Random();
            List<string> coinString = new List<string> { "Heads", "Tails" };

            if (fixedGame)
            {
                coinString.Add("Heads");
                coinString.Add("Heads");
            }

            return coinString.ElementAt(random.Next(0, coinString.Count));
        }
    }
}
