CREATE PROCEDURE [Project].[AddLocation]  
(  
   @Building    NVARCHAR(256),  
   @RoomNumber  INT
)  
AS
INSERT INTO Project.[Location]
VALUES
(   @Building,
    @RoomNumber
)