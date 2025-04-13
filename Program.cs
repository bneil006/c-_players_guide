using Extensions;

Random random = new Random();
CoinFlip coinFlipFair = new CoinFlip();
CoinFlip coinFlipUnfair = new CoinFlip();

Dictionary<string, int> evenOdds = new Dictionary<string, int>();
Dictionary<string, int> unevenOdds = new Dictionary<string, int>();

for (int i = 0; i < 1000; i++)
{
    string side = coinFlipFair.CoinFlipSpecial(false);
    if (evenOdds.ContainsKey(side))
    {
        evenOdds[side] += 1;
    }
    else
    {
        evenOdds[side] = 1;
    }
}

for (int i = 0; i < 1000; i++)
{
    string side = coinFlipUnfair.CoinFlipSpecial(true);
    if (unevenOdds.ContainsKey(side))
    {
        unevenOdds[side] += 1;
    }
    else
    {
        unevenOdds[side] = 1;
    }
}

foreach (var side in evenOdds)
{
    Console.WriteLine(side);
}

foreach (var side in unevenOdds)
{
    Console.WriteLine(side);
}

Console.ReadLine();