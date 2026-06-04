class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Cook Pasta", "ChefMario", 320);
        v1.AddComment(new Comment("Alice", "Great recipe, very easy!"));
        v1.AddComment(new Comment("Bob", "I tried it and loved it."));
        v1.AddComment(new Comment("Carlos", "Best pasta tutorial ever."));
        videos.Add(v1);

        Video v2 = new Video("Learn C# in 10 Minutes", "CodeWithMe", 600);
        v2.AddComment(new Comment("Diana", "Very clear explanation!"));
        v2.AddComment(new Comment("Eric", "This helped me so much."));
        v2.AddComment(new Comment("Fiona", "Please make more videos!"));
        v2.AddComment(new Comment("George", "Subscribed immediately."));
        videos.Add(v2);

        Video v3 = new Video("Top 10 Travel Destinations", "WanderWorld", 480);
        v3.AddComment(new Comment("Hannah", "I want to visit all of them!"));
        v3.AddComment(new Comment("Ivan", "Great cinematography."));
        v3.AddComment(new Comment("Julia", "Number 3 is my favorite."));
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title:    {video.GetTitle()}");
            Console.WriteLine($"Author:   {video.GetAuthor()}");
            Console.WriteLine($"Length:   {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine();
        }
    }
}