using System;

namespace Classes
{
    public class Triangle
    {
        private float _base;
        private float _height;

        public Triangle(float baseLength, float height)
        {
            _base = baseLength;
            _height = height;
        }

        public void PrintTriangleInfo() // Ensure this is public
        {
            Console.WriteLine($"Base: {_base}, Height: {_height}");
        }

        public float TriangleArea()
        {
            return (_base * _height) / 2;
        }
    }
}
