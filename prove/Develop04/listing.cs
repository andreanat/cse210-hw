using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "Guide the user to think broadly...", 10)
    {
        _count = 5; 
        _prompts = new List<string>();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public override void Run()
    {
        for (int i = 1; i <= _count; i++)
        {
            Console.WriteLine($"Item {i}: {GetRandomPrompt()}");
            ShowCountDown(2); 
        }
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }
}
