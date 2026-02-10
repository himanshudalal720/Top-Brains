using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityCourseRegistrationSystem
{
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; }
        public Dictionary<string, Student> Students { get; }
        public List<Student> ActiveStudents { get; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
            ActiveStudents = new List<Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course code already exists.");

            AvailableCourses[code] = new Course(code, name, credits, maxCapacity, prerequisites);
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            if (Students.ContainsKey(id))
                throw new ArgumentException("Student ID already exists.");

            var student = new Student(id, name, major, maxCredits, completedCourses);
            Students[id] = student;
            ActiveStudents.Add(student);
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId) || !AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Student or Course not found.");
                return false;
            }

            var student = Students[studentId];
            var course = AvailableCourses[courseCode];

            if (!student.AddCourse(course))
            {
                Console.WriteLine("Registration failed (credit limit, prerequisites, duplicate, or course full).");
                return false;
            }

            Console.WriteLine($"Registration successful! Total Credits: {student.GetTotalCredits()}/{student.MaxCredits}");
            return true;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            if (!Students[studentId].DropCourse(courseCode))
            {
                Console.WriteLine("Course not found in student's schedule.");
                return false;
            }

            Console.WriteLine("Course dropped successfully.");
            return true;
        }
        public void DisplayAllCourses()
        {
            Console.WriteLine("\nCode\tName\t\t\tCredits\tEnrollment");
            Console.WriteLine("--------------------------------------------------");

            foreach (var c in AvailableCourses.Values)
            {
                Console.WriteLine($"{c.CourseCode}\t{c.CourseName,-20}\t{c.Credits}\t{c.GetEnrollment()}/{c.MaxCapacity}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            int totalEnrollments = AvailableCourses.Values.Sum(c => c.GetEnrollment());
            double avgEnrollment = AvailableCourses.Count == 0 ? 0 : (double)totalEnrollments / AvailableCourses.Count;

            Console.WriteLine("\nSystem Summary:");
            Console.WriteLine($"Total Students: {Students.Count}");
            Console.WriteLine($"Total Courses: {AvailableCourses.Count}");
            Console.WriteLine($"Average Enrollment: {avgEnrollment:F1}");
        }
    }
}
