use cis560_team20;
CREATE TYPE [Project].[ClassTableType] AS 
			TABLE(ClassId INT,
				  InstructorId INT,
				  LocationId INT,
				  TimeId INT,
				  TermId INT,
				  ClassTypeId INT,
				  ClassName NVARCHAR(256))
GO
SELECT * FROM Project.Class C WHERE C.ClassName = 'CIS 560'
GO

GO
CREATE PROCEDURE [Project].[FilterDepartment] @ClassTable Project.ClassTableType READONLY, @Department NVARCHAR(30)
AS
SELECT * FROM
@ClassTable CT
WHERE CT.ClassName = @Department
RETURN
GO
CREATE PROCEDURE [Project].[FilterTime] @ClassTable ClassTableType READONLY, @StartTime TIME(0), @EndTime TIME(0)
AS
SELECT * FROM
@ClassTable CT
INNER JOIN Project.[Time] T ON CT.TimeId = T.TimeId
WHERE T.StartTime = @StartTime AND T.EndTime = @EndTime
GO

CREATE PROCEDURE [Project].FilterDays @ClassTable ClassTableType READONLY, @Days VARBINARY
AS
SELECT * FROM
@ClassTable CT
INNER JOIN Project.[Time] T ON CT.TimeId = T.TimeId
WHERE T.[Days] = @Days
GO

CREATE PROCEDURE [Project].[FilterInstructorFirstName] @ClassTable AS ClassTableType READONLY, @FirstName AS NVARCHAR(30)
AS
SELECT * FROM
@ClassTable CT
INNER JOIN Project.Instructor I ON I.InstructorId = CT.InstrcutorId
WHERE @FirstName = I.FirstName
GO

CREATE PROCEDURE [Project].[FilterInstructorLastName] @ClassTable AS ClassTableType READONLY, @LastName AS NVARCHAR(30)
AS
SELECT * FROM
@ClassTable CT
INNER JOIN Project.Instructor I ON I.InstructorId = CT.InstructorId
WHERE @LastName = I.LastName
GO


CREATE PROCEDURE [Project].[FilterClassType] @ClassTable ClassTableType READONLY, @ClassType NVARCHAR(16)
AS 
SELECT * FROM
@ClassTable CT
INNER JOIN ClassType CType ON CT.ClassTypeId = CType.ClassTypeId
WHERE CType.[Type] = @ClassType
GO

CREATE PROCEDURE [Project].[FilterTerm] @ClassTable ClassTableType READONLY, @Year INT, @Semester NVARCHAR(6)
AS
SELECT * FROM
@ClassTable CT
INNER JOIN Project.Term T ON CT.TermId = T.TermId
WHERE T.TermName = @Semester AND T.TermYear = @Year
GO

