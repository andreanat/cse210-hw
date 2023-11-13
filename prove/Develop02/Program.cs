using System;
using System.Collections.Generic; //I added this line bc I couldnt make the program work

public class JournalEntry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public JournalEntry(string promptText, string entryText)
    {
        Date = DateTime.Now.ToShortDateString();
        PromptText = promptText;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"{Date} - {PromptText}: {EntryText}");
    }
}

public class Journal
{
    private List<JournalEntry> _entries;

    public Journal()
    {
        _entries = new List<JournalEntry>(); 
    }

    public void AddEntry(JournalEntry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (var writer = new System.IO.StreamWriter(file))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"{entry.Date},{entry.PromptText},{entry.EntryText}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine($"Error writing to the file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                if (parts.Length == 3)
                {
                    AddEntry(new JournalEntry(parts[1], parts[2]) { Date = parts[0] });
                }
                else
                {
                    Console.WriteLine($"Invalid entry format in the file: {line}");
                }
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        catch (System.IO.IOException ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
        }
    }
}

public class MenuManager
{
    private Journal _journal;
    private PromptGenerator _promptGenerator;

    public MenuManager()
    {
        _journal = new Journal();
        _promptGenerator = new PromptGenerator();
    }

    public void RunMenu()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;

                case "2":
                    DisplayJournal();
                    break;

                case "3":
                    SaveJournal();
                    break;

                case "4":
                    LoadJournal();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    private void WriteNewEntry()
    {
        string randomPrompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");

        Console.Write("Enter your entry: ");
        string entryText = Console.ReadLine();

        _journal.AddEntry(new JournalEntry(randomPrompt, entryText));
    }

    private void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        _journal.DisplayAll();
    }

    private void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string saveFileName = Console.ReadLine();
        _journal.SaveToFile(saveFileName);
    }

    private void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string loadFileName = Console.ReadLine();
        _journal.LoadFromFile(loadFileName);
    }
}

public class PromptGenerator
{
    private string[] _prompts;

    public PromptGenerator()
    {
        _prompts = new string[]
        {
            "How am I feeling today?", 
            "How does my body feel today?",
            "What are my top priorities for the day?",
            "What’s something I can do to make today amazing?",
            "What did I learn today? How can I apply this knowledge in the future?",
            "What can I learn from today?",
            "What did I do today that brought me joy or fulfillment?",
            "What was a moment of joy, delight, or contentment today?",
            "What was a small detail I noticed today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        return _prompts[index];
    }
}

class Program
{
    static void Main()
    {
        MenuManager menuManager = new MenuManager();
        menuManager.RunMenu();
    }
}