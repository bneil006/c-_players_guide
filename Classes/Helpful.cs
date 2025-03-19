using System;
using System.Collections.Generic;

namespace Helpful
{
    class Helper
    {
        public static void Print<T>(T message)
        {
            Console.WriteLine(message);
        }

        public static T ReturnGeneric<T>(T message) // not sure if theres even a point to this method yet, might remove
        {
            return message;
        }

        public static void PrintTypeOf<T>(T message)
        {
            Console.WriteLine(message.GetType());
        }

        public static void EqualTypes<T1, T2>(T1 expected, T2 actual)
        {
            bool equal = false;
            if (expected.GetType() == actual.GetType())
            {
                equal = true;
            }
            Console.WriteLine(equal);
        }

    }
}
