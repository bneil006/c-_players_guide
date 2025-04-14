using System.Linq.Expressions;

namespace Challenges
{
    public class ExeptiGame // Challenge on Page 290
    {
        private bool gameRunning = true;

        private Random random = new Random();
        private int oatMealCookie;
        private List<int> pickedNumbers = new List<int>();

        private ExeptiPlayer playerOne;
        private ExeptiPlayer playerTwo;

        public ExeptiGame(ExeptiPlayer playerOne, ExeptiPlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            oatMealCookie = random.Next(0, 10);
        }

        public void Game()
        {
            Console.WriteLine(
                "GAME: COOKIE EXCEPTION\n" +
                "There are 10 Cookies that need to be gathered and eaten. There are 9 Chocolate Chip Cookies and One Oatmeal Cookie.\n" +
                "Eating a Chocolate chip cookie keeps you in the game.\n" +
                "Eating the Oatmeal cookie loses you the game.\n" +
                "GoodLuck!\n");

            while (gameRunning)
            {
                gameRunning = Run(playerOne);
                if (!gameRunning) break;

                gameRunning = Run(playerTwo);
            }
        }

        public bool Run(ExeptiPlayer player)
        {
            
            while (true)
            {
                int number = player.ChooseNumber();

                if (number == oatMealCookie)
                {
                    Console.WriteLine($"{player.name} ATE THE OATMEAL COOKIE. GAMEOVER YOU LOSE.");
                    return false;
                }

                if (!pickedNumbers.Contains(number))
                {
                    pickedNumbers.Add(number);
                    Console.WriteLine($"{player.name} ATE A CHOCOLATE CHIP COOKIE. GOOD JOB, YOU'RE STILL IN THIS.");
                    return true;
                }
                else
                {
                    Console.WriteLine("That number / Cookie was already choosen, choose again.");
                }
            }

        }

        public void GetOatMealCookie()
        {
            Console.WriteLine(oatMealCookie);
        }

        public void GetPickedNumbers()
        {
            foreach (int number in pickedNumbers)
            {
                Console.WriteLine(number);
            }
        }

    }

    public class ExeptiPlayer
    {
        public string name;
        public ExeptiPlayer(string name)
        {
            this.name = name;
        }

        public int ChooseNumber()
        {
            int number = -1;
            while (number < 0 || number > 9)
            {
                try
                {
                    Console.Write($"{name} Choose a number: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number < 0 || number > 9) Console.WriteLine("Number must be between 0 and 9\n");
                }
                catch (FormatException e) { Console.WriteLine(e.Message); }
                catch (OverflowException e) { Console.WriteLine(e.Message); }
            }
            return number;
        }
    }
}
