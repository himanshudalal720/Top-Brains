using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            if (string.IsNullOrWhiteSpace(code) || code.Length < 3 || code.Length > 10)
                throw new ArgumentException("Course code must be 3–10 characters.");

            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course already exists.");

            if (credits < 1 || credits > 4)
                throw new ArgumentException("Credits must be between 1 and 4.");

            if (maxCapacity < 10 || maxCapacity > 100)
                throw new ArgumentException("Capacity must be between 10 and 100.");

            if (prerequisites != null && prerequisites.Contains(code))
                throw new ArgumentException("Course cannot be its own prerequisite.");

            Course course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses[code] = course;


        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Student ID cannot be empty.");

            if (Students.ContainsKey(id))
                throw new ArgumentException("Student already exists.");

            if (maxCredits < 1 || maxCredits > 24)
                throw new ArgumentException("Max credits must be between 1 and 24.");
                
            Student student = new Student(id, name, major, maxCredits, completedCourses);
            Students[id] = student;

        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            if (AvailableCourses.ContainsKey(courseCode) && Students.ContainsKey(studentId))
            {
                return Students[studentId].AddCourse(AvailableCourses[courseCode]);
            }
            return false;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if (Students[studentId].DropCourse(courseCode))
                return true;

            return false;
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            foreach (var i in AvailableCourses)
            {
                Course course = i.Value;
                Console.WriteLine($"{course.CourseCode} {course.CourseName} {course.Credits} {course.GetEnrollmentInfo()}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if (Students.ContainsKey(studentId))
            {
                Students[studentId].DisplaySchedule();
                return;
            }
            throw new Exception($"Student {studentId} doesn't exists!");
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            Console.WriteLine($"Student: {Students.Count}, Course: {AvailableCourses.Count}, Average Enrollment: {(AvailableCourses.Count * 1.0) / (Students.Count * 1.0)}");
        }
    }
}
