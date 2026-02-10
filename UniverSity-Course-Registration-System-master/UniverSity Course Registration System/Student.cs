using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityCourseRegistrationSystem
{
    public class Student
    {
        public string StudentId { get; }
        public string Name { get; }
        public string Major { get; }
        public int MaxCredits { get; }
        public List<string> CompletedCourses { get; }
        public List<Course> RegisteredCourses { get; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            return RegisteredCourses.Sum(c => c.Credits);
        }

        public bool CanAddCourse(Course course)
        {
            if (RegisteredCourses.Any(c => c.CourseCode == course.CourseCode))
                return false;

            if (GetTotalCredits() + course.Credits > MaxCredits)
                return false;

            if (!course.HasPrerequisites(CompletedCourses))
                return false;

            return true;
        }

        public bool AddCourse(Course course)
        {
            if (!CanAddCourse(course) || course.IsFull())
                return false;

            RegisteredCourses.Add(course);
            course.EnrollStudent();
            return true;
        }

        public bool DropCourse(string courseCode)
        {
            var course = RegisteredCourses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course == null)
                return false;

            RegisteredCourses.Remove(course);
            course.DropStudent();
            return true;
        }

        public void DisplaySchedule()
        {
            if (RegisteredCourses.Count == 0)
            {
                Console.WriteLine("No courses registered.");
                return;
            }

            Console.WriteLine("\nCourse Code\tCourse Name\t\tCredits");
            Console.WriteLine("-----------------------------------------------");

            foreach (var c in RegisteredCourses)
            {
                Console.WriteLine($"{c.CourseCode}\t\t{c.CourseName,-20}\t{c.Credits}");
            }
        }
    }
}
