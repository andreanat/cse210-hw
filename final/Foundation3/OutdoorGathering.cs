public class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, DateTime time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {weatherStatement}";
    }
}
