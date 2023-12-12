using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        videos.Add(CreateVideo("Introduction to Magic Spells", "Professor Dumbledore", 300,
                               new List<Comment>
                               {
                                   new Comment("Harry", "Lumos and Nox are the first spells I learned at Hogwarts."),
                                   new Comment("Hermione", "This tutorial is great for beginners!"),
                                   new Comment("Ron", "Wingardium Leviosa is a classic spell!"),
                                   new Comment("Ginny", "I can't wait to see more magical videos!")
                               }));

        videos.Add(CreateVideo("Defense Against the Dark Arts", "Professor Lupin", 450,
                               new List<Comment>
                               {
                                   new Comment("Luna", "Nargles beware!"),
                                   new Comment("Neville", "This will be useful against the dark creatures in the Forbidden Forest."),
                                   new Comment("Fred", "Expecto Patronum is my favorite spell!"),
                                   new Comment("George", "Can we have a video on magical pranks?")
                               }));

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); 
        }
    }

    static Video CreateVideo(string title, string author, int length, List<Comment> comments)
    {
        var video = new Video(title, author, length);
        video.Comments.AddRange(comments);
        return video;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string name, string text)
    {
        Comments.Add(new Comment(name, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
