using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Video Analysis Program");
        Console.WriteLine("===============================\n");

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Easy Cooking: Alfredo Pasta", "Chef Maria", 420);
        video1.AddComment(new Comment("Carlos Lopez", "Excellent recipe! I made it last night and it was delicious."));
        video1.AddComment(new Comment("Ana Torres", "I love how you explain each step, very clear."));
        video1.AddComment(new Comment("Pedro Martinez", "Can I substitute the cream with something lighter?"));
        video1.AddComment(new Comment("Laura Sanchez", "I'll try it this weekend, thanks for sharing."));
        videos.Add(video1);

        Video video2 = new Video("Home Workout Routine", "FitLife Channel", 600);
        video2.AddComment(new Comment("Miguel Angel", "Great routine, I feel more active after one week."));
        video2.AddComment(new Comment("Sofia Ruiz", "Perfect for those of us who don't have time to go to the gym."));
        video2.AddComment(new Comment("David Perez", "The 8:30 minute is my favorite, what a burn!"));
        videos.Add(video2);

        Video video3 = new Video("Python Tutorial: Introduction", "CodeMaster Pro", 900);
        video3.AddComment(new Comment("Alejandro Garcia", "Exactly what I needed to start, thank you very much."));
        video3.AddComment(new Comment("Elena Vargas", "Will there be a part two? I want to learn more."));
        video3.AddComment(new Comment("Roberto Diaz", "Clear and concise explanation, perfect for beginners."));
        video3.AddComment(new Comment("Carmen Jimenez", "The practical examples are very helpful, thank you."));
        videos.Add(video3);

        Video video4 = new Video("Review: Latest Smartphone on Market", "TechReviewer", 480);
        video4.AddComment(new Comment("Javier Romero", "Very comprehensive analysis, helped me decide on my purchase."));
        video4.AddComment(new Comment("Patricia Gomez", "I'd like you to compare it with the previous model."));
        video4.AddComment(new Comment("Fernando Cruz", "The battery life is impressive, just as you mentioned."));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds ({video.Length / 60} minutes)");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("\nComments:");
            Console.WriteLine("------------");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("======================================");
        Console.WriteLine("Analysis completed. Total videos processed: " + videos.Count);
    }
}

public class Comment
{

    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{

    public string Title { get; }
    public string Author { get; }
    public int Length { get; }

    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}