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
    }
}
    