public abstract class Goal
{
    public abstract void RecordEvent();
    public abstract int GetPoints();
}

public class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override int GetPoints()
    {
        return _points;
    }
}

public class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        // Never completes, always gives points
    }

    public override int GetPoints()
    {
        return _points;
    }
}