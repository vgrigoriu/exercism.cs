using System;
using System.Collections.Generic;

public class SpaceAge
{
    private const double secondsInEarthYear = 365.25 * 24 * 60 * 60;

    private static readonly Dictionary<Planet, double> factor = new Dictionary<Planet, double>
    {
        {Planet.Mercury, 0.2408467},
        {Planet.Venus, 0.61519726},
        {Planet.Mars, 1.8808158},
        {Planet.Jupiter, 11.862615},
        {Planet.Saturn, 29.447498},
        {Planet.Uranus, 84.016846},
        {Planet.Neptune, 164.79132},
    };

    private enum Planet
    {
        Earth,
        Mercury,
        Venus,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }

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
        return OnEarth() / factor[Planet.Mercury];
    }

    public double OnVenus()
    {
        return OnEarth() / factor[Planet.Venus];
    }

    public double OnMars()
    {
        return OnEarth() / factor[Planet.Mars];
    }

    public double OnJupiter()
    {
        return OnEarth() / factor[Planet.Jupiter];
    }

    public double OnSaturn()
    {
        return OnEarth() / factor[Planet.Saturn];
    }

    public double OnUranus()
    {
        return OnEarth() / factor[Planet.Uranus];
    }

    public double OnNeptune()
    {
        return OnEarth() / factor[Planet.Neptune];
    }
}