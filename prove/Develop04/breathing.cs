using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 5)
    {
        
    }

    public override void Run()
    {
        for (int seconds = 0; seconds < _duration; seconds++)
        {
            if (seconds % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");

            ShowCountDown(3); 
        }
    }
}
