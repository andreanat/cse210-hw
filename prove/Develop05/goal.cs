public abstract class Goal
{
    public string _shortName;
    public string _description;
    public int _points;

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
