
/* DDL PART START */

CREATE DATABASE Triggers

USE Triggers

CREATE TABLE [Group]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GroupNumber NVARCHAR(50) NOT NULL CHECK (LEN(GroupNumber) > 3),
    Year INT NOT NULL CHECK ([Year] >= 1 AND [Year] <= 5),
    StudentsCount INT NOT NULL DEFAULT 0
);

CREATE TABLE Student
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(50) NOT NULL CHECK (LEN(StudentName) > 3),
    StudentSurname NVARCHAR(50) NOT NULL CHECK (LEN(StudentSurname) > 3),
    GPA INT NOT NULL DEFAULT 0 CHECK (GPA > 0 AND GPA <= 5),
    GroupId INT FOREIGN KEY REFERENCES [Group](Id)
)

CREATE TABLE Teacher
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TeacherName NVARCHAR(50) NOT NULL CHECK (LEN(TeacherName) > 3),
    TeacherSurname NVARCHAR(50) NOT NULL CHECK (LEN(TeacherSurname) > 3),
    Salary MONEY NOT NULL CHECK ([Salary] > 0)
)

CREATE TABLE Courses
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(50) NOT NULL CHECK (LEN(CourseName) > 3)
)

CREATE TABLE Lectures
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    LectureRoom NVARCHAR(50) NOT NULL CHECK (LEN(LectureRoom) > 3),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id),
    TeacherId INT FOREIGN KEY REFERENCES [Teacher](Id)
)

CREATE TABLE CourseRegistration
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id)
)

CREATE TABLE Grade
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id),
    Grade INT NOT NULL DEFAULT 0 CHECK (Grade > 0 AND Grade <= 5),
)

CREATE TABLE GradeHistory
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id),
    OldGrade INT NOT NULL DEFAULT 0 CHECK (OldGrade > 0 AND OldGrade <= 5),
    NewGrade INT NOT NULL DEFAULT 0 CHECK (NewGrade > 0 AND NewGrade <= 5),
    ChangeDate DATETIME DEFAULT GETDATE()
)

CREATE TABLE Warnings
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    Reason NVARCHAR(50) NOT NULL CHECK (LEN(Reason) > 3),
    Date DATETIME DEFAULT GETDATE()
)


CREATE TABLE Attendance
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id),
    IsPresent BIT DEFAULT 0 NOT NULL,
    Date DATETIME DEFAULT GETDATE()
)

CREATE TABLE RetakeList
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id)
)

CREATE TABLE Payments
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES [Student](Id),
    CourseId INT FOREIGN KEY REFERENCES [Courses](Id),
    IsPaid BIT DEFAULT 0 NOT NULL,
    Fee MONEY NOT NULL CHECK ([Fee] > 0)
)


/* DDL PART END */

-----------------------------------------------------------------------

/* DML PART START */


INSERT INTO [Group] (GroupNumber, Year, StudentsCount) VALUES
('A101', 1, 2),
('B202', 2, 3),
('C303', 3, 1);

INSERT INTO Student (StudentName, StudentSurname, GPA, GroupId) VALUES
('Alice', 'Johnson', 3, 1),
('Riad', 'Smith', 4, 1),
('Charlie', 'Brown', 2, 2),
('David', 'Williams', 5, 2),
('Event', 'Davis', 3, 3);

INSERT INTO Teacher (TeacherName, TeacherSurname, Salary) VALUES
('John', 'Black', 3000),
('Jane', 'White', 3500),
('Michael', 'Black', 4000);

INSERT INTO Courses (CourseName) VALUES
('Mathematics'),
('Physics'),
('Computer Science');

INSERT INTO Lectures (LectureRoom, CourseId, TeacherId) VALUES
('Room 101', 1, 1),
('Room 202', 2, 2),
('Room 303', 3, 3);

INSERT INTO Grade (StudentId, CourseId, Grade) VALUES
(1, 1, 3),
(2, 2, 4),
(3, 3, 2),
(4, 1, 5),
(5, 2, 3);

INSERT INTO GradeHistory (StudentId, CourseId, OldGrade, NewGrade, ChangeDate) VALUES
(1, 1, 3, 4, '2025-01-15'),
(2, 2, 4, 5, '2025-02-01'),
(3, 3, 2, 3, '2025-02-10'),
(4, 1, 4, 5, '2025-02-20'),
(5, 2, 3, 4, '2025-02-25');

INSERT INTO Attendance (StudentId, CourseId, IsPresent, Date) VALUES
(1, 1, 1, '2025-02-10'),
(2, 2, 0, '2025-02-11'),
(3, 3, 1, '2025-02-12'),
(4, 1, 1, '2025-02-13'),
(5, 2, 0, '2025-02-14');

INSERT INTO Payments (StudentId, CourseId, IsPaid, Fee) VALUES
(1, 1, 1, 500),
(2, 2, 0, 600),
(3, 3, 1, 550),
(4, 1, 1, 500),
(5, 2, 0, 600);


/* DML PART END */

-----------------------------------------------------------------------

/* TRIGGERS PART START */


--1

CREATE TRIGGER trg_CheckCountOfStudents on Student
FOR INSERT
AS
BEGIN
    DECLARE @GroupId INT;
    SELECT @GroupId = GroupId FROM inserted

    IF(SELECT COUNT(*) FROM Student WHERE GroupId = @GroupId) >= 3
        BEGIN
            print (N'Enough Student !')
            ROLLBACK TRANSACTION
        END
END

DROP TRIGGER trg_CheckCountOfStudents

--2

CREATE TRIGGER trg_UpdateStudentsCount on Student
FOR INSERT, DELETE
AS
BEGIN
    UPDATE [Group]
    SET StudentsCount = (SELECT COUNT(*) FROM Student WHERE Student.GroupId = [Group].Id)
    WHERE Id IN (SELECT DISTINCT GroupId FROM inserted)

    UPDATE [Group]
    SET StudentsCount = (SELECT COUNT(*) FROM Student WHERE Student.GroupId = [Group].Id)
    WHERE Id IN (SELECT DISTINCT GroupId FROM deleted)

end

DROP TRIGGER trg_UpdateStudentsCount


--3

CREATE TRIGGER trg_StudentRegistration on Student
FOR INSERT
AS
BEGIN
    DECLARE @StudentId INT
    SELECT @StudentId =  Id FROM inserted

    INSERT INTO CourseRegistration(StudentId, CourseId)VALUES(@StudentId, 3)
end

DROP TRIGGER trg_StudentRegistration


--4

CREATE TRIGGER trg_GradeLevelChecking on Grade
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO Warnings (StudentId, Reason, Date)
    SELECT i.StudentId, 'Bad Grade', GETDATE() FROM inserted i
    WHERE i.Grade < 3
end

DROP TRIGGER trg_GradeLevelChecking


--5

CREATE TRIGGER trg_PermissionToRemoveTeachers on Teacher
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Lectures WHERE TeacherId IN (SELECT Id FROM deleted))
    BEGIN
        print ('You can not delete teacher !')
        RETURN
    end


    DELETE FROM Teacher WHERE Id IN (SELECT Id FROM deleted);
end

DROP TRIGGER trg_PermissionToRemoveTeachers


--6

CREATE TRIGGER trg_UpdateGradeHistory on Grade
FOR UPDATE
AS
BEGIN
    INSERT INTO GradeHistory (StudentId, CourseId, OldGrade, NewGrade, ChangeDate)
    SELECT d.StudentId, d.CourseId, d.Grade, i.Grade, GETDATE() FROM deleted d
    JOIN inserted i ON d.StudentId = i.StudentId AND d.CourseId = i.CourseId;
end

DROP TRIGGER trg_UpdateGradeHistory


--7

CREATE TRIGGER trg_CheckingTheNumberOfAbsences on Attendance
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM RetakeList RL
    JOIN inserted i ON RL.StudentId = i.StudentId AND RL.CourseId = i.CourseId)
    BEGIN
        RETURN;
    END;

    INSERT INTO RetakeList(StudentId, CourseId)
    SELECT i.StudentId, i.CourseId FROM inserted i
    WHERE (
        SELECT COUNT(*)
        FROM Attendance A
        WHERE A.StudentId = i.StudentId
        AND A.CourseId = i.CourseId
        AND A.IsPresent = 0
        ) > 5
end

DROP TRIGGER trg_CheckingTheNumberOfAbsences


--8

CREATE TRIGGER trg_PermissionToRemoveStudent on Student
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Payments p
    WHERE p.StudentId IN (SELECT Id FROM deleted)
    AND p.IsPaid = 0
    )
    BEGIN
        print ('You can not delete Student because he or she did not pay the fee!')
        RETURN
    end

    IF EXISTS (SELECT 1 FROM Grade g
    WHERE g.StudentId IN (SELECT Id FROM deleted)
    AND g.Grade < 3
    )
    BEGIN
        print ('You can not delete Student because he or she have bad stats!')
        RETURN
    end


    DELETE FROM Student WHERE Id IN (SELECT Id FROM deleted);
end

DROP TRIGGER trg_PermissionToRemoveStudent


--9

CREATE TRIGGER trg_UpdateStudentGPA on Grade
FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @StudentId INT

    SELECT @StudentId = StudentId FROM inserted

    UPDATE Student
    SET GPA = (
        SELECT AVG(Grade) FROM Grade
        WHERE StudentId = @StudentId
        )
    WHERE Id = @StudentId
end

DROP TRIGGER trg_UpdateStudentGPA

/* TRIGGERS PART END */