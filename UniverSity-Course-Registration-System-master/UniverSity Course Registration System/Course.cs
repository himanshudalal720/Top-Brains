using System;
using System.Collections.Generic;

namespace UniversityCourseRegistrationSystem
{
    public class Course
    {
        public string CourseCode { get; }
        public string CourseName { get; }
        public int Credits { get; }
        public int MaxCapacity { get; }
        public List<string> Prerequisites { get; }

        private int CurrentEnrollment;

        public Course(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            CourseCode = code;
            CourseName = name;
            Credits = credits;
            MaxCapacity = maxCapacity;
            Prerequisites = prerequisites ?? new List<string>();
            CurrentEnrollment = 0;
        }

        public bool IsFull()
        {
            return CurrentEnrollment >= MaxCapacity;
        }

        public bool HasPrerequisites(List<string> completedCourses)
        {
            foreach (var pre in Prerequisites)
            {
                if (!completedCourses.Contains(pre))
                    return false;
            }
            return true;
        }

        public void EnrollStudent()
        {
            if (IsFull())
                throw new InvalidOperationException("Course is already full.");

            CurrentEnrollment++;
        }

        public void DropStudent()
        {
            if (CurrentEnrollment > 0)
                CurrentEnrollment--;
        }

        public int GetEnrollment()
        {
            return CurrentEnrollment;
        }
    }
}
