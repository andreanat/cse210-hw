using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public virtual void Run()
    {
        Console.WriteLine("Base activity running...");
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"Please enter the duration in seconds for the {_name} activity:");
        if (int.TryParse(Console.ReadLine(), out _duration))
        {
            Console.WriteLine("Get ready to begin!");
            ShowSpinner(3);
        }
        else
        {
            Console.WriteLine("Invalid input. Using default duration.");
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You've completed the {_name} activity for {_duration} seconds.");
        Console.WriteLine("Well done!");
        ShowSpinner(3); 
        Console.WriteLine($"Ending {_name} activity...");
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < futureTime)
        {
            Console.Write("+");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("-");
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        Console.WriteLine($"Countdown: {seconds} seconds...");
        while (DateTime.Now < futureTime)
        {
            Console.Write($"{futureTime.Subtract(DateTime.Now).Seconds} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
