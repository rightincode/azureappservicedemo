CREATE PROCEDURE [dbo].[GetNewSignups]
AS
	SELECT Id, FirstName, LastName, Email, Phone, [Status]
	FROM [dbo].[Customers]
	WHERE [Status] = 0

	UPDATE [dbo].[Customers]
	SET [Status] = 1
	WHERE [Status] = 0
