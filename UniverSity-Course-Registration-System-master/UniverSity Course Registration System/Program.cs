using System;
using System.Collections.Generic;
using UniversityCourseRegistrationSystem;

class Program
{
    static void Main()
    {
        UniversitySystem system = new UniversitySystem();

        Console.WriteLine("Welcome to University Course Registration System");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Course");
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
                    case "1":
                        Console.Write("Course Code: ");
                        string cCode = Console.ReadLine();

                        Console.Write("Course Name: ");
                        string cName = Console.ReadLine();

                        Console.Write("Credits (1-4): ");
                        int credits = int.Parse(Console.ReadLine());

                        Console.Write("Max Capacity (10-100): ");
                        int cap = int.Parse(Console.ReadLine());

                        Console.Write("Prerequisites (comma separated or blank): ");
                        var preInput = Console.ReadLine();
                        var prereq = string.IsNullOrWhiteSpace(preInput)
                            ? new List<string>()
                            : new List<string>(preInput.Split(','));

                        system.AddCourse(cCode, cName, credits, cap, prereq);
                        Console.WriteLine("Course added successfully.");
                        break;

                    case "2":
                        Console.Write("Student ID: ");
                        string sId = Console.ReadLine();

                        Console.Write("Name: ");
                        string sName = Console.ReadLine();

                        Console.Write("Major: ");
                        string major = Console.ReadLine();

                        Console.Write("Max Credits (<=24): ");
                        int maxCred = int.Parse(Console.ReadLine());

                        Console.Write("Completed Courses (comma separated or blank): ");
                        var compInput = Console.ReadLine();
                        var completed = string.IsNullOrWhiteSpace(compInput)
                            ? new List<string>()
                            : new List<string>(compInput.Split(','));

                        system.AddStudent(sId, sName, major, maxCred, completed);
                        Console.WriteLine("Student added successfully.");
                        break;

                    case "3":
                        Console.Write("Student ID: ");
                        system.RegisterStudentForCourse(
                            Console.ReadLine(),
                            Prompt("Course Code: ")
                        );
                        break;

                    case "4":
                        Console.Write("Student ID: ");
                        system.DropStudentFromCourse(Console.ReadLine(), Prompt("Course Code: "));
                        break;

                    case "5":
                        system.DisplayAllCourses();
                        break;

                    case "6":
                        Console.Write("Student ID: ");
                        system.DisplayStudentSchedule(Console.ReadLine());
                        break;

                    case "7":
                        system.DisplaySystemSummary();
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static string Prompt(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine();
    }
}
