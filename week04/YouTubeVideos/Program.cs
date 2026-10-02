using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Cook Pasta", "ChefMario", 320);
        video1.AddComment(new Comment("Alice", "Great recipe, very easy!"));
        video1.AddComment(new Comment("Bob", "I tried it and loved it."));
        video1.AddComment(new Comment("Carlos", "Best pasta tutorial ever."));
        videos.Add(video1);

        Video video2 = new Video("Learn C# in 10 Minutes", "CodeWithMe", 600);
        video2.AddComment(new Comment("Diana", "Very clear explanation!"));
        video2.AddComment(new Comment("Eric", "This helped me so much."));
        video2.AddComment(new Comment("Fiona", "Please make more videos!"));
        video2.AddComment(new Comment("George", "Subscribed immediately."));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Travel Destinations", "WanderWorld", 480);
        video3.AddComment(new Comment("Hannah", "I want to visit all of them!"));
        video3.AddComment(new Comment("Ivan", "Great cinematography."));
        video3.AddComment(new Comment("Julia", "Number 3 is my favorite."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}