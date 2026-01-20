using System;
using System.Collections.Generic;
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}
class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        int marksCompare = y.Marks.CompareTo(x.Marks);
        if (marksCompare != 0)
            return marksCompare;
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Aman", Age = 20, Marks = 90 },
            new Student { Name = "Riya", Age = 19, Marks = 90 },
            new Student { Name = "Kunal", Age = 21, Marks = 85 },
            new Student { Name = "Sneha", Age = 20, Marks = 95 }
        };
        students.Sort(new StudentComparer());
        foreach (var s in students)
            Console.WriteLine($"{s.Name} {s.Age} {s.Marks}");
    }
}
