using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolNET
{
    internal class UserFunctions
    {
        internal static void getAllStudents(SqlConnection connection)
        {
            Console.WriteLine("Select sorting: ");
            Console.Write("1. First name ascending, 2. First name descending, 3. Surname ascending, 4. Surname descending: ");

            int choice = int.Parse(Console.ReadLine());

            string sortColumn = choice switch
            {
                1 => "FirstName ASC",
                2 => "FirstName DESC",
                3 => "LastName ASC",
                4 => "LastName DESC",
                _ => "FirstName ASC"
            };

            string query = $"SELECT * FROM Students ORDER BY {sortColumn}";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        int studentID = Convert.ToInt32(reader["StudentID"]);

                        Console.WriteLine($"Name: {firstName} {lastName}");
                    }
                }
            }
            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();

        }
        internal static void getAllStudentsInClass(SqlConnection connection)
        {
            Console.WriteLine("Available Classes:");
            Helpers.DisplayClasses(connection);

            Console.Write("\nSelect a class by entering its ID: ");
            if (int.TryParse(Console.ReadLine(), out int selectedClassID))
            {
                string className = Helpers.GetClassName(connection, selectedClassID);

                if (!string.IsNullOrEmpty(className))
                {
                    Console.Clear();
                    Console.WriteLine($"You selected class: {className}");
                    Console.WriteLine("Do you want to show the students? (Y/N) ");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        string query = $"SELECT * FROM Students WHERE ClassID = {selectedClassID}";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.Clear ();
                                Console.WriteLine($"Students in Class '{className}':");

                                while (reader.Read())
                                {
                                    string firstName = reader["FirstName"].ToString();
                                    string lastName = reader["LastName"].ToString();

                                    Console.WriteLine($"Name: {firstName} {lastName}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nOperation canceled by the user.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid class ID. Please select a valid class.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }

        internal static void AddNewStaff(SqlConnection connection)
        {
            Console.WriteLine("Enter details for the staff member:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Position: ");
            string profession = Console.ReadLine();

            // You might need to adjust the column names based on your actual database schema
            string query = $"INSERT INTO Staff (FirstName, LastName, Profession) VALUES ('{firstName}', '{lastName}', '{profession}')";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("\nNew staff added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("\nFailed to add a new staff.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }


        internal static void GetStaff(SqlConnection connection)
        {
            Console.WriteLine("Select filtering:");
            Console.WriteLine("1. All Staff");
            Console.WriteLine("2. Teachers");

            int choice = int.Parse(Console.ReadLine());

            string filter = choice switch
            {
                1 => "",
                2 => "AND Profession = 'Teacher'",
                _ => ""
            };

            try
            {
                string query = $@"
            SELECT Staff.FirstName, Staff.LastName, Staff.Profession
            FROM Staff
            WHERE 1 = 1 {filter}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("Staff:");

                        while (reader.Read())
                        {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string profession = reader["Profession"].ToString();

                            Console.WriteLine($"Name: {firstName} {lastName}, Profession: {profession}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }


        internal static void GetGradesForStudent(SqlConnection connection)
        {
            Console.Write("Enter the student's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the student's last name: ");
            string lastName = Console.ReadLine();

            try
            {
                // Kontrollera om användaren finns i databasen
                string checkUserQuery = $@"
            SELECT COUNT(*) as UserCount
            FROM Students
            WHERE FirstName = '{firstName}' AND LastName = '{lastName}'";

                int userCount;
                using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                {
                    userCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                }

                if (userCount == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"No user found with that name.");
                }
                else
                {
                    // Användare finns i databasen, hämta och visa betygen
                    string query = $@"
                SELECT Students.FirstName, Students.LastName, Courses.CourseName, Grades.Grade
                FROM Grades
                INNER JOIN Students ON Grades.StudentID = Students.StudentID
                INNER JOIN Courses ON Grades.CourseID = Courses.CourseID
                WHERE Students.FirstName = '{firstName}' AND Students.LastName = '{lastName}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.Clear();
                            Console.WriteLine($"Grades for {firstName} {lastName}:");

                            while (reader.Read())
                            {
                                string courseName = reader["CourseName"].ToString();
                                string grade = reader["Grade"].ToString();

                                Console.WriteLine($"Course: {courseName}, Grade: {grade}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }

        internal static void GetAverageGradePerCourse(SqlConnection connection)
        {
            try
            {
                // Anpassa kolumnnamnen och tabellnamnen baserat på din databasstruktur
                string query = @"
            SELECT Courses.CourseName,
                   AVG(Grades.Grade) as AverageGrade,
                   MAX(Grades.Grade) as MaxGrade,
                   MIN(Grades.Grade) as MinGrade
            FROM Courses
            LEFT JOIN Grades ON Courses.CourseID = Grades.CourseID
            GROUP BY Courses.CourseName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        Console.WriteLine("Average Grade per Course:");

                        while (reader.Read())
                        {
                            string courseName = reader["CourseName"].ToString();
                            double averageGrade = Convert.ToDouble(reader["AverageGrade"]);
                            string maxGrade = reader["MaxGrade"].ToString();
                            string minGrade = reader["MinGrade"].ToString();

                            Console.WriteLine($"Course: {courseName}, Average Grade (1-5): {averageGrade:F2}, " +
                                $"Max Grade: {maxGrade}, " +
                                $"Min Grade: {minGrade}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }

        internal static void AddNewStudent(SqlConnection connection)
        {
            Console.Write("Enter the new student's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the new student's last name: ");
            string lastName = Console.ReadLine();

            try
            {
                // Lägg till den nya eleven i Students-tabellen
                string insertStudentQuery = $@"
            INSERT INTO Students (FirstName, LastName)
            VALUES ('{firstName}', '{lastName}');

            SELECT SCOPE_IDENTITY();"; // Hämta det tilldelade StudentID

                int newStudentID;

                using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
                {
                    newStudentID = Convert.ToInt32(command.ExecuteScalar());
                }

                // Anta att 1 är ClassID för klass 1A (ändra detta baserat på din databasstruktur)
                int classID = 1;

                // Koppla den nya eleven till klassen i Students-tabellen
                string updateStudentClassQuery = $@"
            UPDATE Students
            SET ClassID = {classID}
            WHERE StudentID = {newStudentID}";

                using (SqlCommand command = new SqlCommand(updateStudentClassQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"New student '{firstName} {lastName}' added to class 1A in the database.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add the new student. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("\nPress Enter to continue.");
            Console.ReadLine();
        }



    }
}
