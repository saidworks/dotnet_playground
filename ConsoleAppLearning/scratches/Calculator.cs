namespace ConsoleAppLearning;

public class Calculator
{
    // Method to calculate the average of an array
    public static double CalculateAverage(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            Console.WriteLine("Array is empty");
            return 0;
        }
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum / numbers.Length;
    }



}