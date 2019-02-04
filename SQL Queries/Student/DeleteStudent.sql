CREATE PROCEDURE [Project].[DeleteStudent]  
(  
   @StudentId INT  
)  
AS  
   DELETE FROM Student
   WHERE StudentId = @StudentId