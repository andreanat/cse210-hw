using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("welcome to your favorite Mindfulness Program");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        RunActivity(new BreathingActivity());
                        break;
                    case 2:
                        RunActivity(new ListingActivity());
                        break;
                    case 3:
                        RunActivity(new ReflectingActivity());
                        break;
                    case 4:
                        Console.WriteLine("Exiting program. Goodbye! See you later.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void RunActivity(Activity activity)
    {
        activity.DisplayStartingMessage();
        activity.Run();
        activity.DisplayEndingMessage();
    }
}