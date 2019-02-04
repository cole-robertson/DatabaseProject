CREATE PROCEDURE [Project].[GetClassDetails]
(
	@ClassId INT
)
AS  
   SELECT * FROM Class
   WHERE ClassId = @ClassId