using System;

class Program
{
    static void Main()
    {
        // Create an event of each type
        var lecture = new Lecture("Tech Talk", "Latest in AI", DateTime.Now, DateTime.Now.AddHours(2), new Address(), "John Doe", 50);
        var reception = new Reception("Networking Event", "Connect with professionals", DateTime.Now, DateTime.Now.AddHours(3), new Address(), "rsvp@example.com");
        var outdoorGathering = new OutdoorGathering("Summer Picnic", "Enjoy outdoor activities", DateTime.Now, DateTime.Now.AddHours(4), new Address(), "Sunny with a slight breeze");

        // Display marketing messages
        Console.WriteLine("Lecture Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\n\nReception Details:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\n\nOutdoor Gathering Details:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}