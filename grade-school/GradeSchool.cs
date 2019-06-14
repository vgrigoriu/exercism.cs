using System;
using System.Collections.Generic;

public class GradeSchool
{
    private List<string> roster = new List<string>();

    public void Add(string student, int grade)
    {
        roster.Add(student);
    }

    public IEnumerable<string> Roster()
    {
        return roster;
    }

    public IEnumerable<string> Grade(int grade)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}