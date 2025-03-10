using System;

namespace Classes
{
    public class Triangle
    {
        private float triangleBase;
        private float triangleHeight;

        // Properties
        public float TriangleBase
        {
            get { return triangleBase; } // read
            set { triangleBase = value; } // set
        }

        public float TriangleHeight
        {
            get { return triangleHeight; }
            set
            {
                if (value > 5000)
                {
                    triangleHeight = 5000;
                    Console.WriteLine("Height can not be greater than 5000, Height was set to 5000");
                }
                else
                {
                    triangleHeight = value;
                }
            } // we can use logic here for the setting
        }

        public Triangle(float triangleBase, float triangleHeight)
        {
            TriangleBase = triangleBase;
            TriangleHeight = triangleHeight;
        }

        public void PrintTriangleInfo()
        {
            Console.WriteLine($"Base: {triangleBase}, Height: {triangleHeight}");
        }
    }
}

