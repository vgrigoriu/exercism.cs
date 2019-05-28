using System;
using System.Collections.Generic;

public class SpaceAge
{
    private const double secondsInEarthYear = 365.25 * 24 * 60 * 60;

    private static readonly Dictionary<string, double> factor = new Dictionary<string, double>
    {
        {"Mercury", 0.2408467},
        {"Venus", 0.61519726},
        {"Mars", 1.8808158},
        {"Jupiter", 11.862615},
        {"Saturn", 29.447498},
        {"Uranus", 84.016846},
        {"Neptune", 164.79132},
    };

    private readonly int seconds;

    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    public double OnEarth()
    {
        return seconds / secondsInEarthYear;
    }

    public double OnMercury()
    {
        return OnEarth() / factor["Mercury"];
    }

    public double OnVenus()
    {
        return OnEarth() / factor["Venus"];
    }

    public double OnMars()
    {
        return OnEarth() / factor["Mars"];
    }

    public double OnJupiter()
    {
        return OnEarth() / factor["Jupiter"];
    }

    public double OnSaturn()
    {
        return OnEarth() / factor["Saturn"];
    }

    public double OnUranus()
    {
        return OnEarth() / factor["Uranus"];
    }

    public double OnNeptune()
    {
        return OnEarth() / factor["Neptune"];
    }
}