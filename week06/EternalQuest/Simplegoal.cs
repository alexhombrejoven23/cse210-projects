// A Simple Goal is completed once and never again.
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }

        // Already done
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Format:: SimpleGoal:name,description,points,isComplete
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}