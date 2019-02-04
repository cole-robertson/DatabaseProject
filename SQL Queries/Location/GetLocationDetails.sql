CREATE PROCEDURE [Project].[GetLocationDetails]
(
	@LocationId INT
)
AS  
   SELECT * FROM [Location]
   WHERE LocationId = @LocationId