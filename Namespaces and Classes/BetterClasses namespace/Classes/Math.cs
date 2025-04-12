using System;
using System.Collections.Generic;
using System.Numerics;

namespace BetterClasses
{
    public class MyAverage
    {
        public T Average<T>(params T[] numbers) where T : INumber<T>
        {
            if (numbers == null || numbers.Length <= 0)
            {
                throw new ArgumentException("Numbers Array can not be Null or have Less than 1 Item");
            }

            T sum = T.Zero;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum / T.CreateChecked(numbers.Length);
        }
    }
}
