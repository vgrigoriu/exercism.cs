using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private SortedDictionary<int, SortedList<string, string>> grades = new SortedDictionary<int, SortedList<string, string>>();

    public void Add(string student, int grade)
    {
        var students = Students(grade);
        students.Add(student, student);
    }

    public IEnumerable<string> Roster()
    {
        return from grade in grades.Keys
               let students = grades[grade]
               from student in students.Keys
               select student;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return Students(grade).Keys.ToList();
    }

    private SortedList<string, string> Students(int grade)
    {
        // not exactly thread safe
        if (!grades.ContainsKey(grade))
        {
            grades[grade] = new SortedList<string, string>();
        }

        return grades[grade];
    }
}