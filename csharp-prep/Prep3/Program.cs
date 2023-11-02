using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = -1;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I've selected a random number between 1 and 100. Try to guess it!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();

            if (guess < magicNumber)
            {
                Console.WriteLine("Try guessing higher.");

            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Try guessing lower.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number: " + magicNumber);
            }
        }

    }
}