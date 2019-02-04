CREATE PROCEDURE [Project].[AddStudentClass]  
(    
   @ClassId  INT,  
   @StudentId    INT
)  
AS
INSERT INTO Project.StudentClass
VALUES
(    
   @ClassId,
   @StudentId
)