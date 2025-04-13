namespace Challenges
{
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


}