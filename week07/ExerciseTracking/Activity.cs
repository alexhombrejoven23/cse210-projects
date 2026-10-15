using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        CultureInfo culture = CultureInfo.InvariantCulture;

        string dateText = _date.ToString("dd MMM yyyy", culture);
        string name = GetType().Name;
        string distance = GetDistance().ToString("0.0", culture);
        string speed = GetSpeed().ToString("0.0", culture);
        string pace = GetPace().ToString("0.0", culture);

        return $"{dateText} {name} ({_minutes} min) - Distance {distance} miles, Speed {speed} mph, Pace: {pace} min per mile";
    }
}