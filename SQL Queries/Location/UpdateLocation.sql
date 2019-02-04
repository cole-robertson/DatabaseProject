CREATE PROCEDURE [Project].[UpdateLocation]  
(  
   @LocationId INT,  
   @Building NVARCHAR(256),  
   @RoomNumber INT
)  
AS   
   UPDATE Location  
   SET Building = @Building,  
   RoomNumber = @RoomNumber
   WHERE LocationId = @LocationId