namespace Challenges
{
    public static class ManticoreGame
    {
        public static void RunGame(Battler manticore, Battler city) // challenge on page 124
        {
            Console.Clear();

            int cityStartingHealth = city.GetHealth();
            int manticoreStartingHealth = manticore.GetHealth();

            while (manticore.GetHealth() > 0 && city.GetHealth() > 0)
            {
                Console.WriteLine("-------------------------------------------------");
                Status(city.GetAttack(), manticore, city);
                city.FindTarget(manticore);
            }

            void Status(int round, Battler manticore, Battler city)
            {
                Console.WriteLine($"STATUS: Round: {city.GetAttack()} City: {city.GetHealth()}/{cityStartingHealth} Manticore: {manticore.GetHealth()}/{manticoreStartingHealth}");
            }

            if (manticore.GetHealth() <= 0)
            {
                Console.WriteLine($"The {manticore.GetName()} has been destoryed! The city of Consolas has been saved!");
            }
            else
            {
                Console.WriteLine($"The {city.GetName()} has been destoryed!");
            }
        }
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
            _end = 50;
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
