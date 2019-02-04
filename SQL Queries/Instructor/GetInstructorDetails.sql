CREATE PROCEDURE [Project].[GetInstructorDetails]
(
	@InstructorId INT
)
AS  
   SELECT * FROM Instructor
   WHERE InstructorId = @InstructorId