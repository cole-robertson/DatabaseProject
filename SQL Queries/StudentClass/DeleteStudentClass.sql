CREATE PROCEDURE [Project].[DeleteStudentClass]  
(  
   @StudentId INT,
   @ClassId   INT
)  
AS  
   DELETE FROM StudentClass
   WHERE StudentId = @StudentId
   AND   ClassId   = @ClassId