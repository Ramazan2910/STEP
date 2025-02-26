CREATE DATABASE Academy2

/* CREATING TABLES PART */
------------------------------------------------------------------------

USE Academy2

CREATE TABLE Departments
(
    [Id] int identity(1,1) NOT NULL PRIMARY KEY,
    [Financing] money NOT NULL DEFAULT 0 CHECK ([Financing] > 0),
    [DepartmentName] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([DepartmentName]) > 3),
);

CREATE TABLE Faculties
(
    [Id] int identity(1,1) NOT NULL PRIMARY KEY,
    [Dean] nvarchar(max) NOT NULL CHECK (LEN([Dean]) > 3),
    [FacultyName] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([FacultyName]) > 3),
);

CREATE TABLE Groups
(
    [Id] int identity(1,1) NOT NULL PRIMARY KEY,
    [GroupName] nvarchar(10) NOT NULL UNIQUE CHECK (LEN([GroupName]) > 3),
    [Rating] int NOT NULL CHECK ([Rating] >= 0 AND [Rating] <= 5),
    [Year] int NOT NULL CHECK ([Year] > 0 AND [Year] <= 5)
);

CREATE TABLE Teachers
(
    [Id] int identity(1,1) NOT NULL PRIMARY KEY,
    [TeacherName] nvarchar(max) NOT NULL CHECK (LEN([TeacherName]) > 3),
    [TeacherSurname] nvarchar(max) NOT NULL CHECK (LEN([TeacherSurname]) > 3),
    [EmploymentDate] date NOT NULL CHECK([EmploymentDate] >= '1990-01-01'),
    [Position] nvarchar(max) NOT NULL CHECK (LEN([Position]) > 3),
    [IsAssistant] bit NOT NULL DEFAULT 0,
    [IsProfessor] bit NOT NULL DEFAULT 0,
    [Salary] money NOT NULL CHECK ([Salary] > 0),
    [Premium] money NOT NULL DEFAULT 0 CHECK ([Premium] > 0),
);



/* INSERT PART */
------------------------------------------------------------------------



INSERT INTO Departments (Financing, DepartmentName)
VALUES
(50000, N'Computer Science'),
(75000, N'Mathematics'),
(60000, N'Physics'),
(9000, N'History'),
(30000, N'Biology'),
(8000, N'Philosophy'),
(40000, N'Engineering');

INSERT INTO Faculties (Dean, FacultyName)
VALUES
(N'Dr. John Smith', N'Faculty of Engineering'),
(N'Dr. Emily Johnson', N'Faculty of Science'),
(N'Dr. Robert Brown', N'Faculty of Arts');

INSERT INTO Groups (GroupName, Rating, Year)
VALUES
(N'CS101', 5, 3),
(N'MATH202', 4, 2),
(N'PHYS303', 3, 4);

INSERT INTO Teachers (TeacherName, TeacherSurname, EmploymentDate, Position, IsAssistant, IsProfessor, Salary, Premium)
VALUES
(N'Alice', N'Williams', '2005-09-15', N'Senior Lecturer', 1, 0, 3500, 500),
(N'Michael', N'Anderson', '2010-03-22', N'Professor', 0, 1, 7000, 1000),
(N'Sophia', N'Martinez', '1998-06-30', N'Assistant', 1, 0, 3000, 300),
(N'Herman', N'Georgio', '1999-06-11', N'Assistant', 1, 0, 1000, 100);




/* SELECT PART */
------------------------------------------------------------------------



-- 1
SELECT * FROM Departments
ORDER BY Id desc

-- 2

SELECT g.GroupName as GroupName, g.Rating as GroupRating FROM Groups g

-- 3
SELECT t.TeacherSurname,
       (t.Premium / t.Salary) * 100 as PrecentageOfPremium,
       (t.Salary/(t.Salary + t.Premium)) * 100 PrecentageOfSalary
FROM Teachers t

-- 4
SELECT ('The dean of faculty ' + f.FacultyName + ' is ' + f.Dean) FROM Faculties f

-- 5
SELECT t.TeacherSurname FROM Teachers t
WHERE t.IsProfessor = 1 and t.Salary > 1050

-- 6
SELECT d.DepartmentName FROM Departments d
WHERE d.Financing < 11000 or d.Financing > 25000

-- 7
SELECT f.FacultyName FROM Faculties f
WHERE f.FacultyName != 'Computer Science'

-- 8
SELECT t.TeacherSurname, t.Position FROM Teachers t
WHERE t.IsProfessor = 0

-- 9
SELECT t.TeacherSurname, t.Position, t.Salary, t.Premium FROM Teachers t
WHERE t.IsProfessor = 0 and (t.Premium > 160 and t.Premium < 550)

-- 10
SELECT t.TeacherSurname, t.Salary FROM Teachers t
WHERE t.IsProfessor = 0

-- 11
SELECT t.TeacherSurname, t.Position FROM Teachers t
WHERE t.EmploymentDate < '2000-01-01'

-- 12
SELECT d.DepartmentName as NameOfDepartment FROM Departments d
WHERE d.DepartmentName < 'Software Development'

-- 13
SELECT t.TeacherSurname FROM Teachers t
WHERE (t.Salary + t.Premium) < 1200

-- 14
SELECT g.GroupName FROM Groups g
WHERE g.Year = 5 and (g.Rating >= 2 and g.Rating <= 4)

-- 15
SELECT t.TeacherSurname FROM Teachers t
WHERE t.Salary < 550 or t.Premium < 220