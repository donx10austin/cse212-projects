// These classes map the JSON keys to C# properties
public class EarthquakeResponse
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Property properties { get; set; }
}

public class Property
{
    public double mag { get; set; }
    public string place { get; set; }
}