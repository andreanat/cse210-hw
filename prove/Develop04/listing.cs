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
        _prompts.Add("Prompt 1");
        _prompts.Add("Prompt 2");
        // Add more prompts
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
