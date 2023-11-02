using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Pleas introduce your grade for the course: ");
        if (double.TryParse(Console.ReadLine(), out double score))
        {
            string grade = Grade(score);
            Console.WriteLine($"Your letter grade for the course is: {grade}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric score.");
        }
    }

    static string Grade(double score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else if (score >= 80)
        {
            return "B";
        }
        else if (score >= 70)
        {
            return "C";
        }
        else if (score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}