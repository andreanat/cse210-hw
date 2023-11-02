using System;

class Program
{
    static void Main(string[] args)
    {
           List<int> numbers = new List<int>();
        int input;

        do
        {
            Console.Write("Enter a number (0 to quit): ");
            if (int.TryParse(Console.ReadLine(), out input))
            {
                numbers.Add(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (input != 0);

        Console.WriteLine("Numbers entered:");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
//sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum of the numbers is: {sum}");
//average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");
//max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
}
}