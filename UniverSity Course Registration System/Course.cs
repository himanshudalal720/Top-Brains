using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Course Class
    // =========================
    public class Course
    {
        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public int Credits { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<string> Prerequisites { get; private set; }

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
            // TODO: Return true if CurrentEnrollment >= MaxCapacity
            if(CurrentEnrollment >= MaxCapacity) return true;
            return false;
        }

        public bool HasPrerequisites(List<string> completedCourses)
        {
            // TODO: Check if ALL prerequisites exist in completedCourses
            foreach(var i in Prerequisites)
            {
                if (!completedCourses.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void EnrollStudent()
        {
            // TODO:
            // 1. Throw InvalidOperationException if course is full
            // 2. Otherwise increment CurrentEnrollment
            if(CurrentEnrollment == MaxCapacity)
            {
                throw new InvalidOperationException("Course is Full!");
            }
            CurrentEnrollment++;
        }

        public void DropStudent()
        {
            // TODO: Decrement CurrentEnrollment only if greater than zero
            if(CurrentEnrollment > 0)
            {
                CurrentEnrollment--;
            }
        }

        public string GetEnrollmentInfo()
        {
            return $"{CurrentEnrollment}/{MaxCapacity}";
        }
    }
}
