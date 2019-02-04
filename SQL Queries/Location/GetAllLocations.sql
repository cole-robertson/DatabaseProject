CREATE PROCEDURE [Project].[GetAllLocations] 
AS  
   SELECT * FROM [Location]
   ORDER BY Building ASC, RoomNumber ASC