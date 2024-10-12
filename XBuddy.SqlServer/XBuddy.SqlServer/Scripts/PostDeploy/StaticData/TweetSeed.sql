IF NOT EXISTS(SELECT 1 FROM [xb]. [Tweets])
BEGIN

	INSERT INTO [xb].[Tweets] (Id, CreatedDate, ModifiedDate, UserId,Content,LikeCount)
	VALUES
		(NEWID(), GETDATE(), NULL, @userId1, 'Hello World1!', 0),
		(NEWID(), GETDATE(), NULL, @userId2, 'Hello World2!', 0),
		(NEWID(), GETDATE(), NULL, @userId1, 'Hello World3!', 0), 
		(NEWID(), GETDATE(), NULL, @userId2, 'Hello World4!', 0),
		(NEWID(), GETDATE(), NULL, @userId1, 'Hello World5!', 0),
		(NEWID(), GETDATE(), NULL, @userId2, 'Hello World6!', 0),
		(NEWID(), GETDATE(), NULL, @userId1, 'Hello World7!', 0),
		(NEWID(), GETDATE(), NULL, @userId2, 'Hello World8!', 0), 
		(NEWID(), GETDATE(), NULL, @userId1, 'Hello World9!', 0), 
		(NEWID(), GETDATE(), NULL, @userId2, 'Hello World10!', 0)
END;