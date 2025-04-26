namespace TwoSum;

public class TwoSumExists
{
    public static bool IsTwoSum(int[] numbers, int targetSum)
    {

        if (numbers == null || numbers.Length < 2) // Can't make a sum out of less than 2 numbers no matter what
        {
            return false;
        }

        Dictionary<int, int> numberMap = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            int newTarget = targetSum - numbers[i];
            if (numberMap.ContainsKey(newTarget))
            {
                return true;
            }
            numberMap[numbers[i]] = i;
        }

        return false;

    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter the array of numbers separated by spaces:");
        string input = Console.ReadLine();
        int[] numbers = Array.ConvertAll(input.Split(' '), int.Parse);

        Console.WriteLine("Please enter the target sum:");
        int targetSum = int.Parse(Console.ReadLine());

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