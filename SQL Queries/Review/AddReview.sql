CREATE PROCEDURE [Project].[AddReview]  
(  
   @ClassId     INT,  
   @ScreenName  NVARCHAR(32) DEFAULT 'Anonymous',  
   @Description NVARCHAR(MAX),
   @Rating      INT
)  
AS
INSERT INTO Project.Review
VALUES
(   @ClassId,
    @ScreenName,
    @Description,
    @Rating
)
