using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please introduce your grade for the course: ");
        string grade = Console.ReadLine();
        int score = int.Parse(grade);

        string letter = "";

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (score >= 70)
        {
            Console.WriteLine("Congratulations! Keep up the hard work.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You can do better next time!");
        }
    }
}