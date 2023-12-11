USE Master

CREATE DATABASE SchoolDB
GO

USE SchoolDB
GO

CREATE TABLE Students (
	StudentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, --
	FirstName NVARCHAR(30),
	LastName NVARCHAR(30),
	DateOfBirth DATE
)
GO

CREATE TABLE Courses (
	CourseID INT IDENTITY(1,1) PRIMARY KEY,
	CourseName NVARCHAR(45) NOT NULL,
	Teacher NVARCHAR(35)
)
GO

CREATE TABLE Enrollments (
	EnrollmentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	StudentID_FK INT,
	CourseID_FK INT,
	Grade CHAR(1)
	FOREIGN KEY(StudentID_FK) REFERENCES Students(StudentID),
	FOREIGN KEY(CourseID_FK) REFERENCES Courses(CourseID)
)
GO

INSERT INTO Students(FirstName, LastName, DateOfBirth)
VALUES 
('Niklas','Sjödin', '1992-06-25'),
('Linda', 'Ohlsson', '1998-03-28'),
('Matilda', 'Sjödin', '1994-12-04')
GO

INSERT INTO Courses(CourseName, Teacher)
VALUES
('Databases', 'Aldor'),
('C# och .NET', 'Christoffer'),
('Webbutveckling', 'Reidar'),
('API', 'Aldor')
GO

INSERT INTO Enrollments(StudentID_FK, CourseID_FK)
VALUES
(1, 1),
(1,2),
(1,3),
(2,1),
(2,2),
(2,3)
GO

UPDATE Enrollments
SET Grade = 'B'
WHERE Enrollments.StudentID_FK = 1 AND Enrollments.CourseID_FK = 2