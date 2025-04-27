namespace TwoSum;
/*
This login problem is known as the "Two Sum" problem.
The function takes an array of integers and a target sum as input, and then returns a boolean indicating whether or not
there are two distinct numbers in the array that add up to the target sum.
*/
public class TwoSumExists
{
    public static bool IsTwoSum(int[] numbers, int targetSum)
    {

        if (numbers == null || numbers.Length < 2) // Can't make a sum out of less than 2 numbers no matter what, and also handles the null case.
        {
            return false;
        }

        // Using a dictionary as it is the C# equivalent of a hash table. This allows for a faster lookup time (usually O(1))
        // The dictionary also allows us to solve the problem in a single pass through the array.
        Dictionary<int, int> numberMap = new Dictionary<int, int>();

        /* Loop through the array of numbers and subtract the current number from the target sum. This is our new target, and what we are looking for.
        a + b = c, so if we subtract a from c, we get b. If b is in the array, then we have our two numbers a + b = c.
        This won't find the answer on the first pass of one of the numbers between a and b due to the fact that we are checking the dictionary for the target, 
        but it allows us to maintain our one pass approach and is still quite quick (O(n) in the worst case).
        */
        for (int i = 0; i < numbers.Length; i++)
        {
            int newTarget = targetSum - numbers[i];
            if (numberMap.ContainsKey(newTarget)) // Check if the new target is in the dictionary. If it's found, then we have our answer.
            {
                return true;
            }
            numberMap[numbers[i]] = i; // This adds the current number to the dictionary so we can check if the hash table contains it later.
        }

        return false; // If we finish the loop and don't find anything, then return false.

    }

    // Main method if you want to personally run the code and manually test it.
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the array of numbers separated by spaces:");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty. Please try again.");
            return;
        }
        int[] numbers = Array.ConvertAll(input.Split(' '), int.Parse);

        Console.WriteLine("Please enter the target sum:");
        string? targetSumInput = Console.ReadLine();
        if (string.IsNullOrEmpty(targetSumInput) || !int.TryParse(targetSumInput, out int targetSum))
        {
            Console.WriteLine("Target sum cannot be empty or must be a valid integer. Please try again.");
            return;
        }

        bool result = IsTwoSum(numbers, targetSum);

        if (result)
        {
            Console.WriteLine("There are two numbers in the array that add up to the target sum.");
        }
        else
        {
            Console.WriteLine("No two numbers in the array add up to the target sum.");
        }
    }
}