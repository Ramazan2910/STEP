IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Academy')
    CREATE DATABASE Academy

/* CREATE PART */

USE Academy

GO

CREATE Table Curators
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[CuratorName] nvarchar(max) NOT NULL CHECK (LEN([CuratorName]) >= 3),
	[CuratorSurname] nvarchar(max) NOT NULL CHECK (LEN([CuratorSurname]) >= 3),
);

GO

CREATE Table Faculties
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
	[FacultyName] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([FacultyName]) >= 3),
);

GO


CREATE Table Departments
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
	[DepartmentName] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([DepartmentName]) >= 3),
	[FacultyId] int NOT NULL FOREIGN KEY REFERENCES Faculties(Id),
);

GO

CREATE Table Groups
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[GroupName] nvarchar(10) NOT NULL UNIQUE CHECK (LEN([GroupName]) >= 3),
	[Year] int NOT NULL CHECK ([Year] >= 1 AND [Year] <=5),
	[DepartmentId] int NOT NULL FOREIGN KEY REFERENCES Departments(Id),
);

GO

CREATE Table GroupsCurators
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[CuratorId] int NOT NULL FOREIGN KEY REFERENCES Curators(Id),
	[GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
);

GO

/*Lecture*/

CREATE Table Teachers
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[TeacherName] nvarchar(max) NOT NULL CHECK (LEN([TeacherName]) >= 3),
	[TeacherSurname] nvarchar(max) NOT NULL CHECK (LEN([TeacherSurname]) >= 3),
	[Salary] money NOT NULL CHECK (([Salary]) > 0)
);

GO

CREATE Table Subjects
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[SubjectName] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([SubjectName]) >= 3),
);

GO

CREATE Table Lectures
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[LectureRoom] nvarchar(max) NOT NULL CHECK (LEN([LectureRoom]) >= 3),
	[SubjectId] int NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	[TeacherId] int NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
);

GO

CREATE Table GroupsLectures
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
	[LectureId] int NOT NULL FOREIGN KEY REFERENCES Lectures(Id),
);


------------------------------------------------------------------------------
/* INSERT PART */

INSERT INTO Curators (CuratorName, CuratorSurname)
VALUES
(N'Ivan', N'Ivanov'),
(N'Olga', N'Petrova'),
(N'Dmitry', N'Sidorov'),
(N'Anna', N'Kuznetsova'),
(N'Pavel', N'Vasiliev'),
(N'Maria', N'Smirnova');


INSERT INTO Faculties (Financing, FacultyName)
VALUES
(150000.00, N'Faculty of Computer Science'),
(200000.00, N'Faculty of Economics'),
(180000.00, N'Faculty of Law'),
(120000.00, N'Faculty of Arts'),
(160000.00, N'Faculty of Engineering'),
(140000.00, N'“Computer Science');


INSERT INTO Departments (Financing, DepartmentName, FacultyId)
VALUES
(50000.00, N'Department of Software Engineering', 1),
(60000.00, N'Department of Marketing', 2),
(55000.00, N'Department of Public Law', 3),
(45000.00, N'Department of History', 4),
(70000.00, N'Department of Robotics', 5),
(65000.00, N'Department of Surgery', 6);


INSERT INTO Groups (GroupName, Year, DepartmentId)
VALUES
(N'P107', 1, 1),
(N'ECO201', 2, 2),
(N'LAW301', 3, 3),
(N'ART101', 5, 4),
(N'ROBOT101', 1, 5),
(N'MED301', 5, 6),
(N'CS102', 2, 1),
(N'ECO301', 3, 2);


INSERT INTO GroupsCurators (CuratorId, GroupId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(1, 7),
(2, 8);


INSERT INTO Teachers (TeacherName, TeacherSurname, Salary)
VALUES
(N'Samantha', N'Adams', 50000.00),
(N'Anna', N'Novikova', 55000.00),
(N'Sergey', N'Kozlov', 60000.00),
(N'Irina', N'Petrova', 65000.00),
(N'Andrey', N'Smirnov', 70000.00),
(N'Elena', N'Kuznetsova', 75000.00);


INSERT INTO Subjects (SubjectName)
VALUES
(N'Mathematics'),
(N'Economics'),
(N'Constitutional Law'),
(N'Art History'),
(N'Robotics'),
(N'Human Anatomy'),
(N'Physics'),
(N'Database Theory');


INSERT INTO Lectures (LectureRoom, SubjectId, TeacherId)
VALUES
(N'Room 101', 1, 1),
(N'Room 102', 2, 2),
(N'B103', 3, 3),
(N'Room 104', 4, 4),
(N'Room 105', 5, 5),
(N'Room 106', 6, 6),
(N'B103', 7, 1),
(N'Room 108', 8, 2);


INSERT INTO GroupsLectures (GroupId, LectureId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(1, 8),
(2, 7),
(3, 6);



------------------------------------------------------------------------
/* TASKS */


-- 1

SELECT t.TeacherName, g.GroupName FROM Teachers t
JOIN Lectures l on t.Id = l.TeacherId
JOIN GroupsLectures gl on l.Id = gl.LectureId
JOIN Groups g on gl.GroupId = g.Id



-- 2

SELECT f.FacultyName FROM Faculties f
JOIN Departments d on f.Id = d.FacultyId
WHERE d.Financing > f.Financing

-- 3


SELECT c.CuratorName, g.GroupName FROM Curators c
JOIN GroupsCurators gc on c.Id = gc.CuratorId
JOIN Groups g on gc.GroupId = g.Id


-- 4

SELECT t.TeacherName, t.TeacherSurname FROM Teachers t
JOIN Lectures l on t.Id = l.TeacherId
JOIN GroupsLectures gl on l.Id = gl.LectureId
JOIN Groups g on gl.GroupId = g.Id
WHERE g.GroupName = 'P107'

-- 5

SELECT DISTINCT t.TeacherSurname, f.FacultyName FROM Teachers t
JOIN Lectures l on t.Id = l.TeacherId
JOIN GroupsLectures gl on l.Id = gl.LectureId
JOIN Groups g on g.Id = gl.GroupId
JOIN Departments d on g.DepartmentId = d.Id
JOIN Faculties f on d.FacultyId = f.Id


-- 6

SELECT d.DepartmentName, g.GroupName FROM Departments d
JOIN Groups g on d.Id = g.DepartmentId

-- 7

SELECT s.SubjectName FROM Subjects s
JOIN Lectures l on s.Id = l.SubjectId
JOIN Teachers t on l.TeacherId = t.Id
WHERE t.TeacherName = 'Samantha' AND t.TeacherSurname = 'Adams'

-- 8

SELECT d.DepartmentName FROM Departments d
JOIN Groups g on d.Id = g.DepartmentId
JOIN GroupsLectures gl on g.Id = gl.GroupId
JOIN Lectures l on gl.LectureId = l.Id
JOIN Subjects s on l.SubjectId = s.Id
WHERE s.SubjectName = 'Database Theory'

-- 9

SELECT g.GroupName FROM Groups g
JOIN Departments d on g.DepartmentId = d.Id
JOIN Faculties f on d.FacultyId = f.Id
WHERE f.FacultyName = 'Computer Science'

-- 10

SELECT g.GroupName, f.FacultyName FROM Groups g
JOIN Departments d on g.DepartmentId = d.Id
JOIN Faculties f on d.FacultyId = f.Id
WHERE g.Year = 5


-- 11

SELECT t.TeacherName,
       t.TeacherSurname,
       s.SubjectName,
       g.GroupName
FROM Teachers t
JOIN Lectures l on t.Id = l.TeacherId
JOIN Subjects s on l.SubjectId = s.Id
JOIN GroupsLectures gl on l.Id = gl.LectureId
JOIN Groups g on gl.GroupId = g.Id
WHERE l.LectureRoom = N'B103'





