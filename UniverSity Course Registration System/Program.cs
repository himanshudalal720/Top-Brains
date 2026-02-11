
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                string choice = Console.ReadLine() ?? " ";

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods\
                    switch (choice)
                    {
                        case "1":
                            {

                                Console.WriteLine("Enter Course Code:");
                                string CourseCode = Console.ReadLine() ?? " ";

                                Console.WriteLine("Enter Course Name:");
                                string CourseName = Console.ReadLine() ?? " ";

                                Console.WriteLine("Enter Credits:");
                                if (!int.TryParse(Console.ReadLine(), out int credits))
                                {
                                    Console.WriteLine("Invalid number entered.");
                                    break;
                                }
                                Console.WriteLine("Enter Max Capacity(default 50):");
                                if(!int.TryParse(Console.ReadLine(), out int maxCapacity))
                                {
                                    maxCapacity = 50;
                                }
                                Console.WriteLine("Enter Prerequisites (comma-separated, or Enter for none):");
                                string temp1 = Console.ReadLine() ?? "";
                                List<string> prerequisites;

                                if (temp1 == "" || temp1 == null)
                                    prerequisites = null;
                                else
                                    prerequisites = temp1.Split(",").ToList();

                                system.AddCourse(CourseCode, CourseName, credits, maxCapacity, prerequisites);
                                Console.WriteLine($"\nCourse {CourseCode} added successfully.");

                                break;


                            }
                        case "2":
                            {

                                Console.WriteLine("Enter Student ID:");
                                string id = Console.ReadLine() ?? " ";

                                Console.WriteLine("Enter Name:");
                                string name = Console.ReadLine() ?? " ";

                                Console.WriteLine("Enter Major:");
                                string major = Console.ReadLine() ?? " ";

                                Console.WriteLine("Enter Max Credits (default 18):");
                                if(!int.TryParse(Console.ReadLine(), out int maxCredits))
                                {
                                    maxCredits = 18;
                                }

                                Console.WriteLine("Enter Completed Courses (comma-separated, or Enter for none):");
                                string temp2 = Console.ReadLine();

                                List<string> completedCourses;

                                if (temp2 == null || temp2 == "")
                                {
                                    completedCourses = null;
                                }
                                else
                                {
                                    completedCourses = new List<string>();
                                    string[] parts = temp2.Split(',');
                                    completedCourses = parts.ToList();
                                }

                                system.AddStudent(id, name, major, maxCredits, completedCourses);
                                Console.WriteLine($"\nStudent {id} added successfully");


                                break;
                            }
                        case "3":
                            {

                                Console.WriteLine("Enter Student ID:");
                                string studentId = Console.ReadLine() ?? " ";
                                Console.WriteLine("Enter Course Code:");
                                string courseCode = Console.ReadLine() ?? " ";
                                if (system.RegisterStudentForCourse(studentId, courseCode))
                                    Console.WriteLine($"Registration successful! Total credits: {system.Students[studentId].GetTotalCredits()}/{system.Students[studentId].MaxCredits}.");
                                else
                                    Console.WriteLine("Can't register Course");

                                break;
                            }
                        case "4":
                            {

                                Console.WriteLine("Enter Student ID:");
                                string studentId = Console.ReadLine() ?? " ";
                                Console.WriteLine("Enter Course Code:");
                                string courseCode = Console.ReadLine() ?? " ";
                                if (system.DropStudentFromCourse(studentId, courseCode))
                                    Console.WriteLine($"Student {studentId} Dropped from Course {courseCode} successfully.");

                                break;
                            }
                        case "5":
                            {

                                Console.WriteLine($"Displaying All Courses:");
                                system.DisplayAllCourses();
                                break;

                            }
                        case "6":
                            {

                                Console.WriteLine("Enter Student ID:");
                                string studentId = Console.ReadLine() ?? " ";
                                Console.WriteLine($"Displaying Student Schedule :");
                                system.DisplayStudentSchedule(studentId);

                                break;
                            }
                        case "7":
                            {

                                Console.WriteLine($"Displaying Student Summary :");
                                system.DisplaySystemSummary();

                                break;
                            }
                        case "8":
                            {
                                exit = true;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

