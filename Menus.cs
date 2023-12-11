using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNET
{
    internal static class Menus
    {
        internal static bool MainMenu(SqlConnection connection)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the School of .NET.\n");

                Console.WriteLine("1. Get all students");
                Console.WriteLine("2. Get students in a specific class");
                Console.WriteLine("3. Add new staff members");
                Console.WriteLine("4. Show all staff members");
                Console.WriteLine("5. Retrieve all grades set in the last month");
                Console.WriteLine("6. Average grade per course");
                Console.WriteLine("7. Add new students");
                Console.WriteLine("8. Exit the program\n");

                int chosenOption;
                string userInput;

                do
                {
                    Console.Write("Choose what you would like to do (1-8): ");
                    userInput = Console.ReadLine();
                } while (!int.TryParse(userInput, out chosenOption) || chosenOption < 1 || chosenOption > 8);

                switch (chosenOption)
                {
                    case 1:
                        Console.Clear();
                        UserFunctions.getAllStudents(connection);
                        break;

                    case 2:
                        Console.Clear();
                        UserFunctions.getAllStudentsInClass(connection);
                        break;

                    case 3:
                        Console.Clear();
                        UserFunctions.AddNewStaff(connection);
                        break;

                    case 4:
                        Console.Clear();
                        UserFunctions.GetStaff(connection);
                        break;

                    case 5:
                        Console.Clear();
                        UserFunctions.GetGradesForStudent(connection);
                        break;

                    case 6:
                        Console.Clear();
                        UserFunctions.GetAverageGradePerCourse(connection);
                        break;

                    case 7:
                        Console.Clear();
                        UserFunctions.AddNewStudent(connection);
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(2000);
                        return false;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
