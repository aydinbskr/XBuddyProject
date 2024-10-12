CREATE TABLE [xb].[AuditLogs]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CreatedDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [TableName] NVARCHAR(100) NOT NULL, 
    [Operation] NCHAR(10) NOT NULL, 
    [OldValue] NVARCHAR(1000) NULL, 
    [NewValue] NVARCHAR(1000) NULL, 
    CONSTRAINT [FK_AuditLogs_UserId] FOREIGN KEY ([UserId]) REFERENCES xb.[Users]([Id])
)
