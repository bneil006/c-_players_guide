namespace Challenges
{
    public static class LawsOfFreach
    {
        /// <summary>
        /// Provide numbers and this method will output the string of the Minimum value and the Average of all numbers.
        /// </summary>
        /// <param name="arrayOfNumbers"></param>
        public static void MinAndAverage(params int[] arrayOfNumbers) // challenge on page 95
        {
            int minNumber = int.MaxValue;
            int total = 0;
            foreach (int number in arrayOfNumbers)
            {
                total += number;
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            int average = total / arrayOfNumbers.Length;
            Console.WriteLine($"Min Number: {minNumber}, Average: {average}");
        }
    }
}
