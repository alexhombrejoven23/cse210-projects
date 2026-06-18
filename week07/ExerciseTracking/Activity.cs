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

    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        CultureInfo us = CultureInfo.GetCultureInfo("en-US");
        return string.Format(us,
            "{0:dd MMM yyyy} {1} ({2} min) - Distance: {3:F1} miles, Speed: {4:F1} mph, Pace: {5:F2} min per mile",
            _date, GetType().Name, _minutes, GetDistance(), GetSpeed(), GetPace());
    }
}