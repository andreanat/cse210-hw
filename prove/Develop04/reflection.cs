using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times ...", 50)
    {
        _prompts = new List<string>();
        _questions = new List<string>();
        InitializePrompts();
        InitializeQuestions();
    }

    private void InitializePrompts()
    {
        _prompts.Add("Prompt 1");
        _prompts.Add("Prompt 2");
        // Add more prompts
    }

    private void InitializeQuestions()
    {
        _questions.Add("Question 1");
        _questions.Add("Question 2");
        // Add more questions
    }

    public override void Run()
    {
        Console.WriteLine("Reflect on the following prompts:");
        foreach (var prompt in _prompts)
        {
            Console.WriteLine(prompt);
            ShowCountDown(2); 
        }

        Console.WriteLine("Now, consider the following questions:");
        foreach (var question in _questions)
        {
            Console.WriteLine(question);
            ShowCountDown(2); 
        }
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[new Random().Next(_questions.Count)];
    }
}
