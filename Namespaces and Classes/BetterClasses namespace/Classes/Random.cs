using System;
using System.Collections.Generic;

namespace BetterClasses
{
    public class MyTesting
    {
        public void DisplayNumber(ref int number)
        {
            Console.WriteLine(number);
        }

        public void AddToNumber(ref int number, int toAdd)
        {
            number += toAdd;
            Console.WriteLine(number);
        }
    }
}
