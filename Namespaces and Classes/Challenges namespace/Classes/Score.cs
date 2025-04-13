namespace Challenges
{
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
}