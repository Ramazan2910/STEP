IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Academy')
    CREATE DATABASE Academy
   
GO


CREATE Table Groups
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[Name] nvarchar(10) NOT NULL UNIQUE CHECK (LEN([Name]) >= 3),
	[Rating] int NOT NULL CHECK ([Rating]>0 AND [Rating]<5),
	[Year] int NOT NULL CHECK ([Year] >1 and [Year]<5)
);


GO

CREATE Table Departments
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[Financing] money DEFAULT 0 NOT NULL CHECK ([Financing] >= 0),
	[Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([Name]) >= 3),
);

GO

CREATE Table Faculties
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([Name]) >= 3),
);

GO

CREATE Table Teachers
(
	[Id] int NOT NULL identity(1, 1) PRIMARY KEY,
	[EmploymentDate] date NOT NULL CHECK(([EmploymentDate]) >= '1990-01-01'),
	[Name] nvarchar(255) NOT NULL UNIQUE CHECK (LEN([Name]) >= 3),
	[Surname] nvarchar(255) NOT NULL CHECK (LEN([Surname]) >= 3),
	[Premium] money NOT NULL DEFAULT 0 CHECK (([Premium]) > 0),
	[Salary] money NOT NULL CHECK (([Salary]) > 0)
);