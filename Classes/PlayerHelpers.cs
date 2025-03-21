using System;
using System.Collections.Generic;

namespace PlayerHelpers
{
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
    enum SpiceType
    {
        Spicy,
        Salty,
        Sweet
    }
    enum IngredientType
    {
        Mushroom,
        Chicken,
        Carrot,
        Potatoe
    }

    enum FoodType
    {
        Soup,
        Stew,
        Gumbo
    }

    enum ChestStates // challenge on page 135 SimulaChest()
    {
        Open,
        Closed,
        Locked,
        Unlocked
    }
    #endregion
}