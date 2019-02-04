CREATE PROCEDURE [Project].[DeleteReview]  
(  
   @ReviewId INT  
)  
AS  
   DELETE FROM Review
   WHERE ReviewId = @ReviewId