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
    
            if (Message(letter))
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Keep working hard. You can do better next time!");
            }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric score.");
        }
    }

    static string CalculateGrade(double score)
    {
        string letter;

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

        return letter;
    }
}