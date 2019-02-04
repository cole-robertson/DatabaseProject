CREATE PROCEDURE [Project].[GetStudentsDetails]
(
	@StudentId INT
)
AS  
   SELECT * FROM Student
   WHERE StudentId = @StudentId