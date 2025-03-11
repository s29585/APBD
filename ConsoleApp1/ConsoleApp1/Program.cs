using ConsoleApp1;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        double average = Calculations.CalculateAverage(numbers);
        Console.WriteLine($"Średnia z liczb ({string.Join(", ", numbers)}) to: {average}");
        
        int max = Calculations.FindMaxValue(numbers);
        Console.WriteLine($"Maksymalna wartość: {max}");
    }
}