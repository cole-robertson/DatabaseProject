CREATE PROCEDURE [Project].[GetFullClassDetails]
(
	@StudentId INT
)
AS 
SELECT C.ClassName, C.ClassId, I.FirstName, I.LastName, T.TermName, T.TermYear, TI.Days, TI.StartTime, TI.EndTime, L.Building, L.RoomNumber
FROM Project.Class C
INNER JOIN Project.StudentClass SC ON C.ClassId = SC.ClassId
INNER JOIN Project.Student S ON SC.StudentId = s.StudentId AND S.StudentId = @StudentId
INNER JOIN Project.Instructor I ON I.InstructorId = C.InstructorId
INNER JOIN Project.Term T ON T.TermId = C.TermId
INNER JOIN Project.Location L ON L.LocationId = C.LocationId
INNER JOIN Project.Time TI ON TI.TimeId = C.TimeId;