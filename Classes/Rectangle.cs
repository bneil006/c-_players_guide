using System;

namespace Classes
{
	public class Rectangle
	{
		private float side;
		private float top;

		public float Side
		{
			get { return side; }
			set { side = value; }
		}

		public float Top
		{
			get { return top; }
			set { top = value; }
		}

		public Rectangle(float side, float top)
		{
			Side = side;
			Top = top;
		}

		public void PrintRectangleInfo()
		{
			Console.WriteLine($"SIDE: {side}, TOP: {top}");
		}
	}
}
