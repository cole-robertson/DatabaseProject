CREATE PROCEDURE [Project].[UpdateStudent]  
(  
   @StudentId INT,  
   @FirstName NVARCHAR(32),  
   @LastName NVARCHAR(32),  
   @Email NVARCHAR(32)  
)  
AS   
   UPDATE Student  
   SET FirstName = @FirstName,  
   LastName = @LastName,  
   Email = @Email  
   WHERE StudentId = @StudentId  
