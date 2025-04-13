namespace Challenges
{
    public class TicTacToe
    {
        private static bool gameOver = false;
        private static Dictionary<int, string> gameBoard = new Dictionary<int, string>()
        {
            { 1, " " },
            { 2, " " },
            { 3, " " },
            { 4, " " },
            { 5, " " },
            { 6, " " },
            { 7, " " },
            { 8, " " },
            { 9, " " }
        };

        public string Letter { get; set; }

        public TicTacToe(string letter)
        {
            Letter = letter;
        }

        private static void ShowGameBoard()
        {
            Console.WriteLine($" {gameBoard[7]} | {gameBoard[8]} | {gameBoard[9]}     7 | 8 | 9 ");
            Console.WriteLine($"---+---+---   ---+---+---");
            Console.WriteLine($" {gameBoard[4]} | {gameBoard[5]} | {gameBoard[6]}     4 | 5 | 6 ");
            Console.WriteLine($"---+---+---   ---+---+---");
            Console.WriteLine($" {gameBoard[1]} | {gameBoard[2]} | {gameBoard[3]}     1 | 2 | 3 ");
        }

        public static void UpdateBoard(TicTacToe player, int number)
        {
            int ChooseAgain()
            {
                Console.Write($"{player.Letter} choose again: ");
                int number = int.Parse(Console.ReadLine());
                return number;
            }

            while (true)
            {

                if (gameBoard[number] != " ")
                {
                    Console.WriteLine("SPOT ALREADY TAKEN.");
                    number = ChooseAgain();
                }
                else
                {
                    gameBoard[number] = player.Letter;
                    break;
                }
            }
        }

        public static void RunGame(TicTacToe playerOne, TicTacToe playerTwo)
        {
            ShowGameBoard();
            Console.WriteLine();

            while (true)
            {

                int number;

                gameOver = CheckForWin(playerTwo);
                if (gameOver == false)
                {
                    Console.Write($"Player One: ");
                    number = int.Parse(Console.ReadLine());
                    UpdateBoard(playerOne, number);
                    ShowGameBoard();
                }
                else
                {
                    break;
                }

                gameOver = CheckForWin(playerOne);
                if (gameOver == false)
                {
                    Console.Write($"Player Two: ");
                    number = int.Parse(Console.ReadLine());
                    UpdateBoard(playerTwo, number);
                    ShowGameBoard();
                }
                else
                {
                    break;
                }
            }
        }

        private static bool CheckForWin(TicTacToe player)
        {
            bool topAcrossWin = gameBoard[7] == player.Letter && gameBoard[8] == player.Letter && gameBoard[9] == player.Letter;
            bool middleAcrossWin = gameBoard[4] == player.Letter && gameBoard[5] == player.Letter && gameBoard[6] == player.Letter;
            bool bottomAcrossWin = gameBoard[1] == player.Letter && gameBoard[2] == player.Letter && gameBoard[3] == player.Letter;

            bool leftDownWin = gameBoard[7] == player.Letter && gameBoard[4] == player.Letter && gameBoard[1] == player.Letter;
            bool middleDownWin = gameBoard[8] == player.Letter && gameBoard[5] == player.Letter && gameBoard[2] == player.Letter;
            bool rightDownWin = gameBoard[9] == player.Letter && gameBoard[6] == player.Letter && gameBoard[3] == player.Letter;

            bool zigFromLeftWin = gameBoard[1] == player.Letter && gameBoard[5] == player.Letter && gameBoard[9] == player.Letter;
            bool zigFromRightWin = gameBoard[3] == player.Letter && gameBoard[5] == player.Letter && gameBoard[7] == player.Letter;

            if (
                (topAcrossWin || middleAcrossWin || bottomAcrossWin)
                || (leftDownWin || middleDownWin || rightDownWin)
                || (zigFromLeftWin || zigFromRightWin))
            {
                Console.WriteLine($"{player.Letter} WINS");
                return true;
            }
            if (!gameBoard.ContainsValue(" "))
            {
                Console.WriteLine("DRAW");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"This is my ToString Override, Player Letter: {Letter}";
        }

    }




}