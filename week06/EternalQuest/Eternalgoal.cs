// An Eternal Goal never finishes — you just keep doing it forever.
// Every time you log it, you earn points. That's all.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }
    // Always gives points
    public override int RecordEvent()
    {
        return _points;
    }
    // This goal never ends
    public override bool IsComplete()
    {
        return false;
    }
    // Format: EternalGoal:name,description,points
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}