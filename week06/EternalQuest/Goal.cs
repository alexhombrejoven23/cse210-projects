public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Each goal type handles recording differently
    public abstract int RecordEvent();

    // Each goal type decides when it's finished
    public abstract bool IsComplete();

    // Each goal type knows how to save itself
    public abstract string GetStringRepresentation();
    
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public string ShortName => _shortName;
}