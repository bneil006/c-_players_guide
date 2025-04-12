using System;
using System.Collections.Generic;

namespace Challenges
{

    #region Generics Challenge Level 30
    public class Bow { }

    public class Axe { }

    public class Dagger { }

    public class ColoredWeapon<T>where T : class
    {
        public WeaponColors Color { get; set; }
        public string Name
        {
            get
            {
                Type baseClass = typeof(T);
                return baseClass.Name;
            }
        }
        public ColoredWeapon(WeaponColors color)
        {
            Color = color;
        }

        public void DisplayWeapon()
        {
            Console.WriteLine($"{Color} {Name}");
        }
    }

    public enum WeaponColors
    {
        Blue,
        Green,
        Red
    }
    #endregion

    #region Records & War Preparations Challenge
    public record Sword
    {
        public GemstoneType GemstoneMaterial { get; init; }
        public SwordType SwordMaterial { get; init; }
        public int Length { get; init; }
        public int Width { get; init; }

        public Sword()
        {

        }
        public Sword(GemstoneType gem, SwordType sword, int length, int width)
        {
            GemstoneMaterial = gem;
            SwordMaterial = sword;
            Length = length;
            Width = width;
        }
    }

    public enum GemstoneType
    {
        Emerald,
        Amber,
        Sapphire,
        Diamond,
        Bitstone
    }

    public enum SwordType
    {
        Wood,
        Bronze,
        Iron,
        Steel,
        Binarium
    }
    #endregion

    #region Structs & Room Coordinates Challenge
    public struct Vector3
    {
        public int X { get; init; }
        public int Z { get; init; }
        public int Y { get; init; }

        public Vector3(int x, int z, int y)
        {
            X = x; 
            Z = z;
            Y = y; 
        }
    }

    #region Example of Class and Struct interaction with assignments
    //PairOfPair myPair = new PairOfPair();

    //myPair.PairOne.X = 3;
    //myPair.PairTwo.Y = 8;

    //myPair.Display();
    public class PairOfPair
    {
        public PairOfIntStruct PairOne;
        public PairOfIntStruct PairTwo;

        public void Display()
        {
            Console.WriteLine($"[Pair One] X: {PairOne.X}, Y: {PairOne.Y}");
            Console.WriteLine($"[Pair Two] X: {PairTwo.X}, Y: {PairTwo.Y}");
        }
    }

    public struct PairOfIntStruct
    {
        public int X;
        public int Y;
    }
    #endregion


    #endregion

    #region Robot Classes

    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public List<RobotCommandBase> Commands { get; } = new List<RobotCommandBase>();
        
        public void Run()
        {
            foreach (RobotCommandBase command in Commands)
            {
                command.Run(this);
                Console.WriteLine($"X: {X}, Y: {Y}, IsPowered: {IsPowered}");
            }
        }

        public void AddCommands(params List<RobotCommandBase> commands)
        {
            foreach (RobotCommandBase command in commands)
            {
                Commands.Add(command);
            }
        }
        
    }

    public abstract class RobotCommandBase
    {
        public abstract void Run(Robot robot);
        public virtual void UnPowered()
        {
            Console.WriteLine("Action can't be performed, Robot is powered off.");

        }
    }

    public class PowerOn : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = true;
        }
    }

    public class PowerOff : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            robot.IsPowered = false;
        }
    }

    public class MoveNorthRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y += 1;
            }
            else
            {
                UnPowered();
            }
        }

        public override void UnPowered()
        {
            Console.WriteLine("Can't move North, Robot is powered off.");
        }
    }

    public class MoveSouthRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.Y -= 1;
            }
            else
            {
                UnPowered();
            }
        }
    }

    public class MoveWestRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X += 1;
            }
            else
            {
                UnPowered();
            }
        }
    }

    public class MoveEastRobot : RobotCommandBase
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
            {
                robot.X -= 1;
            }
            else
            {
                UnPowered();
            }
        }
    }


    #endregion

    #region Packing & Labeling Inventory Challenge
    public class Pack
    {
        #region Base Class Properties
        public int BagItemCapacity { get; protected set; }
        public float BagWeightCapacity { get; protected set; }
        public float BagVolumeCapacity { get; protected set; }
        public List<InventoryItem> PackInventoryList { get; protected set; }

        #endregion
        public Pack(int itemCapacity, int weightCapacity, int volumeCapacity)
        {
            BagItemCapacity = itemCapacity;
            BagWeightCapacity = weightCapacity;
            BagVolumeCapacity = volumeCapacity;
            PackInventoryList = new List<InventoryItem>();
        }
        public override string ToString()
        {
            string itemList = string.Empty;

            for (int i = 1; i < PackInventoryList.Count; i++)
            {
                itemList += $"{i}: {PackInventoryList[i].ToString()} ";
            }
            if (itemList == string.Empty)
            {
                itemList = "Pack is empty";
            }
            return itemList;
        }

        public bool PackItem(InventoryItem item)
        {
            if (item.ItemWeight > BagWeightCapacity)
            {
                Console.WriteLine($"Overweight, {item} can not be added.");
                return false;
            }
            else if (item.ItemVolume > BagVolumeCapacity)
            {
                Console.WriteLine($"Overvolume, {item} can not be added.");
                return false;
            }
            else if (BagItemCapacity <= 0)
            {
                Console.WriteLine($"Over Item Capacity, {item} can not be added.");
                return false;
            }
            else
            {
                BagItemCapacity -= 1;
                BagWeightCapacity -= item.ItemWeight;
                BagVolumeCapacity -= item.ItemVolume;

                Console.WriteLine();
                Console.WriteLine($"Item Added: {item.ToString()}");
                PackInventoryList.Add(item);
                PackStatus();

                return true;
            }
        }

        public void PackItems(params InventoryItem[] items)
        {
            foreach (InventoryItem item in items)
            {
                PackItem(item);
            }
        }

        public Pack CreateNewPack() // not finished implementing but i get the jist of the challenge on 205 so i probably wont finish this class in full.
        {
            return new Pack(10, 8, 4);
        }

        public void PackStatus()
        {
            Console.WriteLine($"PACK STATUS | Item Capacity Left: {BagItemCapacity}, Weight Capacity Left: {BagWeightCapacity:.##}, Volume Capacity Left: {BagVolumeCapacity:.##}");
        }
    }

    public abstract class InventoryItem
    {
        public string ItemName {  get; set; }
        public float ItemWeight { get; set; }
        public float ItemVolume { get; set; }
        public InventoryItem()
        {

        }

        public override string ToString()
        {
            return $"{ItemName}";
        }
    }

    public class ArrowItem : InventoryItem
    {
        public ArrowItem()
        {
            ItemName = "Arrow";
            ItemWeight = 0.1f;
            ItemVolume = 0.05f;
        }
    }

    public class BowItem : InventoryItem
    {
        public BowItem()
        {
            ItemName = "Bow";
            ItemWeight = 1.0f;
            ItemVolume = 4.0f;
        }
    }

    public class RopeItem : InventoryItem
    {
        public RopeItem()
        {
            ItemName = "Rope";
            ItemWeight = 1.0f;
            ItemVolume = 1.5f;
        }
    }

    public class WaterItem : InventoryItem
    {
        public WaterItem()
        {
            ItemName = "Water";
            ItemWeight = 2.0f;
            ItemVolume = 3.0f;
        }
    }

    public class FoodRationItem : InventoryItem
    {
        public FoodRationItem()
        {
            ItemName = "Food Ration";
            ItemWeight = 1.0f;
            ItemVolume = 0.5f;
        }
    }

    public class SwordItem : InventoryItem
    {
        public SwordItem()
        {
            ItemName = "Sword";
            ItemWeight = 5.0f;
            ItemVolume = 3.0f;
        }
    }
    #endregion

    #region TicTacToe Class
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
    #endregion

    #region PasswordValidator Class
    public class PasswordValidator
    {
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                bool noCapitalLetterT = true; // requirement of Ingelmar in IT on page 192 of C# Players Guide to not contain a Capital T
                bool noAmperstand = true; // requirment of Ingelmar in IT on page 192 of C# Players Guide to not contain a &

                bool lengthRequirements = false;
                bool oneUppercaseLetter = false;
                bool oneLowercaseLetter = false;
                bool hasSpecialCharacter = false;
                bool hasDigit = false;

                List<char> specialCharacters = new List<char>() { '!', '@', '#', '$', '%', '^', '*' };

                if (value.Count<char>() < 6)
                {
                    Console.WriteLine("Password to short. Min 6 characters, Max 13 characters");
                }
                else if (value.Count<char>() > 13)
                {
                    Console.WriteLine("Password to long. Min 6 characters, Max 13 characters");
                }
                else
                {
                    lengthRequirements = true;
                }

                foreach (char c in value)
                {
                    if (c == 'T')
                    {
                        Console.WriteLine("\"T\" is not allowed in the password.");
                        noCapitalLetterT = false;
                    }
                    else if (c == '&')
                    {
                        Console.WriteLine("\"&\" is not allowed in the password.");
                        noAmperstand = false;
                    }
                    else if (char.IsUpper(c))
                    {
                        oneUppercaseLetter = true;
                    }
                    else if (char.IsLower(c))
                    {
                        oneLowercaseLetter = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        hasDigit = true;
                    }
                }

                foreach(char c in value)
                {
                    if (specialCharacters.Contains(c))
                    {
                        hasSpecialCharacter = true;
                    }
                }

                if (!oneUppercaseLetter)
                {
                    Console.WriteLine("Atleast One Uppercase Letter required in password.");
                }
                else if (!oneLowercaseLetter)
                {
                    Console.WriteLine("Atleast One Lowercase Letter required in password.");
                }
                else if (!hasDigit)
                {
                    Console.WriteLine("Atleast One Digit required in password.");
                }
                else if (!hasSpecialCharacter)
                {
                    Console.WriteLine("Atleast One Special required in password.");
                }

                if (
                    noCapitalLetterT == true
                    && noAmperstand == true
                    && lengthRequirements == true
                    && oneUppercaseLetter == true
                    && oneLowercaseLetter == true
                    && hasSpecialCharacter == true
                    && hasDigit == true)
                {
                    password = value;
                }

            }
        }
        public PasswordValidator(string password)
        {
            Password = password;
        }
    }
    #endregion

    #region Door Class
    public class Door
    {
        private int passcode;
        private string doorState = "LOCKED";

        public Door(int intPasscode)
        {
            this.passcode = intPasscode;
        }

        public void InteractWithDoor()
        {
            Console.WriteLine("AVALIABLE ACTIONS:");
            Console.WriteLine("OPEN, CLOSE, LOCK, UNLOCK, CHANGE PASSWORD, STOP");
            Console.WriteLine();

            AskUserForAction();
        }

        private void AskUserForAction()
        {
            while (true)
            {

                Console.WriteLine($"The door is {doorState}");
                Console.WriteLine($"What would you like to do: ");
                string userResponse = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (userResponse == "UNLOCK" && (doorState == "LOCKED"))
                {
                    UnlockDoor();
                }
                else if (userResponse == "OPEN" && (doorState == "UNLOCKED" || userResponse == "OPEN" && doorState == "CLOSED"))
                {
                    OpenDoor();
                }
                else if (userResponse == "CLOSE" && doorState == "OPEN")
                {
                    CloseDoor();
                }
                else if (userResponse == "LOCK" && (doorState == "CLOSED" || userResponse == "LOCK" && doorState == "UNLOCKED"))
                {
                    LockDoor();
                }
                else if (userResponse == "CHANGE PASSWORD" || userResponse == "PASSWORD")
                {
                    Console.Write("Provide the current password: ");
                    int userPasswordResponse = int.Parse(Console.ReadLine());
                    ChangePasscode(userPasswordResponse, passcode);
                }

            }
        }

        private void UnlockDoor()
        {
            Console.Write($"Please provide the pin to unlock the door: ");
            int userProvidedPasscode = int.Parse(Console.ReadLine());
            if (passcode == userProvidedPasscode)
            {
                doorState = "UNLOCKED";
                AskUserForAction();
            }
            else
            {
                Console.WriteLine("Wrong passcode provided.");
                Console.WriteLine();
                AskUserForAction();
            }
        }

        private void OpenDoor()
        {
            doorState = "OPEN";
            AskUserForAction();
        }

        private void CloseDoor()
        {
            doorState = "CLOSED";
            AskUserForAction();
        }

        private void LockDoor()
        {
            doorState = "LOCKED";
            AskUserForAction();
        }

        private void ChangePasscode(int newPasscode, int oldPasscode)
        {
            if (oldPasscode == newPasscode)
            {
                Console.Write("New Passcode PIN #: ");
                int response = int.Parse(Console.ReadLine());

                Console.WriteLine($"Passcode changed.");
                Console.WriteLine();

                passcode = response;
                AskUserForAction();
            }
            else
            {
                Console.WriteLine($"Passcode not changed, wrong current passcode.");
                Console.WriteLine();
            }
        }
    }
    #endregion

    #region Card Class
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
    #endregion

    #region Color Class
    public class Color // challenge on page 191
    {
        public static Color White() => new Color(255, 255, 255);
        public static Color Black() => new Color(0, 0, 0);
        public static Color Red() => new Color(255, 0, 0);
        public static Color Orange() => new Color(255, 165, 0);
        public static Color Yellow() => new Color(255, 255, 0);
        public static Color Green() => new Color(0, 128, 0);
        public static Color Blue() => new Color(0, 0, 255);
        public static Color Purple() => new Color(128, 0, 128);

        private int r;
        private int g;
        private int b;

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color() : this(0, 0, 0)
        {

        }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void DisplayRGB()
        {
            Console.WriteLine($"Red: {R}, Green: {G}, Blue: {B}");
        }
    }
    #endregion

    #region Point Class
    public class Point // challenge on page 191
    {
        private static List<Point> points = new List<Point>();
        public static void ShowPoints()
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine($"{(points[i].X, points[i].Y)}");
            }
        }

        private int x;
        private int y;

        public int X { get; set; }
        public int Y { get; set; }

        public Point() : this(0, 0)
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            points.Add(this);
        }
    }
    #endregion

    #region Arrows Class
    public class Arrows // challenge on page 154, 164, 168 and 173
    {
        #region Class Statics
        private readonly static List<Arrows> soldArrow = new List<Arrows>();
        public static Arrows CreateEliteArrow() => new Arrows("Steel", 95, "Plastic");
        public static Arrows CreateBeginnerArrow() => new Arrows("Wood", 75, "Goose");
        public static Arrows CreateMarksmanArrow() => new Arrows("Obsidian", 65, "Turkey");

        public static void SoldArrowLedger()
        {
            for (int i = 0; i < soldArrow.Count; i++)
            {
                Console.WriteLine($"Head: {soldArrow[i].Head}, Fletching: {soldArrow[i].Fletching}, Length: {soldArrow[i].ShaftLength}, Cost: {soldArrow[i].Cost}");
            }
        }
        #endregion

        #region Instance Fields
        private string head;
        private string fletching;
        private float shaftLength;
        #endregion

        #region Properties
        public string Head // began working on properties for better getters and setters vs creating your own class methods
        {
            get { return head; }
            set { head = value.ToUpper(); }
        }

        public string Fletching
        {
            get { return fletching; }
            set { fletching = value.ToUpper(); }
        }

        public float ShaftLength
        {
            get { return shaftLength; }
            set { shaftLength = Math.Clamp(value, 60.0f, 100.0f); }
        }

        public float Cost
        {
            get
            {
                float headCost;
                float fletchingCost;
                float lengthCost;

                headCost = Head switch
                {
                    "STEEL" => 10.0f,
                    "WOOD" => 3.0f,
                    "OBSIDIAN" => 5.0f,
                    _ => throw new Exception($"Invalid selection: {Head}, Choose [Steel, Wood, Obsidian]")
                };

                fletchingCost = Fletching switch
                {
                    "PLASTIC" => 10.0f,
                    "TURKEY" => 5.0f,
                    "GOOSE" => 3.0f,
                    _ => throw new Exception($"Invalid selection: {Fletching}, Choose [Plastic, Turkey, Goose]")
                };

                lengthCost = 0.05f * ShaftLength;

                return headCost + fletchingCost + lengthCost;
            }
        }
        #endregion

        #region Constructors
        public Arrows() : this("STEEL", 60, "PLASTIC")
        {
            
        }

        public Arrows(string head, float shaftLength, string fletching)
        {
            Head = head;
            Fletching = fletching;
            ShaftLength = shaftLength;
            soldArrow.Add(this);
        }
        #endregion
    }
    #endregion

    #region Score Class
    public class Score
    {
        public string name;
        public int points;
        public int level;

        public Score()
        {
            // no parameters to allow for Instance creations without any arguments
        }

        public Score(string name, int points, int level)
        {
            this.name = name;
            this.points = points;
            this.level = level;
        }

        public bool EarnedStar() => (points / level) >= 1000;
    }
    #endregion

    #region Battler Class
    public class Battler // used for HuntingTheManticore() and challenge on page 124
    {
        private string _name;
        private int _health;
        private int _distance;
        private int _start;
        private int _end;
        private int _attack = 1;

        public Battler(string name, int health)
        {
            _name = name;
            _health = health;
            _start = 1;
            _end = 2;
            _distance = ChooseRange(_start, _end);
        }

        public Battler(string name, int health, int start, int end)
        {
            _name = name;
            _health = health;
            _start = start;
            _end = end;
            _distance = ChooseRange(start, end);
        }

        public string GetName() => _name;
        public int GetHealth() => _health;
        public int GetDistance() => _distance;
        public int GetAttack() => _attack;
        public void Hurt(int damage) => _health -= damage;

        public int ChooseRange(int start, int end)
        {
            while (true)
            {
                Console.Write($"{GetName()} choose a distance [{start} - {end}]: ");
                _distance = int.Parse(Console.ReadLine());

                if (_distance < start || _distance > end)
                {
                    Console.WriteLine($"Thats not within {start} - {end} range, choose again: ");
                }
                else
                {
                    break;
                }
            }
            return _distance;
        }

        public int FindTarget(Battler name)
        {
            _attack++;

            Console.WriteLine("-------------------------------------------------");
            void ExpectedDamage()
            {
                Console.WriteLine($"The cannon is expected to deal {DefenderCannonBallDamage()} this round.");
            }

            if (_distance == name.GetDistance())
            {
                ExpectedDamage();
                Console.WriteLine($"That round was a DIRECT HIT!");
                name.Hurt(DefenderCannonBallDamage());
                Hurt(1);
            }
            else if (_distance < name.GetDistance())
            {
                ExpectedDamage();
                Console.WriteLine($"That round FELL SHORT of {name.GetName()}");
                ChooseRange(_start, _end);
                Hurt(1);
            }
            else
            {
                ExpectedDamage();
                Console.WriteLine($"That round OVERSHOT {name.GetName()}");
                ChooseRange(_start, _end);
                Hurt(1);
            }

            return _attack;
        }

        public int DefenderCannonBallDamage()
        {

            bool electricBall = _attack % 5 == 0;
            bool fireball = _attack % 3 == 0;

            if (electricBall && fireball)
            {
                return 8;
            }
            else if (electricBall)
            {
                return 5;
            }
            else if (fireball)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
    }
    #endregion

    #region General Enums
    

    enum ChestStates // challenge on page 135 SimulaChest()
    {
        Open,
        Closed,
        Locked,
        Unlocked
    }
    #endregion
}