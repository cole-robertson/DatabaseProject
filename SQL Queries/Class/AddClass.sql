CREATE PROCEDURE [Project].[AddClass]  
(    
   @InstructorId  INT,  
   @LocationId    INT,
   @TimeId        INT,
   @TermId        INT,
   @ClassTypeId   INT,
   @ClassName     NVARCHAR(256)
)  
AS
INSERT INTO Project.Class
VALUES
(    
   @InstructorId,
   @LocationId,  
   @TimeId,     
   @TermId,   
   @ClassTypeId,
   @ClassName
)