using System;
using System.Collections.Generic;
using System.Linq;

[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private static readonly List<Allergen> allAllergens = Enum.GetValues(typeof(Allergen)).OfType<Allergen>().ToList();
    private readonly Allergen mask;

    public Allergies(int mask) : this((Allergen)mask) { }

    public Allergies(Allergen mask) => this.mask = mask;

    public bool IsAllergicTo(Allergen allergen) => mask.HasFlag(allergen);

    public Allergen[] List()
    {
        return allAllergens
            .Where(IsAllergicTo)
            .ToArray();
    }
}