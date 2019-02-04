CREATE PROCEDURE [Project].[GetReviewDetails]
(
	@ReviewId INT
)
AS  
   SELECT * FROM Review
   WHERE ReviewId = @ReviewId