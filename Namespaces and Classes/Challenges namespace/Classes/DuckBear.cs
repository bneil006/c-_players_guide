namespace Challenges
{
    public class DuckBear // challenge on Page 54 & Refactored for Challenge on page 276
    {
        private int _sisters;
        public int Sisters
        {
            get { return _sisters; }
            set 
            {
                while (_sisters <= 0)
                {
                    Console.Write("How many sisters are there to share the Chocolate eggs with? ");
                    string response = Console.ReadLine();
                    int number;

                    int.TryParse(response, out number);
                    if (int.TryParse(response, out number) && number > 0)
                    {
                        _sisters = number;
                        Console.WriteLine(); // just for some extra spacing
                    }
                    else
                    {
                        Console.WriteLine("Please provide a positive number.\n");
                    }
                }    
            }
        }

        public DuckBear(int sisters = 0)
        {
            this._sisters = sisters;
        }

        public void SplitBetweenSisters()
        {
            Console.WriteLine("The sisters collect eggs all day and decide to split the eggs evenly between " +
                "eachother and the remainder of the chocolate eggs will be given to their DuckBear.\n");
            int number = 0;

            while (number <= 0)
            {
                Console.Write("How many eggs where collected? ");
                string response = Console.ReadLine();
                
                if (int.TryParse(response, out number))
                {
                    Console.WriteLine(); // just for some extra spacing
                }
                else
                {
                    Console.WriteLine("Please provide a positive number of Chocolate eggs collected.\n");
                }
            }

            int duckBearShare = number % Sisters;
            int sisterShare = (number / Sisters);
            Console.WriteLine($"The DuckBear Receives: {duckBearShare} Chocolate Eggs. The Sisters receive: {sisterShare} each.");
        }
    }
}
