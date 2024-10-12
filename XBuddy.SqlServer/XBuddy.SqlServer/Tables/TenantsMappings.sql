CREATE TABLE [xb].[TenantsMappings]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [TenantId] NVARCHAR(50) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    
    CONSTRAINT [FK_TenantsMappings_UserId] FOREIGN KEY ([UserId]) REFERENCES xb.[Users]([Id])
)
