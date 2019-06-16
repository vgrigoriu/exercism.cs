using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Grades grades = new Grades();

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

    public IEnumerable<string> Grade(int grade) => Students(grade).Keys;

    private SortedList<string, string> Students(int grade)
    {
        if (!grades.ContainsKey(grade))
        {
            grades[grade] = new SortedList<string, string>();
        }

        return grades[grade];
    }

    private class Grades : SortedDictionary<int, SortedList<string, string>> {}
}