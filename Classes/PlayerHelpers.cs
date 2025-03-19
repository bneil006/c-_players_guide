using System;
using System.Collections.Generic;

namespace PlayerHelpers
{
    public class Arrows // challenge on page 154
    {
        public string head;
        public float shaftLength;
        public string fletching;

        private ArrowHeadType headType;
        private FletchingType fletchingType;

        public Arrows() : this("STEEL", 60, "PLASTIC")
        {
            AskUserToChoose();
            Logic();
        }

        public Arrows(string head, float shaftLength, string fletching)
        {
            this.head = head;
            this.shaftLength = shaftLength;
            this.fletching = fletching;

            Logic();
        }

        private void AskUserToChoose()
        {
            Console.WriteLine("ITEMS");
            Console.WriteLine("---------------------");
            Console.WriteLine($"ARROW HEAD TYPES: Steel (10 gold), Wood (3 gold), Obsidian (5 gold)");
            Console.WriteLine($"FLETCHING TYPES: Plastic (10 gold), Turkey (5 gold), Goose (3 gold)");
            Console.WriteLine($"SHAFT SIZES BETWEEN 60 - 100");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Console.Write("CHOOSE ARROW HEAD: ");
            head = Console.ReadLine();

            Console.Write("CHOOSE FLETCHING: ");
            fletching = Console.ReadLine();

            Console.Write("CHOOSE LENGTH: ");
            shaftLength = float.Parse(Console.ReadLine());
        }

        private void Logic()
        {
            head = head.ToUpper();
            fletching = fletching.ToUpper();

            if (shaftLength < 60.0f)
            {
                shaftLength = 60.0f;
            }
            else if (shaftLength > 100.0f)
            {
                shaftLength = 100.0f;
            }

            switch (head)
            {
                case "STEEL":
                    headType = ArrowHeadType.Steel;
                    break;
                case "WOOD":
                    headType = ArrowHeadType.Wood;
                    break;
                case "OBSIDIAN":
                    headType = ArrowHeadType.Obsidian;
                    break;
                default:
                    throw new Exception($"Didn't choose arrow head [Steel, Wood, Obsidian]");
            }

            fletchingType = fletching switch
            {
                "PLASTIC" => FletchingType.Plastic,
                "TURKEY" => FletchingType.Turkey,
                "GOOSE" => FletchingType.Goose,
                _ => throw new Exception($"Didn't choose fletching [Plastic, Turkey, Goose]")
            };
        }

        public float GetCost()
        {
            float headCost;
            float fletchingCost;
            float lengthCost;

            headCost = headType.ToString() switch
            {
                "Steel" => 10.0f,
                "Wood" => 3.0f,
                "Obsidian" => 5.0f
            };

            fletchingCost = fletchingType.ToString() switch
            {
                "Plastic" => 10.0f,
                "Turkey" => 5.0f,
                "Goose" => 3.0f
            };

            lengthCost = 0.05f * shaftLength;
            return headCost + fletchingCost + lengthCost;
        }

        public void GetHeadType()
        {
            Console.WriteLine($"HEAD CHOOSEN: {headType}");
        }

        public void GetFletchingType ()
        {
            Console.WriteLine($"FLETCHING CHOOSEN: {fletchingType}");
        }

        enum ArrowHeadType
        {
            Steel,
            Wood,
            Obsidian
        }

        enum FletchingType
        {
            Plastic,
            Turkey,
            Goose
        }

    }

    

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
}
