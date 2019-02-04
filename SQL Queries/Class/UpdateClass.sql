CREATE PROCEDURE [Project].[UpdateClass]  
(  
   @ClassId       INT,  
   @InstructorId  INT,  
   @LocationId    INT,
   @TimeId        INT,
   @TermId        INT,
   @ClassTypeId   INT,
   @ClassName     NVARCHAR(256) 
)  
AS   
   UPDATE Class  
   SET InstructorId = @InstructorId,  
   LocationId = @LocationId,  
   TimeId = @TimeId,
   TermId = @TermId,
   ClassTypeId = @ClassTypeId,
   ClassName = @ClassName
   WHERE ClassId = @ClassId