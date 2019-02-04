CREATE PROCEDURE [Project].[AddStudent]  
(  
   @FirstName NVARCHAR(32),  
   @LastName  NVARCHAR(32),  
   @Email     NVARCHAR(32)  
)  
AS
INSERT INTO Project.Student
VALUES
(   @FirstName,
    @LastName,
    @Email
)