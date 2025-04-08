namespace PlayerHelpers
{
    public class Player
    {
        #region Properties
        public string Name {  get; set; }
        #endregion

        #region Fields
        public bool playerAlive = true;
        public (int Row, int Column) playerPosition;
        private List<(int Row, int Column)> visitedRooms = new List<(int Row, int Column)>
        {
            (0, 0)
        };
        #endregion

        public Player(string name)
        {
            Name = name;

            playerPosition = (0,  0);
        }

        public void MoveNorth(int number)
        {
            playerPosition.Row += number;
            AddToVisitedRooms(playerPosition);
        }

        public void MoveSouth(int number)
        {
            playerPosition.Row -= number;
            AddToVisitedRooms(playerPosition);
        }

        public void MoveWest(int number)
        {
            playerPosition.Column -= number;
            AddToVisitedRooms(playerPosition);
        }

        public void MoveEast(int number)
        {
            playerPosition.Column += number;
            AddToVisitedRooms(playerPosition);
        }

        private void AddToVisitedRooms((int, int) position)
        {
            if (!visitedRooms.Contains(playerPosition))
            {
                visitedRooms.Add(playerPosition);
            }
        }

        public void ShowVisitedRooms()
        {
            Console.WriteLine("Visited Rooms");
            Console.WriteLine("------------------------------");

            int count = 0;
            foreach (var room in visitedRooms)
            {
                if (count == 5)
                {
                    Console.WriteLine();
                    count = 0;
                }
                Console.Write($"{room} ");
                count++;
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------");
        }
    }
}