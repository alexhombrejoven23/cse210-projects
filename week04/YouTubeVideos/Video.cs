public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment) => _comments.Add(comment);

    public int GetNumberOfComments() => _comments.Count;

    public string GetTitle() => _title;
    public string GetAuthor() => _author;
    public int GetLength() => _lengthSeconds;
    public List<Comment> GetComments() => _comments;
}