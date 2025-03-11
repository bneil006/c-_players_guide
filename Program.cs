using System;

int[] myIntArray = { 1, 2, 3 };
float[] myFloatArray = { 1.0f, 2.0f, 3.0f };
string[] myStringArray = { "apple", "banana", "cherry" };

/*
 * using Generics, if we didn't use this we would have to make 3 methods / functions
 * to loop over the items in the arrays, but by using Generics Method<T>(T[] parameter)
 * we could name T to anything honestly, Bro Code uses Thing ex.,
 * static void DisplayElements<Thing>(Thing[] arrayVariable)
 * 
 * This also changes our usage in the method such as in a foreach loop ex.,
 * foreach (T variable in arrayVariable) --- Bro Code uses
 * foreach (Thing variable in arrayVariable) for example.
 * 
 * T here stands for Type
*/
static void DisplayElements<T>(T[] array)
{
    foreach (T item in array)
    {
        Console.WriteLine($"ITEM: {item}");
    }
    Console.WriteLine(); // to add blank space between other functions
}

DisplayElements(myIntArray);
DisplayElements(myFloatArray);
DisplayElements(myStringArray);

Console.ReadLine();