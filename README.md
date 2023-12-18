# SQL SchoolNET

Welcome to SQL SchoolNET, a console-based program in C# that helps manage school-related data through a simple SQL database. This program allows users to perform various operations, from retrieving information about students and personnel to managing grades and courses.

## Table of Contents

1. [Creating a Database](#creating-a-database)
2. [Setting Up the Application Foundation](#setting-up-the-application-foundation)
3. [Implementing Functionality](#implementing-functionality)

## Creating a Database

### Create a Simple Database

Create a basic database that stores the following entities. The database does not need to have an advanced architecture.

- [ ] Students
- [ ] Classes that students can belong to
- [ ] Courses
- [ ] Grades that a specific student has received in a specific course (store as numeric values)
- [ ] Personnel who can belong to different categories (e.g., teacher, administrator, principal)

## Setting Up the Application Foundation

### Create the Application Structure

- [ ] Create a new console program in C#.
- [ ] Implement simple navigation in the program, allowing users to choose between the functions below. Use a basic switch statement, and allow users to input a number to navigate to a specific function.
- [ ] After a function is executed, the user should be able to press Enter to return to the main menu.

## Implementing Functionality

### Create the Following Functions

Implement the following functions that users can navigate to in the application. All these functions should be solved using pure SQL without any ORM.

1. **Retrieve All Students**

   Allow users to choose whether they want to see students sorted by first or last name and whether the sorting should be ascending or descending.

2. **Retrieve All Students in a Specific Class**

   Users should first see a list of all classes available. Afterward, they can choose a class, and all students in that class will be displayed.

   Extra Challenge: Allow users to choose the sorting order of students as in the previous point.

3. **Add New Personnel**

   Users should have the ability to enter information about a new employee, and that data is then saved in the database.

4. **Retrieve Personnel**

   Allow users to choose whether they want to see all employees or only those within a specific category, such as teachers.

5. **Retrieve All Grades Set in the Last Month**

   Display a list of all grades set in the last month, showing the student's name, course name, and grade.

6. **Average Grade per Course**

   Retrieve a list of all courses, along with the average grade that students have received in each course, as well as the highest and lowest grades obtained in each course.

   Users should see a list of all courses in the database, along with the average grade, highest grade, and lowest grade for each course.

   Note: It might be challenging to do this with letter grades, so consider storing grades as numeric values.

7. **Add New Students**

   Provide users with the ability to enter information about a new student, and that data is then saved in the database.

Feel free to explore and modify the program to suit your specific needs. Happy coding!
