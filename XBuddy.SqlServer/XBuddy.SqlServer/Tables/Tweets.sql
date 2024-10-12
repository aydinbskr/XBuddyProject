CREATE TABLE [xb].[Tweets]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Content] NVARCHAR(280) NOT NULL, 
    [LikeCount] INT NULL, 
    [ViewCount] INT NULL, 
    CONSTRAINT [FK_Tweets_UserId] FOREIGN KEY ([UserId]) REFERENCES xb.[Users]([Id])
)
