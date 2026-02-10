using System;
using System.Collections.Generic;

namespace University_Course_Registration_System
{
    // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": // Add Course
                            Console.Write("Course Code: ");
                            string code = Console.ReadLine();

                            Console.Write("Course Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine());

                            Console.Write("Max Capacity: ");
                            int capacity = int.Parse(Console.ReadLine());

                            Console.Write("Prerequisites (comma-separated or empty): ");
                            string prereqInput = Console.ReadLine();

                            List<string> prerequisites =
                                string.IsNullOrWhiteSpace(prereqInput)
                                ? new List<string>()
                                : new List<string>(prereqInput.Split(',', StringSplitOptions.TrimEntries));

                            system.AddCourse(code, name, credits, capacity, prerequisites);
                            Console.WriteLine("Course added successfully.");
                            break;

                        case "2": // Add Student
                            Console.Write("Student ID: ");
                            string id = Console.ReadLine();

                            Console.Write("Name: ");
                            string studentName = Console.ReadLine();

                            Console.Write("Major: ");
                            string major = Console.ReadLine();

                            Console.Write("Max Credits: ");
                            int maxCredits = int.Parse(Console.ReadLine());

                            Console.Write("Completed Courses (comma-separated or empty): ");
                            string completedInput = Console.ReadLine();

                            List<string> completedCourses =
                                string.IsNullOrWhiteSpace(completedInput)
                                ? new List<string>()
                                : new List<string>(completedInput.Split(',', StringSplitOptions.TrimEntries));

                            system.AddStudent(id, studentName, major, maxCredits, completedCourses);
                            Console.WriteLine("Student added successfully.");
                            break;

                        case "3": // Register Student
                            Console.Write("Student ID: ");
                            string regStudentId = Console.ReadLine();

                            Console.Write("Course Code: ");
                            string regCourseCode = Console.ReadLine();

                            if (system.RegisterStudentForCourse(regStudentId, regCourseCode))
                                Console.WriteLine("Student registered successfully.");
                            break;

                        case "4": // Drop Student from Course
                            Console.Write("Student ID: ");
                            string dropStudentId = Console.ReadLine();

                            Console.Write("Course Code: ");
                            string dropCourseCode = Console.ReadLine();

                            if (system.DropStudentFromCourse(dropStudentId, dropCourseCode))
                                Console.WriteLine("Course dropped successfully.");
                            else
                                Console.WriteLine("Course not found or not registered.");
                            break;

                        case "5": // Display All Courses
                            system.DisplayAllCourses();
                            break;

                        case "6": // Display Student Schedule
                            Console.Write("Student ID: ");
                            string scheduleId = Console.ReadLine();
                            system.DisplayStudentSchedule(scheduleId);
                            break;

                        case "7": // Display System Summary
                            system.DisplaySystemSummary();
                            break;

                        case "8": // Exit
                            exit = true;
                            Console.WriteLine("Exiting system. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter 1–8.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter numeric values where required.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
