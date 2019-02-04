CREATE PROCEDURE [Project].[UpdateReview]  
(  
   @ReviewId INT,  
   @ClassId  INT,  
   @ScreenName NVARCHAR(32),  
   @Description NVARCHAR(MAX)  
)  
AS   
   UPDATE Review  
   SET ClassId = @ClassId,  
   ScreenName = @ScreenName,  
   [Description] = @Description  
   WHERE ReviewId = @ReviewId