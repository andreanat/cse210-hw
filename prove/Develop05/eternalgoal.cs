public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return true;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points}";
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} - {_points} points (Eternal)";
    }
}
