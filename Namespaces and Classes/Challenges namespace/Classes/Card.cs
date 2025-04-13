namespace Challenges
{
    public class Card
    {
        private Dictionary<string, int> cards = new Dictionary<string, int>();
        private bool faceCard;
        private string cardSelection;

        public string CardSelection
        {
            get { return cardSelection; }
            set 
            {
                cardSelection = value;
                CreateDeck();
                int cardIntNumber = cards[cardSelection];
                if (cardIntNumber > 10)
                {
                    faceCard = true;
                }
                else
                {
                    faceCard = false;
                }
            }
        }
        public bool FaceCard
        {
            get { return faceCard; }
        }

        public Card() : this("Red One")
        {
        }

        public Card(string cardSelection)
        {
            CardSelection = cardSelection;
        }

        private Dictionary<string, int> CreateDeck()
        {
            List<CardColorType> cardColors = new List<CardColorType> 
            { 
                CardColorType.Red,
                CardColorType.Green,
                CardColorType.Blue,
                CardColorType.Yellow
            };
            List<CardRankType> cardRanks = new List<CardRankType> 
            { 
                CardRankType.One, 
                CardRankType.Two, 
                CardRankType.Three, 
                CardRankType.Four,
                CardRankType.Five,
                CardRankType.Six,
                CardRankType.Seven,
                CardRankType.Eight,
                CardRankType.Nine,
                CardRankType.Ten,
                CardRankType.Jack,
                CardRankType.Queen,
                CardRankType.King,
                CardRankType.Ace
            };

            for (int i = 0; i < cardColors.Count; i++)
            {
                for (int j = 0; j < cardRanks.Count; j++)
                {
                    cards.Add($"{cardColors[i].ToString()} {cardRanks[j].ToString()}", (int)cardRanks[j]);
                }
            }
            return cards;
        }

        public void ShowDeck()
        {
            foreach (var card in cards)
            {
                Console.WriteLine($"The {card.Key}");
            }
        }

        internal enum CardColorType
        {
            Red,
            Green,
            Blue,
            Yellow
        }

        internal enum CardRankType
        {
            One = 1, 
            Two = 2, 
            Three = 3, 
            Four = 4, 
            Five = 5, 
            Six = 6, 
            Seven = 7, 
            Eight = 8, 
            Nine = 9, 
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
    }




}