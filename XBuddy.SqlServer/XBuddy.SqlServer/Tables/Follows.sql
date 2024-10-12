CREATE TABLE [xb].[Follows]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [FollowingUserId] UNIQUEIDENTIFIER NOT NULL, 
    [FollowerUserId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_Follows_FollowingUserId] FOREIGN KEY ([FollowingUserId]) REFERENCES xb.[Users]([Id]),
    CONSTRAINT [FK_Follows_FollowerUserId] FOREIGN KEY ([FollowerUserId]) REFERENCES xb.[Users]([Id])
)
