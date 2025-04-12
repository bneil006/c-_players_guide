namespace Challenges
{
    public static class ReplicatorOfDto
    {
        public static void Run() // challenge on page 94
        {
            Console.WriteLine("This program just lists out the elements in the array, after you provide 5 numbers.");
            int[] numberArray = new int[5];

            int count = 0;
            while (count < 5)
            {
                Console.Write($"Provide a number: ");
                int response = int.Parse(Console.ReadLine());
                numberArray[count] = response;
                count++;
            }

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {numberArray[i]}");
            }
        }

    }
}
