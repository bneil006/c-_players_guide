namespace DungeonGame
{
    public class Dungeon
    {
        #region Properties
        public string RoomSizeSelection
        {
            set 
            {   
                Dictionary<string, int[,]> validSizes = new Dictionary<string, int[,]>() 
                {
                    { "Small", new int[4, 4] },
                    { "Medium", new int[6, 6] },
                    { "Large", new int[8, 8] }
                };

                while (!validSizes.ContainsKey(value))
                {
                    Console.Write("Please enter a Dungeon Size [Small, Medium, Large]: ");
                    value = Console.ReadLine();
                }

                roomSizeType = value;
                roomSize = validSizes[value];
            }
        }
        #endregion

        #region Fields
        private int[,] roomSize;
        public string roomSizeType;
        public Dictionary<(int, int), string> dungeonRooms = new Dictionary<(int, int), string>();
        public List<(int, int)> pitRooms = new List<(int, int)>();
        public List<(int, int)> stormRooms = new List<(int, int)>();
        public List<(int, int)> bearRooms = new List<(int, int)>();
        private List<(int, int)> fountainLocation = new List<(int, int)>();

        #endregion

        #region Constructor
        public Dungeon(string roomSizeRequest)
        {
            RoomSizeSelection = roomSizeRequest;
        }
        #endregion

        #region Methods
        public void SetDungeonRooms ()
        {
            Random random = new Random();

            List<string> AddDangers(int number)
            {
                List<string> dangerList = new List<string>();
                for (int i = 0; i < number; i++)
                {
                    dangerList.Add("Pit");
                    dangerList.Add("Storm");
                    dangerList.Add("Bear");
                }
                return dangerList;
            }

            List<string> dangers = new List<string>();

            switch (roomSizeType)
            {
                case "Small":
                    dangers = AddDangers(1);
                    break;
                case "Medium":
                    dangers = AddDangers(2);
                    break;
                case "Large":
                    dangers = AddDangers(4);
                    break;
            }
            
            int rows = 0;
            int columns = 0;
            for (int i = 0; i < roomSize.GetLength(0); i++)
            {
                columns = 0;
                for (int j = 0; j < roomSize.GetLength(1); j++)
                {
                    dungeonRooms.Add((rows, columns), "Empty");
                    columns++;
                }
                rows++;
            }

            while (dangers.Count > 0)
            {
                int randomDungeonNumber = random.Next(1, dungeonRooms.Count);
                int dungeonChoice = randomDungeonNumber;

                if (dungeonRooms.ElementAt(dungeonChoice).Value == "Empty")
                {
                    int randomDangerNumber = random.Next(0, dangers.Count);
                    int dangerChoice = randomDangerNumber;

                    dungeonRooms[dungeonRooms.ElementAt(dungeonChoice).Key] = dangers.ElementAt(dangerChoice);
                    dangers.RemoveAt(dangerChoice);
                }
            }

            for (int i = 0; i < dungeonRooms.Count; i++)
            {
                if (dungeonRooms.ElementAt(i).Value == "Pit")
                {
                    pitRooms.Add(dungeonRooms.ElementAt(i).Key);
                }

                if (dungeonRooms.ElementAt(i).Value == "Storm")
                {
                    stormRooms.Add(dungeonRooms.ElementAt(i).Key);
                }

                if (dungeonRooms.ElementAt(i).Value == "Bear")
                {
                    bearRooms.Add(dungeonRooms.ElementAt(i).Key);
                }
            }
        }

        public void SetFountainLocation()
        {

            while (true)
            {
                Random random = new Random();
                int choice = random.Next(8, dungeonRooms.Count);
                (int Row, int Column) selection = dungeonRooms.ElementAt(choice).Key;
                if (dungeonRooms[selection] != "Empty")
                {
                    random.Next(8, dungeonRooms.Count);
                    selection = dungeonRooms.ElementAt(choice).Key;
                }
                else
                {
                    dungeonRooms[selection] = "Fountain Of Objects";
                    fountainLocation.Add(selection);
                    break;
                }
            }
        }

        public void ShowDungeonRooms()
        {
            foreach (var item in dungeonRooms)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowDangerRooms()
        {
            foreach (var item in pitRooms)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stormRooms)
            {
                Console.WriteLine(item);
            }

            foreach (var item in bearRooms)
            {
                Console.WriteLine(item);
            }

            foreach (var item in fountainLocation)
            {
                Console.WriteLine(item);
            }
        }
        #endregion
    }
}