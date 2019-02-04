CREATE PROCEDURE [Project].[AddInstructor]  
(  
   @FirstName NVARCHAR(32),  
   @LastName  NVARCHAR(32),  
   @Email     NVARCHAR(32)  
)  
AS
INSERT INTO Project.Instructor
VALUES
(   @FirstName,
    @LastName,
    @Email
)
