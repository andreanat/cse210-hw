public class SimpleGoal : Goal
{
    public bool _isComplete;

    public SimpleGoal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points},{_isComplete}";
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} - {_points} points";
    }
}
