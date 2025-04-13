namespace Challenges
{
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


}