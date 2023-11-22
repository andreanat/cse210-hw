using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("Matthew", 7, 7, 8);
        Scripture scripture = new Scripture(reference, "Ask, and it shall be given you; seek, and ye shall find; knock, and it shall be opened unto you: For every one that asketh receiveth; and he that seeketh findeth; and to him that knocketh it shall be opened.");

        while (true)
        {
            scripture.ClearConsole();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine($"Reference: {scripture.GetReferenceDisplayText()}");

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}

class Scripture
{
    private Reference _reference { get; }
    private List<Word> _words { get; }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = SplitTextIntoWords(text);
    }

    private List<Word> SplitTextIntoWords(string text)
    {
        return text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(word => new Word(word))
                   .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        Console.WriteLine("Scripture text:");
        string displayText = "";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden);
    }

    public string GetReferenceDisplayText()
    {
        return _reference.GetDisplayText();
    }

    public void ClearConsole()
    {
        Console.Clear();
    }
}

class Reference
{
    private string _book { get; }
    private int _chapter { get; }
    private int _verse { get; }
    private int _endVerse { get; }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

class Word
{
    private string _text { get; }
    private bool _isHidden { get; set; }

    public Word(string text)
    {
        _text = text;
        _isHidden = false;  
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}