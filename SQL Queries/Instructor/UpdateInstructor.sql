CREATE PROCEDURE [Project].[UpdateInstructor]  
(  
   @InstructorId INT,  
   @FirstName NVARCHAR(32),  
   @LastName NVARCHAR(32),  
   @Email NVARCHAR(32)  
)  
AS   
   UPDATE Instructor  
   SET FirstName = @FirstName,  
   LastName = @LastName,  
   Email = @Email  
   WHERE InstructorId = @InstructorId