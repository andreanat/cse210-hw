using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I've selected a random number between 1 and 100. Try to guess it!");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse (Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Try guessing higher.");

            }
            else if (magicNumber < guess)
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